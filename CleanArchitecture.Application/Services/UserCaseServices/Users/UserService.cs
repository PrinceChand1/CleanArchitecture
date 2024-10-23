using CleanArchitecture.Application.AdminDtos.UserDtos.ResponseDto;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Dtos.AdminDtos.RequestDto;
using CleanArchitecture.Application.Dtos.AdminDtos.ResponseDto;
using CleanArchitecture.Application.Services.AbstractServices.Users;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories;

namespace CleanArchitecture.Application.Services.UserCases.Users;
public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // User Activity
    public async Task<Result<bool>> Delete(int[] ids)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<IEnumerable<UserResponseDto>>> GetAll(SearchDto searchDto)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<UserResponseDto>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<UserResponseDto>> SaveAndUpdate(UserRequestDto userRequestDto)
    {
        throw new NotImplementedException();
    }


    // Login Activity
    public async Task<Result<UserLoginResponseDto>> GetToken(UserLoginRequestDto userLoginRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<ResetPasswordResponseDto>> ResetPassword(ResetPasswordRequestDto resetPasswordRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<bool>> ForgotPassword(string email, string path)
    {
        throw new NotImplementedException();
    }

}
