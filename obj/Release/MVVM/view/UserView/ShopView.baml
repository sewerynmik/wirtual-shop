   M S B A M L   `   `   `  ���� 	  bazy3    bazy3.MVVM.view.ShopView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  
������ .���   � RowDefinitions  �� $��40 ��� .+���  �� Orientation$ 
Horizontal=�$��0��$��0,0,5,0q�.+��� -    ��Name$ FilterTextBox��$��Center=�$�� 5 0 0 0q�   ModernTextBox#��[  �� $��1��$��Visible=�$��Disabled=�.���� -    ��Name$ ItemsControl��$��5q����� .R��  � Orientation$ 
Horizontal=� � 
ItemHeight$	 160������  �� 
TargetType" ��.���  �� Property � �� �� Value$ Stretch=���  � �� �� *ActualWidth+	 �� RelativeSource	 �� 
 �� AncestorType$
 	WrapPanelL����� .R���   Card#��[ $��0 0 5 5q�._��  � ColumnDefinitions �� �� �� .+��� $��0��$ Vertical=�.+���  	 CName#��[ ���� *Nazwa+�� $ 
Horizontal=�.+���  	 CRest#��[ $��Cena: ���� #��[ ���� *Cena.X+�� #��[ ���� *Cena.Y+�� $ 
Horizontal=�.+��� #��[ $��Producent: ���� #��[ ���� *	Producent+�� $��1��.+��� $��Uniform=�$	��100������ *
Kategoria2+�� -   $��2��  CardShopButton#��[ ���� *Id+.��"  FontAwesome.WPF.ImageAwesome     Icon$ ShoppingBasket=�   
Foreground �#918B9C