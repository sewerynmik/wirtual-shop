   M S B A M L   `   `   `  ����@  <bazy3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:bazy3.MVVM.viewModel.ProducentViewModel'bazy3.MVVM.viewModel.ProducentViewModel  5   	       bazy3.Producent   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   K	viewModel5clr-namespace:bazy3.MVVM.viewModel.ProducentViewModel     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   -   5          � Title$  User2��5	   	   $	��600��6   $	��920��6$    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6   
������  � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	    � Topmost .  � DataContext 5      @   :bazy3.MVVM.viewModel.ProducentViewModel.ProducentViewModel  5   
   .��5      �� ���#272537 �� CornerRadius$ 20��5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      	 � RowDefinitions	 5      �� 5      $��75 �6    �� 5      .+�5"      �� $��FishProducent��6   $��Center=�5#      $
��Left=�5$      
�������$��20(�5&      $��20,0,0,0q�5'      �� 5)      $��1��6   $��0��6&   .+�5+      	�    UserMenuButton#��[  6   
 d� 	IsChecked$

 TrueY�5,      
 � Tag$	 red��5.      ��5-      �� *HomeViewCommand+.��50      ��  �� Orientation$ 
Horizontal=�6!   .+�51      "  FontAwesome.WPF.ImageAwesome     Icon$
 Home=�6*     MenuButtonIcon#��[ 66   �� 52      $
��Home��6$     MenuButtonText#��[ 60   53      54      	� 55      #��[  6   $
 blue��57      ��56      �� *MyProductsViewCommand+.��59      �� $ 
Horizontal=�6!   .+�5:        $ ShoppingCart=�6*   #��[ 6>   �� 5;      $��
MyProducts��6$   #��[ 66   5<      5=      	� 5>      #��[  6   $ yellow��5@      ��5?      �� *ProfileViewCommand+.��5B      �� $ 
Horizontal=�6!   .+�5C        $
 Gear=�6*   #��[ 66   �� 5D      $��Profile��6$   #��[ 63   5E      5F      5H      �� 5K      -   5        $��0��5K      $��1��6"   $��Right=�5L        TurnOffButton#��[ 5M      $��0,0,60,0q�5N      $��-��5O      
�������$��50(�5Q      5R      �� 5T      -   5        $��0��5T      $��1��6"   $��Right=�5U      #��[ 5W      $��0,0,10,0q�5X      .��5Y      �� $"��../images/icons8-exit-50.png��6   5Z      �� 5\      $��1��6   $��1��6*   $��10q�5]      ��5^      �� *CurrentView+5`      5a      5b      