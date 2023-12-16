using System;
using ASP.NET_MySQL.Models;
using ASP.NET_MySQL.Util;
using MySql.Data.MySqlClient;

namespace ASP.NET_MySQL.Services
{
	public class UserService
	{

        private readonly DatabaseHelper _databaseHelper;

        public UserService(IConfiguration configuration)
        {
            _databaseHelper = new DatabaseHelper(configuration);
        }

        public void CreateUser(User user)
        {
            using var connection = _databaseHelper.GetConnection();
            connection.Open();
            using var command = new MySqlCommand("INSERT INTO users VALUES (@Id,@Name, @Email)", (MySqlConnection)connection);

            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public User GetUserById(int id)
        {
            using var connection = _databaseHelper.GetConnection();
            connection.Open();
            using var command = new MySqlCommand("SELECT * FROM users WHERE id=@Id", (MySqlConnection)connection);

            command.Parameters.AddWithValue("@Id",id);

            using var reader = command.ExecuteReader();

            var user = new User();

            if (reader.Read())
            {
                user.Id = reader.GetInt32("id");
                user.Name = reader.GetString("name");
                user.Email = reader.GetString("email");
            }

            connection.Close();
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            var users = new List<User>();

            using var connection = _databaseHelper.GetConnection();
            connection.Open();

            using var command = new MySqlCommand("SELECT * FROM users", (MySqlConnection)connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User
                (
                    reader.GetInt32("id"),
                    reader.GetString("name"),
                    reader.GetString("email")
                ));
            }

            connection.Close();
            return users;
        }

        public int DeleteUser(int id)
        {
            using var connection = _databaseHelper.GetConnection();
            connection.Open();
            using var command = new MySqlCommand("DELETE FROM users WHERE id = @Id", (MySqlConnection)connection);
            command.Parameters.AddWithValue("@Id", id);

            var noRows = command.ExecuteNonQuery();

            connection.Close();
            return noRows;
        }

        public int UpdateUser(User user)
        {
            using var connection = _databaseHelper.GetConnection();
            connection.Open();
            using var command = new MySqlCommand("UPDATE users SET name = @Name, email = @Email WHERE id = @Id", (MySqlConnection)connection);
            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);

            var noRows = command.ExecuteNonQuery();

            connection.Close();
            return noRows;
        }

    }
}

