   M S B A M L   `   `   `  ���� J  FHRSM.DXHouseApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:HRSM.DXHouseApp.UtilsHRSM.DXHouseApp.Utils  +    %HRSM.DXHouseApp.Views.ListToolBarView   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  +c#clr-namespace:HRSM.DXHouseApp.Utils  -     >�Name$  ucBar�� � 	Resources ��%    .��� .+�(  "DevExpress.Xpf.Bars.ToolBarControl  -   $
��tbar��$��Stretch=�$��0��$��Stretch=�   IsCollapsed .  ,  &DevExpress.Xpf.Bars.ToolBarControlBase   Caption$ 	工具栏��   AllowQuickCustomization .     BarItemDisplayMode$ ContentAndGlyph=�   ShowBackground .    Items. '  !DevExpress.Xpf.Bars.BarButtonItem  -     Name$ toolFind��!  DevExpress.Xpf.Bars.BarItem	   Content)  #DevExpress.Xpf.Core.ObjectConverter$	 查询 
   
KeyGesture$
 Ctrl+Q��   Glyph *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ MarqueeZoom_16x16.png    	IsVisible �� *
ShowFind+   Command �� *FindCommand+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�  -   $ 
toolImport��$	 导入 $
 Ctrl+M��   $ ImportImage_16x16.png  �� *
ShowImport+ �� *ImportCommand+$ TwoWay=�$ PropertyChanged=�  -   $ toolPublish��$	 发布 $
 Ctrl+B��   $ Publish_16x16.png  �� *ShowPublish+ �� *PublishCommand+$ TwoWay=�$ PropertyChanged=�   CommandParameter ��  �� ElementName$ ucBar��  -   $ toolUnPublish��$	 取消发布 $
 Ctrl+U��   $ Reset_16x16.png  �� *ShowUnPublish+ �� *UnPublishCommand+$ TwoWay=�$ PropertyChanged=� �� $ ucBar��.  (DevExpress.Xpf.Bars.BarItemLinkSeparator    -    �Name$ toolAllFULog��$	 所有客户日志    $ ListBullets_16x16.png  �� *ShowAllCustFULog+ �� *CustAllFULogCommand+$ TwoWay=�$ PropertyChanged=�  -   $ toolCustFULog��$	 客户跟进日志 $
 Ctrl+F��   $ ListBullets_16x16.png  �� *ShowCustFULog+ �� *CustFULogCommand+$ TwoWay=�$ PropertyChanged=� �� $ ucBar��  -	   $ toolAllRequestList��$	 所有客户需求    $ ListBullets_16x16.png  �� *ShowAllRequestList+ �� *AllRequestListCommand+$ TwoWay=�$ PropertyChanged=�  -
   $ toolCustRequestList��$	 客户意向需求 $
 Ctrl+G��   $ ListBullets_16x16.png  �� *ShowCustRequestList+ �� *CustRequestListCommand+$ TwoWay=�$ PropertyChanged=� �� $ ucBar��    -   $ toolAdd��$	 新增 $
 Alt+N��   $ Add_16x16.png  �� *	ShowAdd+ �� *
AddCommand+$ TwoWay=�$ PropertyChanged=� �� $ ucBar��  -   $ toolEdit��$	 修改 $
 Ctrl+E��   $ Edit_16x16.png  �� *
ShowEdit+ �� *EditCommand+$ TwoWay=�$ PropertyChanged=� �� $ ucBar��    -   $ toolInfo��$	 查看 $
 Ctrl+X��   $ PageInfo_16x16.png  �� *
ShowInfo+ �� *InfoCommand+$ TwoWay=�$ PropertyChanged=� �� $ ucBar��    -   $ toolDel��$	 删除 $
 Ctrl+D��   $ Delete_16x16.png  �� *
ShowDelete+ �� *DeleteCommand+$ TwoWay=�$ PropertyChanged=� �� $ ucBar��  -   $ toolRecover��$	 恢复 $
 Ctrl+S��   $ Reset2_16x16.png  �� *ShowRecover+ �� *RecoverCommand+$ TwoWay=�$ PropertyChanged=� �� $ ucBar��  -   $ 
toolRemove��$	 移除 $
 Ctrl+R��   $ Remove_16x16.png  �� *
ShowRemove+ �� *RemoveCommand+$ TwoWay=�$ PropertyChanged=� �� $ ucBar��    -   $ 	toolRight��$	 权限分配 $
 Ctrl+P��   $ Role_16x16.png  �� *	ShowRight+ �� *RightCommand+$ TwoWay=�$ PropertyChanged=� �� $ ucBar��    -   $ 	toolClose��$	 关闭 $
 Ctrl+L��   $ Close_16x16.png  �� *	ShowClose+ �� *CloseCommand+$ TwoWay=�$ PropertyChanged=� �� $ ucBar��