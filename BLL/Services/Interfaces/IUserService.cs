using BLL.DTOs;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        public ResponseDTO Register(UserRequestDTO userRequestDTO);
        public ResponseDTO<UserResponseDTO> Login(UserLoginDTO userLoginDTO);
        public ResponseDTO<UserResponseDTO> GetById(int id);
        public ResponseDTO<IEnumerable<UserResponseDTO>> GetAll(string search);
        public ResponseDTO ForgotPassword(string email, UserResetPasswordDTO userResetPasswordDTO);
        public ResponseDTO UpdateUser(int id, UserProfileDTO userProfileDTO);
    }
}
