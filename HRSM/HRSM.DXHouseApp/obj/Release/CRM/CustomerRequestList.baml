   M S B A M L   `   `   `  ���� J  FHRSM.DXHouseApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:HRSM.DXHouseApp.ViewsHRSM.DXHouseApp.Views  O,clr-namespace:HRSM.DXHouseApp.ViewModels.CRMHRSM.DXHouseApp.ViewModels.CRM  F BHRSM.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullN6clr-namespace:HRSM.Models.VModels;assembly=HRSM.ModelsHRSM.Models.VModels -    'HRSM.DXHouseApp.CRM.CustomerRequestList   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     j fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  f bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa	 ]DevExpress.Xpf.Grid.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 c
 _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity 
 /Views#clr-namespace:HRSM.DXHouseApp.Views 
 5vm,clr-namespace:HRSM.DXHouseApp.ViewModels.CRM 
 Cvmodel6clr-namespace:HRSM.Models.VModels;assembly=HRSM.Models 
 -   $��ucCustomerRequestList��  � 	Resources   �� 
TargetType �� Property �� Value   
chkShowDel&   DevExpress.Xpf.Editors.CheckEdit$ 	 DevExpress.Xpf.Grid.GridColumn$  DevExpress.Xpf.Grid.BaseColumn��%:  '>�       &	  C     '  �     '�� �     �� " >�.���  � ��$ Stretch=���  � ��$ Stretch=��� "  .���  � ��$ 
0,10,10,10q���  � ��$ Right=���  � ��
 �  ���� "  .���  �@ HeaderTemplate �� .R��� $
��10,0q����� �� " ��.���  � ��$
 10,2q� � DataContext A   ;HRSM.DXHouseApp.ViewModels.CRM.CustomerRequestListViewModel  .���  � RowDefinitions �� $��30 ��� $
��auto ��� $��* �.+�+   %HRSM.DXHouseApp.Views.ListToolBarView  -     Name$
 tbar��$��0�� �� *ToolBarInfo+  -   $��
chkShowDel��   Content)  #DevExpress.Xpf.Core.ObjectConverter$ 显示已删除 $��1��#��[     	IsChecked �� *	IsShowDel+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�   Command �� *FindCustRequestListCmd+% 	 DevExpress.Xpf.Grid.GridControl  -     Name$ gridInCustRequests��$��3��)  #DevExpress.Xpf.Grid.DataControlBase#   EnableSmartColumnsGeneration .  $��Stretch=�   AutoGenerateColumns$ KeepOld=�   SelectionMode$	 Row=�$��Stretch=�   ItemsSource �� *CustRequestList+   CurrentItem �� *CurrentItem+   View #	 	 DevExpress.Xpf.Grid.TableView	   	  AllowPerPixelScrolling . &
   DevExpress.Xpf.Grid.DataViewBase 
  ShowTotalSummary .   
  AllowEditing .  & 	  DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .   	  AlternationCount$ 2�� 	  AlternateRowBackground �	#FFCADEEF   AllowPaging .    PageSize$ 20X� 	  	AutoWidth .    Columns.   -     Name$ chkCol��$  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ IsCheck��'    HorizontalHeaderContentAlignment$ Center=�    HeaderTemplate  �� .R�  !  Name$! chkAll��$ 全选  �� *DataContext.IsCheckAll+$	 TwoWay=�$
 PropertyChanged=�" �� RelativeSource" �� # �� Mode$# FindAncestor=�$ �� AncestorType"$ >� �� *DataContext.CheckAllCmd+" �� $# FindAncestor=�"$ >�%   CellTemplate% �� .R�  $��Center=� �� & �� Path$& Value�$	 TwoWay=�$
 PropertyChanged=� �� *DataContext.CheckItemCmd+" �� $# FindAncestor=�"$ >�'   CommandParameter' �� " �� $
# Self=�$& DataContext.RowData.Row�  $# CustRequestInfo.CustRequestId��(   Header$( 编号 % �� .R��� $
��10,2q����� $& Value�  $" CustRequestInfo.CustomerName��$( 	客户名 % �� .R��� $
��10,2q����� $& Value�  $$ CustRequestInfo.RequestContent��$( 需求内容 % �� .R��� $
��10,2q����� $& Value�  $" CustRequestInfo.FollowUpUser��$( 	跟进人 % �� .R��� $
��10,2q����� $& Value�  $  CustRequestInfo.CreateTime��$( 创建时间 % �� .R��� $
��10,2q����� $& Value�  $" CustRequestInfo.RequestState��$( 状态 % �� .R��� $
��10,2q����� $& Value�0  *DevExpress.Xpf.LayoutControl.LayoutControl  $
��Left=�$��1��$	��Top=�.  (DevExpress.Xpf.LayoutControl.LayoutGroup)   Orientation$) Vertical=�4  .DevExpress.Xpf.LayoutControl.LayoutControlBase*   	ItemSpace$* 10Q�.+�  $* 10Q�.+�-  'DevExpress.Xpf.LayoutControl.LayoutItem  +   Label$+ 客户名：��,   Content., %  DevExpress.Xpf.Editors.TextEdit  -   $��txtCustomerName��$	��120��)  #DevExpress.Xpf.Editors.TextEditBase-   Text- �� *
CustName+$	 TwoWay=�$
 PropertyChanged=�  $+ 跟进人：��.,   -   $��txtFollowUpUser��$	��120��- �� *FollowUpUser+$
 PropertyChanged=�$	 TwoWay=�  $+ 客户类别：��., )  #DevExpress.Xpf.Editors.ComboBoxEdit  -   $��cboCustomerTypes��$	��100��+  %DevExpress.Xpf.Editors.LookUpEditBase.   ItemsSource. �� *CboCustomerTypes+- �� *CustomerType+$	 TwoWay=�$
 PropertyChanged=�. 
 (System.Windows.Interactivity.Interaction/   Triggers/ / 
 )System.Windows.Interactivity.EventTrigger  0   	EventName$0 SelectedIndexChanged��. 
 (System.Windows.Interactivity.TriggerBase1   Actions.1 6 
 0System.Windows.Interactivity.InvokeCommandAction  2   Command2 �� *FindCustRequestListCmd+  $+ 需求内容：��.,   -	   $��
txtContent��$	��120��- �� *RequestContent+$	 TwoWay=�$
 PropertyChanged=�