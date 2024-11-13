using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using HRSM.Common;
using HRSM.DXHouseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HRSM.DXHouseApp
{
        public class ComUtility
        {
                /// <summary>
                /// 子页面获取父类窗体
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="reference"></param>
                /// <returns></returns>
                public static T GetAncestor<T>(DependencyObject reference) where T : DependencyObject
                {
                        DependencyObject parent = VisualTreeHelper.GetParent(reference);
                        while (!(parent is T) && parent != null)
                        {
                                parent = VisualTreeHelper.GetParent(parent);
                        }
                        if (parent != null)
                                return (T)parent;
                        else
                                return null;
                }

                public static childitem FindVisualChild<childitem>(DependencyObject obj, string name)
                    where childitem : FrameworkElement
                {
                        if (obj == null)
                                return null;
                        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                        {
                                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                                if (child != null && child is childitem && ((childitem)child).Name == name)
                                        return (childitem)child;
                                else
                                {
                                        childitem childOfChild = FindVisualChild<childitem>(child, name);
                                        if (childOfChild != null)
                                                return childOfChild;
                                }
                        }
                        return null;
                }

                public static childitem FindLogicChild<childitem>(DependencyObject obj, string name)
                   where childitem : FrameworkElement
                {
                        if (obj == null)
                                return null;
                        foreach (var child in LogicalTreeHelper.GetChildren(obj))
                        {
                                if (child != null && child is childitem && ((childitem)child).Name == name)
                                        return (childitem)child;
                                else
                                {
                                        childitem childOfChild = FindLogicChild<childitem>(child as DependencyObject, name);
                                        if (childOfChild != null)
                                                return childOfChild;
                                }
                        }
                        return null;
                }





                /// <summary>
                /// 将指定的UserControl添加到Tab页
                /// </summary>
                /// <param name="tab"></param>
                /// <param name="uc"></param>
                /// <param name="headerText"></param>
                public static void AddTabPage(UserControl ucList, UserControl uc, string headerText)
                {
                        DXTabControl tab = ComUtility.GetAncestor<DXTabControl>(ucList);
                        bool bl = IsHasTabPage(tab, headerText);
                        if (!bl)
                        {
                                DXTabItem tabitem = new DXTabItem();
                                tabitem.Header = headerText;
                                Frame fInfo = new Frame();
                                fInfo.Content = uc;
                                tabitem.Content = fInfo;

                                tab.Items.Add(tabitem);
                                tab.SelectTabItem(tabitem);
                        }
                        else
                        {
                                DXTabItem tabitem = GetTabPage(tab, headerText);
                                if (tabitem != null)
                                {
                                        Frame fInfo = new Frame();
                                        fInfo.Content = uc;
                                        tabitem.Content = fInfo;
                                        tab.SelectTabItem(tabitem);
                                }
                        }
                }

                /// <summary>
                /// 判断指定标题的选项卡是否已存在
                /// </summary>
                /// <param name="tab"></param>
                /// <param name="headerText"></param>
                /// <returns></returns>
                public static bool IsHasTabPage(DXTabControl tab, string headerText)
                {
                        bool bl = false;
                        foreach (DXTabItem item in tab.Items)
                        {
                                if (item.Header.ToString() == headerText)
                                {
                                        bl = true;
                                        break;
                                }
                        }
                        return bl;
                }

                /// <summary>
                /// 获取指定标题的TabItem
                /// </summary>
                /// <param name="tab"></param>
                /// <param name="headerText"></param>
                /// <returns></returns>
                public static DXTabItem GetTabPage(DXTabControl tab, string headerText)
                {
                        foreach (DXTabItem item in tab.Items)
                        {
                                if (item.Header.ToString() == headerText)
                                {
                                        return item;
                                }
                        }
                        return null;
                }



                public enum RSType
                {
                        出租,
                        出售
                }

                /// <summary>
                /// 获取租售类型列表
                /// </summary>
                /// <returns></returns>
                public static List<string> GetRSTypes(bool isDefault)
                {
                        List<string> list = new List<string>();
                        if (isDefault)
                                list.Add("请选择");
                        foreach (string val in Enum.GetNames(typeof(RSType)))
                        {
                                list.Add(val);
                        }
                        return list;
                }




                /// <summary>
                /// 获取房屋朝向列表
                /// </summary>
                /// <param name="isDefault"></param>
                /// <returns></returns>
                public static List<string> GetHouseDirections(bool isDefault)
                {
                        List<string> list = new List<string>();
                        if (isDefault)
                                list.Add("请选择");
                        list.Add("坐南朝北");
                        list.Add("坐北朝南");
                        list.Add("坐东朝西");
                        list.Add("坐西朝东");
                        return list;
                }


                public enum StatType
                {
                        HouseStat,
                        SaleHouseStat,
                        SaleTimeHouseStat
                }


        }
}
