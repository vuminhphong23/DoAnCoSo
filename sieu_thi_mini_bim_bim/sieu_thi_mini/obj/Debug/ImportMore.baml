   M S B A M L   `   `   `  ����H  Dsieu_thi_mini, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:sieu_thi_mini.Viewsieu_thi_mini.View  5   	       sieu_thi_mini.ImportMore   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:sieu_thi_mini.View     5   	   -   5        $	��341��5   	   $	��800��6     � WindowStartupLocation$  CenterScreen=�6"    � WindowStyle$
 None=�5	       � AllowsTransparency . 
������ .��5
      �� ���#f6f6f8 �� CornerRadius$ 20��6"   ._�5   
   � $��0,0,0,1q�6    � ColumnDefinitions 5      �� 5      .+�5      �� $��Mã sản phẩm��6   
���   �$��15(�6=   $
��Bold"�6K   $��30,30,661,275q�6]   �� 5      $��Tên sản phẩm��6   
���   �$��15(�6>   $
��Bold"�6L   $��30,100,659,203q�6^   �� 5      $��Số lượng nhập��6   
���   �$��15(�6?   $
��Bold"�6M   $��30,170,657,135q�6_   �� 5      $��Giá nhập��6   
���   �$��15(�6:   $
��Bold"�6H   $��30,240,682,65q�6Z   �� 5      $��	Giá bán��6   
���   �$��15(�69   $
��Bold"�6G   $��415,30,299,275q�6Y   �� 5      $��Ngày nhập��6   
���   �$��15(�6;   $
��Bold"�6I   $��415,100,300,205q�6[   �� 5      $��Hạn sử dụng��6   
���   �$��15(�6=   $
��Bold"�6K   $��415,170,284,135q�6]   �� 5      -   5         ��Name$ txtMaSanPham��5       �� TextWrapping$
 Wrap=�6,    �� 
IsReadOnly . $��164,25,420,275q�6R   �� 5      -   5        $ txtTenSanPham��5      $
 Wrap=�6-    . $��164,95,420,205q�6S   �� 5      -   5        $ 
txtSoLuong��5      $
 Wrap=�6*   $��164,165,420,135q�6?   �� 5      -   5        $ 
txtGiaNhap��5      $
 Wrap=�6*   $��164,235,420,65q�6?   �� 5      -   5        $ 	txtGiaBan��5      $
 Wrap=�6)   $��546,25,44,275q�6=   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 
dpNgayNhap��5      $��40��6-   {�.  $��546,95,44,0q�6K   $	��Top=�6`     5      -   5        $ dpHSD��5      $��42��6(   $��546,165,44,0q�66   $	��Top=�6L   �� 5      -	   5        	 ��Name$	 btCancel��5      $	��100��6'   $	��NaN��63      	allButton#��[  6@   $��Hủy��6c   $��0,275,255,30q�6q   6�   �� 5       -
   5        $	 btSave��5       $	��100��6%   $	��NaN��61   #��[  6?   $
��Lưu��6b   $��0,275,137,30q�6p   6�   �� 5!      -   5        $	 btExit��5!      $	��100��6%   $	��NaN��61   #��[  6?   $��Thoát��6b   $��0,275,25,30q�6r   6�   5"      5#      5$      