using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.Repository;

namespace WebAPI.Controller
{
    [ApiController]
    [Route("")]
    public class ToyController : ControllerBase
    {
        private IToyRepository _toyRepository;

        public ToyController(IToyRepository toyRepository)
        {
            _toyRepository = toyRepository;
        }
        
        [Route("api/toy/getAll")]
        [HttpGet]
        public async Task<ActionResult<IList<Toy>>> GetAllToys ()
        {
            try
            {
                var result = _toyRepository.GetAllToys();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Route("api/toy/create")]
        [HttpPost]
        public async Task<ActionResult> CreateToy([FromBody] Toy toy, [FromQuery] int childId)
        {
            try
            {
                await _toyRepository.CreateToy(toy, childId);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500, e.Message);
            }
        }

        [Route("api/toy/delete")]
        [HttpDelete]
        public async Task<ActionResult> DeleteToy(int id)
        {
            try
            {
                await _toyRepository.DeleteToy(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
    }
}