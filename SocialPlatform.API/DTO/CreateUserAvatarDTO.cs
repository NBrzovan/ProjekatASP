using SocialPlatform.Application.DTO.Create;

namespace SocialPlatform.API.DTO
{
    public class CreateUserAvatarDTO : CreateUserDTO
    {
        public IFormFile? File { get; set; }
    }
}


