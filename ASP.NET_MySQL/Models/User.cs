using System;
namespace ASP.NET_MySQL.Models
{
	public class User
	{
		public int? Id { get; set; }

		public String? Name { get; set; }

		public String? Email { get; set; }

		public User(int id,String name,String email)
		{
			Id = id;
			Name = name;
			Email = email;
		}

        public User()
        {
        }
    }
}

