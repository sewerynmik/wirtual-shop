   M S B A M L   `   `   `  ����@  <bazy3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:bazy3.MVVM.viewModel.AdminViewModel#bazy3.MVVM.viewModel.AdminViewModel  5   	       bazy3.Admin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   G	viewModel1clr-namespace:bazy3.MVVM.viewModel.AdminViewModel     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   -   5          � Title$  User2��5	   	   $	��600��6   $	��920��6$    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6   
������  � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	    � Topmost .  � DataContext 5      8   2bazy3.MVVM.viewModel.AdminViewModel.AdminViewModel  5   
   .��5      �� ���#272537 �� CornerRadius$ 20��5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      	 � RowDefinitions	 5      �� 5      $��75 �6    �� 5      .+�5"      �� $��	FishAdmin��6   $��Center=�5#      $
��Left=�5$      
�������$��20(�5&      $��20,0,0,0q�5'      �� 5)      $��1��6   $��0��6&   .+�5+      	�    UserMenuButton#��[  6   
 d� 	IsChecked$

 TrueY�5,      
 � Tag$	 red��5.      ��5-      �� *HomeViewCommand+.��50      ��  �� Orientation$ 
Horizontal=�6!   .+�51      "  FontAwesome.WPF.ImageAwesome     Icon$
 Home=�6*     MenuButtonIcon#��[ 66   �� 52      $
��Home��6$     MenuButtonText#��[ 60   53      54      	� 55      #��[  6   $
 blue��57      ��56      �� *ProductsViewCommand+.��59      �� $ 
Horizontal=�6!   .+�5:        $ ShoppingCart=�6*   #��[ 6>   �� 5;      $��Products��6$   #��[ 64   5<      5=      	� 5>      #��[  6   $ yellow��5@      ��5?      �� *OrdersViewCommand+.��5B      �� $ 
Horizontal=�6!   .+�5C        $
 Gear=�6*   #��[ 66   �� 5D      $��Orders��6$   #��[ 62   5E      5F      	� 5G      #��[  6   $ orange��5I      ��5H      �� *UsersViewCommand+.��5K      �� $ 
Horizontal=�6!   .+�5L        $
 User=�6*   #��[ 66   �� 5M      $��Users��6$   #��[ 61   5N      5O      	� 5Q      #��[  6   $
 Pink��5S      ��5R      �� *ProducersViewCommand+.��5U      �� $ 
Horizontal=�6!   .+�5V        $
 User=�6*   #��[ 66   �� 5W      $��	Producers��6$   #��[ 65   5X      5Y      5[      �� 5]      -   5        $��0��5]      $��1��6"   $��Right=�5^        TurnOffButton#��[ 5_      $��0,0,60,0q�5`      $��-��5a      
�������$��50(�5c      5d      �� 5f      -   5        $��0��5f      $��1��6"   $��Right=�5g      #��[ 5i      $��0,0,10,0q�5j      .��5k      �� $"��../images/icons8-exit-50.png��6   5l      �� 5n      $��1��6   $��1��6*   $��10q�5o      ��5p      �� *CurrentView+5r      5s      5t      