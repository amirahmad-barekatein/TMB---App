using System.ComponentModel.DataAnnotations;
using DatasetAttributsNS;
using MiareFinancial.DAL;
using MiareFinancial.Models;
using MiareFinancial.Models.Courier;
using Microsoft.EntityFrameworkCore;
using MiareFinancial.SupersetModels;

namespace MiareFinancial.RequestModels
{
    public class BaseRequestModel<T> where T :  MiareBaseModel
    {
        public virtual int DatasetId {get; private set;}

        public virtual string FilterColumnName {get; set;} = "week"; 
        public SSDataRequest DataRequestModel {get; set;}

        public List<T> NewRecords{get; set;} = new List<T>();
        public List<T> OldRecords{get; set;} = new List<T>();
        public List<T> UniqueRecordsToAdd{get; set;} = new List<T>();

        public string FilterStartDate {get; private set;} = "";
        public string FilterEndtDate {get; private set;} = "";

        public Dictionary<string, string> UrlParams {get; set;} = new Dictionary<string, string>();


        public static List<string>? GetColumnNames(T obj)
        {
            return obj.GetType().GetProperties()
                            .Where( p => p.IsDefined(typeof(SSDatasetAttribute), true))?
                            .Select(info => SSDatasetAttribute.GetPropertyAttributes(info))?.ToList<string>();
        }
        public static string? GetKeyPropertyName(T obj)
        {
            return obj.GetType().GetProperties()
                            .Where( p => p.IsDefined(typeof(KeyAttribute), true))?
                            .Select(info => info.Name)?.FirstOrDefault();
        }
        public object? this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName)?.GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName)?.SetValue(this, value, null); }
        }

        public static object? GetKeyValue(T obj){
            if(GetKeyPropertyName(obj) == null)
                return null;
            return obj.GetType().GetProperty((GetKeyPropertyName(obj) ?? ""))?.GetValue(obj, null);
        }

        public static bool HasKeyProperty(T obj){
            return GetKeyPropertyName(obj) != null;
        }

        public T InstiateDummyRecords(object keyValue){
            var newObject = GetInstance<T>();
            newObject.GetType().GetProperty(GetKeyPropertyName(newObject) ?? "")?.SetValue( newObject, keyValue);
            newObject.DateTime = DateTime.ParseExact((string)keyValue, "yyyy-MM-dd", null);
            return newObject;
        } 

        public T GetInstance<T>(List<string> recordFromCsv)
        {
            // Console.WriteLine(typeof(T).Name);
            return (T)Activator.CreateInstance(typeof(T), recordFromCsv);
        }
        public T GetInstance<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
        public BaseRequestModel()
        {
            //DatasetId Must Be
            DataRequestModel = new SSDataRequest();
            DataRequestModel.ColumnNames = GetColumnNames(GetInstance<T>()) ?? new List<string>();
            DataRequestModel.DatasourceId = DatasetId;
            // Console.WriteLine(DataRequestModel.ColumnNames.Count);
        }

        public async Task<List<List<string>>> RunQuery(string startDate = "", string endDate = "", Dictionary<string, string>? urlParams = null )
        {
            if(ensureRunQuery(startDate, endDate) == false){
                NewRecords = new List<T>();
                return new List<List<string>>();
            }
            DataRequestModel.Filters = GetFilterObject(startDate, endDate);
            if(urlParams == null )
            {
                DataRequestModel.UrlParams = new Dictionary<string, string>();
            }
            else
            {
                DataRequestModel.UrlParams = urlParams;
                Console.WriteLine($"Urlparams: {DataRequestModel.UrlParams.Keys} , {DataRequestModel.UrlParams.Values}");
            }
            NewRecords = new List<T>();
            var values = await DataRequestModel.Run();
            values.ForEach( v => NewRecords.Add(GetInstance<T>(v)));
            return values;
        }

        public virtual List<Dictionary<string, object>> GetFilterObject(string startDate = "", string endDate = "")
        {
            var filters = new List<Dictionary<string, object>>();
            if(startDate != "")
            {
                var startDateFilter = new Dictionary<string, object>();
                startDateFilter.Add("col", FilterColumnName);
                startDateFilter.Add("op", ">=");
                startDateFilter.Add("val", startDate);
                filters.Add(startDateFilter);
            }
            if(endDate != "")
            {
                var endDateFilter = new Dictionary<string, object>();
                endDateFilter.Add("col", FilterColumnName);
                endDateFilter.Add("op", "<=");
                endDateFilter.Add("val", endDate);
                filters.Add(endDateFilter);
            }
            return filters;
        }

        private bool hasNewDataToAdd(){
            if(this.NewRecords == null || this.NewRecords.Count == 0){
                Console.WriteLine($"Create Null Record For Table {typeof(T).Name}");
                var startDateObject = InstiateDummyRecords(FilterStartDate);
                var endDateObject = InstiateDummyRecords(FilterEndtDate);
                this.UniqueRecordsToAdd = new List<T>() { startDateObject, endDateObject};
                return true;
            }
            ReadAllDB();
            if(HasKeyProperty(GetInstance<T>()))
            {
                this.UniqueRecordsToAdd = this.NewRecords
                                                    .Where(newTP => !this.OldRecords
                                                                    .Any(oldTP => GetKeyValue(oldTP)?.ToString() == GetKeyValue(newTP)?.ToString()))
                                                    .ToList();
            }
            else
            {
                this.UniqueRecordsToAdd = this.NewRecords;
            }    
            return (UniqueRecordsToAdd.Count > 0);
        }
        public async Task<bool> AddToDB()
        {
             if(hasNewDataToAdd()){
                var db = new MiareFinancialContext();
                var dbSet = db.Set<T>();
                var addTask = dbSet.AddRangeAsync(UniqueRecordsToAdd); 
                var saveTask = db.SaveChangesAsync();
                Task.WaitAll(addTask, saveTask);
                Console.WriteLine($"Adding Some Object To {typeof(T).Name} Table Succsessfully");
                return true;
             }
             return false;
        }

        public async Task<bool> RunAndAddToDB(object[] arguments)// string startDate = "", string endDate = "", Dictionary<string, string> urlParams = null )
        {
            var startDate = (string)arguments[0];
            var endDate = (string)arguments[1];
            Dictionary<string, string>? urlParams = null;
            if(arguments.Count() == 3)
                urlParams = (Dictionary<string, string>) arguments[2];
            if(urlParams != null)
                Console.WriteLine(urlParams);
            FilterStartDate = startDate;
            FilterEndtDate = endDate;
            if(ensureRunQuery(startDate, endDate) == false)
                return false;
            var query = await this.RunQuery(startDate, endDate, urlParams);
            Console.WriteLine($"Query Len Res {query.Count}");
            var addStatus = await this.AddToDB();
            // Task.WhenAll(queryTasks);
            return addStatus;
        }

        private Tuple<T, T>? getFirstLastRecord(){
            using var db = new MiareFinancialContext();
            var sortedDbSet = db.Set<T>()?.OrderBy(r => r.DateTime);
            T? FirstObjcet = sortedDbSet?.FirstOrDefault();
            T? LastObject = sortedDbSet?.LastOrDefault();
            return new Tuple<T, T> (FirstObjcet, LastObject);        
        }

        private bool ensureRunQuery(string startDate = "", string endDate = ""){
            var startDateTime = (startDate == "") ? DateTime.MaxValue :  DateTime.ParseExact(startDate, "yyyy-MM-dd", null);
            var endDateTime = (endDate == "") ? DateTime.MinValue : DateTime.ParseExact(endDate, "yyyy-MM-dd", null);
            //Store Date Filterd
            FilterStartDate = startDate;
            FilterEndtDate = endDate;
            //Check
            var firstLastObjects = getFirstLastRecord();
            if(firstLastObjects.Item1 == null || firstLastObjects.Item2 == null)
            {
                Console.WriteLine($"Table {typeof(T).Name} has not any record for start date: {startDate} - end date: {endDate}");
                return true;
            }
            if(startDateTime > endDateTime){
                Console.WriteLine("started and ended dates not match");
                Console.WriteLine($"start date: {startDate} - end date: {endDate}");
                return false;
            }
            if (firstLastObjects.Item1.DateTime <= startDateTime && firstLastObjects.Item2.DateTime >= endDateTime  )
            {
                Console.WriteLine($"Table {typeof(T).Name} Has Data For Stating Date: {startDate} & Ending Date: {endDate}!");
                return false;
            }
            return true;
        }

        public List<T> ReadAllDB()
        {
            using var db = new MiareFinancialContext();
            var dbSet = db.Set<T>();
            this.OldRecords = dbSet.ToList<T>();  
            return this.OldRecords;
        }

        public bool ClearAllDB()
        {
            ReadAllDB(); 
            using var db = new MiareFinancialContext();
            var dbSet = db.Set<T>();
            dbSet.RemoveRange(this.OldRecords);
            this.OldRecords = new List<T>();
            db.SaveChanges();
            return true;
        }
    }
}