   M S B A M L   `   `   `  ����   HRSM.DXHouseApp&     HRSM.DXHouseApp.BM.HouseInfoView   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  j fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  -   $��ucHouseInfo��  � 	Resources  &   DevExpress.Xpf.Core.SimpleButton �� 
TargetType �� Property �� Value%  DevExpress.Xpf.Editors.TextEdit)  #DevExpress.Xpf.Editors.ComboBoxEdit%  DevExpress.Xpf.Editors.BaseEdit2  ,DevExpress.Xpf.LayoutControl.LayoutItemLabel   labelItemStyle-  'DevExpress.Xpf.LayoutControl.LayoutItem.  (DevExpress.Xpf.LayoutControl.LayoutGroup4  .DevExpress.Xpf.LayoutControl.LayoutControlBase��%  '        '  m     '  �     &	      '  L    7   '  �    �� "  .���  � ��$ Center=���  � ��$ Center=���  � ��$ 66����  � ��$ 25���� "  .���  � ��$	 150����  � �� �	#FF2E46E2�� "  .���  �@ 
IsReadOnly .  ��  � ��$	 150����  � �� �	#FF2E46E2�� "  .���  � ��$ Right=���  � ��$ 60���� "  .���  � ��$
 Left=���  �@ 
LabelStyle8   �� "  .���  �@ 	ItemSpace$ 10Q���  � ��$
 Left=�.���  � RowDefinitions �� $��30 ��� $��* ��� $��50 �.+��� $��>房屋信息页面��$��0��$
��10,0q�$
��Left=�$��Bottom=�$��18(��� $��1��$��10q�
�������
�����_�$��1q� �� CornerRadius$ 5��._�� .+�0	  *DevExpress.Xpf.LayoutControl.LayoutControl	  $��Stretch=�$��Stretch=�   Orientation$ Vertical=�   	ItemSpace$ 10Q�$��	0,10,0,10q�.+�  $ 20Q�.+�     Label$ 房屋名称：��	   Content.	   -   $��txtHouseName��)
  #DevExpress.Xpf.Editors.TextEditBase
 
  Text
 �� *HouseInfo.HouseName+  $ 所在楼宇：��.	   -   $��txtBuilding��
 �� *HouseInfo.Building+  $ 房屋地址：��.	   -   $��
txtAddress��
 �� *HouseInfo.HouseAddress+  $ 20Q�.+�  $ 租售类型：��$��Center=�$	��212��.	 +  %DevExpress.Xpf.Core.UniformStackPanel     Orientation$ 
Horizontal=�$��Center=�.+�	� -   $��rbtnRent��$��出租�� d� 	IsChecked �� *IsRent+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=����� *CheckRentSaleCmd+	� -   $��rbtnSale��$��出售�� �� *IsSale+$ TwoWay=�$ PropertyChanged=����� *CheckRentSaleCmd+  $ 	价格：��.	 %  DevExpress.Xpf.Editors.SpinEdit  -   $��txtPrice��   MaskType$ Numeric=�   Mask$ n2��   	Increment$ 1~�$	��150��   	EditValue �� *HouseInfo.HousePrice+  $ 	单位：��.	   -   $��cboUnits��+  %DevExpress.Xpf.Editors.LookUpEditBase   DisplayMember$ 	PUnitName��   ValueMember$ PUnitId��   ItemsSource �� *
CboUnits+
 �� *	PriceUnit+  $ 20Q�.+�  $ 	朝向：��.	   -	   $��cboDirections�� �� *CboDirections+
 �� *HouseDirection+  $ 	户型：��.	   -
   $��
cboLayouts��$ HLName�� �� *
CboLayouts+
 �� *HouseLayout+  $ 	业主：��.	   -   $��	cboOwners��$ 	OwnerName��$ OwnerId�� �� *	CboOwners+ �� *	OwnerId+  $ 20Q�.+�  $ 	楼层：��.	   -   $��txtFloor��
 �� *HouseInfo.HouseFloor+  $ 	面积：��.	   -   $��txtAreas��$ Numeric=�$ n2��
 �� *HouseInfo.HouseArea+  $ 	状态：��.	   -   $��	cboStates��$ 	StateName��$ StateId�� �� *	CboStates+$ TwoWay=�$ PropertyChanged=�
 �� *
HouseState+  $y�Visible=�$ 20Q�.+�  $ 发布时间：��.	   -   $��	tbPubTime��{�.  
 �� *HouseInfo.PublishTime+  $ 添加时间：��.	   -   $��tbCreateTime��{�.  
 �� *HouseInfo.CreateTime+  $ 	发布：��.	   .+�	� -   $��rbtnPublish��$	��是�� �� *HouseInfo.IsPublish+$ TwoWay=�$ PropertyChanged=�	� -   $��rbtnUnPublish��$	��否�� �� *	UnPublish+$ TwoWay=�$ PropertyChanged=�  $ 20Q�$
��Left=�.+�  $ 房屋图片：��$
��Left=�.	 &   DevExpress.Xpf.Editors.ImageEdit  -   $��imgPic��$	��200��$	��100��   ShowMenu .      ShowLoadDialogOnClickMode$ Never=�   Source �� *
HousePic+$ TwoWay=�$ PropertyChanged=�.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ MouseLeftButtonDown��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *ChoosePicCmd+  $ 房屋描述：��$
��Left=�.	   -   $��	txtRemark��$	��400�� 
  TextWrapping$
 Wrap=�$	��Top=�$	��100��
 �� *HouseInfo.Remark+  $��2��$��Center=�.+�  -   $��btnAdd������ *ConfirmBtnContent+{��� *IsConfirmBtnEnabled+y��� *IsConfirmBtnVisible+���� *
ConfirmCmd+����  �� ElementName$ ucHouseInfo��   Glyph *  $DevExpress.Xpf.Core.DXImageExtension      Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$  Apply_16x16.png   -   $��btnClose��$��关闭��$
��20,0q����� *CloseTabPage+���� $ ucHouseInfo��   $  Cancel_16x16.png 