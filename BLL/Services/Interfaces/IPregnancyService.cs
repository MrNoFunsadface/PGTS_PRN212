using BLL.DTOs;

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
