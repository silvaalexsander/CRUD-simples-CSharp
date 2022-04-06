using Npgsql;

namespace TesteDB.Classes
{
    internal class Conexao
    {
        NpgsqlConnection con = new NpgsqlConnection();

        public Conexao()
        {
            con.ConnectionString = @"SERVER=localhost;Port=5432;User Id=postgres;Password=12345678";
        }

        public NpgsqlConnection conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        public void desconctar()
        {
            con.Close();

        }
    }
}
