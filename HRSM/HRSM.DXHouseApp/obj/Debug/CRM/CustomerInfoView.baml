   M S B A M L   `   `   `  ����  HRSM.DXHouseApp*    $HRSM.DXHouseApp.CRM.CustomerInfoView   5      a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      j fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      -   5        $��ucCustomerInfo��5
   8     � 	Resources  5   
   -  'DevExpress.Xpf.LayoutControl.LayoutItem �� 
TargetType �� Property �� Value)  #DevExpress.Xpf.Editors.ComboBoxEdit%  DevExpress.Xpf.Editors.TextEdit)  #DevExpress.Xpf.Editors.TextEditBase&   DevExpress.Xpf.Core.SimpleButton   TextEditErrorTemplate  teditCT �� 
TargetType��%�  '        '  O     '  �     '  z    &	  6    &	 ^    �� 5      "  6   .�5      ��  � ��$
 Left=�6G   6V   5      �� 5      "  6   .�5      ��  � ��$
 Left=�6@   6O   �� 5       � ��$	 150��62   6@   5      �� 5      "  6   .�5      ��  � ��$
 Left=�6@   6O   �� 5       � ��$	 150��62   6@   �� 5       �@ NullTextForeground
 �  ��6?   5      �� 5      "  6   .�5      ��  � ��$ Center=�6@   �� 5       � ��$ Center=�6>   �� 5       � ��$ 66��62   �� 5       � ��$ 25��63   5      �� 5       .R�5!      �� 5"      �� 5$      "  62   .R�5%      �� #��z��6!   #��z��6K   #��z��6w   5'      5(      5)      .��5*   
   �  � RowDefinitions 5+      �� 5,      $��40 �6(   �� 5-      $��* �6(   �� 5.      $��50 �6(   .+�50      �� $��-->客户信息页面��6   $��0��6,   $
��10,0q�69   $
��Left=�6G   $��Center=�6b   $��16(�6}   $��微软雅黑)�6�   �� 51      $��1��6   $
��Left=�6&   
������� �� CornerRadius$ 5��6T   
�����_�$��1q�6}   ._�52      � .+�53   "   0  *DevExpress.Xpf.LayoutControl.LayoutControl  $��Stretch=�66   .  (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�6R   4  .DevExpress.Xpf.LayoutControl.LayoutControlBase   	ItemSpace$ 10Q�6i   $��	0,10,0,10q�6x   .+�54   *     $ 20Q�6;   $
��Left=�6J   .+�55   2     	   Label$	 客户名称：��6B   
   Content.
 56   :     -   5        $��txtCustomerName��56   G   %	  DevExpress.Xpf.Editors.BaseEdit 	  NullText$! 客户名称不能为空！��6|      Text 6^   �� *CustomerName+57   ;   58   3     59   2   $	 联系人：��6B   .
 5:   :     -   5        $��txtContactor��5:   G    5;   B   �� 5<   J    �� Path$ CustInfo.Contactor�6R    �� UpdateSourceTrigger$ PropertyChanged=�6m    �� ValidatesOnDataErrors . 6�   5@   ;   5A   3     5B   2   $	 客户电话：��6B   .
 5C   :     -   5        $��txtPhone��5C   G   $ 请输入客户电话！��6    6W   �� *CustInfo.CustomerPhone+6   5D   3     5E   2   $	 客户类别：��6B   .
 5F   :   +
  %DevExpress.Xpf.Core.UniformStackPanel
   
  Orientation$ 
Horizontal=�6O   $��Center=�6h   .+�5G   B   	� -   5        $��rbtnPersonal��5G   N   $��个人��6b   $
��10,0q�6�    d� 	IsChecked 6o   �� *
IsPersonal+6�   	� 5H   B   -   5        $��rbtnUnit��5H   N   $��单位��6^   $
��10,0q�6l    6z   �� *IsUnit+6�   5I   ;   5J   3   5K   +     5L   *   $ 20Q�6;   $
��Left=�6J   .+�5M   2     $	 客户地址：��6B   $
��Left=�6P   .
 5N   :     -   5        $��
txtAddress��5N   G   $	��375��6Y    6e   �� *CustInfo.CustomerAddress+5O   3     5P   2   $	 客户状态：��6B   $
��Left=�6P   .
 5Q   :     -   5        $��cboCustStates��5Q   K   +  %DevExpress.Xpf.Editors.LookUpEditBase   ItemsSource 6`   �� *CboCustStates+ 6�   �� *CustInfo.CustomerState+5R   3     5S   2   $	 创建时间：��6B   $
��Left=�6P   .
 5T   :     -	   5        $��txtCreateTime��5T   G    	  
IsReadOnly .    MaskType$ DateTime=�6�      Mask$ G��6�    6n   �� *CustInfo.CreateTime+6�   5U   3   5V   +     5W   *   $ 20Q�6;   $
��Left=�6J   .+�5X   2     $	 客户描述：��6B   $
��Left=�6P   .
 5Y   :     -
   5        $��	txtRemark��5Y   H   $	��800��6z   $	��200��6�      TextWrapping$
 Wrap=�6�   $	��Top=�6�    6Y   �� *CustInfo.Remark+6�   5Z   3   5[   +   5\   #   5]      5^      
  5`      $��2��6(   $��Center=�66   .+�5a        -   5        $��btnAdd��5a   *   ��68   �� *ConfirmBtnContent+y�6^   �� *IsConfirmBtnVisible+��6�   �� *
ConfirmCmd+   Glyph 6�   *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Apply_16x16.png   5b      -   5        $��btnClose��5b   *   $��关闭��6:   $
��20,0q�6�   ��6G   �� *CloseTabPage+��6h   ��  �� ElementName$ ucCustomerInfo�� 6�     $ Cancel_16x16.png 5c      5d      5e      