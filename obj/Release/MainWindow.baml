   M S B A M L   `   `   `  ���� 	  bazy3    bazy3.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$  
MainWindow��$	��300��$	��500�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � Topmost .  � WindowStartupLocation$ CenterScreen=�����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,2&�.���  � Color$ #BDE3FF�� � Offset$	 0.0Q�� $ #BDE3FF��$ 1Q�.��� 	 � RowDefinitions	 �� $��20 ��� �� �� �� $��30 ��� �� $��20 �
 � ColumnDefinitions
 �� $	��100 ��� �� $	��100 �.+�� $��1��$��1��.+��� $��Podaj dane logowania��   TextBlockStyle#��[  � $��2��$��1��
 �� �� .+��� $��Login:��$��0��#��[  �� -   $��Login��$��1��  TextBoxStyle#��[ 
���   �� $��3��$��1��
 �� �� .+��� $��Hasło:��$��0��#��[  G� -   $
��Pass��$��1��  PasswordBoxStyle#��[ � $��5��$��1��
 �� �� .+��� -   $��1��$��zaloguj��
�������$��14(�$��Medium"�  ButtonStyle#��[ �� -   $��0��$��anuluj��
�������$��14(�$��Medium"�#��[ � $��4��$��1��.+��� -    ��Name$
 Info��$*��$Podano nieprawidłowe dane logowania��$��15(�
���  ��$y�	Collapsed=�#��[  