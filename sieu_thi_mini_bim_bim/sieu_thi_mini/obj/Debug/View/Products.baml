   M S B A M L   `   `   `  ����H  Dsieu_thi_mini, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:sieu_thi_mini.Utilitiessieu_thi_mini.Utilities  5      A%clr-namespace:sieu_thi_mini.ViewModelsieu_thi_mini.ViewModel  5      -clr-namespace:sieu_thi_minisieu_thi_mini  5      !    sieu_thi_mini.View.Products   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6Menu%clr-namespace:sieu_thi_mini.Utilities     5      4vm%clr-namespace:sieu_thi_mini.ViewModel     5      -localclr-namespace:sieu_thi_mini     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5
      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      -   5           
Page_Style#��[  5        � DataContext  5      '  !sieu_thi_mini.ViewModel.ProductVM  5   
   .��5      � .+�5   
   ��  �� CornerRadius$ 0, 20, 20, 0��6   �� 5   
   -   5         ��Name$ 	txtSearch��5      $��	Search...��6%   
���   �$��30��6I   $	��200��6U   $��480,23,190,517q�6a   6y   �� 5   
   -   5        $��Search��5        	allButton#��[ 6"   $
��Left=�6E   $	��Top=�6`   $��80��6x   $��35��6�   $��
684,25,0,0q�6�   6�   �� 5   
   $
��Auto=�6   $��Disabled=�6:   $��0,73,0,0q�6c   .��5      � .+�5      �� -   5        $��foodItemsControl��5      $
��Left=�67   $	��Top=�6R   $��
10 0 10 10q�6j   ��6~   �� *	FoodItems+��5      �� 5      .R�5      �  � Orientation$ 
Horizontal=�6(   $	��420��6A   5      5       ��5"      �� 5#      .R�5$      �� -   5        #��[ 5$   %   $	��125��6H   $	��110��6T   $��5q�6a   .��5%   "   �� .+�5&   &   �� $��65��6I   $��65��6T   ��6,   �� *	ImagePath+6T   �� 5'   &   $��Center=�6F   ��60   �� *Name+6F   �� 5(   &   ��60   �� *Price+ �� StringFormat$ Giá :{0:N0}đ��5)   #   5*      5+      5-      5.      5/      &   System.Windows.Controls.DataGrid  51   
   -   5        $��selectedItemsDataGrid��51         AutoGenerateColumns .  $
��Left=�6L   $	��Top=�6g   $��
480,75,0,0q�6   $	��355��6�   $	��300��6�      Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$
 Tên��6%      
IsReadOnly . 	   CanUserResize	 .  
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6f   �� *Name+  54      $
 Giá��6%    . 	 .  $
 85 6Z    6e   �� *Price+$ 	 {0:N0}đ��  55      $ Số lượng��6%    . 	 .  $
 86 6_    6j   �� *
Quantity+  56      $ Thành tiền��6%    . 	 .  $
 95 6a    6l   �� *
totalPrice+$ 	 {0:N0}đ��58      �� 5:   
   -   5         ��Name$ totalPriceTextBlock��5:   J      MaterialDesignBody2TextBlock#��[ 6   $
��Left=�6g   $	��Top=�6�   $��680,394,0,0q�6�   �� 5=   
   -   5         ��Name$ btLoad��5=      #��[ 6!   $��0,24,20,511q�6Y   $��50��6n   .��5>      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ 
RotateLeft=�6$   $��Center=�66   $��20��6Q   $��50��6\   $��8 1 8 0q�6h   5?      �� 5@   
   -	   5        $ btSave��5@      $��Lưu hóa đơn��6!   #��[ 67   $
��Left=�6Z   $	��Top=�6u   $	��150��6�   $��30��6�   $��680,430,0,0q�6�   6�   �� 5A   
   -
   5        $ btCancle��5A      $��Hủy hóa đơn��6$   #��[ 6:   $
��Left=�6]   $	��Top=�6x   $	��150��6�   $��30��6�   $��481,430,0,0q�6�   6�   5B      5C      