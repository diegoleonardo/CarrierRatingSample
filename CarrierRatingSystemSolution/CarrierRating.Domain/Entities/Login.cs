using CarrierRating.Domain.Entities.MongoEntities;
using System.IdentityModel.Tokens;

namespace CarrierRating.Domain.Entities
{
    public class Login: MongoEntity
    {
        public string Email { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        private UserNameSecurityToken Token;
        public string TokenKey { get; private set; }

        public void SetUserId(string pUserId)
        {
            UserId = pUserId;
        }

        public void GenerateToken(string pEmail, string pPassword)
        {
            this.Token = new UserNameSecurityToken(Email, pPassword);
            this.TokenKey = Token.SecurityKeys.ToString();
        }
    }
}