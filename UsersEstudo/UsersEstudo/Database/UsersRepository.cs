using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UsersStudy.Database

{
    public class UsersRepository
    {
        public List<Users> SearchUsers()
        {
            var users = new List<Users>();
            var connection = new Connection();
            var command = new SqlCommand("Select * from Users", connection.GetConnection());
            command.Connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var user = new Users();
                user.Id = Convert.ToInt32(reader["Id"]);
                user.Name = Convert.ToString(reader["Name"]);
                user.Age = Convert.ToInt32(reader["Age"]);
                user.Mail = Convert.ToString(reader["Mail"]);
                user.Phone = Convert.ToString(reader["Phone"]);
                users.Add(user);
            }
            return users;
        }

        public Users SearchUserByEmail(string mail)
        {
            var user = new Users();
            var connection = new Connection();
            var command = new SqlCommand($"Select * from Users where email = '{mail}'", connection.GetConnection());
            command.Connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                user.Id = Convert.ToInt32(reader["Id"]);
                user.Name = Convert.ToString(reader["Name"]);
                user.Age = Convert.ToInt32(reader["Age"]);
                user.Mail = Convert.ToString(reader["Mail"]);
                user.Phone = Convert.ToString(reader["Phone"]);
            }

            return user;
        }

        public bool InsertUsers(Users newuser)
        {
            var connection = new Connection();
            var command = new SqlCommand($"insert into Users (Name, Age, Mail, Phone) values ('{newuser.Name}', {newuser.Age}, '{newuser.Mail}', '{newuser.Phone}')", connection.GetConnection());
            command.Connection.Open();
            var result = command.ExecuteNonQuery();
            return result == 1;
        }
    }
}
