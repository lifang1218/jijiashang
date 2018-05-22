using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jjs.Models
{
    /// <summary>
    /// 前台模板页model
    /// </summary>
    public class LayoutViewModel
    {
        /// <summary>
        /// 根菜单
        /// </summary>
        public List<Menu> menusRoot;

        /// <summary>
        /// 二级菜单
        /// </summary>
        public List<Menu> menusSublevel;

        /// <summary>
        /// 滚动图
        /// </summary>
        public List<ArticleContent> rollPictures;

        /// <summary>
        /// 热门套餐
        /// </summary>
        public List<ArticleContent> hotPackages;

        /// <summary>
        /// 经典案例
        /// </summary>
        public List<ArticleContent> classicCase;

        /// <summary>
        /// 团装小区
        /// </summary>
        public List<ArticleContent> groupBuilds;

        /// <summary>
        /// 环保装修
        /// </summary>
        public List<ArticleContent> environmentalBuilds;

        /// <summary>
        /// 家具设计
        /// </summary>
        public List<ArticleContent> homeDesigns;

        public Message message;

        /// <summary>
        /// 设计师
        /// </summary>
        public List<Designer> designers;

        public LayoutViewModel(JiJiaShangDB db)
        {
            menusRoot = db.Menus.Where(w => w.MenuLevel == 1).ToList();
            menusSublevel = db.Menus.Where(w => w.MenuLevel == 2).ToList();
        }
    }
}