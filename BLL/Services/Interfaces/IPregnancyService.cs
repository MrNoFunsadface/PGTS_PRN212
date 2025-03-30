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
        ResponseDTO Add(PregnancyRequestDTO pregnancyRequestDto);
        ResponseDTO<IEnumerable<PregnancyResponseDTO>> GetAll(DateOnly? from, DateOnly? to);
        ResponseDTO<PregnancyResponseDTO> GetById(int id);
        ResponseDTO Update(int id, PregnancyRequestDTO pregnancyRequestDto);
        ResponseDTO Delete(int id);
    }
}
