   M S B A M L   `   `   `  ���� 	  bazy3!    bazy3.MVVM.view.ProfileView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  
������ .���   � RowDefinitions  �� $
��Auto ��� $��* �.+��� $��Moje zamówienia��   ModernTextBlock#��[  $��0���� $��25 10q�$��Visible=�$��Disabled=�$��1��.���� -    ��Name$ OrderCollection��$��5q�$��Stretch=����� .R��  � Orientation$ 
Horizontal=� � 
ItemHeight$	 160������  �� 
TargetType" ��.���  �� Property � �� �� Value$ Stretch=���  � �� �� *ActualWidth+ �� RelativeSource ��  �� AncestorType$ 	WrapPanelL����� .R���   Card#��[ $��0 0 5 5q�._��   �� �� 	 � ColumnDefinitions	 �� �� $
��0.2* �.+��� $��0��$��0��
 �� Orientation$
 
Horizontal=�.+���  	 CRest#��[ $��Numer zamówienia: ���� #��[ ���� *NrZamowienia+�� $��0��$��1��$
 
Horizontal=�.+��� #��[ $#��Data złożenia zamówienia: ���� #��[ ���� *Data+�� -   $��2��$��0��$��1��  
CardButton#��[ $��Zobacz������ *ZamowienieId+