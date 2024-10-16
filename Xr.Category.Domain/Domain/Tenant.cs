using Aspros.Base.Framework.Domain;
using Xr.System.Domain.ValueObjects;

namespace Xr.System.Domain.Domain
{
    public class Tenant : BaseEntity, IAggregateRoot
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public long ContactUserId { get; private set; } = 0;
        public string ContactName { get; private set; } = string.Empty;
        public string ContactMobile { get; private set; } = string.Empty;
        public Status Status { get; private set; } = Status.Normal;
        public string Website { get; private set; } = string.Empty;
        public long PackageId { get; private set; }
        public DateTime ExpireTime { get; private set; }
        public int AccountCount { get; private set; } = 0;

        public virtual List<User> Users { get; set; }

        public Tenant() { }

        public Tenant(string name, string website, long packgeId, DateTime expireTime)
        {
            Name = name;
            Website = website;
            PackageId = packgeId;
            ExpireTime = expireTime;
            Status = Status.Normal;
        }

        public void SetUserCount(int count)
        {
            AccountCount += count;
            UpdateTime = DateTime.Now;
        }
    }
}
