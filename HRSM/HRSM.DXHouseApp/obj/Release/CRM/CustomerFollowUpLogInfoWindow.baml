   M S B A M L   `   `   `  ����   HRSM.DXHouseApp7    1HRSM.DXHouseApp.CRM.CustomerFollowUpLogInfoWindow   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  j fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  -   $��custFollowUpLogInfoWindow��  � Title$#  CustomerFollowUpLogInfoWindow��$	��400��$	��600�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � 	Resources -  'DevExpress.Xpf.LayoutControl.LayoutItem �� 
TargetType �� Property �� Value)  #DevExpress.Xpf.Editors.ComboBoxEdit%  DevExpress.Xpf.Editors.TextEdit&   DevExpress.Xpf.Core.SimpleButton��%2  '        '  %     '  a     '  �     �� "  .���  � ��$
 Left=��� "  .���  � ��$
 Left=���  � ��$	 150���� "  .���  � ��$
 Left=���  � ��$	 150���� "  .���  � ��$ Center=���  � ��$ Center=���  � ��$ 66����  � ��$ 25��.���  � RowDefinitions �� $��40 ��� $��* ��� $��50 �.+��� -   $%��>客户跟进日志信息页面��$��0��$
��10,0q�$��Stretch=�$��Stretch=�$��18(��� $��1��$��10q�$��Center=�
������� �� CornerRadius$ 5��
�����_�$��1q�._�� .+�0  *DevExpress.Xpf.LayoutControl.LayoutControl  $��Stretch=�.  (DevExpress.Xpf.LayoutControl.LayoutGroup	   Orientation$	 Vertical=�4  .DevExpress.Xpf.LayoutControl.LayoutControlBase
   	ItemSpace$
 10Q�$��	0,10,0,10q�.+�  $
 10Q�$
��Left=�.+�     Label$ 跟进时间：��   Content. %  DevExpress.Xpf.Editors.DateEdit  -   $��txtFollowTime��$	��150��%	  DevExpress.Xpf.Editors.BaseEdit 	  DisplayFormatString$ yyyy-MM-dd HH:mm:ss��)
  #DevExpress.Xpf.Editors.TextEditBase 
  Text �� *FollowUpTime+ 	  StyleSettings :  4DevExpress.Xpf.Editors.DateEditCalendarStyleSettings    $ 跟进人：��.   -   $��txtFUser�� �� *FollowUpUser+  .+�  $ 客户需求：��.   -   $��cboCustRequests��$	��380��+  %DevExpress.Xpf.Editors.LookUpEditBase   DisplayMember$ RequestContent��   ValueMember$ CustRequestId��   ItemsSource �� *CboCustRequests+ 	  	EditValue �� *CustRequestId+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�{��� *IsCboRequestEnable+  $
 20Q�$
��Left=�.+�  $ 跟进内容：��$
��Left=�.   -   $��txtFollowUpContent��$	��400��$	��100�� 
  TextWrapping$
 Wrap=�$	��Top=� �� *FollowUpContent+  .+�  $ 跟进状态��.   -   $��cboFUStates�� �� *CboFUStates+ �� *FollowUpState++  %DevExpress.Xpf.Core.UniformStackPanel  $��2��$��Center=�.+�  -   $��btnAdd������ *ConfirmBtnContent+y��� *IsConfirmBtnVisible+���� *
ConfirmCmd+   Glyph *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Apply_16x16.png   -	   $��btnClose��$��关闭��$
��20,0q����� *CloseWindowCmd+����  �� ElementName$ custFollowUpLogInfoWindow��   $ Cancel_16x16.png 