   M S B A M L   `   `   `  ����   HRSM.DXHouseApp(    "HRSM.DXHouseApp.HSat.HouseStatList   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     f bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   j fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  -   $��ucHouseStatList��  � 	Resources  %  DevExpress.Xpf.Editors.TextEdit �� 
TargetType �� Property �� Value-  'DevExpress.Xpf.LayoutControl.LayoutItem$  DevExpress.Xpf.Grid.GridColumn$  DevExpress.Xpf.Grid.BaseColumn��%�   '        '  $     '  I     �� "  .���  � ��$	 100���� "  .���  � ��$
 Left=��� "  .���  �@ HeaderTemplate �� .R��� $
��10,0q����� .���  � RowDefinitions �� $
��auto ��� .+�%  DevExpress.Xpf.Grid.GridControl  -     Name$ 
gridHouses��$��2��$��4��)  #DevExpress.Xpf.Grid.DataControlBase#   EnableSmartColumnsGeneration .  $��Stretch=�   AutoGenerateColumns$ KeepOld=�   SelectionMode$	 Row=�$��Stretch=�	   ItemsSource	 �� *	HouseList+
   CurrentItem
 �� *CurrentItem+   View #  DevExpress.Xpf.Grid.TableView     AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .     AllowEditing .  &	   DevExpress.Xpf.Grid.GridViewBase 	  ShowGroupPanel .     AlternationCount$ 2��   AlternateRowBackground �	#FFCADEEF 	  AllowPaging .  	  PageSize$ 20X�   	AutoWidth .    Columns.   $
  DevExpress.Xpf.Grid.ColumnBase 
  	FieldName$ Id��   Header)  #DevExpress.Xpf.Core.ObjectConverter$ 编号  
  CellTemplate �� .R��� $
��10,2q�����  �� Path$ Value�  $ 	HouseName��$ 名称  �� .R��� $
��10,2q����� $ Value�  $ Building��$ 楼宇  �� .R��� $
��10,2q����� $ Value�  $ HouseAddress��$ 地址    Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	 200  �� .R��� $
��10,2q����� $ Value�  $ 	OwnerName��$ 业主  �� .R��� $
��10,2q����� $ Value�  $ RentSale��$ 租售  �� .R��� $
��10,2q����� $ Value�  $ HouseDirection��$ 朝向  �� .R��� $
��10,2q����� $ Value�  $ HouseLayout��$ 户型  �� .R��� $
��10,2q����� $ Value�  $ 
HouseState��$ 状态  �� .R��� $
��10,2q����� $ Value�0  *DevExpress.Xpf.LayoutControl.LayoutControl  $��Stretch=�$��0��$	��Top=�.  (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�4  .DevExpress.Xpf.LayoutControl.LayoutControlBase   	ItemSpace$ 10Q�.+�  $ 20Q�$
��Left=�.+�     Label �� $ StatCountName�   Content.   -   $��txtStaCount��%  DevExpress.Xpf.Editors.BaseEdit   
IsReadOnly . $	��200��)  #DevExpress.Xpf.Editors.TextEditBase    Text  �� $ 	StatCount�  -   $��liUser��$ 销售员：��$y�Visible=�.   -   $��txtSaleUser��  �� *
SaleUser+  -   $��liStTime��$ 开始时间：��.   -   $��	txtStTime��  �� *StTime+  -   $��liEtTime��$ 结束时间：��.   -	   $��	txtEtTime��  �� *EtTime+  . &   DevExpress.Xpf.Core.SimpleButton  -
   $��btnOutPutExcel��$��导出������ *
ExportData+