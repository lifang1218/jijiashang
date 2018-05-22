//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace jjs.Models
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    public partial class Menu
    {
    	/// <summary>  
        /// 自增长id  
        /// </summary> 
    	[DisplayName("自增长id")]
        public int Id { get; set; }
    	/// <summary>  
        /// 菜单名  
        /// </summary> 
    	[DisplayName("菜单名")]
        public string MenuTitle { get; set; }
    	/// <summary>  
        /// 菜单链接（可指定到自定义的页面）  
        /// </summary> 
    	[DisplayName("菜单链接（可指定到自定义的页面）")]
        public string MenuLink { get; set; }
    	/// <summary>  
        /// 菜单级别(一级菜单可以没有链接)  
        /// </summary> 
    	[DisplayName("菜单级别(一级菜单可以没有链接)")]
        public int MenuLevel { get; set; }
    	/// <summary>  
        /// 二级菜单时(需要指定父菜单)  
        /// </summary> 
    	[DisplayName("二级菜单时(需要指定父菜单)")]
        public int ParentId { get; set; }
    	/// <summary>  
        /// 添加时间  
        /// </summary> 
    	[DisplayName("添加时间")]
        public Nullable<System.DateTime> InDateTime { get; set; }
    	/// <summary>  
        /// 修改时间  
        /// </summary> 
    	[DisplayName("修改时间")]
        public Nullable<System.DateTime> EditDateTime { get; set; }
    	/// <summary>  
        /// 添加人  
        /// </summary> 
    	[DisplayName("添加人")]
        public string InUserName { get; set; }
    	/// <summary>  
        /// 修改人  
        /// </summary> 
    	[DisplayName("修改人")]
        public string EditUserName { get; set; }
    }
}
