using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Application.DTO.Create
{
    public class CreateAnswerDTO
    {
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public int? ParentId { get; set; } 
        public string Body { get; set; }
    }

}
