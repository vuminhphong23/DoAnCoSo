   M S B A M L   `   `   `  ����H  Dsieu_thi_mini, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:sieu_thi_mini.Utilitiessieu_thi_mini.Utilities  5      A%clr-namespace:sieu_thi_mini.ViewModelsieu_thi_mini.ViewModel  5      -clr-namespace:sieu_thi_minisieu_thi_mini  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5
      Q MLiveCharts, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8df;,clr-namespace:LiveCharts;assembly=LiveCharts
LiveCharts 5      g cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137akOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.MaterialMahApps.Metro.IconPacks 5          sieu_thi_mini.View.Home   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6Menu%clr-namespace:sieu_thi_mini.Utilities     5      4vm%clr-namespace:sieu_thi_mini.ViewModel     5      -localclr-namespace:sieu_thi_mini     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5
      7lvc1,clr-namespace:LiveCharts;assembly=LiveCharts  5      Z	 VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/ 	 5      ZIconOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.Material 	 5      -   5        .��5      �� 
�������  �� CornerRadius$  20��6    $��0 15 0 0q�62   ._�5   
   �  � RowDefinitions 5      �� 5      $
��154* �6    �� 5      $
��131* �6    .+�5      #  MaterialDesignThemes.Wpf.Card  $��8q�5       "  PrimaryHueLightForegroundBrush#���   5      $��	0,15,15,0q�6K   $	��Top=�6^   $��Right=�6v   $	��220��6�   $��72��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ 	#FFC3248D��6'   � 5      $ 	#FF7825F6��6'    � Offset$ 1Q�69   � 5      $ 	#FF310F64��6'   $ 1Q�69   5       .��5"      �� $��Doanh thu ngày��5#      $	��Top=�5%      $
��Wrap=�5&      $��
45,-9,11,0q�6%   $��16(�69   
�������6G   5'      '  !MaterialDesignThemes.Wpf.PackIcon  5(         Kind$ CurrencyUsd=�6&   $	��Top=�69   $��Right=�6Q   $��
0,26,180,0q�6m   $��50��6�   $��40��6�   
�������6�   �� 5*      -   5         ��Name$ moneyDay��5*      $	��150��6&   $��1��62   $
��Left=�6>   $��
690,35,0,0q�6Y   $	��Top=�6m   $��24(�6�   
�������6�     5+      $��8q�5-      #���   5.      $	��Top=�6K   $
��Left=�6c   $	��220��6~   $��72��6�   $��	15,15,0,0q�6�   ��5/      �� 50      $ 0.5,1&�6*   $ 0.5,0&�6;   .��51      � $ 	#FFF11A3E��6'   � 52      $ 	#FFDE8C43��6'   $ 1Q�69   � 53      $ 	#FFDE8C43��6'   $ 1Q�69   54      .��56      �� $$��Số hóa đơn trong ngày��57      $
��Wrap=�58      $��57,-3,12,-9q�6%   $��16(�6:   
�������6H   59        5:      $
 Cart=�6&   $��	32,26,0,0q�62   $��50��6E   $��40��6Q   
�������6\   �� 5<      -   5        $ 
countOrder��5<      
�������$	��100��6;   $
��Left=�6J   $��
175,30,0,0q�6e   $	��Top=�6y   $��24(�6�     5=      $��8q�5>      #���   5?      $	��220��6K   $��72��6W   $	��Top=�6c   $��Center=�6{   $��0,15,0,0q�6�   ��5@      �� 5A      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5B      � $ 	#FF00E4FF��6'   � 5C      $ 	#FF016CFD��6'   $ 1Q�69   � 5D      $ 	#FF016CFD��6'   $ 1Q�69   5E      .��5G      �� $,��&Số sản phẩm bán trong ngày��5H      $
��Wrap=�5I      $��63,-3,34,-3q�6%   $��16(�6:   
�������6H   5J        5K      $ BasketCheck=�6&   $��
344,26,0,0q�69   $��50��6M   $��40��6Y   
�������6d   �� 5L      -   5        $ countProduct��5L      $	��100��6*   $��Right=�68   $��
0,30,335,0q�6T   $	��Top=�6h   $��24(�6�   
�������6�   �� 5M      
�������$  20��6(   $	��0.2q�6:   
�������$��15,106,349,10q�6c   ._�5N      � .+�5O      �� $:��4Biểu đồ thể hiện doanh thu trong ngày��6    $	��Top=�6R   $��Center=�6j   $��14(�6�   #  LiveCharts.Wpf.CartesianChart  5Q      -   5        $��columnChart��5Q   )   $��0 20 0 0q�6<   &   LiveCharts.Wpf.Charts.Base.Chart	   Series	 6N   �� *ColumnChartSeriesCollection+
   AxisX
 5S        LiveCharts.Wpf.Axis     Title$ Giờ��6'      Labels 63   �� *Labels+   AxisY 5V        $ 	Doanh Thu��6'      LabelFormatter 69   �� *
YFormatter+5X      5Y      5[      �� 5\      $��0��6   
�������$  20��65   $	��0.2q�6G   
�������$��Right=�6p   $	��320��6�   $��0,106,15,10q�6�   ._�5]      � .+�5^      �� $B��<Biểu đồ top 5 sản phẩm bán chạy trong ngày��6    $	��Top=�6Y   $��Center=�6q   $��14(�6�     LiveCharts.Wpf.PieChart  5`      -   5        $��PieChart��5`   #   $��0 20 0 0q�63   	 6E   �� *PieChartSeriesCollection+5a      5b      5e      �� 5f      
�������$  20��6(   $	��0.2q�6:   
�������$��15,10,349,15q�6c   $��1��6y   ._�5g      � .+�5h      �� $R��LBiểu đồ thể hiện số hóa đơn bán được trong ngày��6    $	��Top=�6`   $��Center=�6x   $��14(�6�     5j      -   5        $��	lineChart��5j   )   $��0 20 0 0q�6:   	 6L   �� *LineChartSeriesCollection+
 5l        $ Giờ��6'    63   �� *Labels+ 5o        $ Số Hóa Đơn��6'   5q      5r      5t      �� 5v      
�������
�������$	��0.2q�6;   $��Right=�6R   $  20��6o   $��
0,10,15,15q�6�   $��1��6�   $	��320��6�   ._�5w      �� -   5         ��Name$ lbHoaDon��5w   �   $��Hidden=�6   $��Hidden=�6N   
������ 
������ $ 0.5,0.5&�5x   M   ��5w   �   �� *recentInvoices+z�5y      V� 5z      .~�5{      ��  �� ScaleX$ 1Q�6-   �� 5|      �� 5}      T� 5~      5      ��5�      �� 5�      .R�5�      � 
������ $	��0,3q�6<    � ColumnDefinitions 5�   "   �� 5�   &   $��50 �67   �� 5�   &   $
��Auto �67   �� 5�   &   $��* �67   .+�5�   "   �� $��0��6-   .+�5�   &   .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ DownloadBoxOutline=�6<   $��30��6V   $��30��6a   ���#623ed06m   5�   #   �� 5�   "   $��1��6-   $	��170��6=   .+�5�   &   �� 
���   ���60   �� *InvoiceNumber+6O   �� 5�   &   
���������60   �� *employeeNumber+6P   5�   #   �� 5�   "   $��2��6-   $��Right=�6=   .+�5�   &   �� 
�������$��Right=�6s   ��60   �� *Date+ �� StringFormat$ 
dd/MM/yyyy��6s   �� 5�   &   
���   �$��Right=�6t   ��60   �� *Amount+$ 	 {0:N0}đ��6t   5�   #   5�      5�      5�      5�      5�      5�      5�      