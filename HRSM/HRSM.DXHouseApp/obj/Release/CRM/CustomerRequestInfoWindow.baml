   M S B A M L   `   `   `  ����   HRSM.DXHouseApp3    -HRSM.DXHouseApp.CRM.CustomerRequestInfoWindow   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  f bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   j fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  -   $��custRequestInfoWindow��  � Title$  客户需求信息页面��$	��300��$	��600�� � WindowStyle$
 None=� � WindowState$ Normal=� � WindowStartupLocation$ CenterScreen=� � 	Resources -  'DevExpress.Xpf.LayoutControl.LayoutItem �� 
TargetType �� Property �� Value)  #DevExpress.Xpf.Editors.ComboBoxEdit%  DevExpress.Xpf.Editors.TextEdit&   DevExpress.Xpf.Core.SimpleButton��%2  '        '  %     '  a     '  �     �� "  .���  � ��$
 Left=��� "  .���  � ��$
 Left=���  � ��$	 150���� "  .���  � ��$
 Left=���  � ��$	 150���� "  .���  � ��$ Center=���  � ��$ Center=���  � ��$ 66����  � ��$ 25��.���  � RowDefinitions �� -   $��30 ��� $��* ��� $��50 �.+��� $��-->意向客户页面��$��0��$
��10,0q�$
��Left=�$��Bottom=�$��18(��� $��1��$��10q�$��Center=�
�������	 �� CornerRadius$	 5��
�����_�$��1q�._�� .+�0  *DevExpress.Xpf.LayoutControl.LayoutControl  $��Stretch=�.  (DevExpress.Xpf.LayoutControl.LayoutGroup
   Orientation$
 Vertical=�4  .DevExpress.Xpf.LayoutControl.LayoutControlBase   	ItemSpace$ 10Q�$��	0,10,0,10q�.+�  $ 20Q�$
��Left=�.+�     Label$ 客户名称：��   Content. +  %DevExpress.Xpf.Grid.LookUp.LookUpEdit  -   $��luCustomers��*	  $DevExpress.Xpf.Editors.PopupBaseEdit 	  
PopupWidth$	 400Q�$	��120��+
  %DevExpress.Xpf.Editors.LookUpEditBase 
  DisplayMember$ CustomerName�� 
  ValueMember$ 
CustomerId�� 
  ItemsSource �� *LuCustomers+%  DevExpress.Xpf.Editors.BaseEdit   	EditValue �� *
CustomerId+   StyleSettings 8  2DevExpress.Xpf.Grid.LookUp.LookUpEditStyleSettings    $ 跟进人：��.   -   $��txtFUser��)  #DevExpress.Xpf.Editors.TextEditBase   Text �� *FollowUpUser+  $ 20Q�$
��Left=�.+�  $ 客户需求：��.   -   $��txtCustRequest��$	��400��$	��100��   TextWrapping$
 Wrap=�$	��Top=� �� *RequestContent++  %DevExpress.Xpf.Core.UniformStackPanel  $��2��$��Center=�.+�  -   $��btnAdd������ *ConfirmBtnContent+y��� *IsConfirmBtnVisible+���� *
ConfirmCmd+   Glyph *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Apply_16x16.png   -   $��btnClose��$��关闭��$
��20,0q����� *CloseWindowCmd+����  �� ElementName$ custRequestInfoWindow��   $ Cancel_16x16.png 