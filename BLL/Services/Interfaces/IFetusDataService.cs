using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IFetusDataService
    {
        ResponseDTO Add(FetusDataRequestDTO fetusDataRequestDTO);
        ResponseDTO<IEnumerable<FetusDataResponseDTO>> GetAll(string? search, DateOnly? from, DateOnly? to);
        ResponseDTO<IEnumerable<FetusDataResponseDTO>> GetByPregnancyId(int pregnancyId, string? search, DateOnly? from, DateOnly? to);
        ResponseDTO<FetusDataResponseDTO> GetById(int id);
        ResponseDTO Update(int id, FetusDataRequestDTO fetusDataRequestDTO);
        ResponseDTO Delete(int id);
    }
}
