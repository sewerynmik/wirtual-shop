   M S B A M L   `   `   `  ����@  <bazy3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:bazy3.MVVM.viewModelbazy3.MVVM.viewModel  5   	       bazy3.User2   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   8	viewModel"clr-namespace:bazy3.MVVM.viewModel     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   -   5          � Title$  User2��5	   	   $	��600��6   $	��920��6$    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6   
������  � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	    � Topmost .  � DataContext 5      (   "bazy3.MVVM.viewModel.MainViewModel  5   
   .��5      �� ���#272537 �� CornerRadius$ 20��5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      	 � RowDefinitions	 5      �� 5      $��75 �6    �� 5      .+�5"      �� $��FishShop��6   $��Center=�5#      $
��Left=�5$      
�������$��20(�5&      $��20,0,0,0q�5'      �� 5)      $��1��6   $��0��6&   .+�5+      	�    UserMenuButton#��[  6   
 d� 	IsChecked$

 TrueY�5,      
 � Tag$	 red��5.      ��5-      �� *HomeViewCommand+.��50      ��  �� Orientation$ 
Horizontal=�6!   .+�51      "  FontAwesome.WPF.ImageAwesome     Icon$
 Home=�6*     MenuButtonIcon#��[ 66   �� 52      $
��Home��6$     MenuButtonText#��[ 60   53      54      	� 55      #��[  6   $
 blue��57      ��56      �� *DiscoveryViewCommand+.��59      �� $ 
Horizontal=�6!   .+�5:        $ ShoppingCart=�6*   #��[ 6>   �� 5;      $
��Shop��6$   #��[ 60   5<      5=      	� 5>      #��[  6   $ yellow��5@      ��5?      �� *OptionsViewCommand+.��5B      �� $ 
Horizontal=�6!   .+�5C        $
 Gear=�6*   #��[ 66   �� 5D      $��Oprions��6$   #��[ 63   5E      5F      	� 5G      #��[  6   $ orange��5I      ��5H      �� *ProfileViewCommand+.��5K      �� $ 
Horizontal=�6!   .+�5L        $
 User=�6*   #��[ 66   �� 5M      $��Profile��6$   #��[ 63   5N      5O      	� 5P      #��[  6   $
 Pink��5R      ��5Q      �� *CardViewCommand+.��5T      �� $ 
Horizontal=�6!   .+�5U        $ ShoppingBag=�6*   #��[ 6=   �� 5V      $
��Cart��6$   #��[ 60   5W      5X      5Z      �� 5d      -   5        $��0��5d      $��1��6"   $��Right=�5e        TurnOffButton#��[ 5f      $��0,0,60,0q�5g      $��-��5h      
�������$��50(�5j      5k      �� 5m      -   5        $��0��5m      $��1��6"   $��Right=�5n      #��[ 5p      $��0,0,10,0q�5q      .��5r      �� $"��../images/icons8-exit-50.png��6   5s      �� 5u      $��1��6   $��1��6*   $��10q�5v      ��5w      �� *CurrentView+5y      5z      5{      