using Forage.Entities;

namespace Forage.Contracts
{
    public interface IVacancyRepository
    {
        public Task<IEnumerable<Vacancy>> GetVacancies();
        public Task<Vacancy> GetVacancy(Guid id);
        public Task<bool> CreateVacancy(Vacancy vacancy);
        public Task DeleteVacancy(Guid id);
        public Task UpdateVacancy(Vacancy vacancy);
        
    }
}
