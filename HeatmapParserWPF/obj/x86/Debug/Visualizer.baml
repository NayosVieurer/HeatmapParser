   M S B A M L   `   `   `  ����K  GHeatmapParserWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:HeatmapParserWPFHeatmapParserWPF  5      !    HeatmapParserWPF.Visualizer   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /selfclr-namespace:HeatmapParserWPF     5        � 	Resources  5	       �� Source�� 5
   
   $ Styles/Templates.xaml?�6   %     J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$" self:CustomCommands.Increase��5      6f     5   
   -   5        $" self:CustomCommands.Decrease��5      6f   .��5      �  � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��75 �6   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   �� $��
0, 0, 0, 3q�6   ���#1818186/   �� 5   
   $��1��6   $��3��6!   $��
3, 0, 0, 0q�62   ���#1818186O   �� 5!   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��50��6K   $��0,10,0,0q�6W   $	��Top=�6i   $	��380��6�   .+�5"      �� -   5        $��	Creatures��5"   Z   $��Creatures deaths��6   ���#282828���#F8F8F8$��0, 0, 10, 0q�6~   $	��120��6�      CustomButtonTemplate#���   6�   �� 5#      -   5        $��SoldierHits��5#   V   $��Soldier hits��6   ���#282828���#F8F8F8$��0, 0, 10, 0q�6|   $	��120��6�   #���   6�   �� 5$      -   5        $��SoldierSteps��5$   X   $��Soldier steps��6   ���#282828���#F8F8F8$��Right=�6�   $	��120��6�   #���   6�   5%      �� 5'   
   $��1��6   $��1��6%   $��Center=�62   $	��200��6M   $	��175��6Y   $ Vertical=�6f   $y�Visible=�6}   .+�5(      �� 
�������$
��Game��6'   $��Center=�66   �� 5)      -   5        $��gameSelection��5)      $	��Top=�6�   $��Center=�6�   ��6^   ��  �� RelativeSource ��  �� Mode$ FindAncestor=�	 �� AncestorType"	 ��
 �� Path$
 Width�6�   �� 5+      .+�5,      �� -   5        $��CreatureControls��5,   a   $��1��6   $��1��6-   $��Center=�6:   $	��200��6U   $ Vertical=�6y   $y�Visible=�6�   .+�5-      �� 
�������$��Floor��6/   $��Center=�6?   �� 5.      -   5        $��floorSelection��5.      $	��Top=�6�   $��Center=�6�   ��6h   ��  �� $ FindAncestor=�"	 ��$
 Width�6�   5/      �� 51      -	   5        $��soldierControls��51   a   $��1��6   $��1��6-   $��Center=�6:   $	��200��6U   $ Vertical=�6x   $y�Hidden=�6�   .+�53      �� $��
Timeline :��6   $��Center=�61   
�������6N   �� 54      -
   5        $��traceDepthSlider��54   d    � Maximum$	 100Q�6J    � Minimum$ 0Q�6X    �� IsSnapToTickEnabled .  �� TickFrequency$ 1Q�6�   �� 55      $ 
Horizontal=�6!   $��Center=�6:   $��Center=�6W   .+�56      �� 
������ 
������ $��50��6T   $"��self:CustomCommands.Decrease��6_   ��57      F� 58   "   $��Center=�6'   $��Right=�6B   
�������$��2��6p   "���� -1    �    �pr � -1��� 	6�   5:      �� 5;      
������ 
������ $��50��6T   $"��self:CustomCommands.Increase��6_   ��5<      F� 5=   "   $��Center=�6'   $��Right=�6B   
�������$��2��6p   "����        � -1�pr �    ��� 	6�   5?      5@      5A      5B      5C      �� 5E   
   -   5        $��stats��5E      $y�Hidden=�6"   $ Vertical=�66   $��1��6M   $��2��6]   .+�5F      �� -   5        $��amountLabel��5F   4   $��24(�6   $
��Bold"�6"   
�������$"��Total deaths on this floor: ��6Z   $��Center=�6�   �� 5G      -   5        $��amount��5G   &   $��24(�6   
�������$��Center=�6G   5H      �� 5J   
   $��2��6   ���#e9eef1$��
0, 0, 0, 0q�6>   $��1��6R   .��5K      �  5L      �� 5M       5O      �� 5P      .+�5R      �� -   5        $��
background��5R      ���#6565686.   �� 5S      -   5        $��Display��5S      $	��900��6'   $	��900��64   $��Resources/placeholder.png��6@   �� 5T      -   5        $
��Mask��5T      $	��900��6$   $	��900��61   5U      5V      5W      5X      