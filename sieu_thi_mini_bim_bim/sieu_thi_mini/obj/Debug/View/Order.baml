   M S B A M L   `   `   `  ����H  Dsieu_thi_mini, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:sieu_thi_mini.Utilitiessieu_thi_mini.Utilities  5      A%clr-namespace:sieu_thi_mini.ViewModelsieu_thi_mini.ViewModel  5	      -clr-namespace:sieu_thi_minisieu_thi_mini  5
          sieu_thi_mini.View.Order   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6Menu%clr-namespace:sieu_thi_mini.Utilities     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      0vm%clr-namespace:sieu_thi_mini.ViewModel   5	      )localclr-namespace:sieu_thi_mini   5
      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      -   5           
Page_Style#��[  5        � DataContext  5      %  sieu_thi_mini.ViewModel.OrderVM  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $
��499* �6   .+�5   
   � $��0��6   $��	10,10,0,0q�6    � ColumnDefinitions 5      �� 5      $	��120 �6#   �� 5      $��20 �6#   �� 5      $	��120 �6#   �� 5      �� 5       $	��268 �6#   �� 5!      $	��221 �6#   .+�5$      �� -   5         ��Name$ btnPay��5$      $��2��6%   $y�Hidden=�65     	allButton#��[ 5%      $��Đã thanh toán��5&      $��12(�5'      $��
Montserrat)�5(       � Cursor$
 Hand��5)      $��0q�5*      
�������$	��Top=�5,      $��30��5-   )   $	��100��66   $��Center=�6B   $��0,5,0,0q�6_   $��Medium"�6p   �� 5.       �� Orientation$ 
Horizontal=�6   $	��Top=�5/      $��4��50      $��29��6)   .+�51      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�6*   $��0 8 0 0q�69   $��20��6J   $��20��6V   ���#6741d96a   �� 53      -   5         ��Name$ 	txtSearch��53      $��Tìm kiếm . . . ��6-   $��13(�54      $��24��55      $	��300��56      
������ $��Medium"�58      $��
Montserrat)�59      ���#6741d9 �� 
CaretBrush �#6741d9���#6741d9$��0,0,0,1q�5=      $��Center=�5>      $��5,5,0,0q�5?      6/   5@      �� 5A      -   5        $ btSearch��5A   %   $��5��6   #��[ 5B      $��Tìm kiếm��5C      $��12(�5D      $��
Montserrat)�5E      $
 Hand��5F      $��0q�5G      
�������$��Center=�5I      $��40,0,0,0q�5J   ,   $��30��6>   $��72��6J   $
��Left=�6U   $��Medium"�6p   5L      �� 5M      -   5        $ btload��5M      $��5��6%   #��[ 5N      $��12(�5O      $��
Montserrat)�5P      $
 Hand��5Q      $��0q�5R      
�������$��Medium"�5T      $	��Top=�5U      $��30��6B   $��0,5,16,0q�6N   $��31��6`   5V        5W      $ Reload=�6&   
�������$��	0 10 21 0q�6H   $��20��6[   $��20��6f   $	��Top=�6r   $��Right=�6�   $��5��6�   $
��Bold"�6�   5X      �� 5Y   
   $��1��6   
������ 	 �� CornerRadius$	 10��5[      
 �� Padding$
 10q�5\      $��2��6   ._�5]      &   System.Windows.Controls.DataGrid  -   5          Name$ dgOrder��5_        DataGridStyle1#���  5^        DataGridCellStyle1   	CellStyle# �  6:     DataGridColumnHeaderStyle1   ColumnHeaderStyle# �  6k     DataGridRowStyle1   RowStyle# �  6�      AutoGenerateColumns .     RowHeaderWidth$ 0Q�5_   >      GridLinesVisibility$
 None=�6Q   $��Hidden=�6l      CanUserAddRows .  $��0q�5a      ��5`      �� *
products+   Columns 5c      4  .System.Windows.Controls.DataGridTemplateColumn  5d      ,  &System.Windows.Controls.DataGridColumn   CanUserResize .     Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6C      HeaderTemplate 5e      �� 5f      .R�5g   "   ��  ��Name$ chkSelectAll��6S   -   5          CheckBoxStyle1#��[ 5g   +    d� 	IsChecked 6i   �� *IsAllSelected+6�   5h         CellTemplate 5j      �� 5k      .R�5l   "   �� -   5        #��[ 5l   e    6�   �� *
IsSelected+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5m      5o      0  *System.Windows.Controls.DataGridTextColumn  5p         Header$ Mã Hóa Đơn��6)      
IsReadOnly .  .  $	 120 6e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6q   �� *	OrderCode+  5q      $ Mã Nhân Viên��6)    .  .  $	 120 6g    6s   �� *EmployeeCode+  5r      $ Ngày��6)    .  .  $	 120 6`    6l   �� *OrderDate.Date+ �� StringFormat$ 
dd/MM/yyyy��  5s      $ Giờ��6)    .  .  $	 100 6_    6k   �� *	OrderTime+  5t      $ Tổng Tiền��6)    .  .  $	 100 6d    6p   �� *
TotalMoney+$ 	 {0:N0}đ��  5v      $ Trạng thái��6)    .  .  $	 130 6e    6q   �� *OrderStatus+  5w      $  ��6-    . $ 90 6I    5x      �� 5y      .R�5z   "   �� $ 
Horizontal=�6-   .+�5{   &   �� -	   5          gridEditButton#��[ 5{   -   .��5|   *   .	  (MahApps.Metro.IconPacks.PackIconMaterial	    	  Kind$  PencilOutline=�6@     gridButtonIcon#��[ 6U   5}   '   �� 5~   &   -
   5        $��10 0 0 0q�5~   -    	 gridRemoveButton#��[	 6?   .��5   *   	  $  DeleteOutline=�6@   #��[ 6U   5�   '   5�   #   5�      5�      5�      5�      5�      5�      