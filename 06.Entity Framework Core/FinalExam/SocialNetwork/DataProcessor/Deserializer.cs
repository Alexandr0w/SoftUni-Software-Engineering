using System.Text;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SocialNetwork.Data;
using SocialNetwork.Data.Enums;
using SocialNetwork.Data.Models;
using SocialNetwork.DataProcessor.ImportDTOs;
using SocialNetwork.Utilities;

namespace SocialNetwork.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format.";
        private const string DuplicatedDataMessage = "Duplicated data.";
        private const string SuccessfullyImportedMessageEntity = "Successfully imported message (Sent at: {0}, Status: {1})";
        private const string SuccessfullyImportedPostEntity = "Successfully imported post (Creator {0}, Created at: {1})";

        public static string ImportMessages(SocialNetworkDbContext dbContext, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            ImportMessageDto[]? messageDtos = XmlHelper.Deserialize<ImportMessageDto[]>(xmlString, "Messages");

            ICollection<Message> validMessages = new List<Message>();

            if (messageDtos != null && messageDtos.Length > 0)
            {
                foreach (ImportMessageDto messageDto in messageDtos)
                {
                    if (!IsValid(messageDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isSentAtValid = DateTime
                        .TryParseExact(messageDto.SentAt, "yyyy-MM-ddTHH:mm:ss", CultureInfo
                        .InvariantCulture, DateTimeStyles.None, out DateTime sentAtDate);

                    bool isStatusValid = Enum
                        .TryParse<MessageStatus>(messageDto.Status, out MessageStatus messageStatus);

                    bool conversationExists = dbContext.Conversations.Any(c => c.Id == messageDto.ConversationId);
                    bool senderExists = dbContext.Users.Any(u => u.Id == messageDto.SenderId);

                    if (!isSentAtValid || !isStatusValid || !conversationExists || !senderExists)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool messageExistsInBatch = validMessages.Any(m =>
                        m.Content == messageDto.Content &&
                        m.SentAt == sentAtDate &&
                        m.Status == messageStatus &&
                        m.SenderId == messageDto.SenderId &&
                        m.ConversationId == messageDto.ConversationId);

                    bool messageExistsInDb = dbContext.Messages.Any(m =>
                        m.Content == messageDto.Content &&
                        m.SentAt == sentAtDate &&
                        m.Status == messageStatus &&
                        m.SenderId == messageDto.SenderId &&
                        m.ConversationId == messageDto.ConversationId);

                    if (messageExistsInBatch || messageExistsInDb)
                    {
                        sb.AppendLine(DuplicatedDataMessage);
                        continue;
                    }

                    Message message = new Message
                    {
                        SentAt = sentAtDate,
                        Content = messageDto.Content,
                        Status = messageStatus,
                        ConversationId = messageDto.ConversationId,
                        SenderId = messageDto.SenderId
                    };

                    validMessages.Add(message);
                    sb.AppendLine(string.Format(SuccessfullyImportedMessageEntity, sentAtDate.ToString("yyyy-MM-ddTHH:mm:ss"), messageStatus));
                }

                dbContext.Messages.AddRange(validMessages);
                dbContext.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportPosts(SocialNetworkDbContext dbContext, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportPostDto[]? postDtos = JsonConvert.DeserializeObject<ImportPostDto[]>(jsonString);

            ICollection<Post> validPosts = new List<Post>();

            if (postDtos != null && postDtos.Length > 0)
            {
                foreach (ImportPostDto postDto in postDtos)
                {
                    if (!IsValid(postDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isCreatedAtValid = DateTime
                        .TryParseExact(postDto.CreatedAt, "yyyy-MM-ddTHH:mm:ss", CultureInfo
                        .InvariantCulture, DateTimeStyles.None, out DateTime createdAtDate);

                    var creator = dbContext.Users.Find(postDto.CreatorId);

                    if (!isCreatedAtValid || creator == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool postExistsInBatch = validPosts.Any(p =>
                        p.Content == postDto.Content &&
                        p.CreatedAt == createdAtDate &&
                        p.CreatorId == postDto.CreatorId);

                    bool postExistsInDb = dbContext.Posts.Any(p =>
                        p.Content == postDto.Content &&
                        p.CreatedAt == createdAtDate &&
                        p.CreatorId == postDto.CreatorId);

                    if (postExistsInBatch || postExistsInDb)
                    {
                        sb.AppendLine(DuplicatedDataMessage);
                        continue;
                    }

                    Post post = new Post
                    {
                        Content = postDto.Content,
                        CreatedAt = createdAtDate,
                        CreatorId = postDto.CreatorId
                    };

                    validPosts.Add(post);
                    sb.AppendLine(string.Format(SuccessfullyImportedPostEntity, creator.Username, createdAtDate.ToString("yyyy-MM-ddTHH:mm:ss")));
                }

                dbContext.Posts.AddRange(validPosts);
                dbContext.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            ValidationContext validationContext = new ValidationContext(dto);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach (ValidationResult validationResult in validationResults)
            {
                if (validationResult.ErrorMessage != null)
                {
                    string currentMessage = validationResult.ErrorMessage;
                }
            }

            return isValid;
        }
    }
}
