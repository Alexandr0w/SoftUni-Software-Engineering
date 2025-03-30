using Newtonsoft.Json;
using SocialNetwork.Data;
using SocialNetwork.Utilities;
using SocialNetwork.DataProcessor.ExportDTOs;

namespace SocialNetwork.DataProcessor
{
    public class Serializer
    {
        public static string ExportUsersWithFriendShipsCountAndTheirPosts(SocialNetworkDbContext dbContext)
        {
            string result = string.Empty;

            var users = dbContext.Users
                .OrderBy(u => u.Username)
                .Select(u => new ExportUserDto
                {
                    Username = u.Username,
                    Friendships = dbContext.Friendships
                        .Where(f => f.UserOneId == u.Id || f.UserTwoId == u.Id).Count(),
                        Posts = u.Posts
                            .OrderBy(p => p.Id)
                            .Select(p => new ExportPostDto
                            {
                                Content = p.Content,
                                CreatedAt = p.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss")
                            })
                            .ToArray()
                })
                .ToArray();

            result = XmlHelper.Serialize(users, "Users");
            return result;
        }


        public static string ExportConversationsWithMessagesChronologically(SocialNetworkDbContext dbContext)
        {
            string result = string.Empty;

            var conversations = dbContext.Conversations
                .Select(c => new
                {
                    c.Id,
                    c.Title,
                    c.StartedAt, 
                    Messages = c.Messages
                        .OrderBy(m => m.SentAt)
                        .Select(m => new
                        {
                            m.Content,
                            m.SentAt,  
                            m.Status,
                            SenderUsername = m.Sender.Username
                        })
                        .ToArray()
                })
                .OrderBy(c => c.StartedAt) 
                .ToArray();  

            var formattedConversations = conversations
                .Select(c => new
                {
                    c.Id,
                    c.Title,
                    StartedAt = c.StartedAt.ToString("yyyy-MM-ddTHH:mm:ss"),  
                    Messages = c.Messages.Select(m => new
                    {
                        m.Content,
                        SentAt = m.SentAt.ToString("yyyy-MM-ddTHH:mm:ss"), 
                        m.Status,
                        m.SenderUsername
                    })
                    .ToArray()
                })
                .ToArray();

            result = JsonConvert.SerializeObject(formattedConversations, Formatting.Indented);
            return result;
        }
    }
}
