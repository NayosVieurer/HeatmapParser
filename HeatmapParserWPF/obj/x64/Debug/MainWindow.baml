   M S B A M L   `   `   `  ����K  GHeatmapParserWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:HeatmapParserWPF.PropertiesHeatmapParserWPF.Properties  5   	   3clr-namespace:HeatmapParserWPFHeatmapParserWPF  5   	   !    HeatmapParserWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :prop)clr-namespace:HeatmapParserWPF.Properties     5   	   /selfclr-namespace:HeatmapParserWPF     5   	   -   5          � Title$  H.I.V.E. Reports��5   	   $	��500��5
   	   $	��750��5   	    � 	Resources 5       �� DataType$  HeatmapParserWPF.GameViewModel �� TextAlignment �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ Styles/Templates.xaml?�6&   %�   (��       5      *, +)�� 6   "  6   .R�5      �� $��25��6   $	��175��6(   $ Center=�64   $��15(�6K   
�������$
��Bold"�6l   $��
0, 5, 0, 5q�6~   ��6�   �� *name+5      5      ��5      �� 5   
    �� Color$ #484848��6   .��5      � -   5        $��mainGrid��5       � ColumnDefinitions 5    
   �� 5!      $��* �6   �� 5"      $��5* �6    � RowDefinitions 5$   
   .+�5'   
   9� -   5        $��Expand��5'   p   $��
5, 5, 0, 0q�6.   $y�Visible=�6[      CustomExpanderTemplate#���   6~   .��5(      �� $
��Auto=�6   .��5)      �� -   5        |�. $	 �� IsSynchronizedWithCurrentItem$
	 TrueY�5)   +   ���#656568$��Stretch=�6�   ��6�   �� *Games+5*      5+      !   HeatmapParserWPF.Visualizer  5-   
   -   5        
  Name$
 
Visualizer��5-   +   |�. $��2��6?   5.      5/      