   M S B A M L   `   `   `  ����	  bazy3!    bazy3.MVVM.view.ProfileView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      
������ .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Moje zamówienia��6      ModernTextBlock#��[  5      $��0��5      �� 5   
   $��25 10q�6   $��Visible=�5      $��Disabled=�5      $��1��5      .��5      �� -   5         ��Name$ OrderCollection��5      $��5q�5      $��Stretch=�5      ��5       �� 5!      .R�5"      �  � Orientation$ 
Horizontal=�6$    � 
ItemHeight$	 160��5#   $   5$      ��5'      �� 5(       �� 
TargetType" ��6   .�5)      ��  �� Property � �� �� Value$ Stretch=�6@   �� 5*       � �� 5+   !   �� *ActualWidth+ �� RelativeSource ��  �� AncestorType$ 	WrapPanelL�5,      ��5/      �� 50      .R�51      ��   Card#��[ 6!   $��0 0 5 5q�6?   ._�52      �   53   "   �� 54   &   �� 55   &   	 � ColumnDefinitions	 58   "   �� 59   &   �� 5:   &   $
��0.2* �67   .+�5>   "   �� $��0��6-   $��0��6:   
 �� Orientation$
 
Horizontal=�6J   .+�5?   &   ��  	 CRest#��[ 60   $��Numer zamówienia: ��6O   �� 5@   &   #��[ 60   ��6O   �� *NrZamowienia+5A   #   �� 5B   "   $��0��6-   $��1��6=   $
 
Horizontal=�6J   .+�5C   &   �� #��[ 60   $#��Data złożenia zamówienia: ��6O   �� 5D   &   #��[ 60   ��6O   �� *Data+5E   #   �� 5G   "   -   5        $��2��5G   )   $��0��6:   $��1��6G     
CardButton#��[ 5H   )   $��Zobacz��5J   )   ��5I   )   �� *ZamowienieId+5K   )   5L      5M      5N      5P      5Q      5R      5S      