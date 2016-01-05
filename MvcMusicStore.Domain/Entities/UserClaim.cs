using System;

namespace MvcMusicStore.Domain.Entities
{
    public class UserClaim
    {
        public UserClaim()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string UserId { get; set; }
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }

        public virtual User User { get; set; }
    }
}
