using AutoMapper;
using BLL.DTOs;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repo;
using Microsoft.IdentityModel.Tokens;

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
            var fetus = _fetusDataRepo.GetSingle(f => f.Id == id);

            if (fetus == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = $"Fetus data with ID:{id} not found"
                };
            }

            var result = _fetusDataRepo.Delete(fetus);
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
                Message = "Fetus data deleted."
            };
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

        public ResponseDTO<FetusDataResponseDTO> GetById(int id)
        {
            var fetus = _fetusDataRepo.GetSingle(f => f.Id == id);
            if (fetus == null)
            {
                return new ResponseDTO<FetusDataResponseDTO>
                {
                    Success = false,
                    Message = "Fetus data not found."
                };
            }

            var fetusResponse = _mapper.Map<FetusDataResponseDTO>(fetus);
            return new ResponseDTO<FetusDataResponseDTO>
            {
                Success = true,
                Message = "Fetus data found.",
                Data = fetusResponse
            };
        }

        public ResponseDTO Update(int id, FetusDataRequestDTO fetusDataRequestDTO)
        {
            var fetus = _fetusDataRepo.GetSingle(f => f.Id == id);
            if (fetus == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Fetus data not found."
                };
            }


            var update = _mapper.Map(fetusDataRequestDTO, fetus);
            var valid = checkValidDate(fetus.Date);
            if (!valid.Success)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = valid.Message
                };
            }
            var result = _fetusDataRepo.Update(update);
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
                Message = "Fetus data updated."
            };
        }
    }
}
