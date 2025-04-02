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
        public ResponseDTO ChangePassword(int id, UserResetPasswordDTO userResetPasswordDTO);
        public ResponseDTO UpdateProfile(int id, UserProfileDTO userProfileDTO);
        public ResponseDTO Update(int id, UserRequestDTO userRequestDTO);
        public ResponseDTO Delete(int id);
        public ResponseDTO ToggleStatus(int id);
    }
}
