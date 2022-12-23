using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using CSVParserNS;

namespace MiareFinancial.SupersetModels {

   
    public class SSAuthoirizationModel 
    {
        [JsonPropertyName("Authorization")]
        public string AuthorizationKey{get; set;}
        public async Task<SSAuthoirizationModel> GetAuthorization()
        {
            AuthorizationKey = await SupersetConncetion.getJWT();
            return this;
        }
    }
    public static class SupersetConncetion 
    {
        public static async Task<string> getJWT()
        {
                Console.WriteLine("Get New JWT at : " + DateTime.Now);
                var jwtPayload = new JWTPayloadModel(){
                    Username = "Amirahmad",
                    Password = "amirBI2",
                    Provider = "db",
                    Refresh = false
                };
                string jwt_url = "https://bi.miare.ir/api/v1/security/login";
                HttpClientHandler handler = new HttpClientHandler();
                handler.AutomaticDecompression = DecompressionMethods.All;
                HttpClient client = new HttpClient(handler);
                var postRequest = new HttpRequestMessage(HttpMethod.Post, jwt_url)
                                {
                                    Content = JsonContent.Create(jwtPayload)
                                };
                var postResponse = await client.SendAsync(postRequest);
                postResponse.EnsureSuccessStatusCode();
                var result = await postResponse.Content.ReadFromJsonAsync<JWTResponseModel>();
                Console.WriteLine("Jwt Success!");
                // Console.WriteLine(result.AccessToken);
                return result.AccessToken;
        }

    }
    
    public class JWTPayloadModel
    {
        [JsonPropertyName("username")]
        public string Username {get; set;}
        [JsonPropertyName("password")]
        public string Password {get; set;}
        [JsonPropertyName("provider")]
        public string Provider {get; set;}
        [JsonPropertyName("refresh")]
        public bool Refresh {get; set;}
    }

    public class JWTResponseModel 
    {
        [JsonPropertyName("access_token")]
        public string AccessToken {get; set;}
    }

    public class SSDatasourceModel
    {
        [JsonPropertyName("id")]
        public int Id {get; set;}
        
        [JsonPropertyName("type")]
        public string Type {get; set;} = "table";
    }

    public class SSQueryExtras
    {
        [JsonPropertyName("time_grain_sqla")]
        public string TimeGrainSQLA {get; set;} =  "P1D";
        [JsonPropertyName("time_range_endpoints")]
        public List<string> TimeRangeEndPoint {get; set;} = new List<string> () {"inclusive", "exclusive"};
        [JsonPropertyName("having")]
        public string HavingClause {get; set;}  = "";
        [JsonPropertyName("having_druid")]
        
        public List<string> HavingDRUID {get; set;} = new List<string> ();
        [JsonPropertyName("where")]
        public string WhereClause {get; set;} =  "";
    }

    public class SSQueryFilter 
    {
        public List<Dictionary<string, object>> FiltersParameters { get; set;} = new List<Dictionary<string, object>>();
    }

    public class EmptyJsonModel
    {
        public Dictionary<string, string> Json { get; set;} = new Dictionary<string, string>();
    }

    public class SSQueryColumns
    {
        public List<string> ColumnNames { get; set;} = new List<string>();
    }

    public class SSQueryInfo
    {
        [JsonPropertyName("time_range")]
        public string TimeRange {get; set;} =  "No filter";
        [JsonPropertyName("filters")]
        public List<Dictionary<string, object>> FiltersParameters {get; set;} = new SSQueryFilter().FiltersParameters;
        [JsonPropertyName("extras")]
        public SSQueryExtras Extras {get; set;} = new SSQueryExtras();
        [JsonPropertyName("applied_time_extras")]
        public Dictionary<string, string> AppliedTimeExtras{get; set;} = new EmptyJsonModel().Json;
        [JsonPropertyName("columns")]
        public List<string> Columns {get; set; } = new SSQueryColumns().ColumnNames;
        [JsonPropertyName("orderby")]
        public List<string> OrderBy{get; set;} = new List<string>();
        [JsonPropertyName("annotation_layers")]
        public List<string> AnnotationLayers{get; set;} = new List<string>();
        [JsonPropertyName("row_limit")]
        public int RowLimit{get; set;} = 100000;
        [JsonPropertyName("timeseries_limit")]
        public int TimeseriesLimit{get; set;} = 0;
        [JsonPropertyName("order_desc")]
        public bool OrderDesc{get; set;} = true;
        [JsonPropertyName("url_params")]
        public Dictionary<string, string> UrlParams{get; set;} = new EmptyJsonModel().Json;
        [JsonPropertyName("custom_params")]
        public Dictionary<string, string> CustomParams{get; set;} = new EmptyJsonModel().Json;
        [JsonPropertyName("custom_form_data")]
        public Dictionary<string, string> CustomFormData{get; set;} = new EmptyJsonModel().Json;
        [JsonPropertyName("post_processing")]
        public List<string> PostProcessing{get; set;} = new List<string>();       
    }

    public class SSQueryRequestData
    {
        [JsonPropertyName("datasource")]
        public SSDatasourceModel Datasource {get; set;}
        [JsonPropertyName("force")]
        public bool Force{get; set;} = true;
        [JsonPropertyName("queries")]
        public List<SSQueryInfo> Queries {get; set;}
        [JsonPropertyName("result_format")]
        public string ResultFormat {get; set;} = "csv";
        [JsonPropertyName("result_type")]
        public string ResultType {get; set;} = "full";
    }

    public class SSQueryRequest 
    {
        [JsonPropertyName("data")]
        public SSQueryRequestData Data {get; set;}

        public async Task<string> GetQueryData()
        {
            Console.WriteLine("Getting Query");
            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.All;
            HttpClient client = new HttpClient(handler);
            string BI_URL = "https://bi.miare.ir/api/v1/chart/data";
            var headerAuth = await SupersetConncetion.getJWT();
            headerAuth = "Bearer " + headerAuth;
            var postRequest = new HttpRequestMessage(HttpMethod.Post, BI_URL)
                                {
                                    Headers = { 
                                                {HttpRequestHeader.Authorization.ToString(), headerAuth },
                                                { HttpRequestHeader.Accept.ToString(), "application/json" }
                                    }, 
                                    Content = JsonContent.Create(Data)
                                };
            // using( var sw = new StreamWriter("query.json")){
            //     var q = JsonSerializer.Serialize(Data );
            //     sw.Write(q);
            // }
                var postResponse = await client.SendAsync(postRequest);
                var result = await postResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Query Run Success { result}");
                return result;
        }

    }

    public class SSDataRequest
    {
        //Public Vars
        public int DatasourceId {get; set;}
        public List<string> ColumnNames {get; set;} = new List<string>();
        public List<Dictionary<string, object>> Filters {get; set;} = new List<Dictionary<string, object>>();

        public string WhereClause {get; set;} = "";
        public string HavingClause {get; set;} = "";

        public Dictionary<string, string> UrlParams{get; set;} = new Dictionary<string, string>();

        //Private Vars
        private SSDatasourceModel datasource;
        private SSQueryExtras extras;
        private SSQueryInfo query;

        private SSQueryRequestData requestData;

        private string csvValueString;
        private CSVParser csvValueObject;

        private List<List<string>> csvValueArray;

        //Initializer
        public SSDataRequest()
        {
            fillPrivateData();
        }
        private void fillPrivateData(){
            //Datasource
            datasource = new SSDatasourceModel();
            datasource.Id = DatasourceId;
            //Extras
            extras = new SSQueryExtras();
            extras.HavingClause = HavingClause;
            extras.WhereClause = WhereClause;
            //Query
            query = new SSQueryInfo();
            query.FiltersParameters = Filters;
            query.Extras = extras;
            query.Columns = ColumnNames;
            query.UrlParams = this.UrlParams;
            //Request Data
            requestData = new SSQueryRequestData();
            requestData.Datasource = datasource;
            requestData.Queries = new List<SSQueryInfo>(); 
            requestData.Queries.Add(query);
        }

       public async Task<List<List<string>>> Run()
       {
        //fill private values
        fillPrivateData();
        //construct request
         var request = new SSQueryRequest();
         request.Data = requestData;
         var values = await request.GetQueryData();
         
         csvValueString = values;
         csvValueObject = new CSVParser(csvValueString);
         csvValueArray = csvValueObject.ArrayData;
         return csvValueArray;

       } 
       public async Task<string> RunQueryValueAsString()
       {
         await Run();
         return csvValueString;
       }

        public async Task<CSVParser> RunQueryValueCsvObject()
        {
         await Run();
         return csvValueObject;
        }
        public async Task<List<List<string>>> RunQueryValueArray()
        {
         await Run();
         return csvValueArray;
        }

        public string getResultAsString(){
            return csvValueString;
        }
        public CSVParser getResultAsCsvObject(){
            return csvValueObject;
        }
        public List<List<string>> getResultAsArray(){
            return csvValueArray;
        }

    }
}