using Npgsql;

namespace Exam
{
    public class DbService
    {
        private string connString = "Server=localhost;Port=5432;User Id=postgres;Password=123890;Database=examnow;";


        public void AddUser(User user)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = "INSERT INTO users (firstname, middlename, lastname, login , password, age) VALUES (@FirstName, @MiddleName, @LastName, @Login, @Password, @Age)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", user.MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Login", user.Login);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Age", user.Age);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<User> LoadUsers()
        {
            List<User> users = new List<User>();

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT * FROM users";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        FirstName = reader.GetString(0),
                        MiddleName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Login = reader.GetString(3),
                        Password = reader.GetString(4),
                        Age = reader.GetString(5)
                    });
                }
            }

            return users;
        }
    }
}

