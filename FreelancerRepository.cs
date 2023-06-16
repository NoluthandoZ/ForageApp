using Dapper;
using Forage.Context;
using Forage.Contracts;
using Forage.Entities;
using System.Data;

namespace Forage.Repository
{
    public class FreelancerRepository : IFreelancerRepository
    {
        private readonly DapperContext _context;
        public FreelancerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateFreelancer(Freelancer vacancy)
        {
            var query = "INSERT INTO Freelancer (Location, Description, JobTitle ) VALUES (@Location, @Description, @JobTitle)";
            var parameters = new DynamicParameters();
            parameters.Add("Location", vacancy.Location, DbType.String);
            parameters.Add("Description", vacancy.Description, DbType.String);
            parameters.Add("JobTitle", vacancy.JobTitle, DbType.String);;
            
            using (var connection = _context.CreateConnection())
            {
               var test =   await connection.ExecuteAsync(query, parameters);  
               return test >= 1? true : false;
            }
        }

        public async Task DeleteFreelancer(Guid id)
        {
            var query = "DELETE FROM Freelancer WHERE Freelancer_id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<IEnumerable<Freelancer>> GetFreelancers()
        {
            var query = "SELECT * FROM Freelancer";
            using (var connection = _context.CreateConnection())
            {
                var vacancies = await connection.QueryAsync<Freelancer>(query);
                return vacancies.ToList();
            }
        }

        public async Task<Freelancer> GetFreelancer(Guid id)
        {
            var query = "SELECT * FROM Freelancer WHERE Freelancer_id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var vacancy = await connection.QuerySingleOrDefaultAsync<Freelancer>(query, new { id });
                return vacancy;
            }
        }

        public async Task UpdateFreelancer(Freelancer vacancy)
        {
            var query = "UPDATE Freelancer SET Location= @Location,  Description = @Description, JobTittle = @JobTittle Where Freelancer_id = @Freelancer_id";

            var parameters = new DynamicParameters();
            parameters.Add("Vacancy_id", vacancy.Freelancer_id, DbType.Guid);
            parameters.Add("CompanyName", vacancy.Location, DbType.String);
            parameters.Add("Description", vacancy.Description, DbType.String);
            parameters.Add("Requirements", vacancy.JobTitle, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
