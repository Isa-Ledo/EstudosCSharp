using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VendaDeCarroEstudo.BancoDeDados
{
    public class CarroRepositorio
    {
        public List<Carro> BuscarTodosOsCarros()
        {
            var carros = new List<Carro>();
            var conexao = new Conexao().ObtemConexao();
            var command = new SqlCommand("Select * from carro", conexao);
            command.Connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                var carro = new Carro();
                carro.Id = Convert.ToInt32(reader["Id"]);
                carro.Modelo = reader["modelo"].ToString();
                carro.Cor = reader["cor"].ToString();
                carro.Quantidade = Convert.ToInt32(reader["quantidade"]);
                carro.MarcaId = Convert.ToInt32(reader["marcaId"]);
                carros.Add(carro);
            }

            return carros;
        }

        public bool InsereCarro(Carro novoCarro)
        {
            var conexao = new Conexao().ObtemConexao();
            var command = new SqlCommand($"insert into Carro (MarcaId,Cor,Modelo, Quantidade) values ({novoCarro.MarcaId}, '{novoCarro.Cor}', '{novoCarro.Modelo}', {novoCarro.Quantidade})", conexao);
            command.Connection.Open();
            var result = command.ExecuteNonQuery();
            return result == 1;
        }

        public bool DeletaCarroPorId(int id)
        {
            var conexao = new Conexao().ObtemConexao();
            var command = new SqlCommand($"DELETE FROM CARRO WHERE ID = {id}", conexao);
            command.Connection.Open();
            var result = command.ExecuteNonQuery();
            return result == 1;
        }

        public bool AtualizaCarro(Carro carroAtualizado)
        {
            var conexao = new Conexao().ObtemConexao();
            var command = new SqlCommand($"UPDATE Carro SET MarcaId = {carroAtualizado.MarcaId},Cor = '{carroAtualizado.Cor}'," +
                $" Modelo = '{carroAtualizado.Modelo}',Quantidade = {carroAtualizado.Quantidade} " +
                $"WHERE id = {carroAtualizado.Id}", conexao);
            command.Connection.Open();
            var result = command.ExecuteNonQuery();
            return result == 1;
        }
    }
}
