   M S B A M L   `   `   `  ����  HRSM.DXHouseApp"    HRSM.DXHouseApp.HS.HouseInfo   5      a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      j fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      -   5        $��ucHouseInfo��5
   "     � 	Resources  5      %  DevExpress.Xpf.Editors.TextEdit �� 
TargetType%  DevExpress.Xpf.Editors.BaseEdit �� Property �� Value2  ,DevExpress.Xpf.LayoutControl.LayoutItemLabel   labelItemStyle-  'DevExpress.Xpf.LayoutControl.LayoutItem.  (DevExpress.Xpf.LayoutControl.LayoutGroup4  .DevExpress.Xpf.LayoutControl.LayoutControlBase��%H  '        &	  �     '       7   '  �    �� 5   
   "  6   .�5      ��  �@ 
IsReadOnly . 6:   �� 5       � ��$	 200��6&   64   �� 5       � �� �	#FF2E46E26?   5      �� 5   
   "  6   .�5      ��  � ��$ Right=�64   6D   �� 5       � ��$ 60��6&   63   5      �� 5   
   "  6   .�5      ��  � ��$
 Left=�64   6C   �� 5       �@ 
LabelStyle8   6+   5      �� 5   
   "  6   .�5      ��  �@ 	ItemSpace$ 10Q�6*   67   �� 5       � ��$
 Left=�64   6C   5      5      .��5      �  � RowDefinitions 5    
   �� 5!      $��50 �6   �� 5"      $
��auto �6   �� 5#      $��50 �6   .+�5%   
   �� $��房屋信息详情��6   $��0��6!   $
��50,5q�6.   $
��Left=�6<   $��Bottom=�6W   $��18(�6r   $
��Bold"�6�   ���	#FFCB6D1F6�   �� 5&   
   $��1��6   $��10q�6   
�������
�����_�$��1q�6V    �� CornerRadius$ 5��6j   ._�5'      � .+�5(      0  *DevExpress.Xpf.LayoutControl.LayoutControl  $��Stretch=�6%   $��Stretch=�6C      Orientation$ Vertical=�6_      	ItemSpace$ 10Q�6v   $��10q�6�    � DataContext 6�   �� *HouseInfoModel+.+�5)        .+�5*        	   Label$	 	业主：��6*   
   Content.
 5+        -   5        $��txtOwner��5+   +   )  #DevExpress.Xpf.Editors.TextEditBase   Text 6;   �� *	OwnerName+5,      5-        5.      $	 房屋名称：��6*   .
 5/        -   5        $��txtHouseName��5/   +    6?   �� *	HouseName+50        51      $	 所在楼宇：��6*   .
 52        -   5        $��txtBuilding��52   +    6>   �� *
Building+53      55        56      .+�57        $	 房屋地址：��6*   .
 58        -   5        $��
txtAddress��58   +   $	��472��6=    6I   �� *HouseAddress+59        5:      $	 	电话：��6*   .
 5;        -   5        $��txtOwnerPhone��5;   +    6@   �� *
OwnerPhone+5<      5=      5?        5@      .+�5A        $	 租售类型：��6*   .
 5B        -   5        $��txtRentSale��5B   +    6>   �� *
RentSale+5C        5D      $	 	价格：��6*   .
 5E        -   5        $��txtPrice��5E   +    6;   �� *
HousePrice+5F        5G      $	 	单位：��6*   .
 5H        -	   5        $��txtUnit��5H   +    6:   �� *	PriceUnit+5I      5J      5L        5M      .+�5N        $	 	朝向：��6*   .
 5O        -
   5        $��txtDirection��5O   +    6?   �� *HouseDirection+5P      5Q        5R      $	 	户型：��6*   .
 5S        -   5        $��	txtLayout��5S   +    6<   �� *HouseLayout+5T      5U        5V      $	 	楼层：��6*   .
 5W        -   5        $��txtFloor��5W   +    6;   �� *
HouseFloor+5X      5Y        5Z      .+�5[        $	 	面积：��6*   .
 5\        -   5        $��txtAreas��5\   +      MaskType$ Numeric=�6;      Mask$ n2��6N    6X   �� *	HouseArea+5]        5^      $	 	状态：��6*   .
 5_        -   5        $��txtState��5_   +    6;   �� *
HouseState+5`      5a      5b        5c      .+�5d        $	 房屋图片：��6*   $
��Left=�68   .
 5e      &	   DevExpress.Xpf.Editors.ImageEdit	  -   5        $��imgPic��5e   ,   $	��150��6:   $	��100��6G    	  ShowMenu .   	  Source 6e   �� *
HousePic+5f        5g      $	 房屋描述：��6*   $
��Left=�68   .
 5h        -   5        $��	txtRemark��5h   ,   $	��400��6=      TextWrapping$
 Wrap=�6a   $	��Top=�6v   $	��100��6�    6I   �� *Remark+6�   5i      5j      5l      5m      5n      5o      5p      