using CleanArchitecture.Application.AdminDtos.UserDtos.ResponseDto;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Dtos.AdminDtos.RequestDto;
using CleanArchitecture.Application.Dtos.AdminDtos.ResponseDto;

namespace CleanArchitecture.Application.Services.AbstractServices.Users;
public interface IUserService
{
    //Task<Result<IEnumerable<UserResponseDto>>> GetAll(SearchDto search);
    //Task<Result<UserLoginResponseDto>> GetToken(UserLoginRequestDto userLoginRequestDto);
    //Task<Result<UserDto>> GetById(int userId, string path);
    //Task<Result<UserRequestDto>> AddUser(UserRequestDto userRequestDto, string path);
    //Task<Result<UserRequestDto>> UpdateUser(UserRequestDto userRequestDto, string path);
    //Task<Result<bool>> ResetPassword(ResetPasswordRequest resetPasswordRequest);
    //Task<Result<bool>> ChangePassword(ChangePasswordRequest changePasswordRequest);
    //Task<Result<bool>> ForgotPassword(string email, string path);
    //Task<Result<bool>> Delete(int[] ids);
    //Task<bool> SendResetPasswordEmail(SendResetPasswordDto resetPasswordRequestDto, string path);
    //Task<Result<User>> AddUserFromOuterForm(UserRequestDto userRequestDto, string path);
    //Task<Result<User>> UpdateUserFromOuterForm(UserRequestDto userRequestDto, string path);
    Task<Result<IEnumerable<UserResponseDto>>> GetAll(SearchDto searchDto);
    Task<Result<UserResponseDto>> GetById(int id);
    Task<Result<UserResponseDto>> SaveAndUpdate(UserRequestDto userRequestDto);
    Task<Result<bool>> Delete(int[] ids);
    Task<Result<UserLoginResponseDto>> GetToken(UserLoginRequestDto userLoginRequestDto);
    Task<Result<ResetPasswordResponseDto>> ResetPassword(ResetPasswordRequestDto resetPasswordRequestDto);
    Task<Result<bool>> ForgotPassword(string email, string path);
}
