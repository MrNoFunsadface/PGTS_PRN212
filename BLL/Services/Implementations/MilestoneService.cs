using AutoMapper;
using BLL.DTOs;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repo;
using Microsoft.IdentityModel.Tokens;

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

            var valid = checkValidDate(milestone.Date);
            if (!valid.Success)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = valid.Message
                };
            }

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
                Message = "Milestone added.",
            };
        }

        private ResponseDTO checkValidDate(DateOnly date)
        {
            if (date.ToString().IsNullOrEmpty())
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Date cannot be empty"
                };
            }

            if (date > DateOnly.FromDateTime(DateTime.Now))
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Date cannot be in the future"
                };
            }

            return new ResponseDTO
            {
                Success = true
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
                    Message = $"Milestone with ID:{id} not found"
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

        public ResponseDTO<IEnumerable<MilestoneResponseDTO>> GetByPregnancyId(int pregnancyId, string? search, DateOnly? from, DateOnly? to)
        {
            var milestones = _milestoneRepo.Get(m => m.PregnancyId == pregnancyId).AsEnumerable();

            if (!string.IsNullOrEmpty(search))
            {
                milestones = milestones.Where(m =>
                    m.Id.ToString().Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    m.Descriptions.ToString().Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            if (from.HasValue)
            {
                milestones = milestones.Where(m => m.Date >= from.Value);
            }

            if (to.HasValue)
            {
                milestones = milestones.Where(m => m.Date <= to.Value);
            }

            milestones = milestones.OrderByDescending(fd => fd.Date);

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

        public ResponseDTO<MilestoneResponseDTO> GetById(int id)
        {
            var milestone = _milestoneRepo.GetSingle(m => m.Id == id);
            if (milestone == null)
            {
                return new ResponseDTO<MilestoneResponseDTO>
                {
                    Success = false,
                    Message = "Milestone not found."
                };
            }

            var milestoneResponse = _mapper.Map<MilestoneResponseDTO>(milestone);
            return new ResponseDTO<MilestoneResponseDTO>
            {
                Success = true,
                Message = "Milestone found.",
                Data = milestoneResponse
            };
        }

        public ResponseDTO Update(int id, MilestoneRequestDTO milestoneRequestDTO)
        {
            var milestone = _milestoneRepo.GetSingle(f => f.Id == id);
            if (milestone == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Milestone not found."
                };
            }


            var update = _mapper.Map(milestoneRequestDTO, milestone);
            var valid = checkValidDate(milestone.Date);
            if (!valid.Success)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = valid.Message
                };
            }
            var result = _milestoneRepo.Update(update);
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
