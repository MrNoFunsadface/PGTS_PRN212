using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IMilestoneService
    {
        ResponseDTO Add(MilestoneRequestDTO milestoneRequestDTO);
        ResponseDTO<IEnumerable<MilestoneResponseDTO>> GetByPregnancyId(int pregnancyId, string? search, DateOnly? from, DateOnly? to);
        ResponseDTO<MilestoneResponseDTO> GetById(int id);
        ResponseDTO Update(int id, MilestoneRequestDTO milestoneRequestDTO);
        ResponseDTO Delete(int id);
    }
}
