using BDU_API.Common;
using Business.Services;
using Entity.DTOS.Event;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BDU_API.Controllers
{
    [ApiController,Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<EventGetDto> data;
            try
            {
                data = await _eventService.GetAll();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response(4322, ex.Message));
            }
            return Ok(data);
        }

        [HttpGet,Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            EventGetDto data;
            try
            {
                data=await _eventService.Get(id);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response(4323, ex.Message));
            }
            return Ok(data);
        }
    }
}
