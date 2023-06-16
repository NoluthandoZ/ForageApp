using Dapper;
using Forage.Context;
using Forage.Contracts;
using Forage.Entities;
using System.Data;

namespace Forage.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;
        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUser(User user)
        {
            var created = true;
            var query = "INSERT INTO [User] (firstName, lastName, password, gender, email ) VALUES (@FirstName, @LastName, @Password, @Gender, @EmailAddress)";
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", user.FirstName, DbType.String);
            parameters.Add("LastName", user.LastName, DbType.String);
            parameters.Add("Password", user.Password, DbType.String);
            parameters.Add("Gender", user.Gender, DbType.String);
            parameters.Add("EmailAddress", user.EmailAddress, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                 var create = await connection.ExecuteAsync(query, parameters);
                if (create == 0)
                {
                    created = false;
                }

                return created;
            }
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            bool delete = true;
            var query = "DELETE FROM [User] WHERE user_id = @Id";
            using (var connection = _context.CreateConnection())
            {
              var deleted =  await connection.ExecuteAsync(query, new { id });
                if (deleted == 0)
                {
                    delete = false;
                }
         
            }

            return delete;
        }

        public async Task<User> GetUser(Guid id)
        {
            var query = "SELECT * FROM [User] WHERE user_id = @user.User_Id";
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { id });
                return user;
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var query = "SELECT * FROM [User] WHERE email = @email";
            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { email });
                return user;
            }
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var query = "SELECT * FROM [User]";
            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<User>(query);
                return users.ToList();
            }
        }

        public async Task UpdateUser(User user)
        {
            var query = "Update * FROM [User] WHERE user_id = @user.User_Id";
            using (var connection = _context.CreateConnection())
            {
                var vacancy = await connection.QuerySingleOrDefaultAsync<User>(query, new { user.User_Id });
            }
        }
    }
}
