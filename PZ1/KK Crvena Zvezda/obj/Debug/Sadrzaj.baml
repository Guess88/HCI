   M S B A M L   `   `   `  ����K  GKK Crvena Zvezda, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:KK_Crvena_ZvezdaKK_Crvena_Zvezda  5   	       KK_Crvena_Zvezda.Sadrzaj   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:KK_Crvena_Zvezda     5   	   -   5          � Title$  Sadrzaj��5   	   $	��550��6   $	��800��6&    � WindowStyle$
 None=�62    � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5	         ButtonTemplate �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius*  $System.Windows.Controls.DataGridCell	 �� Triggers
 P� Property P� Value��%�  &	        '  ;    �� 5
   
   " ��6'   .�5      ��  � ��
 �  ��6+   �� 5       � ��
 �����6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 5��6!   $��1q�62   #��z��6F   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      �� 5   
   "  6   	 5      P� 5      
 �@ 
IsSelected . . �5      ��  � ��
 �����63   �� 5       � ��
 �   �63   5      .�5#      ��  � �� 5$      �� 5%      "  6&   .R�5&      � #��z��6   .+�5'      �� $��Center=�6/   $��Center=�6K   5(      5)      5+      5,      5-      .��5/      � .+�51   
   �� $��Slike/kkcz-logo.png��6   $��60��6-   $��60��69   $��0q�6D   $
��Left=�6O   $	��Top=�6j   �� 52   
   $��Spisak igraca��6   $��Center=�6(   $��40(�6E   $��Bahnschrift)�6S   $
��Bold"�6l   $��	50 6 0 0 q�6   &   System.Windows.Controls.DataGrid  54   
   -   5          Name$ dataGridIgraci��54      $	��400��6+   $	��700��68      AutoGenerateColumns .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .     CanUserAddRows .  ��6D   �� *listaIgraca+   Columns 55      4  .System.Windows.Controls.DataGridCheckBoxColumn  56      -   5        checkBoxObrisi��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 56   B   1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle 57      �� 58      .�59      -   5        5;      5=      5  /System.Windows.Controls.DataGridHyperlinkColumn  5@         Header$ 
Ime igraca��6*   $ 2* 6>      
IsReadOnly .    Binding 6I   �� *
ImePrezime+ 5A      �� 5B      .�5C      -   5        5D      5F      4  .System.Windows.Controls.DataGridTemplateColumn  5H      $ 2* 6)   $ Slika��64      CellTemplate 5I      �� 5J      .R�5K      �� $	��100��6=   $	��100��6I   ��6$   �� *Slika+6I   5L      5N      0	  *System.Windows.Controls.DataGridTextColumn	  5P      -   5        dataGridDatum��$ Datum dodavanja��5P   <   $ * 6x    .  6U   �� *DatumDodavanja+6�   5S      �� 5U   
   $��10��6   $��	0 420 0 0q�6    ��5V      �� 5W       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5X      �  � Offset$	 0.0Q�6#    � Color$ White��60   � 5Y      $	 0.5Q�6#   $	 red��60   � 5Z      $ 1Q�6#   $ white��6.   5[      5]      �� 5^   
    �� Orientation$ 
Horizontal=�6   $��50��6.   $��Bottom=�6:   $��5q�6U   $��Center=�6`   .+�5_      �� -   5         ��Name$ btnDodajIgraca��5_      $��Dodaj igraca��6-   #��[  6D   $��5 5 5 0q�6�   $	��150��6�   6�   �� 5`      -   5        $ btnIzbrisigraca��5`      $��Obrisi igraca��6.   #��[  6F   $��5 5 5 0q�6�   $	��150��6�   6�   �� 5a      -	   5        $ btnIzlaz��5a      $��	Odjavi se��6'   #��[  6;   $��5 5 5 0q�6z   $	��150��6�   6�   5b      5c      5d      