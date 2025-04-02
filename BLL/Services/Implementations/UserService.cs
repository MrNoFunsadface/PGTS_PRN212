using AutoMapper;
using BLL.DTOs;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repo;

namespace BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IGenericRepo<User> _userRepo;
        private readonly IMapper _mapper;

        public UserService(IGenericRepo<User> userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public ResponseDTO Register(UserRequestDTO userRequestDTO)
        {
            var user = _mapper.Map<User>(userRequestDTO);
            var valid = checkValidPassWord(user.Password);
            if (!valid.Success)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = valid.Message
                };
            }

            var existingUser = _userRepo.GetSingle(u => u.Email == user.Email);
            if (existingUser != null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = $"Email: {user.Email} already exists."
                };
            }

            var result = _userRepo.Create(user);
            if (!result)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Register failed."
                };
            }

            return new ResponseDTO
            {
                Success = true,
                Message = "Register successful."
            };
        }

        public ResponseDTO<UserResponseDTO> Login(UserLoginDTO userLoginDTO)
        {
            var existingUser = _userRepo.GetSingle(u => u.Email == userLoginDTO.Email && u.Password == userLoginDTO.Password);
            if (existingUser == null)
            {
                return new ResponseDTO<UserResponseDTO>
                {
                    Success = false,
                    Message = "Wrong Email or Passwword"
                };
            }

            if (!existingUser.isActive)
            {
                return new ResponseDTO<UserResponseDTO>
                {
                    Success = false,
                    Message = "Your account has been disabled."
                };
            }

            var userResponse = _mapper.Map<UserResponseDTO>(existingUser);
            return new ResponseDTO<UserResponseDTO>
            {
                Success = true,
                Message = "Logged in.",
                Data = userResponse
            };
        }

        public ResponseDTO<IEnumerable<UserResponseDTO>> GetAll(string search)
        {
            var users = _userRepo.Get().AsEnumerable();
            if (!string.IsNullOrEmpty(search))
            {
                int userId;
                if (int.TryParse(search, out userId))
                {
                    users = users.Where(u => u.Id == userId || u.Phone.ToLower().Contains(search));
                }
                else
                {
                    var filter = search.ToLower();
                    users = users.Where(u =>
                        u.Name.ToLower().Contains(filter) ||
                        u.Email.ToLower().Contains(filter)).ToList();
                }
            }

            return new ResponseDTO<IEnumerable<UserResponseDTO>>
            {
                Success = true,
                Message = "List of users.",
                Data = users.Select(u => new UserResponseDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Password = u.Password,
                    Phone = u.Phone,
                    isAdmin = u.isAdmin,
                    isActive = u.isActive
                })
            };
        }

        public ResponseDTO<UserResponseDTO> GetById(int id)
        {
            var user = _userRepo.GetSingle(u => u.Id == id);
            if (user == null)
            {
                return new ResponseDTO<UserResponseDTO>
                {
                    Success = false,
                    Message = "user not found."
                };
            }

            var userResponse = _mapper.Map<UserResponseDTO>(user);
            return new ResponseDTO<UserResponseDTO>
            {
                Success = true,
                Message = "ID matched",
                Data = userResponse
            };
        }

        private ResponseDTO checkValidPassWord(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Password cannot be empty"
                };
            }

            if (password.Count() < 4 || password.Count() > 16)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Password's length has to be from 4 to 16 characters"
                };
            }

            return new ResponseDTO
            {
                Success = true
            };
        }

        public ResponseDTO ForgotPassword(string email, UserResetPasswordDTO userResetPasswordDTO)
        {
            var user = _userRepo.GetSingle(u => u.Email == email);

            if (user == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = $"User with email: {email} not found"
                };
            }

            var forgotPasswordUser = _mapper.Map(userResetPasswordDTO, user);

            _userRepo.Update(forgotPasswordUser);

            return new ResponseDTO
            {
                Success = true,
                Message = "Password reset successfully."
            };
        }

        public ResponseDTO ChangePassword(int id, UserResetPasswordDTO userResetPasswordDTO)
        {
            var user = _userRepo.GetSingle(u => u.Id == id);

            var changePasswordUser = _mapper.Map(userResetPasswordDTO, user);

            _userRepo.Update(changePasswordUser);

            return new ResponseDTO
            {
                Success = true,
                Message = "Password updated."
            };
        }

        public ResponseDTO UpdateProfile(int id, UserProfileDTO userProfileDTO)
        {
            var user = _userRepo.GetSingle(u => u.Id == id);
            if (user == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = $"User with ID: {id} not found"
                };
            }

            var updateUser = _mapper.Map(userProfileDTO, user);

            _userRepo.Update(updateUser);

            return new ResponseDTO
            {
                Success = true,
                Message = "User updated."
            };
        }

        public ResponseDTO Update(int id, UserRequestDTO userRequestDTO)
        {
            var user = _userRepo.GetSingle(u => u.Id == id);
            if (user == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = $"User with ID: {id} not found"
                };
            }

            var updateUser = _mapper.Map(userRequestDTO, user);

            _userRepo.Update(updateUser);

            return new ResponseDTO
            {
                Success = true,
                Message = "User updated."
            };
        }

        public ResponseDTO Delete(int id)
        {
            var user = _userRepo.GetSingle(u => u.Id == id);

            if (user == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = $"User with ID:{id} not found"
                };
            }

            var delete = _userRepo.Delete(user);

            if (!delete)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Delete failed."
                };
            }

            return new ResponseDTO
            {
                Success = true,
                Message = "Delete successful"
            };
        }

        public ResponseDTO ToggleStatus(int id)
        {
            var user = _userRepo.GetSingle(u => u.Id == id);
            if (user == null)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = $"User with ID: {id} not found"
                };
            }
            user.isActive = !user.isActive;
            var update = _userRepo.Update(user);
            if (!update)
            {
                return new ResponseDTO
                {
                    Success = false,
                    Message = "Toggle status failed."
                };
            }
            return new ResponseDTO
            {
                Success = true,
                Message = "Toggle status successful."
            };
        }
    }
}
