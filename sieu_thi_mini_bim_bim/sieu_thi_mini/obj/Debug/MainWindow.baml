   M S B A M L   `   `   `  ����H  Dsieu_thi_mini, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:sieu_thi_mini.Utilitiessieu_thi_mini.Utilities  5   	   A%clr-namespace:sieu_thi_mini.ViewModelsieu_thi_mini.ViewModel  5	   	   -clr-namespace:sieu_thi_minisieu_thi_mini  5
   	       sieu_thi_mini.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6Menu%clr-namespace:sieu_thi_mini.Utilities     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   0vm%clr-namespace:sieu_thi_mini.ViewModel   5	   	   )localclr-namespace:sieu_thi_mini   5
   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   -   5          � Title$  
MainWindow��5   	   $	��650��6   $
��1100��6)    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � DataContext 5      *  $sieu_thi_mini.ViewModel.NavigationVM  5   
   .��5      �� ���#eff2f7 �� CornerRadius$ 30��6"   ._�5   
   � .+�5      �  � ColumnDefinitions 5      �� 5      $	��200 �6'   �� 5      $��* �6'   .+�5#      �  � RowDefinitions 5$      �� 5%      $
��auto �6(   �� 5&      $��* �6(   .+�5(      ��  �� Orientation$ 
Horizontal=�6!   $	��Top=�6:   $
��Left=�6R   $��
20 20 0 40q�6m   .+�5)      A� $��12��6"   $��12��6-   ���#eb170069   A� 5*      $��12��6"   $��12��6-   ���#ffaf01$
��10 0q�6H   A� 5+      $��12��6"   $��12��6-   ���#009d0069   5,      �� 50      $��1��6   ���#623ed0$ 	0,50,0,30��6?   ._�51      ]� .+�52      �� $��80��6%   $��80��60   
�������$	 100��6P   $	��Top=�53      $
��Left=�62   $�� 20 -30 0 0q�6M   ._�54   "   A� ��55   &   �� 56   *   	 �� ImageSource$	 ./Images/logo2.png��65   58   #   59      �� 5;      $��Quản Lý Siêu Thị��6(   
�������$��22(�6S   $��SemiBold"�6a   $	��Top=�5<       
 �� TextAlignment$
 Center=�65   $��	5 25 0 10q�6L   �� 5>      $��Bim Bim Mart��6(   ���#d0bfff$��14(�6Q   $��SemiBold"�6_   $	��Top=�5?       $
 Center=�65   �� 5A      $��25 15q�6(   $	��Top=�67   $	��0.8��6L   ���#7e5fdc6Y   �� 5D      $	��Top=�6)   .+�5E   "   ��    
menuButton#��[  6)   ��5F   %   �� *HomeCommand+.��5G   &   �� $ 
Horizontal=�61   .+�5H   *   .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ HomeVariant=�6@     menuButtonIcon#��[ 6S   �� 5I   *   $��Trang chủ��64   5J   '   5K   #   �� 5M   "   #��[  6)   ��5N   %   �� *EmployeeCommand+.��5O   &   �� $ 
Horizontal=�61   .+�5P   *     $ AccountMultipleOutline=�6@   #��[ 6^   �� 5Q   *   $��Nhân viên��64   5R   '   5S   #   �� 5U   "   #��[  6)   ��5V   %   �� *ProductsCommand+.��5W   &   �� $ 
Horizontal=�61   .+�5X   *     $
 Sack=�6@   #��[ 6L   �� 5Y   *   $��Sản phẩm��64   5Z   '   5[   #   �� 5]   "   #��[  6)   ��5^   %   �� *OrdersCommand+.��5_   &   �� $ 
Horizontal=�61   .+�5`   *     $ OrderBoolAscendingVariant=�6@   #��[ 6a   �� 5a   *   $��Đơn hàng��64   5b   '   5c   #   �� 5d   "   #��[  6)   ��5e   %   �� *ImportProductCommand+.��5f   &   �� $ 
Horizontal=�61   .+�5g   *     $ 
FileImport=�6@   #��[ 6R   �� 5h   *   $��Nhập hàng��64   5i   '   5j   #   �� 5k   "   #��[  6)   ��5l   %   �� *StatisticalCommand+.��5m   &   �� $ 
Horizontal=�61   .+�5n   *     $ Finance=�6@   #��[ 6O   �� 5o   *   $��Thống kê��64   5p   '   5q   #   5z      �� 5{      -   5         ��Name$ btlogout��5{   %   #��[  67   $��Bottom=�6[   $��Bottom=�6v   $��
15 0 15 20q�6�   .��5|   "   �� $ 
Horizontal=�6-   .+�5}   &     $ Logout=�6<   #��[ 6J   �� 5~   &   $��Đăng xuất��60   5   #   5�      5�      5�      5�      � 5�      $��1��6   $��30 20 20 20q�6'    5�      �� 5�      $
��auto �6(   �� 5�      $��* �6(   .+�5�      �� $��0��6     	topButton#��[ 6*   $��0,7,20,7q�6M   ���#dcdcdc.��5�        $ Account=�60   $��12��6?   $��22��6J   5�      �� 5�      $ 
Horizontal=�6!   $��Center=�5�      .+�5�        $��25��5�   #   $��25��6/   ���	#FF623ED0$��0,0,10,0q�5�   #    5�   0   �� *Icon+5�   #   �� 5�      ���	#FF623ED0$��20(�5�       $��
Montserrat)�5�       $��Medium"�5�       $��0 2 0 0q�5�       $��Center=�5�       $	��Top=�5�       ��5�   $   �� *	Caption+5�       5�      �� 5�      -   5         ��Name$ Pages��5�   %   $��1��5�   A   ��6!   �� *CurrentView+6A   �� 5�      -   5         ��Name$ txtMaNV��5�       �� 
IsReadOnly . $��0q�6A   $��NV001��6U   $��Right=�6b   $��0,8,55,0q�6~    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $��40��6�   $��11(�6�   $��20��6�   5�      5�      5�      5�      5�      