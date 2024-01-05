namespace Aspros.SaaS.System.Infrastructure
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class Permission(string code, string roleIds) : Attribute
    {
        public string Code { get; set; } = code;
        public string RoleIds { get; set; } = roleIds;
    }
}
