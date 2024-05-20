using System.Data.SqlClient;

public static class SQLHelper
{
    public static string GetSqlConnectionString()
    {
        // Windows Authentication ile bağlanmak için "Integrated Security=true;" kullanılır.
        return "Data Source=localhost;Initial Catalog=verıtabanıodev;Integrated Security=true;";
    }

    // Uygulamanın her yerinden kullanabilmek için SQL bağlantısı açma metodu ortak hale getirildi.
    public static SqlConnection GetSqlConnection()
    {
        // SqlConnection nesnesi oluşturulurken bağlantı dizesi GetSqlConnectionString metodu kullanılarak alınır.
        return new SqlConnection(GetSqlConnectionString());
    }
}

