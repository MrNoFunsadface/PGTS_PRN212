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

        public ResponseDTO<IEnumerable<FetusDataResponseDTO>> GetAll(int pregnancyId, string? search, DateOnly? from, DateOnly? to)
        {
            throw new NotImplementedException();
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
