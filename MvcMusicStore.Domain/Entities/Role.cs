using System;

namespace MvcMusicStore.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
