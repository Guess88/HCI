   M S B A M L   `   `   `  ����K  GKK Crvena Zvezda, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:KK_Crvena_ZvezdaKK_Crvena_Zvezda  5   	   !    KK_Crvena_Zvezda.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:KK_Crvena_Zvezda     5   	   -   5          � SizeToContent$  WidthAndHeight=�5   	    � WindowStyle$
 None=�6(    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5         ButtonTemplate �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius��%E  &	        �� 5   
   " ��6'   .�5      ��  � ��
 �  ��6+   �� 5       � ��
 �����6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $	 5��6!   $��1q�62   #��z��6F   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      5      .��5      �� $	��600��6   $	��400��6   .+�5   
   F� -   5        $��PathUI��5   1   
�������$��2��6   ��5       �� 5!      
 �� ImageSource$
 Slike/login.jpg��6    j� Stretch$
 Fill=�6;   6L   ��5#      B� 5$      .��5%      E�  E� 
StartPoint$
 30,0&�6!   .��5&      ��  �� Size$ 30,30��6%    �� RotationAngle$ 50Q�62    �� 
IsLargeArc .   �� SweepDirection$ Counterclockwise=�6Y    �� Point$
 0,30&�6{   �� 5'       �� Point$ 0 370&�6&   �� 5(      $ 30,30��6%   $ 50Q�62    .  $ Counterclockwise=�6Y   $ 30,400&�6{   �� 5)      $ 570,400&�6&   �� 5*      $ 30,30��6%   $ 50Q�62    .  $ Counterclockwise=�6Y   $ 600,370&�6{   �� 5+      $ 600,30&�6&   �� 5,      $ 30,30��6%   $ 50Q�62    .  $ Counterclockwise=�6Y   $ 570,0&�6{   �� 5-      $
 30,0&�6&   5.      5/      51      �� 54   
   $	��600��6   $��50��6   $	 	30 30 0 0��6)   $��0 0 0 1q�6B   
�������._�55      ��  �� Orientation$ 
Horizontal=�6   .+�56      �� $��Slike/kkcz-logo.png��6   $��60��65   $��0q�6@   6M   �� 57      $��KK Crvena zvezda��6   $��Center=�63   $��25(�6N   $��Consolas)�6\   $
��Bold"�6r   �� 59      -   5         ��Name$ btnMinimize��59      $��0q�6.   
�������$��40��6U   $��40��6a   $��	210 0 0 0q�6l   .��5:      �� $��Slike/m.png��6   63   5;      �� 5=      -   5        $ btnClose��5=      $��0q�6+   
�������$��40��6R   $��40��6^   .��5>      �� -   5         ��Name$ imgClose��5>      $��Slike/close-img1.png��6.   6N   5?      5@      5A      �� 5C   
    �� Left$ 0��6   
 �� Top$ 50��6!    �� Bottom$ 0��61   $	��600��6C   $	��350��6O   $	 0 0 0 50��6\   ._�5D      �� $ Vertical=�6   $��Center=�60   .+�5E      �� $��Prijava��6   $��30(�6*   $��Consolas)�68   $
��Bold"�6N   $��0 10 0 0q�6`   $��Center=�6r   6�   �� 5F      -   5         ��Name$ 
tbUsername��5F      $��30��6/   $	��180��6<   $��5 0 0 5q�6H   $��Center=�6�   G� 5G      -   5         G�Name$ 	PassowrdB��5G      $��30��62   $	��180��6?   $��5 5 0 5q�6K   $��Center=�6�   �� 5H      -   5        $
 tbPW��5H      $��30��6(   $	��180��65   $��
5 -40 0 0 q�6A   $��Center=�6n   6�   �� 5I      -	   5        $��btnLogin��5I      $��30��6)   $	��100��66   $��5 5 0 0q�6B   #��[  6S   $��
Prijavi se��6{   6�   5J      5K      5O      5P      