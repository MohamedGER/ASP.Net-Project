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
        private readonly GenericRepository<Brand> _repo;
        public BrandsController(GenericRepository<Brand> repo) //Konstruktor für "GenericRepository<Brand> repo = new GenericRepository<Brand>();"
        {   
            _repo = repo;
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var Brand = _repo.GetEntity(Id);
            return Ok(Brand);
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var Brands = _repo.GetAllEntities();
            return Ok(Brands);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteById(int Id)
        {
            _repo.RemoveEntity(Id); 

            return Ok("Success");
        }

        [HttpPost("")]
        public IActionResult AddBrand(Brand B)
        {
            _repo.CreateEntity(B);

            return Ok("Success");
        }
    }
}