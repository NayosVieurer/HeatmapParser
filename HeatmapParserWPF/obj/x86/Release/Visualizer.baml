   M S B A M L   `   `   `  ���� K  GHeatmapParserWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:HeatmapParserWPFHeatmapParserWPF  !    HeatmapParserWPF.Visualizer   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /selfclr-namespace:HeatmapParserWPF       � 	Resources   �� Source�� $ Styles/Templates.xaml?�%     J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$" self:CustomCommands.Increase��  -   $" self:CustomCommands.Decrease��.���  � ColumnDefinitions �� $��5* ��� $��* � � RowDefinitions �� $��75 ��� $��2* ��� $��* �.+��� $��
0, 0, 0, 3q����#181818�� $��1��$��3��$��
3, 0, 0, 0q����#181818��  �� Orientation$ 
Horizontal=�$��Center=�$��50��$��0,10,0,0q�$	��Top=�$	��380��.+��� -   $��	Creatures��$��Creatures deaths�����#282828���#F8F8F8$��0, 0, 10, 0q�$	��120��   CustomButtonTemplate#���   �� -   $��SoldierHits��$��Soldier hits�����#282828���#F8F8F8$��0, 0, 10, 0q�$	��120��#���   �� -   $��SoldierSteps��$��Soldier steps�����#282828���#F8F8F8$��Right=�$	��120��#���   �� $��1��$��1��$��Center=�$	��200��$	��175��$ Vertical=�$y�Visible=�.+��� 
�������$
��Game��$��Center=��� -   $��gameSelection��$	��Top=�$��Center=�����  �� RelativeSource ��  �� Mode$ FindAncestor=�	 �� AncestorType"	 ��
 �� Path$
 Width��� .+��� -   $��CreatureControls��$��1��$��1��$��Center=�$	��200��$ Vertical=�$y�Visible=�.+��� 
�������$��Floor��$��Center=��� -   $��floorSelection��$	��Top=�$��Center=�����  �� $ FindAncestor=�"	 ��$
 Width��� -	   $��soldierControls��$��1��$��1��$��Center=�$	��200��$ Vertical=�$y�Hidden=�.+��� $��
Timeline :��$��Center=�
��������� -
   $��traceDepthSlider�� � Maximum$	 100Q� � Minimum$ 0Q� �� IsSnapToTickEnabled .  �� TickFrequency$ 1Q��� $ 
Horizontal=�$��Center=�$��Center=�.+��� 
������ 
������ $��50��$"��self:CustomCommands.Decrease����F� $��Center=�$��Right=�
�������$��2��"���� -1    �    �pr � -1��� 	�� 
������ 
������ $��50��$"��self:CustomCommands.Increase����F� $��Center=�$��Right=�
�������$��2��"����        � -1�pr �    ��� 	�� -   $��stats��$y�Hidden=�$ Vertical=�$��1��$��2��.+��� -   $��amountLabel��$��24(�$
��Bold"�
�������$"��Total deaths on this floor: ��$��Center=��� -   $��amount��$��24(�
�������$��Center=��� $��2�����#e9eef1$��
0, 0, 0, 0q�$��1��.���  ��  �� .+��� -   $��
background�����#656568�� -   $��Display��$	��900��$	��900��$��Resources/placeholder.png���� -   $
��Mask��$	��900��$	��900��