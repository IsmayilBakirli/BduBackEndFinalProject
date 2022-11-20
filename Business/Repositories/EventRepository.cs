using AutoMapper;
using Business.Base;
using Business.Services;
using DAL.Abstracts;
using Entity.DTOS.Event;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class EventRepository : IEventService
    {
        private readonly IEventDAL _eventDAl;
        private readonly IMapper _mapper;
        public EventRepository(IEventDAL eventDAL,IMapper mapper)
        {
            _eventDAl = eventDAL;
            _mapper = mapper;
        }


        public async Task<EventGetDto> Get(int? id)
        {
            Event data;
            try
            {
                data = await _eventDAl.GetAsync(expression: (n => !n.IsDeleted && n.Id==id), includes: ("ImageEvents.Image"));
            }
            catch (Exception ex)
            {
#pragma warning disable CA2200 // Rethrow to preserve stack details
                throw ex;
#pragma warning restore CA2200 // Rethrow to preserve stack details
            }
            var dto = _mapper.Map<EventGetDto>(data);
            return dto;
        }

        public async Task<List<EventGetDto>> GetAll()
        {
            List<Event> data;
            try
            {
                data = await _eventDAl.GetAllAsync(expression:(n=>!n.IsDeleted),includes:("ImageEvents.Image"));
            }
            catch(Exception ex)
            {
#pragma warning disable CA2200 // Rethrow to preserve stack details
                throw ex;
#pragma warning restore CA2200 // Rethrow to preserve stack details
            }
            var dto = _mapper.Map<List<EventGetDto>>(data);
            return dto;
        }
        public Task Create(EventCreateDto entity)
        {
            throw new NotImplementedException();
        }
        public Task Update(int id, EventUpdateDto entity)
        {
            throw new NotImplementedException();
        }
        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

     
    }
}
