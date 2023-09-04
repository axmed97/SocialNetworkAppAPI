using SocialNetwork.Entities.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Entities.DTOs.CommentDTOs
{
    public class CommentUserDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public UserPostDTO UserPostDTO { get; set; }
    }
}
