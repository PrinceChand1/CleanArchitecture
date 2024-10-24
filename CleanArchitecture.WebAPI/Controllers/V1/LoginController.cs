using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Dtos.AdminDtos.RequestDto;
using CleanArchitecture.Application.Dtos.AdminDtos.ResponseDto;
using CleanArchitecture.Application.Services.AbstractServices.Users;
using CleanArchitecture.Shared.SharedResoures;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers.V1
{
    //[ServiceFilter(typeof(ProducesResponseTypeFilter))]
    public class LoginController : UnAuthBaseController
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LoginController(IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost(nameof(GetToken))]
        [ProducesResponseType(typeof(Result<UserLoginResponseDto>), StatusCodes.Status200OK)]
        public async Task<Result<UserLoginResponseDto>> GetToken(UserLoginRequestDto userLoginRequestDto)
        {
            return (await _userService.GetToken(userLoginRequestDto));
        }

        [HttpPost(nameof(ResetPassword))]
        public async Task<Result<ResetPasswordResponseDto>> ResetPassword(ResetPasswordRequestDto resetPasswordRequestDto)
        {
            return (await _userService.ResetPassword(resetPasswordRequestDto));
        }

        [HttpPost(nameof(ForgotPassword))]
        public async Task<Result<bool>> ForgotPassword(string email)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, SharedResoure.WwwRootPathTemplate);
            return (await _userService.ForgotPassword(email, path));
        }
    }
}
