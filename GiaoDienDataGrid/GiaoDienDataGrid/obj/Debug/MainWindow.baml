   M S B A M L   `   `   `  ����  GiaoDienDataGrid!    GiaoDienDataGrid.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   g cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   $	��720��5   	   $
��1080��6     � WindowStartupLocation$  CenterScreen=�6#    � WindowStyle$
 None=�6H    � AllowsTransparency . 
������  � 	Resources 5         	BoolToVis��%   &	        �� 5   
   6'   5	      .��5
      �� -   5        ���#eff2f7 �� CornerRadius$ 30��5
   "   ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5      �  � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $��* �6$   .+�5      �� $
��Left=�6   $��
20 28 0 35q�64   .��5      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Menu=�6,   $��15��68   $��15��6C   5      �� 5      $��1��6   ���#623ed0$ 	0,50,0,30��6;   ._�5      ]� .+�5      �� $��80��6!   $��80��6,    �� Padding$ 3q�68   
�������$	 100��6W   $	��Top=�5       $
��Left=�62   $�� 20 -30 0 0q�6M   ._�5!      A� ��5"   "   �� 5#   &   	 �� ImageSource$	 /Hinhanh/anh3x4.jpg��61   5%      5&      �� 5(      $��Quản Lý Siêu Thị��6$   
�������$��22(�6O   $��SemiBold"�6]   $	��Top=�5)       
 �� TextAlignment$
 Center=�65   $��	5 25 0 10q�6L   �� 5+      $��Members, France��6$   ���#d0bfff$��14(�6P   $��SemiBold"�6^   $	��Top=�5,       $
 Center=�65   �� 5.      $��25q�6$   $	��Top=�60   $	��0.8��6E   ���#7e5fdc6R   �� 50      $	��Top=�6%   .+�51      ��   
menuButton#��[ 6%   .��52   "   ��  �� Orientation$ 
Horizontal=�6-   .+�53   &     $ HomeVariant=�6<     menuButtonIcon#��[ 6O   �� 54   &   $��Trang chủ��60   55   #   56      �� 58      #��[ 6%   .��59   "   �� $ 
Horizontal=�6-   .+�5:   &     $ CalendarClock=�6<   #��[ 6Q   �� 5;   &   $��Events��60   5<   #   5=      �� 5?      #��[ 6%   ���#7b5cd6
�������.��5@   "   �� $ 
Horizontal=�6-   .+�5A   &     $ AccountMultipleOutline=�6<   #��[ 6Z   �� 5B   &   $��
Sinh viên��60   5C   #   5D      �� 5F      #��[ 6%   .��5G   "   �� $ 
Horizontal=�6-   .+�5H   &     $ CashMultiple=�6<   #��[ 6P   �� 5I   &   $��Wallet��60   5J   #   5K      �� 5L      #��[ 6%   .��5M   "   �� $ 
Horizontal=�6-   .+�5N   &     $ ForumOutline=�6<   #��[ 6P   �� 5O   &   $��Messages��60   5P   #   5Q      5T      �� 5U      #��[ 6!   $��Bottom=�6E   $��Bottom=�6`   $��
15 0 15 20q�6x   .��5V      �� $ 
Horizontal=�6)   .+�5W   "     $ Logout=�68   #��[ 6F   �� 5X   "   $��Logout��6,   5Y      5Z      5[      5\      5]      � 5_      $��1��6   $��30 20 20 20q�6#    5`      �� 5a      $
��auto �6$   �� 5b      $
��auto �6$   �� 5c      $
��auto �6$   �� 5d      $
��auto �6$   �� 5e      $
��auto �6$   �� 5f      $��* �6$   �� 5g      $
��auto �6$   .+�5j      � $	��300��6   $
��Left=�6#   .+�5k      �� $
��20 0q�6    $��Center=�6.   ���#b0b9c6 J� IsHitTestVisible .   K� ZIndex$ 1��5l       $��
Search ...��61   y�5m       ��  �� ElementName$ 	txtSearch�� �� 	Converter# [  �� 5o      -   5         ��Name$ 	txtSearch��5o        textboxSearch#��[ 61     5p      $ Magnify=�6,   $��15��6;   $��15��6F   $��Center=�6R   $��0 0 15 0q�6m   ���#b0b9c6$��Right=�5q   A   5r      �� 5t        	topButton#��[ 6   $��0 0 20 0q�6<   ���#dcdcdc$��Right=�6c   .��5u        $	 Cog=�6,   5w      �� 5y      #��[ 6   $��0 0 55 0q�6<   $��Right=�6N   .��5z        $
 Bell=�6,   5{      �� 5}      $��Members��6   $��1��6+   $��32(�68   $��SemiBold"�6F   $��0 20 0 0q�6\   $
��Left=�5~      ���#12151867   �� 5�        	addButton#��[ 6   .��5�      �� $ 
Horizontal=�6!   .+�5�        $
 Plus=�60   $��Center=�6<   $��11��6W   $��11��6b   $��0 1 8 0q�6n   �� 5�      $��Thêm sinh viên��6$   5�      5�      �� 5�      $��1��6   $��3��6'   ���#dae2ea$��	0 -1 0 10q�6I   �� 5�      $��2��6   $ 
Horizontal=�6*   $��0 10 0 0q�6C   .+�5�      �� $��
Club Staff��6     	tabButton#��[ 62   ���#784ff26U   �� 5�      $��Players��6   #��[ 6/   �� 5�      $��Archived��6   #��[ 60   5�      �� 5�      $��68 Club Staff��6   $��4��61   $��18(�6>   $��SemiBold"�6L   ���#121518$
��Left=�5�   1   $��Center=�6L   �� 5�      $��	Filter by��6   $��4��6-   $��13(�6:   $��SemiBold"�6H   $��	567,0,0,0q�6^   ���#121518$
��Left=�5�   *   $��Center=�6E   � 5�      $	��200��6   $��Right=�6#   $��4��6?   .+�5�      �� $
��15 0q�6    $��Center=�6.   ���#b0b9c6 .  $ 1��5�       $��
Search ...��61   y�5�       �� $ 	txtSearch��# [  �� 5�      -   5        $ 	txtFilter��5�        textboxFilter#��[ 61   5�      &   System.Windows.Controls.DataGrid  5�      -   5          Name$ 	dgMembers��5�   �     DataGridStyle1#���  6    	 DataGridCellStyle1   	CellStyle# � 	 6D    
 DataGridColumnHeaderStyle1   ColumnHeaderStyle# � 
 6u     DataGridRowStyle1   RowStyle# �  6�   $��5��6�      Columns 5�      4  .System.Windows.Controls.DataGridCheckBoxColumn  5�      ,  &System.Windows.Controls.DataGridColumn   CanUserResize .     Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6G     CheckBoxStyle11  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 6T      HeaderTemplate 5�      �� 5�   "   .R�5�   &   �� #��[ 6/   5�   #   5�      0  *System.Windows.Controls.DataGridTextColumn  5�         Header$ #��6-      
IsReadOnly .  .  $
 auto 6`      Binding 6m   �� *Number+4  .System.Windows.Controls.DataGridTemplateColumn  5�      $ Member��61    . $ * 6S      CellTemplate 5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   .+�5�   *   �� $��25��61   $��25��6<   $ 50��6H   $��0 0 10 0q�6Z   ��6l   �� *	BgColor+._�5�   .   �� $��Center=�6S   $��Center=�6n   
�������$��0 0 0 1q�6�   ��68   �� *	Character+6�   5�   +   �� 5�   *   $��Center=�6J   ��64   �� *Name+6J   5�   '   5�   #   5�        5�      $ Position��6-    . $ * 6Q    6[   �� *
Position+  5�      $ Email��6-    . $ * 6N    6X   �� *Email+  5�      $ Phone��6-    . $ * 6N    6X   �� *Phone+  5�      $ 
Operations��61    . $
 auto 6W    5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   .+�5�   *   ��   gridEditButton#��[ 61   .��5�   .     $ PencilOutline=�6D     gridButtonIcon#��[ 6Y   5�   +   �� 5�   *     gridRemoveButton#��[ 61   $��5 0 0 0q�6[   .��5�   .     $ DeleteOutline=�6D   #��[ 6Y   5�   +   5�   '   5�   #   5�      5�      �� 5�      $��6��6   $��Right=�6&   ���#dee4ec$��1q�6X   $ 5��5�      $ 5q�6*   
�������$��
0 10 10 10q�6I   ._�5�      �� $ 
Horizontal=�6!   .+�5�      ��   pagingButton#��[ 6!   .��5�        $ ChevronLeft=�64     pagingButtonIcon#��[ 6G   5�      �� 5�      $��1��6$   ���#dee4ec$	��3 7q�6=   �� 5�      #��[ 6!   $��1��6G   �� 5�      #��[ 6!   $��2��6G   ���#7950f2���#ffffff6h   �� 5�      #��[ 6!   $��3��6G   �� 5�      $	��...��6$   ���#6c7682$��Center=�6D   $��15(�6_   $
��10 0q�6m   �� 5�      #��[ 6!   $��7��6G   �� 5�      #��[ 6!   $��8��6G   �� 5�      #��[ 6!   $��9��6G   �� 5�      #��[ 6!   .��5�        $ ChevronRight=�64   #��[ 6H   5�      5�      5�      5�      5�      5�      5�      