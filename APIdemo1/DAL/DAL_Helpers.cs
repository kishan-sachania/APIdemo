namespace APIdemo1.DAL
{
    public class DAL_Helpers { 
        public static String ConString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("MyConnectionString");
    
    }
}
