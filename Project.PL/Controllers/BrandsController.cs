using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Project.DAL.Database;
using Project.DAL.Models;
using Project.DAL.Repository;


namespace Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        GenericRepository<Brand> repo = new GenericRepository<Brand>();

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var Brand = repo.GetBrand(Id);
            return Ok(Brand);
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var Brands = repo.GetAllBrands();
            return Ok(Brands);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteById(int Id)
        {
            repo.RemoveBrand(Id); 

            return Ok("Success");
        }

        [HttpPost("")]
        public IActionResult AddBrand(Brand B)
        {
            repo.CreateBrand(B);

            return Ok("Success");
        }
    }
}
