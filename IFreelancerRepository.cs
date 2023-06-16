using Forage.Entities;

namespace Forage.Contracts
{
    public interface IFreelancerRepository
    {
        public Task<IEnumerable<Freelancer>> GetFreelancers();
        public Task<Freelancer> GetFreelancer(Guid id);
        public Task<bool> CreateFreelancer(Freelancer vacancy);
        public Task DeleteFreelancer(Guid id);
        public Task UpdateFreelancer(Freelancer vacancy);
        
    }
}
