   M S B A M L   `   `   `  ����   HRSM.DXHouseApp"    HRSM.DXHouseApp.HS.HouseInfo   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     j fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  -   $��ucHouseInfo��  � 	Resources  %  DevExpress.Xpf.Editors.TextEdit �� 
TargetType%  DevExpress.Xpf.Editors.BaseEdit �� Property �� Value2  ,DevExpress.Xpf.LayoutControl.LayoutItemLabel   labelItemStyle-  'DevExpress.Xpf.LayoutControl.LayoutItem.  (DevExpress.Xpf.LayoutControl.LayoutGroup4  .DevExpress.Xpf.LayoutControl.LayoutControlBase��%P  '        &	  a     '  �     7   '  �     �� "  .���  �@ 
IsReadOnly . ��  � ��$	 200����  � �� �	#FF2E46E2�� "  .���  � ��$ Right=���  � ��$ 60���� "  .���  � ��$
 Left=���  �@ 
LabelStyle8   �� "  .���  �@ 	ItemSpace$ 10Q���  � ��$
 Left=�.���  � RowDefinitions �� $��50 ��� $
��auto ��� $��50 �.+��� $��房屋信息详情��$��0��$
��50,5q�$
��Left=�$��Bottom=�$��18(�$
��Bold"����	#FFCB6D1F�� $��1��$��10q�
�������
�����_�$��1q� �� CornerRadius$ 5��._�� .+�0  *DevExpress.Xpf.LayoutControl.LayoutControl  $��Stretch=�$��Stretch=�   Orientation$ Vertical=�   	ItemSpace$ 10Q�$��10q� � DataContext �� *HouseInfoModel+.+�  .+�  	   Label$	 	业主：��
   Content.
   -   $��txtOwner��)  #DevExpress.Xpf.Editors.TextEditBase   Text �� *	OwnerName+  $	 房屋名称：��.
   -   $��txtHouseName�� �� *	HouseName+  $	 所在楼宇：��.
   -   $��txtBuilding�� �� *
Building+  .+�  $	 房屋地址：��.
   -   $��
txtAddress��$	��472�� �� *HouseAddress+  $	 	电话：��.
   -   $��txtOwnerPhone�� �� *
OwnerPhone+  .+�  $	 租售类型：��.
   -   $��txtRentSale�� �� *
RentSale+  $	 	价格：��.
   -   $��txtPrice�� �� *
HousePrice+  $	 	单位：��.
   -	   $��txtUnit�� �� *	PriceUnit+  .+�  $	 	朝向：��.
   -
   $��txtDirection�� �� *HouseDirection+  $	 	户型：��.
   -   $��	txtLayout�� �� *HouseLayout+  $	 	楼层：��.
   -   $��txtFloor�� �� *
HouseFloor+  .+�  $	 	面积：��.
   -   $��txtAreas��   MaskType$ Numeric=�   Mask$ n2�� �� *	HouseArea+  $	 	状态：��.
   -   $��txtState�� �� *
HouseState+  .+�  $	 房屋图片：��$
��Left=�.
 &	   DevExpress.Xpf.Editors.ImageEdit	  -   $��imgPic��$	��150��$	��100�� 	  ShowMenu .   	  Source �� *
HousePic+  $	 房屋描述：��$
��Left=�.
   -   $��	txtRemark��$	��400��   TextWrapping$
 Wrap=�$	��Top=�$	��100�� �� *Remark+