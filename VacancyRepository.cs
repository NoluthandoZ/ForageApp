using Dapper;
using Forage.Context;
using Forage.Contracts;
using Forage.Entities;
using System.Data;

namespace Forage.Repository
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly DapperContext _context;
        public VacancyRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateVacancy(Vacancy vacancy)
        {
            bool created = false;
            var query = "INSERT INTO Vacancies (CompanyName, Description, Requirements, Vacany_type, ClosingDate ) VALUES (@CompanyName, @Description, @Requirements, @Vacany_type, @ClosingDate)";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyName", vacancy.CompanyName, DbType.String);
            parameters.Add("Description", vacancy.Description, DbType.String);
            parameters.Add("Requirements", vacancy.Requirements, DbType.String);
            parameters.Add("Vacany_type", vacancy.Vacany_type, DbType.String);
            parameters.Add("ClosingDate", vacancy.ClosingDate, DbType.DateTime);
            
            using (var connection = _context.CreateConnection())
            {
                var response = await connection.ExecuteAsync(query, parameters);  
                if(response > 0)
                {
                    created = true;
                }
            }

            return created;
        }

        public async Task DeleteVacancy(Guid id)
        {
            var query = "DELETE FROM Vacancies WHERE Vacany_id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<IEnumerable<Vacancy>> GetVacancies()
        {
            var query = "SELECT * FROM Vacancies";
            using (var connection = _context.CreateConnection())
            {
                var vacancies = await connection.QueryAsync<Vacancy>(query);
                return vacancies.ToList();
            }
        }

        public async Task<Vacancy> GetVacancy(Guid id)
        {
            var query = "SELECT * FROM Vacancies WHERE Vacany_id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var vacancy = await connection.QuerySingleOrDefaultAsync<Vacancy>(query, new { id });
                return vacancy;
            }
        }

        public async Task UpdateVacancy(Vacancy vacancy)
        {
            var query = "UPDATE Vacancies SET CompanyName= @CompanyName,  Description = @Description, Requirements = @Requirements, Vacany_type = @Vacany_type , ClosingDate = @ClosingDate Where Vacancy_id = @Vacancy_id";

            var parameters = new DynamicParameters();
            parameters.Add("Vacancy_id", vacancy.Vacany_id, DbType.Guid);
            parameters.Add("CompanyName", vacancy.CompanyName, DbType.String);
            parameters.Add("Description", vacancy.Description, DbType.String);
            parameters.Add("Requirements", vacancy.Requirements, DbType.String);
            parameters.Add("Vacany_type", vacancy.Vacany_type, DbType.String);
            parameters.Add("ClosingDate", vacancy.ClosingDate, DbType.DateTime);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
