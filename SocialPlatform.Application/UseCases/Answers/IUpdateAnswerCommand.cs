using SocialPlatform.Application.DTO.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Application.UseCases.Answers
{
    public interface IUpdateAnswerCommand : ICommand<UpdateAnswerDTO>
    {
    }
}
