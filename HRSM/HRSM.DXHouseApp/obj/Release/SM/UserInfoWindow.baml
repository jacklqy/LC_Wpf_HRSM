   M S B A M L   `   `   `  ���� J  FHRSM.DXHouseApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:HRSM.DXHouseApp.ViewModelsHRSM.DXHouseApp.ViewModels  '    !HRSM.DXHouseApp.SM.UserInfoWindow   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  j fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  1vm(clr-namespace:HRSM.DXHouseApp.ViewModels  -   $��
ucUserInfo��  � Title$  用户信息页��$	��350��$	��500��&   DevExpress.Xpf.Core.ThemedWindow   ShowIcon .   � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanMinimize=� � 	Resources -  'DevExpress.Xpf.LayoutControl.LayoutItem �� 
TargetType �� Property �� Value.  (DevExpress.Xpf.LayoutControl.LayoutGroup4  .DevExpress.Xpf.LayoutControl.LayoutControlBase2  ,DevExpress.Xpf.LayoutControl.LayoutItemLabel,  &DevExpress.Xpf.Editors.PasswordBoxEdit%  DevExpress.Xpf.Editors.TextEdit&   DevExpress.Xpf.Core.SimpleButton   
listItemDT&	   DevExpress.Xpf.Editors.CheckEdit 	  	IsChecked	 	  Content  listPanelTemp
 � Orientation,
  &DevExpress.Xpf.Editors.ListBoxEditItem��%6  '        '  >     '  k     '  �     '  �     '  �     &	  C    &	 �    '
  �    �� "  .���   �@ LabelHorizontalAlignment$
 Left=��� "  .���  �@ 	ItemSpace$ 20Q��� "  .���  � ��$ 40���� "  .���  � ��$	 120���� "  .���  � ��$	 120���� "  .���  � ��$ Center=���  � ��$ Center=���  � ��$ 70����  � ��$ 25���� .R�	   �� *	IsCheck+	 �� *RoleInfo.RoleName+�� .R�� $
 
Horizontal=��� " 
 .���  � ��$	 0,2q���  � ��$ 25��.���  � RowDefinitions �� $��20 ��� $��* ��� $��50 �.+��� $��1��$��Stretch=�$��10q�
������� �� CornerRadius$ 5��
�����_�$��2q�._�� $��10q�
�������.+�0  *DevExpress.Xpf.LayoutControl.LayoutControl  $��Stretch=�$��Stretch=�   Orientation$ Vertical=�   	ItemSpace$ 20Q�.+�  .+�     Label$ 	账号：��   Content.   -   $��txtUserName��%  DevExpress.Xpf.Editors.BaseEdit   NullText$ 请输入用户名！��)  #DevExpress.Xpf.Editors.TextEditBase   Text �� *
UserName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   NullTextForeground �� *UNameFColor+.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ EditValueChanged��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *CheckInfoCmd+  $ 	密码：��.   -   $��
txtUserPwd��$ 请输入密码！��   Password �� *	UserPwd+$ TwoWay=�$ PropertyChanged=� �� *
UPwdFColor+   $ EditValueChanged��.    �� *CheckInfoCmd+  .+�  $ 	姓名：��.   -   $��txtFName�� �� *	UserFName+  $ 	电话：��.   -   $��txtPhone��   MaskType$
 None=�   Mask$ 1[345789](\d){9}�� �� *	UserPhone+$ TwoWay=�$ PropertyChanged=�  .+�  $ 	状态：��. +  %DevExpress.Xpf.Core.UniformStackPanel  .+�	� -   $��
rbtnNormal��$
��20,0q�$��正常�� d� 	IsChecked �� *
IsNormal+$ TwoWay=�$ PropertyChanged=�	� -   $��
rbtnFrozen��$
��20,0q�$��冻结�� �� *
IsFrozen+$ OneWay=�  .+�  $ 	角色：��. (  "DevExpress.Xpf.Editors.ListBoxEdit  $��25��   ItemTemplate# [     
ItemsPanel# [ $��0q�
������     ItemsSource  �� *
RoleList+  $��2��$��Center=�.+�  -   $��btnAdd������ *ConfirmBtnContent+{��� *IsConfirmBtnEnabled+���� *
ConfirmCmd+!   Glyph! *  $DevExpress.Xpf.Core.DXImageExtension  "   Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$" Apply_16x16.png   -	   $��	btnCancel��$��关闭��$
��20,0q����� *CloseWindowCmd+���� # �� ElementName$# 
ucUserInfo��!   $" Close_16x16.png 