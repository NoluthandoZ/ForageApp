using Forage.Contracts;
using Forage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forage.Controllers
{
    [Route("api/Freelancer")]
    [ApiController]
    public class FreelancerController : Controller
    {
        private readonly IFreelancerRepository _freelancerRepo;
        public FreelancerController(IFreelancerRepository freelancerRepo)
        {
            _freelancerRepo = freelancerRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetFreelancers()
        {
            try
            {
                var vacancies = await _freelancerRepo.GetFreelancers();
                return Ok(vacancies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "FreelancerById")]
        public async Task<IActionResult> GetFreelancer(Guid id)
        {
            try
            {
                var vacancy = await _freelancerRepo.GetFreelancer(id);
                if (vacancy == null)
                    return NotFound();

                return Ok(vacancy);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFreelancer(Freelancer freelancer)
        {
            bool freeLancer = false;
            try
            {
                freeLancer = await _freelancerRepo.CreateFreelancer(freelancer);
                return Ok(freeLancer);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFreelancer(Freelancer freelancer)
        {
            try
            {
                await _freelancerRepo.UpdateFreelancer(freelancer);
                return Ok();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            try
            {
                await _freelancerRepo.DeleteFreelancer(id);
               
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);

            }
        }
    }
}
