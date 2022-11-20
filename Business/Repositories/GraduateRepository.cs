using AutoMapper;
using Business.Services;
using DAL.Abstracts;
using Entity.DTOS.Graduate;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class GraduateRepository : IGraduateService
    {
        private readonly IGraduateDAL _graduateDAL;
        private readonly IMapper _mapper;
        public GraduateRepository(IGraduateDAL graduateDAL,IMapper mapper)
        {
            _graduateDAL = graduateDAL;
            _mapper = mapper;
        }
        public async Task<GraduateGetDto> Get(int? id)
        {
            Graduate data;
            try
            {
                data = await _graduateDAL.GetAsync(expression: (n => n.Id == id && !n.IsDeleted), includes: ("Image"));
            }
            catch(Exception ex)
            {
#pragma warning disable CA2200 // Rethrow to preserve stack details
                throw ex;
#pragma warning restore CA2200 // Rethrow to preserve stack details
            }
            var dto = _mapper.Map<GraduateGetDto>(data);
            return dto;

        }

        public async Task<List<GraduateGetDto>> GetAll()
        {
            List<Graduate> data;
            try
            {
                data = await _graduateDAL.GetAllAsync(expression: (n=>!n.IsDeleted), includes: ("Image"));
            }
            catch (Exception ex)
            {
#pragma warning disable CA2200 // Rethrow to preserve stack details
                throw ex;
#pragma warning restore CA2200 // Rethrow to preserve stack details
            }
            var dto = _mapper.Map<List<GraduateGetDto>>(data);
            return dto;
        }
        public Task Update(int id, GraduateUpdateDto entity)
        {
            throw new NotImplementedException();
        }
        public Task Create(GraduateCreateDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
