using Aspros.Base.Framework.Domain;
using Aspros.SaaS.System.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspros.SaaS.Category.Domain.Domain
{
    public class Brand : BasicEntity, IAggregateRoot
    {
        public Brand() { }

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public long BrandId { get; protected set; }
        /// <summary>
        /// 中文名
        /// </summary>
        public string CnName { get; protected set; }
        /// <summary>
        /// 英文名
        /// </summary>
        public string EnName { get; protected set; }
        /// <summary>
        /// 以 pid:vid:vdata表示
        /// </summary>
        public string Properties { get; protected set; }
        /// <summary>
        /// 来源地
        /// </summary>
        public string Country { get; protected set; }
        /// <summary>
        /// logo
        /// </summary>
        public string Logo { get; protected set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; protected set; }
        /// <summary>
        /// 在售的商品数量
        /// </summary>
        public int OnsaleItemNum { get; protected set; }
        /// <summary>
        /// 首字母
        /// </summary>
        public string Initial { get; protected set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; protected set; } = 0;
        /// <summary>
        /// 背景图片
        /// </summary>
        public string BackgroundImage { get; protected set; }
        /// <summary>
        /// 喜欢数量
        /// </summary>
        public int FavoriteQuantity { get; protected set; }

        public virtual ICollection<BrandFavorite> BrandFavorites { get; set; }

        #endregion
    }
}
