   M S B A M L   `   `   `  ����K  GHeatmapParserWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:HeatmapParserWPFHeatmapParserWPF  5      !    HeatmapParserWPF.Visualizer   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /selfclr-namespace:HeatmapParserWPF     5      -   5        |�.   � DataContext  5
      �� *selectedGame+ � 	Resources 5      *  $HeatmapParserWPF.EnumToBoolConverter   EBConverter  VisibleIfTrueConverter �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ../Styles/Templates.xaml?�6%   %:   &	        &	        5      6'   �� 5      6+   5       J� InputBindings 5      �� 5   
    �� Gesture$
 Left��6    �� Command 6$   �� *DecreaseCommand+�� 5   
   $ Right��6    6%   �� *IncreaseCommand+.��5      �  � ColumnDefinitions 5   
   �� 5       $��5* �6   �� 5!      $��* �6    � RowDefinitions 5#   
   �� 5$      $��75 �6   �� 5%      $��2* �6   �� 5&      $��* �6   .+�5)   
   �� $��
0, 0, 0, 3q�6   ���#1818186/   �� 5+   
   $��1��6   $��3��6!   $��
3, 0, 0, 0q�62   ���#1818186O   �� 5-   
   -   5        $��MapsButtons��5-      	 �� Orientation$	 
Horizontal=�6(   $��Center=�6A   $��50��6^   $��0,10,0,0q�6j   $	��Top=�6|   $	��380��6�   .+�5.      	� #��[Bd�6�   $��Creatures deaths��6�   ���#282828���#F8F8F8$��0, 0, 10, 0q�6  $	��120��6   
 d� 	IsChecked
 6   ��  �� Path$
 Type� �� 	Converter# [     HeatmapParserWPF.MapType   Creature �� ConverterParameter# Z 6   	� 5/      #��[Bd�6�   $��Soldier hits��6�   ���#282828���#F8F8F8$��0, 0, 10, 0q�6  $	��120��6  
 6   �� $
 Type�# [     Soldier# Z 6  	� 50      -   5        $��steps��50   �   #��[Bd�6�   $��Steps��6�   ���#282828���#F8F8F8$��Right=�6
  $	��120��6&  
 6   �� $
 Type�# [     Steps# Z 6&  51      �� 53   
   $��1��6   $��1��6%   $��Center=�62   $	��200��6M   $	��175��6Y   $	 Vertical=�6f   $y�Visible=�6}   .+�54      �� 
�������$
��Game��6'   $��Center=�66   �� 55      -   5        $��gameSelection��55      $ �� IsSynchronizedWithCurrentItem$
 TrueY�6K   $	��Top=�6�   $��Center=�6�   ��6,   �� *rounds+��6p   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" ��$ Width�6�   �� 57      .+�58      �� -   5        $��MapsIdentifieers��58   a   $��1��6   $��1��6-   $��Center=�6:   $	��200��6U   $	 Vertical=�6y   ��59      �� 5:       �� 
TargetType" ��6    .�5;      ��  �� Property � y� �� Value$ Visible=�6;    �� Triggers 5<      �� 5=   "    �� Binding 6.   �� *Type+ �� Value	 Steps6G   .a�5>   &   ��  � y�$ Hidden=�6C   5?   #   5A      .+�5C      �� 
�������$��Floor��6/   $��Center=�6?   �� 5D      -   5        $
 TrueY�5D   [   $	��Top=�6�   $��Center=�6
  ��6<   �� *floors+��6�   ��  �� $ FindAncestor=�" ��$ Width�6
  5E      �� 5I      -   5        $��StepsControls��5I   a   $��1��6   $��1��6-   $��Center=�6:   $	��200��6U   $	 Vertical=�6v   ��5J      �� 5K      " ��6    .�5L      ��  � y�$ Hidden=�6;    5M      �� 5N   "    6.   �� *Type+	 Steps6G   .a�5O   &   ��  � y�$ Visible=�6C   5P   #   5R      .+�5T      �� -   5        $��StepsIdentifiers��5T   e   $��1��6!   $��1��61   $��Center=�6>   $	��200��6Y   $	 Vertical=�6}   y�6�   �� $ 	IsChecked� �� ElementName$ steps��# [ .+�5U      �� 
�������$��	Character��63   $��Center=�6G   �� 5V      $
 TrueY�6F   $	��Top=�6�   $��Center=�6�   ��6#   �� *
characters+��6k   ��  �� $ FindAncestor=�" ��$ Width�6�   5W      �� 5X      $��
Timeline :��6   $��Center=�61   
�������6N   �� 5Y      -	   5        $��traceDepthSlider��5Y   t    � Minimum$ 0Q�6h    �� IsSnapToTickEnabled .  �� TickFrequency$ 1Q�6�    � Value 6   �� *TimelineEnd+  �� Mode$  TwoWay=�! � Maximum! 6H   �� *maxTimeline+6�   �� 5Z      $	 
Horizontal=�6!   $��Center=�6:   $��Center=�6W   .+�5[      �� 
������ 
������ $��50��6x   ��6:   �� *DecreaseCommand+��5\      F� 5]   "   $��Center=�6'   $��Right=�6B   
�������$��2��6p   "���� -1    �    �pr � -1��� 	6�   5_      �� 5`      
������ 
������ $��50��6x   ��6:   �� *IncreaseCommand+��5a      F� 5b   "   $��Center=�6'   $��Right=�6B   
�������$��2��6p   "����        � -1�pr �    ��� 	6�   5d      5e      5f      5g      5h      �� 5j   
   -
   5        $��stats��5j      $y�Hidden=�6"   $	 Vertical=�66   $��1��6M   $��2��6]   .+�5k      �� -   5        $��amountLabel��5k   4   $��24(�6   $
��Bold"�6"   
�������$"��Total deaths on this floor: ��6Z   $��Center=�6�   �� 5l      -   5        $��amount��5l   &   $��24(�6   
�������$��Center=�6G   5m      �� 5o   
   $��2��6   ���#e9eef1$��
0, 0, 0, 0q�6>   $��1��6R   .��5p      �  5q      �� 5r       5t      �� 5u      .+�5w      �� -   5        $��
background��5w      ���#6565686.   �� 5x      -   5        $��Display��5x      $	��900��6'   $	��900��64   ��6@   �� *currentImage+�� 5y      -   5        $
��Mask��5y      $	��900��6$   $	��900��61   ��6=   �� *currentMask+5z      5{      5|      5}      