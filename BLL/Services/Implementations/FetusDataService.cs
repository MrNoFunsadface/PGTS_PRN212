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

            var pregnancy = _pregnancyRepo.GetSingle(p => p.Id == fetus.PregnancyId);
            if (pregnancy == null)
            {
                return new ResponseDTO<FetusDataResponseDTO>
                {
                    Success = false,
                    Message = $"Pregnancy not found."
                };
            }

            var result = _fetusDataRepo.Create(fetus);
            if (!result)
            {
                return new ResponseDTO<FetusDataResponseDTO>
                {
                    Success = false,
                    Message = "Add failed."
                };
            }

            return new ResponseDTO<FetusDataResponseDTO>
            {
                Success = true,
                Message = "Fetus data added.",
                Data = new FetusDataResponseDTO
                {
                    Id = fetus.Id,
                    PregnancyId = fetus.PregnancyId,
                    Weight = fetus.Weight,
                    Height = fetus.Height,
                    HeadCircumference = fetus.HeadCircumference,
                    Date = fetus.Date
                }
            };
        }

        public ResponseDTO Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<IEnumerable<FetusDataResponseDTO>> GetAll(string? search, DateOnly? from, DateOnly? to)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<IEnumerable<FetusDataResponseDTO>> GetByPregnancyId(int pregnancyId, string? search, DateOnly? from, DateOnly? to)
        {
            var fetusDatas = _fetusDataRepo.Get(fd => fd.PregnancyId == pregnancyId).AsEnumerable();

            if (!string.IsNullOrEmpty(search))
            {
                int id;
                if (int.TryParse(search, out id))
                {
                    fetusDatas = fetusDatas.Where(fd => fd.Id == id
                                            || fd.PregnancyId == id);
                }

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
                Message = "List of bookings",
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
            throw new NotImplementedException();
        }

        public ResponseDTO Update(int id, FetusDataRequestDTO fetusDataRequestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
