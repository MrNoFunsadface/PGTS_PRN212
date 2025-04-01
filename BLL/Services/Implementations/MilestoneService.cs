using AutoMapper;
using BLL.DTOs;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class MilestoneService : IMilestoneService
    {
        private readonly IGenericRepo<Milestone> _milestoneRepo;
        private readonly IGenericRepo<Pregnancy> _pregnancyRepo;
        private readonly IMapper _mapper;

        public MilestoneService(IGenericRepo<Milestone> milestoneRepo, IGenericRepo<Pregnancy> pregnancyRepo, IMapper mapper)
        {
            _milestoneRepo = milestoneRepo;
            _pregnancyRepo = pregnancyRepo;
            _mapper = mapper;
        }
        public ResponseDTO Add(MilestoneRequestDTO milestoneRequestDTO)
        {
            var milestone = _mapper.Map<Milestone>(milestoneRequestDTO);
            var pregnancy = _pregnancyRepo.GetSingle(p => p.Id == milestone.PregnancyId);
            if (pregnancy == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = $"Pregnancy not found."
                };
            }
            var result = _milestoneRepo.Create(milestone);
            if (!result)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Add failed."
                };
            }
            return new ResponseDTO
            {
                Success = true,
                Message = "Milestone added."
            };
        }

        public ResponseDTO Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<IEnumerable<MilestoneResponseDTO>> GetAll(int pregnancyId, DateOnly? startDate, DateOnly? endDate)
        {
            var milestones = _milestoneRepo.Get().AsEnumerable();
            milestones = milestones.Where(m => m.PregnancyId == pregnancyId);
            if (startDate != null || endDate!=null)
            {
                if (startDate != null)
                {
                    milestones = milestones.Where(m => m.Date >= startDate);
                }
                if (endDate != null)
                {
                    milestones = milestones.Where(m => m.Date <= endDate);
                }
            }
           
            return new ResponseDTO<IEnumerable<MilestoneResponseDTO>>
            {
                Success = true,
                Message = "List of milestones.",
                Data = milestones.Select(m => new MilestoneResponseDTO
                {
                    Id = m.Id,
                    Date = m.Date,
                    Description = m.Descriptions
                })
            };
        }

        public ResponseDTO<MilestoneResponseDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO Update(int id, MilestoneRequestDTO milestoneRequestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
