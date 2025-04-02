using BLL.DTOs;
using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class MilestoneService : IMilestoneService
    {
        public ResponseDTO Add(MilestoneRequestDTO milestoneRequestDTO)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<IEnumerable<MilestoneResponseDTO>> GetAll(string? search)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<MilestoneResponseDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO Update(int id, MilestoneRequestDTO milestoneRequestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
