using CleanArchitecture.Application.AdminDtos.UserDtos.ResponseDto;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Dtos.AdminDtos.RequestDto;
using CleanArchitecture.Application.Dtos.AdminDtos.ResponseDto;
using CleanArchitecture.Application.Services.AbstractServices.Users;
using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories;
using CleanArchitecture.Shared.SharedResoures;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.Application.Services.UserCases.Users;
public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly AppSettingsDto _appSettingsDto;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper, IOptions<AppSettingsDto> appSettingsDto)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _appSettingsDto = appSettingsDto.Value;
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
        var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
        var mapperdata = _mapper.Map<UserResponseDto>(user);
        if (user == null)
        {
            return new Result<UserResponseDto>()
            {
                Success = false,
                Error = SharedResoure.UserNotFound,
            };
        }
        return new Result<UserResponseDto>()
        {
            Data = mapperdata,
            Success = true,
            Error = SharedResoure.UserNotFound,
        };
    }

    public async Task<Result<UserResponseDto>> SaveAndUpdate(UserRequestDto userRequestDto)
    {
        throw new NotImplementedException();
    }


    // Login Activity
    public async Task<Result<UserLoginResponseDto>> GetToken(UserLoginRequestDto userLoginRequestDto)
    {
        var getUser = await _unitOfWork.UserRepository.GetAllAsync(x => x.Username == userLoginRequestDto.Username && x.IsDeleted == false);
        var user = getUser.FirstOrDefault();
        if (user == null)
        {
            return new Result<UserLoginResponseDto>()
            {
                Success = false,
                Error = SharedResoure.UserNotFound
            };
        }
        else
        {
            if (user.Password != userLoginRequestDto.Password)
            {
                return new Result<UserLoginResponseDto>()
                {
                    Success = false,
                    Error = SharedResoure.IncorrectPassword
                };
            }

            UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(user);
            var token = await GenerateJwtToken(userResponseDto);

            var userLoginResponseDto = new UserLoginResponseDto()
            {
                Token = token,
                Id = userResponseDto.Id,
                FirstName = userResponseDto.FirstName,
                Email = userResponseDto.Email,
                UserType = userResponseDto.UserType,
                OfficeStaffType = userResponseDto.OfficeStaffType,
            };

            return new Result<UserLoginResponseDto>()
            {
                Data = userLoginResponseDto,
                Success = true,
            };
        }
    }

    public async Task<Result<ResetPasswordResponseDto>> ResetPassword(ResetPasswordRequestDto resetPasswordRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<bool>> ForgotPassword(string email, string path)
    {
        throw new NotImplementedException();
    }

    private async Task<string> GenerateJwtToken(UserResponseDto userResponseDto)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = await Task.Run(() =>
        {
            var key = Encoding.ASCII.GetBytes(_appSettingsDto.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(GetClaims(userResponseDto)),
                Issuer = _appSettingsDto.Issuer,
                Audience = _appSettingsDto.Audience,
                Expires = DateTime.UtcNow.AddMinutes(_appSettingsDto.AddMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenHandler.CreateToken(tokenDescriptor);
        });
        return tokenHandler.WriteToken(token);
    }

    private List<Claim> GetClaims(UserResponseDto userResponseDto)
    {
        var claims = new List<Claim>()
        {
            new Claim("UserId", Convert.ToString(userResponseDto.Id)),
            new Claim("FirstName", userResponseDto.FirstName),
            new Claim("Username", userResponseDto.Username),
            new Claim("UserType", userResponseDto.UserType),
            new Claim("OfficeStaffType", userResponseDto.Email)
        };
        return claims;
    }
}
