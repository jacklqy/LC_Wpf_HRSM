   M S B A M L   `   `   `  ����   HRSM.DXHouseApp2    ,HRSM.DXHouseApp.CRM.IntentedCustomerInfoView   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     j fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core    � 	Resources  -  'DevExpress.Xpf.LayoutControl.LayoutItem �� 
TargetType �� Property �� Value)  #DevExpress.Xpf.Editors.ComboBoxEdit%  DevExpress.Xpf.Editors.TextEdit��%�   '        '  %     '  a     �� "  .���  � ��$
 Left=��� "  .���  � ��$
 Left=���  � ��$	 150���� "  .���  � ��$
 Left=���  � ��$	 150��.���  � RowDefinitions �� $��30 ��� $
��auto ��� $��50 �.+��� $��>意向客户页面��$��0��$
��10,0q�$
��Left=�$��Bottom=�$��18(��� $��1��$��10q�$
��Left=�
������� �� CornerRadius$ 5��
�����_�$��1q�._�� .+�0  *DevExpress.Xpf.LayoutControl.LayoutControl  $��Stretch=�.  (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�4  .DevExpress.Xpf.LayoutControl.LayoutControlBase   	ItemSpace$ 10Q�$��	0,10,0,10q�$	��800��.+�  $ 20Q�$
��Left=�.+�     Label$ 客户名称：��	   Content.	 '  !DevExpress.Xpf.Editors.ButtonEdit  -   $��txtCustomerName��$	��150��  $ 需求类别：��.	   -   $��cboRequestTypes��
   Items.
 -  'DevExpress.Xpf.Editors.ComboBoxEditItem  .��求租  .��求购  $ 跟进人：��.	   -   $��txtFUser��  $ 20Q�$
��Left=�.+�  $ 客户需求：��$
��Left=�.	 �� -   $��txtCustRequest��$	��500��$	��100��+	  %DevExpress.Xpf.Core.UniformStackPanel	  $��2��$��Center=�.+�&
   DevExpress.Xpf.Core.SimpleButton
  $��添加��$��Center=�$��75�� 
  Glyph *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Apply_16x16.png 
  $��取消��$��Center=�$��75��$
��20,0q�   $ Cancel_16x16.png 