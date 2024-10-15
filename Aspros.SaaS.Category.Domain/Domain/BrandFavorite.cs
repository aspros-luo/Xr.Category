using Aspros.Base.Framework.Domain;
using Aspros.SaaS.System.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspros.SaaS.Category.Domain.Domain
{
    public class BrandFavorite: BasicEntity, IAggregateRoot
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public long Id { get; protected set; }

        /// <summary>
        /// 品牌id
        /// </summary>
        public long BrandId { get; protected set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public long UserId { get; protected set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType UserType { get; protected set; }

        /// <summary>
        /// 是否收藏
        /// </summary>
        public bool IsFavorite { get; protected set; } = true;

        public virtual Brand Brand { get; set; }

        #endregion

        #region method

        public void AddFavorite()
        {
            IsFavorite = true;
        }

        public void CancelFavorite()
        {
            IsFavorite = false;
        }


        #endregion
    }
}
