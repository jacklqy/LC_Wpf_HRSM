   M S B A M L   `   `   `  ����   HRSM.DXHouseApp$    HRSM.DXHouseApp.BM.OwnInfoView   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     j fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  -   $��ucOwnerInfo��  � 	Resources  -  'DevExpress.Xpf.LayoutControl.LayoutItem �� 
TargetType �� Property �� Value)  #DevExpress.Xpf.Editors.ComboBoxEdit%  DevExpress.Xpf.Editors.TextEdit&   DevExpress.Xpf.Core.SimpleButton��%2  '        '  %     '  a     '  �     �� "  .���  � ��$
 Left=��� "  .���  � ��$
 Left=���  � ��$	 150���� "  .���  � ��$
 Left=���  � ��$	 150���� "  .���  � ��$ Center=���  � ��$ Center=���  � ��$ 66����  � ��$ 25��.���  � RowDefinitions �� $��30 ��� $��* ��� $��50 �.+��� $��--业主信息页面��$��0��$
��10,0q�$
��Left=�$��Bottom=�$��16(�$��黑体)�
��������� $��1��$��10q�
������� �� CornerRadius$ 5��
�����_�$��1q�._�� .+�0  *DevExpress.Xpf.LayoutControl.LayoutControl  $��Stretch=�.  (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�4  .DevExpress.Xpf.LayoutControl.LayoutControlBase   	ItemSpace$ 10Q�$��	0,20,0,10q�$
��Left=�.+�  $ 20Q�$
��Left=�.+�     Label$ 业主名称：��	   Content.	   -   $��txtOwnerName��)  #DevExpress.Xpf.Editors.TextEditBase
   Text
 �� *	OwnerName+  $ 业主类型：��.	   -   $��cboOwnTypes��'	  !DevExpress.Xpf.Editors.ButtonEdit 	  IsTextEditable$ FalseX�+
  %DevExpress.Xpf.Editors.LookUpEditBase 
  ItemsSource �� *CboOwnerTypes+
 �� *	OwnerType+  $ 联系人：��.	   -   $��txtContactor��
 �� *	Contactor+  $ 20Q�$
��Left=�.+�  $ 业主电话：��.	   -   $��txtPhone��
 �� *
OwnerPhone+  $ 业主地址：��$
��Left=�.	   -   $��
txtAddress��$	��370��
 �� *OwnerAddress+  $ 20Q�$
��Left=�.+�  $ 业主描述：��$
��Left=�.	   -   $��	txtRemark��   TextWrapping$
 Wrap=�$	��Top=�$	��600��$	��280��
 �� *Remark++  %DevExpress.Xpf.Core.UniformStackPanel  $��2��$��Center=�.+�  -   $��btnAdd������ *ConfirmBtnContent+{��� *IsConfirmBtnEnabled+y��� *IsConfirmBtnVisible+���� *
ConfirmCmd+   Glyph *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Apply_16x16.png   -	   $��btnClose��$��关闭��$
��20,0q����� *CloseTabPage+����  �� ElementName$ ucOwnerInfo��   $ Cancel_16x16.png 