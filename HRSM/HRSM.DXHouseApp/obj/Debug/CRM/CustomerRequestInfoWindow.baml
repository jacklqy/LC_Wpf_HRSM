   M S B A M L   `   `   `  ����  HRSM.DXHouseApp3    -HRSM.DXHouseApp.CRM.CustomerRequestInfoWindow   5      a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      a ]DevExpress.Xpf.Grid.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      j fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      -   5        $��custRequestInfoWindow��5	   |     � Title$  客户需求信息页面��6   $	��300��6   $	��600��6#    � WindowStyle$
 None=�6/    � WindowState$ Normal=�6B    � WindowStartupLocation$ CenterScreen=�6W    � 	Resources 5   
   -  'DevExpress.Xpf.LayoutControl.LayoutItem �� 
TargetType �� Property �� Value)  #DevExpress.Xpf.Editors.ComboBoxEdit%  DevExpress.Xpf.Editors.TextEdit&   DevExpress.Xpf.Core.SimpleButton��%%  '        '  O     '  �     '  A    �� 5      "  6   .�5      ��  � ��$
 Left=�6G   6V   5      �� 5      "  6   .�5      ��  � ��$
 Left=�6@   6O   �� 5       � ��$	 150��62   6@   5      �� 5      "  6   .�5      ��  � ��$
 Left=�6@   6O   �� 5       � ��$	 150��62   6@   5      �� 5      "  6   .�5      ��  � ��$ Center=�6@   �� 5       � ��$ Center=�6>   �� 5       � ��$ 66��62   �� 5       � ��$ 25��63   5      5      .��5   
   �  � RowDefinitions 5       �� 5!      -   5        $��30 �5!   (   64   �� 5"      $��* �6(   �� 5#      $��50 �6(   .+�5%      �� $��-->意向客户页面��6   $��0��6,   $
��10,0q�69   $
��Left=�6G   $��Bottom=�6b   $��18(�6}   �� 5&      $��1��6   $��10q�6&   $��Center=�62   
�������	 �� CornerRadius$	 5��6b   
�����_�$��1q�6�   ._�5'      � .+�5(   "   0  *DevExpress.Xpf.LayoutControl.LayoutControl  $��Stretch=�66   .  (DevExpress.Xpf.LayoutControl.LayoutGroup
   Orientation$
 Vertical=�6R   4  .DevExpress.Xpf.LayoutControl.LayoutControlBase   	ItemSpace$ 10Q�6i   $��	0,10,0,10q�6x   .+�5)   *     $ 20Q�6;   $
��Left=�6J   .+�5*   2        Label$ 客户名称：��6B      Content. 5+   :   +  %DevExpress.Xpf.Grid.LookUp.LookUpEdit  -   5        $��luCustomers��5+   J   *	  $DevExpress.Xpf.Editors.PopupBaseEdit 	  
PopupWidth$	 400Q�6]   $	��120��6n   +
  %DevExpress.Xpf.Editors.LookUpEditBase 
  DisplayMember$ CustomerName��6�    
  ValueMember$ 
CustomerId��6�    
  ItemsSource 6z   �� *LuCustomers+%  DevExpress.Xpf.Editors.BaseEdit   	EditValue 6�   �� *
CustomerId+   StyleSettings 5,   B   8  2DevExpress.Xpf.Grid.LookUp.LookUpEditStyleSettings  5-   J   5/   ;   50   3     51   2   $ 跟进人：��6B   . 52   :     -   5        $��txtFUser��52   G   )  #DevExpress.Xpf.Editors.TextEditBase   Text 6X   �� *FollowUpUser+53   3   54   +     56   *   $ 20Q�6;   $
��Left=�6J   .+�57   2     $ 客户需求：��6B   . 58   :     -   5        $��txtCustRequest��58   H   $	��400��6~   $	��100��6�      TextWrapping$
 Wrap=�6�   $	��Top=�6�    6^   �� *RequestContent+6�   59   3   5:   +   5;   #   5<      5=      +  %DevExpress.Xpf.Core.UniformStackPanel  5?      $��2��6(   $��Center=�66   .+�5@        -   5        $��btnAdd��5@   *   ��68   �� *ConfirmBtnContent+y�6^   �� *IsConfirmBtnVisible+��6�   �� *
ConfirmCmd+   Glyph 6�   *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Apply_16x16.png   5A      -   5        $��btnClose��5A   *   $��关闭��6:   $
��20,0q�6�   ��6H   �� *CloseWindowCmd+��6l   ��  �� ElementName$ custRequestInfoWindow�� 6�     $ Cancel_16x16.png 5B      5C      5D      