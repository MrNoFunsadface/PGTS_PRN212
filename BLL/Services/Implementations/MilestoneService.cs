using AutoMapper;
using BLL.DTOs;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;

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
                return new ResponseDTO<MilestoneResponseDTO>
                {
                    Success = false,
                    Message = $"Pregnancy not found."
                };
            }

            var result = _milestoneRepo.Create(milestone);
            if (!result)
            {
                return new ResponseDTO<MilestoneResponseDTO>
                {
                    Success = false,
                    Message = "Add failed."
                };
            }

            return new ResponseDTO<MilestoneResponseDTO>
            {
                Success = true,
                Message = "Milestone added.",
                Data = _mapper.Map<MilestoneResponseDTO>(milestone)
            };
        }

        public ResponseDTO Delete(int id)
        {
            var milestone = _milestoneRepo.GetSingle(m => m.Id == id);
            if (milestone == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Milestone not found."
                };
            }

            var result = _milestoneRepo.Delete(milestone);
            if (!result)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Delete failed."
                };
            }

            return new ResponseDTO
            {
                Success = true,
                Message = "Milestone deleted."
            };
        }

        public ResponseDTO<IEnumerable<MilestoneResponseDTO>> GetByPregnancyId(int pregnancyId, string? search, DateOnly? date)
        {
            var milestones = _milestoneRepo.Get(m => m.PregnancyId == pregnancyId).AsEnumerable();

            if (!string.IsNullOrEmpty(search))
            {
                milestones = milestones.Where(m =>
                    m.Id.ToString().Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    m.Descriptions.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            if (date.HasValue)
            {
                milestones = milestones.Where(m => m.Date == date.Value);
            }

            milestones = milestones.OrderByDescending(m => m.Date);

            return new ResponseDTO<IEnumerable<MilestoneResponseDTO>>
            {
                Success = true,
                Message = "List of milestones",
                Data = milestones.Select(m => new MilestoneResponseDTO
                {
                    Id = m.Id,
                    PregnancyId = m.PregnancyId,
                    Descriptions = m.Descriptions,
                    Date = m.Date
                })
            };
        }

        public ResponseDTO Update(int id, MilestoneRequestDTO milestoneRequestDTO)
        {
            var milestone = _milestoneRepo.GetSingle(m => m.Id == id);
            if (milestone == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Milestone not found."
                };
            }

            _mapper.Map(milestoneRequestDTO, milestone);

            var result = _milestoneRepo.Update(milestone);
            if (!result)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Update failed."
                };
            }

            return new ResponseDTO
            {
                Success = true,
                Message = "Milestone updated."
            };
        }
    }
}