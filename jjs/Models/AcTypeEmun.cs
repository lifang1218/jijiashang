using jjs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace jjs.Models
{
    public enum AcTypeEmun
    {
        /// <summary>
        /// 滚动图
        /// </summary>
        [Remark("滚动图")]
        ROLL = 1,

        /// <summary>
        /// 热门套餐
        /// </summary>
        [Remark("热门套餐")]
        HOTPACKAGE = 2,

        /// <summary>
        /// 经典案例
        /// </summary>
        [Remark("经典案例")]
        CLASSCASE = 3,

        /// <summary>
        /// 团装小区
        /// </summary>
        [Remark("团装小区")]
        GROUPBUILD = 4,

        /// <summary>
        /// 家居设计
        /// </summary>
        [Remark("家居设计")]
        HOMEDESIGN = 5,

        /// <summary>
        /// 环保装修
        /// </summary>
        [Remark("环保装修")]
        ENVIRONMENTAL = 6,

        /// <summary>
        /// 其他
        /// </summary>
        [Remark("其他")]
        OTHER =666



    }
}