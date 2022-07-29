using System;
using System.Data.SqlClient;

namespace VendaDeCarroEstudo.BancoDeDados
{
    public class Conexao
    {
        public SqlConnection ObtemConexao()
        {
            var conexao = new SqlConnection(@"Server=DESKTOP-HCO59RI\SQLEXPRESS;Database=VendaCarro;Trusted_Connection=True;");
            return conexao;
        }
    }
}
