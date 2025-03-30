using AutoMapper;
using BLL.DTOs;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repo;
using Microsoft.IdentityModel.Tokens;
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

        public ResponseDTO Add(PregnancyRequestDTO pregnancyRequestDto)
        {
            var pregnancy = _mapper.Map<Pregnancy>(pregnancyRequestDto);
            var valid = checkValidDate(pregnancy.ConceptionDate, pregnancy.DueDate);
            if (!valid.Success)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = valid.Message
                };
            }

            var result = _pregnancyRepo.Create(pregnancy);
            if (!result)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Add pregnancy failed."
                };
            }

            return new ResponseDTO
            {
                Success = true,
                Message = "Pregnancy added."
            };
        }

        private ResponseDTO checkValidDate(DateOnly conceptionDate, DateOnly? dueDate)
        {
            if (conceptionDate.ToString().IsNullOrEmpty())
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Conception date cannot be empty"
                };
            }

            if (conceptionDate > dueDate)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Due date has to be after conception date"
                };
            }

            if (conceptionDate > DateOnly.FromDateTime(DateTime.Now))
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Conception date cannot be in the future"
                };
            }

            return new ResponseDTO
            {
                Success = true
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

        public ResponseDTO<IEnumerable<PregnancyResponseDTO>> GetAll(DateOnly? from, DateOnly? to)
        {
            var pregnancies = _pregnancyRepo.Get().AsEnumerable();

            if (from.HasValue)
            {
                pregnancies = pregnancies.Where(p => p.ConceptionDate >= from.Value || (p.DueDate.HasValue && p.DueDate.Value >= from.Value));
            }

            if (to.HasValue)
            {
                pregnancies = pregnancies.Where(p => p.ConceptionDate <= to.Value || (p.DueDate.HasValue && p.DueDate.Value <= to.Value));
            }

            pregnancies = pregnancies.OrderByDescending(p => p.ConceptionDate);

            return new ResponseDTO<IEnumerable<PregnancyResponseDTO>>
            {
                Success = true,
                Message = "List of pregnancies.",
                Data = pregnancies.Select(p => new PregnancyResponseDTO
                {
                    Id = p.Id,
                    ConceptionDate = p.ConceptionDate,
                    DueDate = p.DueDate.GetValueOrDefault(),
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
            var valid = checkValidDate(pregnancy.ConceptionDate, pregnancy.DueDate);
            if (!valid.Success)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = valid.Message
                };
            }
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
