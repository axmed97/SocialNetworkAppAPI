﻿using SocialNetwork.Core.Utilities.Result.Abstract;
using SocialNetwork.Entities.DTOs.CommentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business.Abstract
{
    public interface ICommentService
    {
        IResult AddComment(int userId, CommentCreateDTO commentCreateDTO);
    }
}
