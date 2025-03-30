using BLL.DTOs;
using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class FetusDataService : IFetusDataService
    {
        public ResponseDTO Add(FetusDataRequestDTO fetusDataRequestDTO)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<IEnumerable<FetusDataResponseDTO>> GetAll(string? search)
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
