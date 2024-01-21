using Aspros.Base.Framework.Domain;
using Aspros.SaaS.System.Domain.ValueObjects;

namespace Aspros.SaaS.System.Domain.Domain
{
    public class Menu : BaseEntity, IAggregateRoot
    {
        #region 属性

        public long Id { get; private set; }
        public long ParentId { get; private set; }
        public string Path { get; private set; }
        public string Name { get; private set; }
        public MenuType Type { get; private set; }
        public int Sort { get; private set; } = 0;
        public string Permission { get; private set; }
        public string Component { get; private set; }
        public string Icon { get; private set; } = string.Empty;
        public Status Status { get; private set; } = Status.Normal;
        public bool Visible { get; private set; } = true;

        #endregion

        public Menu() { }

        public Menu(long parentId, string parentPath, string name, MenuType type, int sort, string permission, string component, string icon, bool visible = true)
        {
            ParentId = parentId;
            Path = ParentId == 0 ? parentId.ToString() : parentPath + "|" + Id;
            Name = name;
            Type = type;
            Sort = sort;
            Permission = permission;
            Component = component;
            Icon = icon;
            Visible = visible;
        }

        /// <summary>
        /// 修改菜单信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="sort"></param>
        /// <param name="permission"></param>
        /// <param name="component"></param>
        /// <param name="icon"></param>
        /// <param name="visible"></param>
        public void Modify(string name, MenuType type, int sort, string permission, string component, string icon, bool visible = true)
        {
            Name = name;
            Type = type;
            Sort = sort;
            Permission = permission;
            Component = component;
            Icon = icon;
            Visible = visible;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public void Delete()
        {
            Deleted = true;
        }
    }
}
