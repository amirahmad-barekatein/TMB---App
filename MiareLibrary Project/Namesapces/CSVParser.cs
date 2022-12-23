using System.Text.RegularExpressions;

namespace CSVParserNS{
    public class CSVParser{
        public const string TempFilePath = "QueryValue.csv";
        public int RowCount{get;set;}
        public int ColumnCount{get;set;}
        public string RawCsvData{get; set;}
        public List<string> Header {get;set;}
        public List<List<string>> ArrayData {get; set;}
        public CSVParser(string csvRaw){
            RawCsvData = csvRaw;
            Parse();
        }
        public List<List<string>> Parse()
        {
            // using(StreamWriter sw = new StreamWriter(TempFilePath)){
            //     sw.WriteAsync(RawCsvData);
            // }
            // Console.WriteLine($"RawCsv Coutn in Parse {RawCsvData}");
            List<string> Lines = Regex.Split(RawCsvData, "\r\n|\r|\n").ToList<string>();
            //Purifying Lines
            Lines.RemoveAll(l => ((string)l).Length == 0);
            RowCount = Math.Max(Lines.Count() - 1, 0 );
            ArrayData = new List<List<string>>();
            if(RowCount < 2 )
                return ArrayData;
            ArrayData = Lines.Select(line => new List<string>(line.Split(","))).ToList();
            Header = ArrayData.First();
            ColumnCount = Header.Count;
            //Delete Header
            ArrayData.RemoveAt(0);
            return ArrayData;
        }   
    }
}