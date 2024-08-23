namespace Ferreweb.conexion
{
    public class conexion1
    {
        private string cadena_sql = string.Empty;

        public conexion1()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadena_sql = builder.GetSection("ConnectionStrings:CadenaConexionSQL").Value;

        }
        public string getcadenasql()
        {
            return cadena_sql;
        }
    }
}