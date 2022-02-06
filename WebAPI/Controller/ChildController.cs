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
    public class ChildController : ControllerBase
    {
        private IChildRepository _childRepository;


        public ChildController(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        [Route("api/child/getAll")]
        [HttpGet]
        public async Task<ActionResult<IList<Child>>> GetAllChildren()
        {
            try
            {
                var result = await _childRepository.GetAllChildren();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Route("api/child/create")]
        [HttpPost]
        public async Task<ActionResult> CreateChild([FromBody] Child child)
        {
            try 
            {
                await _childRepository.CreateChild(child);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
                
        }

        
        [Route("api/child/delete")]
        [HttpDelete]
        public async Task<ActionResult> DeleteChild([FromQuery] int id)
        {
            try
            {
                await _childRepository.DeleteChild(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}