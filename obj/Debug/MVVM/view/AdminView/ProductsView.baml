   M S B A M L   `   `   `  ����	  bazy3,    &bazy3.MVVM.view.AdminView.ProductsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5   
   �� 5	      $��40 �6   �� 5
      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0,0,5,0q�6;   .+�5      �� -   5        $��Dodaj nowy produkt��5      $��0q�6N   $
��Left=�6Y      ModernButton#��[  6t   �� 5      -   5        $��Zwiększ cene o 5%��5      $��5 0 0 0q�6[   $
��Left=�6l   #��[  6�   �� 5      -   5         ��Name$ FilterTextBox��5      $��Center=�6.   $�� 5 0 0 0q�6I     ModernTextBox#��[ 5      5      5      �� 5   
   $��1��6   $
��Auto=�6$   $��Disabled=�6G   $��5,5,5,5q�6p   .��5      �� -   5         ��Name$ ItemsControl��5      ��5      �� 5      .R�5      �  � Orientation$ 
Horizontal=�6$    � 
ItemHeight$	 160��6=   5      ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ Stretch=�6@   �� 5       � �� 5    !   �� *ActualWidth+	 �� RelativeSource	 �� 
 �� AncestorType$
 	WrapPanelL�5!      ��5#      �� 5$      .R�5%      ��   Card#��[ 6!   $��0 0 5 5q�6?   ._�5&      �  � ColumnDefinitions 5'   "   �� 5(   &   �� 5)   &   �� 5*   &   .+�5-   "   �� $��0��6-   $ Vertical=�6=   .+�5.   &   ��  	 CName#��[ 60   ��6O   �� *Nazwa+�� 5/   &   $ 
Horizontal=�61   .+�50   *   ��  	 CRest#��[ 64   $��Cena: ��6S   �� 51   *   #��[ 64   ��6S   �� *Cena.X+�� 52   *   #��[ 64   ��6S   �� *Cena.Y+53   '   �� 54   &   $ 
Horizontal=�61   .+�55   *   �� #��[ 64   $��Producent: ��6S   �� 56   *   #��[ 64   ��6S   �� *	Producent+57   '   58   #   �� 5:   "   $��1��6-   .+�5;   &   �� $��Uniform=�6,   $	��100��6>   ��6N   �� *
Kategoria2+5<   #   �� 5>   "   $��2��6-   $ 
Horizontal=�6=   $��Center=�5?   -   $��Center=�5@   -   .+�5A   &   �� -   5          CardAdminButton#��[ 5C   )   $��Edytuj��5D   )   $��	0 0 10 0 q�5F   )   ��5E   )   �� *Id+5H   '   �� 5J   &   -   5        #��[ 5L   )   $��Usuń��5M   )   ��5N   )   �� *Id+5O   '   5P   #   5R      5S      5T      5V      5W      5X      5Y      