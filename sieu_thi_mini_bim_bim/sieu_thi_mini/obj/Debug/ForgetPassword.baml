   M S B A M L   `   `   `  ����H  Dsieu_thi_mini, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:sieu_thi_minisieu_thi_mini  5   	   "    sieu_thi_mini.ForgetPassword   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   )localclr-namespace:sieu_thi_mini   5   	   -   5          � WindowStyle$
  None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   ���#3aa9ad � Title$ AddEmployees��5   	   $	��240��6   $	��500��6+    � 	Resources 5         TextBoxStyle �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 �� CornerRadius J� SnapsToDevicePixels ��Name ��Name
 � Tag �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName��%  &	        �� 5   
   " ��6%   .�5      ��  � ��
 �����6+   �� 5       � ��
 ��  �6,   �� 5       � ��$ 2q�60   �� 5       � ��$	 6 3q�6(   �� 5       � ��$ 
Montserrat)�6+   �� 5       �@�Cursor$ IBeam��6'   �� 5       � ��
 �� ��6+   �� 5       � ��$
 Left=�64   �� 5       � ��$	 Top=�62   �� 5       �@J�	AllowDrop . 6*   �� 5       �@��TextWrapping$
 Wrap=�6-   �� 5       � ��$	 200��6&   �� 5       � ��$ 40��6'   �� 5       � ��$
 Left=�6;   �� 5        � ��$ Center=�69   �� 5!       � �� 5"      �� 5#      " ��6&   .R�5$      �� $	 	txtBorder��6!   $
 5��5%      #��z��5&      #��z��5'      #��z��5(       . ._�5*      � #��z��6#   .+�5+   "   �� $ PART_ContentHost��6A   |�.  $��Hidden=�5,   '   $��Hidden=�5-   '   �� 5.   "   $ WaterMarkerLabel��6(   #��z 5/   (   #��z��50   (   #��z��51   (   #��z��52   (   $y�	Collapsed=�53      #��z��54   (   #��z��55   (   56      57       58      ]� 59       5:   "   �� 5;   &    � ��$  ��6@   ./�5=   "   �� $ WaterMarkerLabel��5>   !    � y�$ Visible=�5?   !   5@      5B      5D      5E      5F      .��5G      �� ���#623ed0$��2q�5H      
����  �._�5J   
   � .+�5K      �� $��Lấy Lại Mật Khẩu��6   $
��Bold"�5L      
�������$��18(�5N      $��
Montserrat)�5O      $��	20,25,0,0q�60   $	��Top=�5P      $
��Left=�60   �� 5Q      $��Nhập Email của bạn:��6   
�������$��16(�5S      $��
Montserrat)�5T      $��	20,90,0,0q�60   $	��Top=�5U      $
��Left=�60   �� 5V      -   5         ��Name$ txtEmail��5V      $��
190,80,0,0q�6(   #���   6<   $ Email��6c   �� 5Y      -   5         ��Name$ btnSend��5\        	allButton#��[ 5Y      $��0,186,263,15q�68   ���	#FF352084$	��200��5[      .��5^      ��  �� Orientation$ 
Horizontal=�6   .+�5_      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ EmailFastOutline=�6,   $��Center=�6D   $��22��6_   $��11��6j   $��0 1 8 0q�6v   �� 5`      $��Lấy lại mật khẩu��6    5a      5b      �� 5c      -   5        $ btnClose��5g      #��[ 5c      $��0,186,34,15q�68   ���	#FFBA1515$	��200��5e      .��5i      �� $ 
Horizontal=�6   .+�5j        $ WindowClose=�6,   $��Center=�6?   $��11��6Z   $��11��6e   $��0 1 8 0q�6q   �� 5k      $��Đóng��6    5l      5m      �� 5n      $��Mật khẩu của bạn:��6   
�������$��16(�5p      $��
Montserrat)�5q      $��
20,143,0,0q�6   $	��Top=�5r      $
��Left=�6)   �� 5s      -   5         ��Name$ txbPw��5s      
���  ��$��14(�68   $	��Top=�6F   $
��Left=�6^   $��190,144,0,0q�6y   6�   5t      5u      5v      