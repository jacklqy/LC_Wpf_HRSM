   M S B A M L   `   `   `  ���� J  FHRSM.DXHouseApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HRSM.DXHouseAppHRSM.DXHouseApp  "    HRSM.DXHouseApp.MsgBoxWindow   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:HRSM.DXHouseApp       � Title$  	消息框��$	��206��$	��420�� � WindowStartupLocation$ CenterScreen=�$��1,0,1,1q� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � AllowsTransparency . 
������ .��� -   
������ .+��� ���	#FF3757E6$��2q� �� CornerRadius$ 10��$��5q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Color$ 	#FF7F59D3��	   ShadowDepth$	 3Q�
   Opacity$	
 0.8Q�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFFBFBFB�� � Offset$ 0.439Q�� $ 	#FFE1EDF1��$ 0.986Q�._�� -    �Name$
 grid��$��5q� � RowDefinitions �� $��30 ��� �� $��50 �.+�� $��0��
������ .+��� ���	#FFFAFAFA���	#FF3757E6$��0q�$ 5,5,0,0��._��� -   $��imgs/errbtn.jpg��$��Right=�$��0,3,3,2q��� $��1��$��Center=� �� Orientation$ 
Horizontal=�.+��� $��62��$��62��$��40,20,20,20q����� *	ImagePath+�� $��Center=�$
��Left=�$��WrapWithOverflow=�$	��280�� �� TextAlignment$
 Left=�$��12(����� *MessageBoxText+�� $��2��$ 
Horizontal=�$��Right=�.+��� -    ��Name$ OkButton��$��确 定��$��80��$��25��$��	10,0,15,0q� �� 	IsDefault . y��� *OkButtonVisibility+ �� Mode$ OneWay=��� -   $ 	YesButton��$	��是��$��80��$��25��$��	10,0,15,0q�y��� *YesButtonVisibility+$ OneWay=��� -   $ NoButton��$	��否��$��80��$��25��$��	10,0,15,0q�y��� *NoButtonVisibility+$ OneWay=��� -   $ CancelButton��$��取消��$��80��$��25��$��	10,0,15,0q�y��� *CancelButtonVisibility+