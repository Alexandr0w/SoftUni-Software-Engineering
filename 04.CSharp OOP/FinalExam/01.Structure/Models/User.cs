using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;

namespace BlackFriday.Models
{
    public abstract class User : IUser
    {
        private string _email;

        protected User(string userName, string email, bool hasDataAccess)
        {
            if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentException(ExceptionMessages.UserNameRequired);

            this.UserName = userName;
            this.Email = email;
        }

        public string UserName { get; private set; }
        public abstract bool HasDataAccess { get; }
        public string Email
        {
            get
            {
                if (HasDataAccess)
                    return "hidden";
                return _email;
            }
            private set
            {
                if (!HasDataAccess && string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmailRequired);
                }
                _email = value;
            }
        }

        public override string ToString()
        {
            string status = this.GetType().Name == "Admin" ? "Admin" : "Client";
            return $"{this.UserName} - Status: {status}, Contact Info: {this.Email}";
        }
    }
}
