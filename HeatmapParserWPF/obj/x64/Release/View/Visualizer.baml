   M S B A M L   `   `   `  ���� K  GHeatmapParserWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:HeatmapParserWPFHeatmapParserWPF  !    HeatmapParserWPF.Visualizer   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /selfclr-namespace:HeatmapParserWPF     |�.   � DataContext  �� *selectedGame+ � 	Resources *  $HeatmapParserWPF.EnumToBoolConverter   EBConverter  VisibleIfTrueConverter �� MergedDictionaries �� Source��  �� $ ../Styles/Templates.xaml?�%   &	        &	        ��  J� InputBindings ��  �� Gesture$
 Left�� �� Command �� *DecreaseCommand+�� $ Right�� �� *IncreaseCommand+.���  � ColumnDefinitions �� $��5* ��� $��* � � RowDefinitions �� $��75 ��� $��2* ��� $��* �.+��� $��
0, 0, 0, 3q����#181818�� $��1��$��3��$��
3, 0, 0, 0q����#181818�� -   $��MapsButtons��	 �� Orientation$	 
Horizontal=�$��Center=�$��50��$��0,10,0,0q�$	��Top=�$	��380��.+�	� #��[Bd�$��Creatures deaths�����#282828���#F8F8F8$��0, 0, 10, 0q�$	��120��
 d� 	IsChecked
 ��  �� Path$
 Type� �� 	Converter# [     HeatmapParserWPF.MapType   Creature �� ConverterParameter# Z 	� #��[Bd�$��Soldier hits�����#282828���#F8F8F8$��0, 0, 10, 0q�$	��120��
 �� $
 Type�# [     Soldier# Z 	� -   $��steps��#��[Bd�$��Steps�����#282828���#F8F8F8$��Right=�$	��120��
 �� $
 Type�# [     Steps# Z �� $��1��$��1��$��Center=�$	��200��$	��175��$	 Vertical=�$y�Visible=�.+��� 
�������$
��Game��$��Center=��� -   $��gameSelection��$ �� IsSynchronizedWithCurrentItem$
 TrueY�$	��Top=�$��Center=����� *rounds+����  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" ��$ Width��� .+��� -   $��MapsIdentifieers��$��1��$��1��$��Center=�$	��200��$	 Vertical=�����  �� 
TargetType" ��.���  �� Property � y� �� Value$ Visible=� �� Triggers ��  �� Binding �� *Type+ �� Value	 Steps.a���  � y�$ Hidden=�.+��� 
�������$��Floor��$��Center=��� -   $
 TrueY�$	��Top=�$��Center=����� *floors+����  �� $ FindAncestor=�" ��$ Width��� -   $��StepsControls��$��1��$��1��$��Center=�$	��200��$	 Vertical=����� " ��.���  � y�$ Hidden=� ��  �� *Type+	 Steps.a���  � y�$ Visible=�.+��� -   $��StepsIdentifiers��$��1��$��1��$��Center=�$	��200��$	 Vertical=�y��� $ 	IsChecked� �� ElementName$ steps��# [ .+��� 
�������$��	Character��$��Center=��� $
 TrueY�$	��Top=�$��Center=����� *
characters+����  �� $ FindAncestor=�" ��$ Width��� $��
Timeline :��$��Center=�
��������� -   $��traceDepthSlider�� � Minimum$ 0Q� �� IsSnapToTickEnabled .  �� TickFrequency$ 1Q� � Value �� *TimelineEnd+  �� Mode$  TwoWay=�! � Maximum! �� *maxTimeline+�� $	 
Horizontal=�$��Center=�$��Center=�.+��� 
������ 
������ $��50������ *DecreaseCommand+��F� $��Center=�$��Right=�
�������$��2��"���� -1    �    �pr � -1��� 	�� 
������ 
������ $��50������ *IncreaseCommand+��F� $��Center=�$��Right=�
�������$��2��"����        � -1�pr �    ��� 	�� -	   $��stats��$y�Hidden=�$	 Vertical=�$��1��$��2��.+��� -
   $��amountLabel��$��24(�$
��Bold"�
�������$"��Total deaths on this floor: ��$��Center=��� -   $��amount��$��24(�
�������$��Center=��� $��2�����#e9eef1$��
0, 0, 0, 0q�$��1��.���  ��  �� .+��� -   $��
background�����#656568�� -   $��Display��$	��900��$	��900������ *currentImage+�� -   $
��Mask��$	��900��$	��900������ *currentMask+