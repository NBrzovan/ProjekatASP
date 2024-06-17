using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Application.DTO.Read
{
    public class GetQuestionDTO
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Topic { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public List<AnswersForQuestionDTO> Answers { get; set; }
        public List<TagsForQuestionDTO> Tags { get; set; }
    }

    public class AnswersForQuestionDTO
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Answer { get; set; }
        public DateTime Createt { get; set; }
        public List<AnswersForQuestionDTO> Replies { get; set; }
    }

    public class TagsForQuestionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

