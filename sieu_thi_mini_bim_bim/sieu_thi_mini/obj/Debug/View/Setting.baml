   M S B A M L   `   `   `  ����H  Dsieu_thi_mini, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:sieu_thi_mini.Utilitiessieu_thi_mini.Utilities  5      A%clr-namespace:sieu_thi_mini.ViewModelsieu_thi_mini.ViewModel  5      -clr-namespace:sieu_thi_minisieu_thi_mini  5           sieu_thi_mini.View.Setting   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6Menu%clr-namespace:sieu_thi_mini.Utilities     5      4vm%clr-namespace:sieu_thi_mini.ViewModel     5      -localclr-namespace:sieu_thi_mini     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5
      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5         
Page_Style#��[  5        � DataContext  5      '  !sieu_thi_mini.ViewModel.SettingVM  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $	��350 �6   6+   �� 5      $��50 �6   6*   �� 5      6   .+�5   
   � $��0��6   
������ .+�5      �� $��Thông tin cá nhân��6   $��20 0 0 0q�61   
���   �$��25(�6V   $��Center=�6d   6�   5      � 5   
   $��1��6   
������ .+�5       �� $��
Họ tên:��6   $
��Left=�6&   $��	45,62,0,0q�6A   $	��Top=�6T   $	��100��6l   $��26��6x   �� 5!      -   5         ��Name$ txtHoTen��5!      $��13(�5"      
������ $��Normal"�5$      $��
Montserrat)�5%       �� 
CaretBrush �#E285DE���#E285DE$��0,0,0,1q�5(      $
��Left=�5)      $��
134,62,0,0q�69    �� TextWrapping$
 Wrap=�6M   $	��Top=�6a   $	��266��6y   $��26��6�   (  "System.Windows.Controls.DatePicker  5*      -   5        $��txtNgaySinh��5*      $
��Left=�6,   $	��Top=�6G   $	��266��6_   ���#F0F0F0
���   ����#707070$��1q�5,   +      SelectedDateFormat$ Short=�5-      $��134,228,0,0q�60   $��25��6E   �� 5/      -   5          	allButton#��[ 5/      $��0,291,32,24q�68   $	��194��50      ���#623ed0��53      �� *LoginCommand+.��54      ��  �� Orientation$ 
Horizontal=�6   .+�55      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ ContentSave=�6,   $��Center=�6?   $��11��6Z   $��11��6e   $��0 1 8 0q�6q   �� 56      $
��Lưu��6    57      58      �� 59      $��Giới tính:
��6   $
��Left=�63   $��
45,142,0,0q�6N   $	��Top=�6b   $	��100��6z   $��26��6�   �� 5:      $��Ngày sinh:��6   $
��Left=�6)   $��
45,228,0,0q�6D   $	��Top=�6X   $	��100��6p   $��26��6|   �� 5;      $��Số điện thoại:��6   $
��Left=�6-   $��
477,62,0,0q�6H   $	��Top=�6\   $	��100��6t   $��26��6�    J� RenderTransformOrigin$ -0.03,-0.273&�6�   �� 5<      $��Địa chỉ:��6   $
��Left=�6'   $��477,142,0,0q�6B   $	��Top=�6W   $	��100��6o   $��26��6{   �� 5=      $��Email:��6   $
��Left=�6%   $��477,227,0,0q�6@   $	��Top=�6U   $	��100��6m   $��26��6y   �� 5>      -   5        $ txtGioiTinh��5>      $��13(�5?      
������ $��Normal"�5A      $��
Montserrat)�5B       �#E285DE���#E285DE$��0,0,0,1q�5E      $
��Left=�5F      $��134,142,0,0q�6,   $
 Wrap=�6A   $	��Top=�6U   $	��266��6m   $��26��6y   �� 5G      -   5        $ txtSoDienThoai��5G      $��13(�5H      
������ $��Normal"�5J      $��
Montserrat)�5K       �#E285DE���#E285DE$��0,0,0,1q�5N      $
��Left=�5O      $��
577,62,0,0q�6,   $
 Wrap=�6@   $	��Top=�6T   $	��261��6l   $��26��6x   �� 5P      -   5        $ 	txtDiaChi��5P      $��13(�5Q      
������ $��Normal"�5S      $��
Montserrat)�5T       �#E285DE���#E285DE$��0,0,0,1q�5W      $
��Left=�5X      $��577,142,0,0q�6,   $
 Wrap=�6A   $	��Top=�6U   $	��261��6m   $��26��6y   �� 5Y      -   5        $ txtEmail��5Y      $��13(�5Z      
������ $��Normal"�5\      $��
Montserrat)�5]       �#E285DE���#E285DE$��0,0,0,1q�5`      $
��Left=�5a      $��577,227,0,0q�6,   $
 Wrap=�6A   $	��Top=�6U   $	��261��6m   $��26��6y   5b      � 5d   
   $��2��6   
������ .+�5e      �� $��Thông tin tài khoản��6   $��20 0 0 0q�63   
���   �$��25(�6X   $��Center=�6f   6�   5f      � 5h   
   $��3��6   
������ .+�5i      �� $��Tên đăng nhập:��6   $
��Left=�6-   $��	41,30,0,0q�6H   $	��Top=�6[   $	��100��6s   $��26��6   $ 0.51,-0.488&�6�   �� 5j      -   5        $ txtTenDangNhap��5l      $��13(�5k      
������ $��Normal"�5n      $��
Montserrat)�5o       �#E285DE���#E285DE$��0,0,0,1q�5r      $
��Left=�5s      $��
146,34,0,0q�6-   $
 Wrap=�6A   $	��Top=�6U   $	��266��6m   $��26��6y   �� 5t      $��Mật khẩu:��6   $
��Left=�6(   $��	41,84,0,0q�6C   $	��Top=�6V   $	��100��6n   $��26��6z   $ 0.51,-0.488&�6�   �� 5u      -	   5        $ 
txtMatKhau��5w      $��13(�5v      
������ $��Normal"�5y      $��
Montserrat)�5z       �#E285DE���#E285DE$��0,0,0,1q�5}      $
��Left=�5~      $��
146,79,0,0q�6,   $
 Wrap=�6@   $	��Top=�6T   $	��266��6l   $��26��6x   �� 5      -
   5        #��[ 5      $	��194��5�      ���#623ed0$��
0,61,32,24q�5�   2   ��6   �� *LoginCommand+.��5�      �� $ 
Horizontal=�6   .+�5�        $ ContentSave=�6,   $��Center=�6?   $��11��6Z   $��11��6e   $��0 1 8 0q�6q   �� 5�      $��Xác nhận ��6    5�      5�      5�      5�      5�      