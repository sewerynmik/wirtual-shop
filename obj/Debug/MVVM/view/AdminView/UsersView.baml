   M S B A M L   `   `   `  ����	  bazy3)    #bazy3.MVVM.view.AdminView.UsersView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5   
   �� 5	      $��40 �6   �� 5
      .+�5   
   �� -   5        $��0��5      $��Dodaj nowego klienta��6   $��0q�6V   $
��Left=�6a      ModernButton#��[  6|   �� 5   
   $��1��6   $
��Auto=�6$   $��Disabled=�6G   .��5      �� -   5         ��Name$ ItemsControl��5      $��5q�61   ��5      �� 5      .R�5      �  � Orientation$ 
Horizontal=�6$    � 
ItemHeight$	 160��6=   5      ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ Stretch=�6@   �� 5       � �� 5   !   �� *ActualWidth+ �� RelativeSource ��  �� AncestorType$ 	WrapPanelL�5      ��5      �� 5      .R�5      ��   Card#��[ 6!   $��0 0 5 5q�6?   $	��160��6P   ._�5       � 	 � ColumnDefinitions	 5!   "   �� 5"   &   �� 5#   &   .+�5&   "   �� $��0��6-   
 �� Orientation$
 Vertical=�6=   .+�5'   &   �� $
 
Horizontal=�61   .+�5(   *   ��  	 CName#��[ 64   $��0 2 5 0q�6i   ��6S   �� *Imie+6i   �� 5)   *   #��[ 64   ��6S   �� *
Nazwisko+5*   '   �� 5+   &   $
 
Horizontal=�61   .+�5,   *   ��  	 CRest#��[ 64   $��Email: ��6S   �� 5-   *   #��[ 64   ��6S   �� *Email+5.   '   �� 5/   &   $
 
Horizontal=�61   .+�50   *   �� #��[ 64   $��Pesel: ��6S   �� 51   *   #��[ 64   ��6S   �� *Pesel+52   '   �� 53   &   $
 
Horizontal=�61   .+�54   *   �� #��[ 64   $��Numer telefonu: ��6S   �� 55   *   #��[ 64   ��6S   �� *NrTel+56   '   57   #   �� 59   "   $��1��6-   $
 
Horizontal=�6=   $��Center=�5:   -   $��Center=�5;   -   .+�5<   &   �� -   5          CardAdminButton2#��[ 5>   )   $��Edytuj dane logowania��5?   )   $��	0 0 10 0 q�5A   )   ��5@   )   �� *
KlientId+5C   '   �� 5E   &   -   5        #��[ 5G   )   $��Edytuj dane��5H   )   $��	0 0 10 0 q�5J   )   ��5I   )   �� *
KlientId+5L   '   �� 5N   &   -   5          CardAdminButton#��[ 5P   )   $��Usuń��5Q   )   ��5R   )   �� *
KlientId+5S   '   5T   #   5U      5V      5W      5Y      5Z      5[      5\      