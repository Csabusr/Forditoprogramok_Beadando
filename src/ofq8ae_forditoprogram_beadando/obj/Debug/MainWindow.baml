   M S B A M L   `   `   `  ����Y  Uofq8ae_forditoprogram_beadando, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ofq8ae_forditoprogram_beadandoofq8ae_forditoprogram_beadando  5   	   /    )ofq8ae_forditoprogram_beadando.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:ofq8ae_forditoprogram_beadando     5   	     � Title$  OFQ8AE_Fordprog_Beadandó��5   	   $	��512��6*   $
��1200��67   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dg_tablazat��5
      $
��Left=�6(   $	��331��6C   $��
10,138,0,0q�6P   $	��Top=�6d   $	��887��6|    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell��%�   '        '  J     �� 5      "  6   .�5      ��  � ��$
 Bold"�63   5      �� 5      "  6   .�5      ��  � ��$ 1q�68   �� 5       � ��
 �����64   �� 5       � ��$ 1 1 1 1q�60   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Column1��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6R   	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 66   �� *	column1+6\     5      $ Column2��6%   $ * 6R   	 . 
 66   �� *	column2+6\     5      $ Column3��6%   $ * 6R   	 . 
 66   �� *	column3+6\     5      $ Column4��6%   $ * 6R   	 . 
 66   �� *	column4+6\     5      $ Column5��6%   $ * 6R   	 . 
 66   �� *	column5+6\     5      $ Column6��6%   $ * 6R   	 . 
 66   �� *	column6+6\     5      $ Column7��6%   $ * 6R   	 . 
 66   �� *	column7+6\   5      �� 5   
   -   5         ��Name$ 
tb_o_input��5      $
��Left=�6&   $��23��6A   $��	10,50,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $��1+1*1#��6t   $	��Top=�6�   $	��887��6�   �� 5    
   -   5        $ 
tb_c_input��5       $
��Left=�6&   $��23��6A   $��	10,80,0,0q�6M   $
 Wrap=�6`   $��
i+i*(1+1)#��6t   $	��Top=�6�   $	��887��6�   �� 5!   
   -   5        $ tb_path��5!      $
��Left=�6#   $��23��6>   $��
10,110,0,0q�6J   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��635��6�   �� 5"   
   -   5         ��Name$ lbl_correct��5"      $��Kérem az inputokat��6%   $
��Left=�6B   $��	10,10,0,0q�6]   $	��Top=�6p   �� 5#   
   -   5        $��Tallóz��5#      $
��Left=�6"   $��777,110,0,0q�6=   $	��Top=�6R   $	��120��6j   $��23��6v   6�   �� 5$   
   -   5        $��
Beégetett��5$      $
��Left=�6%   $��650,110,0,0q�6@   $	��Top=�6U   $	��122��6m   $��23��6y   6�   �� 5%   
   -   5        $ 	tb_output��5%      $
��Left=�6%   $	��427��6@   $��
902,42,0,0q�6M   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��280��6�   �� 5&   
   -	   5        $/��)Lépésrő lépésre történő megoldás��5&      $
��Left=�6<   $��
902,11,0,0q�6W   $	��Top=�6k   $��23��6�   $	��280��6�   6�   �� 5'   
   $l��fA Syntax.csv fájlban a E' és T' Két karakteres mivoltjuk miatt cserélve lett É és G karakterekre��6   $
��Left=�6{   $��
370,11,0,0q�6�   $	��Top=�6�   ���	#FFFDFD076�   5)      5*      