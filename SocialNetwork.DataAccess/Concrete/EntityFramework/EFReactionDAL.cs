using SocialNetwork.Core.DataAccess.EntityFramework;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities.Concrete;

namespace SocialNetwork.DataAccess.Concrete.EntityFramework
{
    public class EFReactionDAL : EFRepositoryBase<Reaction, AppDbContext>, IReactionDAL
    {
        public void DisLikePost(int userId, int postId)
        {
            using var context = new AppDbContext(); // IDisposable
            var reaction = context.Reactions.FirstOrDefault(x => x.UserId == userId && x.PostId == postId);

            if(reaction == null)
            {
                Reaction react = new()
                {
                    UserId = userId,
                    PostId = postId,
                    IsLike = false
                };
                context.Reactions.Add(react);
                context.SaveChanges();
            }else if (!reaction.IsLike)
            {
                reaction.IsLike = true;
                context.Reactions.Update(reaction);
                context.SaveChanges();
            }
            else
            {
                context.Reactions.Remove(reaction);
                context.SaveChanges();
            }

        }

        public void LikePost(int userId, int postId)
        {
            using var context = new AppDbContext();
            var reaction = context.Reactions.FirstOrDefault(x => x.UserId == userId && x.PostId == postId);
            if (reaction == null)
            {
                Reaction react = new()
                {
                    UserId = userId,
                    PostId = postId,
                    IsLike = true
                };
                context.Reactions.Add(react);
                context.SaveChanges();
            }
            else if (reaction.IsLike == false)
            {
                reaction.IsLike = true;
                context.Reactions.Update(reaction);
                context.SaveChanges();
            }
            else
            {
                context.Reactions.Remove(reaction);
                context.SaveChanges();
            }
        }
    }
}
