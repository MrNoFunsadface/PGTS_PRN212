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
    public class PregnancyService : IPregnancyService
    {
        private readonly IGenericRepo<Pregnancy> _pregnancyRepo;
        private readonly IMapper _mapper;

        public PregnancyService(IGenericRepo<Pregnancy> pregnancyRepo, IMapper mapper)
        {
            _pregnancyRepo = pregnancyRepo;
            _mapper = mapper;
        }

        public ResponseDTO<PregnancyResponseDTO> Add(PregnancyRequestDTO pregnancyRequestDto)
        {
            var pregnancy = _mapper.Map<Pregnancy>(pregnancyRequestDto);

            var result = _pregnancyRepo.Create(pregnancy);

            if (!result)
            {
                return new ResponseDTO<PregnancyResponseDTO>
                {
                    Success = false,
                    Message = "Add pregnancy failed."
                };
            }

            return new ResponseDTO<PregnancyResponseDTO>
            {
                Success = true,
                Message = "Pregnancy added.",
                Data = new PregnancyResponseDTO
                {
                    Id = pregnancy.Id,
                    ConceptionDate = pregnancy.ConceptionDate,
                    DueDate = pregnancy.DueDate,
                    UserId = pregnancy.UserId
                }
            };
        }

        public ResponseDTO Delete(int id)
        {
            var pregnancy = _pregnancyRepo.GetSingle(p => p.Id == id);

            if (pregnancy == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = $"Pregnancy with ID:{id} not found"
                };
            }

            var result = _pregnancyRepo.Delete(pregnancy);
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
                Message = "Pregnancy deleted."
            };
        }

        public ResponseDTO<IEnumerable<PregnancyResponseDTO>> GetAll(string? search)
        {
            var pregnancies = _pregnancyRepo.Get().AsEnumerable();

            if (!string.IsNullOrEmpty(search))
            {
                int pregnancyId;
                if (int.TryParse(search, out pregnancyId))
                {
                    pregnancies = pregnancies.Where(p => p.Id == pregnancyId);
                }
                else
                {
                    var filter = search.ToLower();
                    pregnancies = pregnancies.Where(p =>
                        p.ConceptionDate.ToString().ToLower().Contains(filter) ||
                        p.DueDate.ToString().ToLower().Contains(filter));
                }
            }

            return new ResponseDTO<IEnumerable<PregnancyResponseDTO>>
            {
                Success = true,
                Message = "List of pregnancies.",
                Data = pregnancies.Select(p => new PregnancyResponseDTO
                {
                    Id = p.Id,
                    ConceptionDate = p.ConceptionDate,
                    DueDate = p.DueDate,
                    UserId = p.UserId
                })
            };
        }

        public ResponseDTO<PregnancyResponseDTO> GetById(int pregnancyId)
        {
            var pregnancy = _pregnancyRepo.GetSingle(p => p.Id == pregnancyId);
            if (pregnancy == null)
            {
                return new ResponseDTO<PregnancyResponseDTO>
                {
                    Success = false,
                    Message = "Pregnancy not found."
                };
            }

            var pregnancyResponse = _mapper.Map<PregnancyResponseDTO>(pregnancy);
            return new ResponseDTO<PregnancyResponseDTO>
            {
                Success = true,
                Message = "Pregnancy found.",
                Data = pregnancyResponse
            };
        }

        public ResponseDTO Update(int id, PregnancyRequestDTO pregnancyRequestDto)
        {
            var pregnancy = _pregnancyRepo.GetSingle(p => p.Id == id);
            if (pregnancy == null)
            {
                return new ResponseDTO<PregnancyResponseDTO>
                {
                    Success = false,
                    Message = "Pregnancy not found."
                };
            }

            var update = _mapper.Map(pregnancyRequestDto, pregnancy);
            var result = _pregnancyRepo.Update(update);
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
                Message = "Pregnancy updated."
            };
        }
    }
}
