   M S B A M L   `   `   `  ����K  GRedEmpleoOffLine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:RedEmpleoOffLine.ViewRedEmpleoOffLine.View  5   	   !    RedEmpleoOffLine.View.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:RedEmpleoOffLine.View     5   	     � Title$&   Iniciar Session RedEmpleoOffLine��5   	   $��270.18��62   $	��358��6B    � 
ResizeMode$ NoResize=�6N    � ShowInTaskbar .   � WindowStartupLocation$ CenterOwner=�6z   $y�Visible=�6�    J� Opacity$ 0.995Q�6�    � WindowStyle$
 None=�6�    � AllowsTransparency . ��6�   Z� .��5	      � $
��Left=�6   $	��352��6&   $��0,0,0,24q�62    � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   �� ���	#FFC3BEBE$��5q�6)   $
��Left=�6=   $	��222��6X   $��10,10,0,-18q�6e   $	��Top=�6z   $	��330��6�    J� OpacityMask �	#FFEED3D3���	#FFFFFEFE	 �� CornerRadius$	 15��6�   ._�5      � $��8,9,10,6q�6   .+�5      �� -   5        
 ��Name$

 Logo��5      $
��Left=�6(   $��59��6C   $��	80,15,0,0q�6O   $	��Top=�6b   $	��150��6z   �� 5      -   5         ��Name$ textBlockUsuario��5      $
��Left=�66   $��	10,88,0,0q�6Q   $
��Wrap=�6d   $��Usuario:��6x   $	��Top=�6�   $��23��6�   $	��123��6�   $��16(�6�   �� 5      -   5        $ textBlockContrasena��5      $
��Left=�69   $��
10,125,0,0q�6T   $
��Wrap=�6h   $��Contraseña��6|   $	��Top=�6�   $��23��6�   $	��123��6�   $��16(�6�   �� 5      -   5         ��Name$ Usuario��5      $
��Left=�6+   $��23��6F   $��
103,88,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $	��Top=�6{   $	��192��6�   $��16(�6�   G� 5      -   5         G�Name$ 
Contrasena��5      $
��Left=�62   $��23��6M   $��103,125,0,0q�6Y   $	��Top=�6o   $	��192��6�   $��16(�6�   �� 5      -   5        $��x��5      $
��Left=�6%   $��
270,1,-1,0q�6@   $	��Top=�6T   $��33��6l   $��33��6w   $��2q�6�   
�������$��20(�6�   ��5      
� 5      .��5      �  � Color$ White��6+    � Offset$ 1Q�69   � 5      $ 	#FFD41919��6+   $
 0.98Q�6=   5      ��5      
� 5      .��5      � $ White��6+   $ 0.786Q�69   � 5      $ 	#FFFF7575��6+   $ 0.499Q�6=   5       ��5#      �� 5$       �� 
TargetType" ��6*   .R�5%      ��  ��Name$ Border��6%   $	 15��66   $��1q�6H   ���	#FFDD1721
�������._�5&   "   �� $��Center=�64   $	��Top=�6Q   ��.  5'   &   �� 5(   *    �� EndPoint$ 0.5,1&�6>    �� 
StartPoint$ 0.5,0&�6O    � ColorInterpolationMode$ ScRgbLinearInterpolation=�6b   .��5)   .   � $ White��6;   $ 1Q�6I   � 5*   .   $ 	#FFD41919��6;   $
 0.98Q�6M   5+   +   5-   #   5.       �� Triggers 5/      P� 50   "    P� Property �@J�IsMouseOver P� Value . . �51   &   ��  �� 
TargetName$ Border��6-    �� Property � �� �� Value
 �  ��6W   52   #   P� 53   "    � �� . . �54   &   �� $ Border��6-    � �� �	#D79100006W   55   #   57      59      5:      5;      �� 5<   
   -   5         ��Name$ IniciarSession��5<      $��Iniciar Session��6)   $
��Left=�6C   $��100,180,0,0q�6^   $	��Top=�6s   $	��142��6�   $��35��6�   ���	#FFDD1721���	#FFB85D5D$��2q�6�   $��16(�6  ��5=      �� 5>      $ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67   $ 0.5,0&�6[   .��5?      � $ Black��6#   � 5@      $ White��6#   $
 0.13Q�61   5A       J� Effect 5C      3  -System.Windows.Media.Effects.DropShadowEffect  5D         Color$ 	#FF763D3D��6#   ��5F      �� 5G      " ��6"   .R�5H      �� $ Border��6   $	 1,8,1,8��6-   $��2q�6D   ���	#FFDD1721���	#FFDD1721}�.  5I        5J      $ 	#FF873434��6/   ._�5L      �� $��2q�6+   $��Center=�66   $��Center=�6S   ��.  5M      �� 5N   "   $ 0.5,1&�66   $ 0.5,0&�6G   $ ScRgbLinearInterpolation=�6Z   .��5O   &   � $ 	#FF700F0F��63   $ 0Q�6E   � 5P   &   $ 	#FFE22E2E��63   $ 1Q�6E   5Q   #   5S      5T       5U      P� 5V       �@J�IsKeyboardFocused . . �5W      �� $ Border��6%    � ��
 �����6P   5X      P� 5Y       �@J�IsMouseOver . . �5Z      �� $ Border��6%    � ��
 �  ��6O   5[      P� 5\       � �� . . �5]      �� $ Border��6%    � �� �	#D79100006O   �� 5^      $ Border��6%    � �� �	#FF6E51516P   5_      5a      5c      5d      5f      