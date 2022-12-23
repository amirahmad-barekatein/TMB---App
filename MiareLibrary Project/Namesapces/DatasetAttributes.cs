using System.Reflection;

namespace DatasetAttributsNS{
  [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = true)]  
    public class SSDatasetAttribute : System.Attribute  
    {  
        public bool IsColumn {get; set;} = true;  
        public bool IsId {get; set;} = false;
        public bool IsMetric {get; set;} = false;
        public bool IsDate {get; set;} = false;
        public string Name {get; set;}

        public SSDatasetAttribute(){
            IsColumn = true;
        }
        public static string? GetPropertyAttributes(PropertyInfo prop, string attributeName = "SSDataset")
        {
            object[] attrs = prop.GetCustomAttributes(true);
            foreach (object attr in attrs)
            {
                SSDatasetAttribute authAttr = attr as SSDatasetAttribute;
                if (authAttr != null)
                {
                    return authAttr.Name;
                }
            }
            return null;
        }
    }     
}