   M S B A M L   `   `   `  ����H  Dsieu_thi_mini, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:sieu_thi_mini.Utilitiessieu_thi_mini.Utilities  5      A%clr-namespace:sieu_thi_mini.ViewModelsieu_thi_mini.ViewModel  5      -clr-namespace:sieu_thi_minisieu_thi_mini  5      '    !sieu_thi_mini.View.ImportProducts   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6Menu%clr-namespace:sieu_thi_mini.Utilities     5      4vm%clr-namespace:sieu_thi_mini.ViewModel     5      -localclr-namespace:sieu_thi_mini     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5
      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      -   5           
Page_Style#��[  5        � DataContext  5      -  'sieu_thi_mini.ViewModel.ImportProductVM  5   
   .��5      � $��1��6   $��30 20 20 20q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   $��57��6*   �� 5      $
��auto �6   $��56��6*   .+�5   
   � $	��300��6   $
��Left=�6   $��	380,0,0,0q�66   .+�5      �� -   5         ��Name$ btAdd��5        	allButton#��[ 6$   $��-371,16,0,6q�6[   $	��150��6p   $
��Left=�6|   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5       .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Plus=�6,   $��Center=�68   $��11��6S   $��11��6^   $��0 1 8 0q�6j   �� 5!      $��Nhập hàng��6    5"      5#      �� 5%      -   5         ��Name$ 	txtSearch��5%      $��	Search...��6)   
���   �$��30��6M   6Y   �� 5&      -   5        $ btSearch��5&      #��[ 6'   $��
0,15,-70,6q�6a   $��50��6u   .��5'      �� $ 
Horizontal=�6   .+�5(        $ Magnify=�6,   $��Center=�6;   $��11��6V   $��11��6a   $��0 1 8 0q�6m   �� 5)      $
��Tìm��6    5*      5+      �� 5,      -   5        $ btLoad��5,      #��[ 6%   $��0,15,-130,6q�6]   $��50��6r   .��5-      �� $ 
Horizontal=�6   .+�5.        $ 
RotateLeft=�6,   $��Center=�6>   $��20��6Y   $��50��6d   $��8 1 8 0q�6p   5/      50      51      &   System.Windows.Controls.DataGrid  52   
   -   5          Name$ 	dgproduct��52   �     DataGridStyle1#���  6     DataGridCellStyle1   	CellStyle# �  6<     DataGridColumnHeaderStyle1   ColumnHeaderStyle# �  6m     DataGridRowStyle1	   RowStyle#	 �  6�   $��1��6�   $��Hidden=�6�   $��Hidden=�6/  $	��215��6c  $��	0,0,0,230q�6p  
   Columns
 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã sản phẩm��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6X   �� *ProductCode+  55      $ Tên sản phẩm��6%    . $	 120 6M    6Y   �� *ProductName+  56      $ Số lượng nhập��6%    . $	 120 6N    6Z   �� *ImportValue+  57      $ Giá nhập��6%    . $	 120 6I    6U   �� *ProductImportPrice+ �� StringFormat$ 	 {0:N0}đ��  58      $ Ngày nhập��6%    . $	 120 6J    6V   �� *DayImport.Date+$ 
dd/MM/yyyy��  59      $ Hạn sử dụng��6%    . $	 120 6L    6X   �� *Expiry.Date+$ 
dd/MM/yyyy��5;        5<   
   -   5        $ 	dgProduct��5<   �   #���  6   # �  6<   # �  6m   #	 �  6�   $��5��6�   $��Hidden=�6�   $��Hidden=�6/  $	��215��6c  $��	0,230,0,0q�6p  
 5=        5>      $ Mã sản phẩm��6%    . $	 150 6L    6X   �� *ProductCode+  5?      $ Tên sản phẩm��6%    . $	 150 6M    6Y   �� *ProductName+  5@      $ Số lượng tồn��6%    . $	 120 6M    6Y   �� *ProductValue+  5A      $ Phân loại��6%    . $	 150 6J    6V   �� *
Classify+  5B      $ 	Giá bán��6%    . $	 150 6H    6T   �� *ProductPrice+$ 	 {0:N0}đ��4  .System.Windows.Controls.DataGridTemplateColumn  5C       . $
 auto 6;      CellTemplate 5D      �� 5E      .R�5F      �� $ 
Horizontal=�6)   .+�5G   "   �� $ btPlus��6)   -   5          gridEditButton#��[ 5G   9   .��5H   &     $
 Plus=�6<     gridButtonIcon#��[ 6H   5I   #   �� 5J   "   $ btDelete��6)   -	   5          gridRemoveButton#��[ 5J   ;   $��5 0 0 0q�6e   .��5K   &     $ DeleteOutline=�6<   #��[ 6Q   5L   #   5M      5N      5P      5R      5n      5o      