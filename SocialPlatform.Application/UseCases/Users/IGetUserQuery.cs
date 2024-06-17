using SocialPlatform.Application.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Application.UseCases.Users
{
    public interface IGetUserQuery : IQuery<GetUserDTO, int>
    {
    }
}

