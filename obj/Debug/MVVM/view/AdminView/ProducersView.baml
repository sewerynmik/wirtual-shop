   M S B A M L   `   `   `  ����	  bazy3-    'bazy3.MVVM.view.AdminView.ProducersView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5      �� 5	      $��40 �6   �� 5
      .+�5      �� -   5        $��0��5      $��Dodaj nowego producenta��6   $��0q�6_   $
��Left=�6j      ModernButton#��[  6�   �� 5      $��1��6   $
��Auto=�6%   $��Disabled=�6H   .��5      �� -   5         ��Name$ ItemsControl��5      $��5q�61   ��5      �� 5      .R�5      �  � Orientation$ 
Horizontal=�6$    � 
ItemHeight$	 160��6=   5      ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ Stretch=�6@   �� 5       � �� 5   !   �� *ActualWidth+ �� RelativeSource ��  �� AncestorType$ 	WrapPanelL�5      ��5      �� 5      .R�5      ��   Card#��[ 6!   $��0 0 5 5q�6?   ._�5       � 	 � ColumnDefinitions	 5"   "   �� 5#   &   �� 5$   &   .+�5'   "   �� $��0��6-   
 �� Orientation$
 Vertical=�6=   .+�5(   &   ��  	 CName#��[ 60   ��6O   �� *Nazwa+�� 5*   &   $
 
Horizontal=�61   .+�5+   *   ��  	 CRest#��[ 64   $��Kod pocztowy: ��6S   �� 5,   *   #��[ 64   ��6S   �� *KodPocztowy+5-   '   �� 5/   &   $
 
Horizontal=�61   .+�50   *   �� #��[ 64   $��Adres: ��6S   �� 51   *   #��[ 64   ��6S   �� *	Adres.X+�� 52   *   #��[ 64   ��6S   �� *	Adres.Y+53   '   54   #   �� 56   "   $��1��6-   $
 
Horizontal=�6=   $��Center=�57   -   $��Center=�58   -   .+�59   &   �� -   5          CardAdminButton#��[ 5;   )   $��Edytuj��5<   )   $��	0 0 10 0 q�5>   )   ��5=   )   �� *Id+5@   '   �� 5B   &   -   5        #��[ 5D   )   $��Usuń��5E   )   ��5F   )   �� *Id+5G   '   5H   #   5I      5J      5K      5M      5N      5O      5P      