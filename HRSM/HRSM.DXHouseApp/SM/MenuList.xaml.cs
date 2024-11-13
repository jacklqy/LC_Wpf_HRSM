using DevExpress.Xpf.Editors;
using HRSM.BLL;
using HRSM.DXHouseApp.Models;
using HRSM.Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HRSM.DXHouseApp.Utils;
using HRSM.DXHouseApp.Views;
using DevExpress.Xpf.Grid;
using HRSM.DXHouseApp.ViewModels.SM;

namespace HRSM.DXHouseApp.SM
{
	/// <summary>
	/// Interaction logic for MenuList.xaml
	/// </summary>
	public partial class MenuList : UserControl
	{
		public MenuList()
		{
			InitializeComponent();
		}
		private void UcMenuList_Loaded(object sender, RoutedEventArgs e)
		{
			MenuListViewModel menulistVM = new MenuListViewModel();
			this.DataContext = menulistVM;
			//注册菜单信息页面
			this.Register<MenuInfoWindow>("menuInfo");


		}

		//private void TreeListView_NodeCheckStateChanged(object sender, DevExpress.Xpf.Grid.TreeList.TreeListNodeEventArgs e)
		//{
		  
		//	TreeListNode node = e.Node;
		//	CheckChildNodes(node);
		//	CheckParentNode(node);
		//}
		///// <summary>
		///// 设置当前节点的所有子节点的勾选
		///// </summary>
		///// <param name="node"></param>
		//private void CheckChildNodes(TreeListNode node)
		//{
		//	foreach (TreeListNode child in node.Nodes)
		//	{
		//		child.IsChecked = node.IsChecked;
		//		CheckChildNodes(child);
		//	}
		//}
		///// <summary>
		///// 设置父节点的勾选
		///// </summary>
		///// <param name="node"></param>
		//private void CheckParentNode(TreeListNode node)
		//{
		//	TreeListNode pNode = node.ParentNode;
		//	if (pNode != null)
		//	{
		//		bool hasCheck = false;
		//		foreach (TreeListNode child in pNode.Nodes)
		//		{
		//			if (child.IsChecked == true)
		//			{
		//				hasCheck = true;
		//				break;
		//			}
		//		}
		//		pNode.IsChecked = hasCheck;
		//		CheckParentNode(pNode);
		//	}
		//}


		


	}
}
