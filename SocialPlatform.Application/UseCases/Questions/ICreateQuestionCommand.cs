﻿using SocialPlatform.Application.DTO.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Application.UseCases.Questions
{
    public interface ICreateQuestionCommand : ICommand<CreateQuestionDTO>
    {
    }
}
