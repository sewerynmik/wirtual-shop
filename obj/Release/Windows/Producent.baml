   M S B A M L   `   `   `  ���� @  <bazy3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:bazy3.MVVM.viewModel.ProducentViewModel'bazy3.MVVM.viewModel.ProducentViewModel      bazy3.Producent   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     K	viewModel5clr-namespace:bazy3.MVVM.viewModel.ProducentViewModel     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  -     � Title$  User2��$	��600��$	��920�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=�
������  � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=� � Topmost .  � DataContext @   :bazy3.MVVM.viewModel.ProducentViewModel.ProducentViewModel  .���� ���#272537 �� CornerRadius$ 20��._��  � ColumnDefinitions �� $	��200 ��� 	 � RowDefinitions	 �� $��75 ��� .+��� $��FishProducent��$��Center=�$
��Left=�
�������$��20(�$��20,0,0,0q��� $��1��$��0��.+�	�    UserMenuButton#��[  
 d� 	IsChecked$

 TrueY�
 � Tag$	 red������ *HomeViewCommand+.����  �� Orientation$ 
Horizontal=�.+�"  FontAwesome.WPF.ImageAwesome     Icon$
 Home=�  MenuButtonIcon#��[ �� $
��Home��  MenuButtonText#��[ 	� #��[  $
 aqua������ *MyProductsViewCommand+.���� $ 
Horizontal=�.+�  $ ShoppingCart=�#��[ �� $��
MyProducts��#��[ 	� #��[  $ yellow������ *ProfileViewCommand+.���� $ 
Horizontal=�.+�  $
 Gear=�#��[ �� $��Profile��#��[ �� -   $��0��$��1��$��Right=�  TurnOffButton#��[ $��0,0,60,0q�$��-��
�������$��50(��� -   $��0��$��1��$��Right=�#��[ $��0,0,10,0q�.��  $ Close=�   
Foreground
 ������� $��1��$��1��$��10q����� *CurrentView+