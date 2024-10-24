using CleanArchitecture.Application.AdminDtos.UserDtos.ResponseDto;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Dtos.AdminDtos.RequestDto;
using CleanArchitecture.Application.Services.AbstractServices.Users;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers.V1
{
    //[ServiceFilter(typeof(ProducesResponseTypeFilter))]
    public class UserController : AuthBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<Result<IEnumerable<UserResponseDto>>> GetAll(SearchDto searchDto)
        {
            return (await _userService.GetAll(searchDto));
        }

        [HttpGet(nameof(GetById))]
        public async Task<Result<UserResponseDto>> GetById(int id)
        {
            return (await _userService.GetById(id));
        }

        [HttpPost(nameof(SaveAndUpdate))]
        public async Task<Result<UserResponseDto>> SaveAndUpdate(UserRequestDto userRequestDto)
        {
            return (await _userService.SaveAndUpdate(userRequestDto));
        }

        [HttpDelete(nameof(Delete))]
        public async Task<Result<bool>> Delete(int[] ids)
        {
            return (await _userService.Delete(ids));
        }

    }
}
