   M S B A M L   `   `   `  ���� 	  bazy3-    'bazy3.MVVM.view.AdminView.ProducersView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .���   � RowDefinitions  �� $��40 ��� .+��� -   $��0��$��Dodaj nowego producenta��$��0q�$
��Left=�   ModernButton#��[  �� $��1��$
��Auto=�$��Disabled=�.���� -    ��Name$ ItemsControl��$��5q����� .R��  � Orientation$ 
Horizontal=� � 
ItemHeight$	 160������  �� 
TargetType" ��.���  �� Property � �� �� Value$ Stretch=���  � �� �� *ActualWidth+ �� RelativeSource ��  �� AncestorType$ 	WrapPanelL����� .R���   Card#��[ $��0 0 5 5q�._�� 	 � ColumnDefinitions	 �� �� .+��� $��0��
 �� Orientation$
 Vertical=�.+���  	 CName#��[ ���� *Nazwa+�� $
 
Horizontal=�.+���  	 CRest#��[ $��Kod pocztowy: ���� #��[ ���� *KodPocztowy+�� $
 
Horizontal=�.+��� #��[ $��Adres: ���� #��[ ���� *	Adres.X+�� #��[ ���� *	Adres.Y+�� $��1��$
 
Horizontal=�$��Center=�$��Center=�.+��� -     CardAdminButton#��[ $��Edytuj��$��	0 0 10 0 q����� *Id+�� -   #��[ $��Usuń������ *Id+