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
    public class FetusDataService : IFetusDataService
    {
        private readonly IGenericRepo<FetusData> _fetusDataRepo;
        private readonly IGenericRepo<Pregnancy> _pregnancyRepo;
        private readonly IMapper _mapper;

        public FetusDataService(IGenericRepo<FetusData> fetusDataRepo, IGenericRepo<Pregnancy> pregnancyRepo, IMapper mapper)
        {
            _fetusDataRepo = fetusDataRepo;
            _pregnancyRepo = pregnancyRepo;
            _mapper = mapper;
        }

        public ResponseDTO Add(FetusDataRequestDTO fetusDataRequestDTO)
        {
            var fetus = _mapper.Map<FetusData>(fetusDataRequestDTO);

            var valid = checkValidDate(fetus.Date);
            if (!valid.Success)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = valid.Message
                };
            }

            var pregnancy = _pregnancyRepo.GetSingle(p => p.Id == fetus.PregnancyId);
            if (pregnancy == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = $"Pregnancy not found."
                };
            }

            var result = _fetusDataRepo.Create(fetus);
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
                Message = "Fetus data added.",
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
            throw new NotImplementedException();
        }

        public ResponseDTO<IEnumerable<FetusDataResponseDTO>> GetByPregnancyId(int pregnancyId, string? search, DateOnly? from, DateOnly? to)
        {
            var fetusDatas = _fetusDataRepo.Get(fd => fd.PregnancyId == pregnancyId).AsEnumerable();

            if (!string.IsNullOrEmpty(search))
            {
                fetusDatas = fetusDatas.Where(fd =>
                    fd.Id.ToString().Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    fd.Weight.ToString().Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    fd.Height.ToString().Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    fd.HeadCircumference.ToString().Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            if (from.HasValue)
            {
                fetusDatas = fetusDatas.Where(fd => fd.Date >= from.Value);
            }

            if (to.HasValue)
            {
                fetusDatas = fetusDatas.Where(fd => fd.Date <= to.Value);
            }

            fetusDatas = fetusDatas.OrderByDescending(fd => fd.Date);

            return new ResponseDTO<IEnumerable<FetusDataResponseDTO>>
            {
                Success = true,
                Message = "List of fetus growth data",
                Data = fetusDatas.Select(fd => new FetusDataResponseDTO
                {
                    Id = fd.Id,
                    PregnancyId = fd.PregnancyId,
                    Weight = fd.Weight,
                    Height = fd.Height,
                    HeadCircumference = fd.HeadCircumference,
                    Date = fd.Date
                })
            };
        }

        public ResponseDTO Update(int id, FetusDataRequestDTO fetusDataRequestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
