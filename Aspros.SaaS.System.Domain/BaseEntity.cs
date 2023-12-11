namespace Aspros.SaaS.System.Domain
{
    public class BaseEntity
    {
        public string Creator { get; set; } = string.Empty;
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public string Updater { get; set; } = string.Empty;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        public bool Deleted { get; set; } = false;
    }
}
