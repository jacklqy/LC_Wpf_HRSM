   M S B A M L   `   `   `  ����   HRSM.DXHouseApp*    $HRSM.DXHouseApp.CRM.CustomerInfoView   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     j fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  -   $��ucCustomerInfo��  � 	Resources  -  'DevExpress.Xpf.LayoutControl.LayoutItem �� 
TargetType �� Property �� Value)  #DevExpress.Xpf.Editors.ComboBoxEdit%  DevExpress.Xpf.Editors.TextEdit)  #DevExpress.Xpf.Editors.TextEditBase&   DevExpress.Xpf.Core.SimpleButton   TextEditErrorTemplate  teditCT �� 
TargetType��%�  '        '  %     '  a     '  �     &	  5    &	 B    �� "  .���  � ��$
 Left=��� "  .���  � ��$
 Left=���  � ��$	 150���� "  .���  � ��$
 Left=���  � ��$	 150����  �@ NullTextForeground
 �  ���� "  .���  � ��$ Center=���  � ��$ Center=���  � ��$ 66����  � ��$ 25���� .R��� �� "  .R��� #��z��#��z��#��z��.���  � RowDefinitions �� $��40 ��� $��* ��� $��50 �.+��� $��-->客户信息页面��$��0��$
��10,0q�$
��Left=�$��Center=�$��16(�$��微软雅黑)��� $��1��$
��Left=�
������� �� CornerRadius$ 5��
�����_�$��1q�._�� .+�0  *DevExpress.Xpf.LayoutControl.LayoutControl  $��Stretch=�.  (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�4  .DevExpress.Xpf.LayoutControl.LayoutControlBase   	ItemSpace$ 10Q�$��	0,10,0,10q�.+�  $ 20Q�$
��Left=�.+�  	   Label$	 客户名称：��
   Content.
   -   $��txtCustomerName��%	  DevExpress.Xpf.Editors.BaseEdit 	  NullText$! 客户名称不能为空！��   Text �� *CustomerName+  $	 联系人：��.
   -   $��txtContactor�� ��  �� Path$ CustInfo.Contactor� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors .   $	 客户电话：��.
   -   $��txtPhone��$ 请输入客户电话！�� �� *CustInfo.CustomerPhone+  $	 客户类别：��.
 +
  %DevExpress.Xpf.Core.UniformStackPanel
   
  Orientation$ 
Horizontal=�$��Center=�.+�	� -   $��rbtnPersonal��$��个人��$
��10,0q� d� 	IsChecked �� *
IsPersonal+	� -   $��rbtnUnit��$��单位��$
��10,0q� �� *IsUnit+  $ 20Q�$
��Left=�.+�  $	 客户地址：��$
��Left=�.
   -   $��
txtAddress��$	��375�� �� *CustInfo.CustomerAddress+  $	 客户状态：��$
��Left=�.
   -   $��cboCustStates��+  %DevExpress.Xpf.Editors.LookUpEditBase   ItemsSource �� *CboCustStates+ �� *CustInfo.CustomerState+  $	 创建时间：��$
��Left=�.
   -	   $��txtCreateTime�� 	  
IsReadOnly .    MaskType$ DateTime=�   Mask$ G�� �� *CustInfo.CreateTime+  $ 20Q�$
��Left=�.+�  $	 客户描述：��$
��Left=�.
   -
   $��	txtRemark��$	��800��$	��200��   TextWrapping$
 Wrap=�$	��Top=� �� *CustInfo.Remark+
  $��2��$��Center=�.+�  -   $��btnAdd������ *ConfirmBtnContent+y��� *IsConfirmBtnVisible+���� *
ConfirmCmd+   Glyph *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Apply_16x16.png   -   $��btnClose��$��关闭��$
��20,0q����� *CloseTabPage+����  �� ElementName$ ucCustomerInfo��   $ Cancel_16x16.png 