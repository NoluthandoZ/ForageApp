using Forage.Contracts;
using Forage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forage.Controllers
{
    [Route("api/vacancies")]
    [ApiController]
    public class VacanciesController : Controller
    {
        private readonly IVacancyRepository _vacancyyRepo;
        public VacanciesController(IVacancyRepository vacancyRepo)
        {
            _vacancyyRepo = vacancyRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetVacancies()
        {
            try
            {
                var vacancies = await _vacancyyRepo.GetVacancies();
                return Ok(vacancies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "VacancyById")]
        public async Task<IActionResult> GetVacancy(Guid id)
        {
            try
            {
                var vacancy = await _vacancyyRepo.GetVacancy(id);
                if (vacancy == null)
                    return NotFound();

                return Ok(vacancy);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Vacancy")]
        public async Task<IActionResult> CreateVacancy(Vacancy vacancy)
        {
            try
            {
               var response = await _vacancyyRepo.CreateVacancy(vacancy);
                if (response)
                {
                    return Ok(response);
                }
                return BadRequest();
               
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVacancy(Vacancy vacancy)
        {
            try
            {
                await _vacancyyRepo.UpdateVacancy(vacancy);
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
                await _vacancyyRepo.DeleteVacancy(id);
                //if (dbVacancy == null)
                //    return NotFound();
                //await _vacancyyRepo.DeleteCompany(id);
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
