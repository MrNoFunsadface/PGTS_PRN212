using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IPregnancyService
    {
        ResponseDTO<PregnancyResponseDTO> Add(PregnancyRequestDTO pregnancyRequestDto);
        ResponseDTO<IEnumerable<PregnancyResponseDTO>> GetAll(string? search);
        ResponseDTO<PregnancyResponseDTO> GetById(int pregnancyId);
        ResponseDTO Update(int id, PregnancyRequestDTO pregnancyRequestDto);
        ResponseDTO Delete(int id);
    }
}
