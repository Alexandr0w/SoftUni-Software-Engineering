namespace SocialNetwork.Common
{
    public static class ValidationConstants
    {
        // User
        public const int UserUsernameMinLength = 4;
        public const int UserUsernameMaxLength = 20;
        public const int UserEmailMinLength = 8;
        public const int UserEmailMaxLength = 60;
        public const int UserPasswordLength = 6;

        // Conversation
        public const int ConversationTitleMinLength = 2;
        public const int ConversationTitleMaxLength = 30;

        // Post
        public const int PostContentMinLength = 5;
        public const int PostContentMaxLength = 300;

        // Message
        public const int MessageContentMinLength = 1;
        public const int MessageContentMaxLength = 200;
    }
}