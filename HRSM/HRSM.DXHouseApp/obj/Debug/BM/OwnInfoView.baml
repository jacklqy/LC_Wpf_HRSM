   M S B A M L   `   `   `  ����  HRSM.DXHouseApp$    HRSM.DXHouseApp.BM.OwnInfoView   5      a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      j fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      -   5        $��ucOwnerInfo��5
   7     � 	Resources  5   
   -  'DevExpress.Xpf.LayoutControl.LayoutItem �� 
TargetType �� Property �� Value)  #DevExpress.Xpf.Editors.ComboBoxEdit%  DevExpress.Xpf.Editors.TextEdit&   DevExpress.Xpf.Core.SimpleButton��%%  '        '  O     '  �     '  A    �� 5      "  6   .�5      ��  � ��$
 Left=�6G   6V   5      �� 5      "  6   .�5      ��  � ��$
 Left=�6@   6O   �� 5       � ��$	 150��62   6@   5      �� 5      "  6   .�5      ��  � ��$
 Left=�6@   6O   �� 5       � ��$	 150��62   6@   5      �� 5      "  6   .�5      ��  � ��$ Center=�6@   �� 5       � ��$ Center=�6>   �� 5       � ��$ 66��62   �� 5       � ��$ 25��63   5      5      .��5    
   �  � RowDefinitions 5!      �� 5"      $��30 �6(   �� 5#      $��* �6(   �� 5$      $��50 �6(   .+�5&      �� $��--业主信息页面��6   $��0��6+   $
��10,0q�68   $
��Left=�6F   $��Bottom=�6a   $��16(�6|   $��黑体)�6�   
�������6�   �� 5'      $��1��6   $��10q�6&   
������� �� CornerRadius$ 5��6F   
�����_�$��1q�6o   ._�5(      � .+�5)   "   0  *DevExpress.Xpf.LayoutControl.LayoutControl  $��Stretch=�66   .  (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�6R   4  .DevExpress.Xpf.LayoutControl.LayoutControlBase   	ItemSpace$ 10Q�6i   $��	0,20,0,10q�6x   $
��Left=�6�   .+�5*   *     $ 20Q�6;   $
��Left=�6J   .+�5+   2        Label$ 业主名称：��6B   	   Content.	 5,   :     -   5        $��txtOwnerName��5,   G   )  #DevExpress.Xpf.Editors.TextEditBase
   Text
 6[   �� *	OwnerName+5-   3     5.   2   $ 业主类型：��6B   .	 5/   :     -   5        $��cboOwnTypes��5/   K   '	  !DevExpress.Xpf.Editors.ButtonEdit 	  IsTextEditable$ FalseX�6^   +
  %DevExpress.Xpf.Editors.LookUpEditBase 
  ItemsSource 6u   �� *CboOwnerTypes+
 6�   �� *	OwnerType+50   ;   51   3     52   2   $ 联系人：��6B   .	 53   :     -   5        $��txtContactor��53   G   
 6[   �� *	Contactor+54   3   55   +     56   *   $ 20Q�6;   $
��Left=�6J   .+�57   2     $ 业主电话：��6B   .	 58   :     -   5        $��txtPhone��58   G   
 6W   �� *
OwnerPhone+59   3     5:   2   $ 业主地址：��6B   $
��Left=�6P   .	 5;   :     -   5        $��
txtAddress��5;   G   $	��370��6Y   
 6e   �� *OwnerAddress+5<   3   5=   +     5?   *   $ 20Q�6;   $
��Left=�6J   .+�5@   2     $ 业主描述：��6B   $
��Left=�6P   .	 5A   :     -   5        $��	txtRemark��5A   G      TextWrapping$
 Wrap=�6X   $	��Top=�6l   $	��600��6�   $	��280��6�   
 6�   �� *Remark+6�   5B   3   5C   +   5D   #   5E      5F      +  %DevExpress.Xpf.Core.UniformStackPanel  5H      $��2��6(   $��Center=�66   .+�5I        -   5        $��btnAdd��5I   *   ��69   �� *ConfirmBtnContent+{�6_   �� *IsConfirmBtnEnabled+y�6�   �� *IsConfirmBtnVisible+��6�   �� *
ConfirmCmd+   Glyph 6�   *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Apply_16x16.png   5J      -	   5        $��btnClose��5J   *   $��关闭��6:   $
��20,0q�6�   ��6G   �� *CloseTabPage+��6h   ��  �� ElementName$ ucOwnerInfo�� 6�     $ Cancel_16x16.png 5K      5L      5M      