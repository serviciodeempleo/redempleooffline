   M S B A M L   `   `   `  ����K  GRedEmpleoOffLine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:RedEmpleoOffLine.HelpersRedEmpleoOffLine.Helpers  5   	   +    %RedEmpleoOffLine.ViewModel.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   :helpers&clr-namespace:RedEmpleoOffLine.Helpers     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   9    � Title$ RedEmpleoOffLine��5   	   $��649.7��6"   $
��1100��61   
������� � 
ResizeMode$ NoResize=�5   	    � 	Resources 5      3   -RedEmpleoOffLine.Helpers.BoolToImageConverter   ConvertBoolToImage5   /RedEmpleoOffLine.Helpers.StringToImageConverter  ConvertStringToImage3   -RedEmpleoOffLine.Helpers.ViewToImageConverter  ConvertViewToImage8   2RedEmpleoOffLine.Helpers.SelectedItemToItemsSource  SelectedItemToItemsSource  StatusImage �� 	Converter  
PanelImage �� Path
 � Tag �� RelativeSource �� AncestorType  	ViewImage��%  &	        &	      &	 &     &	 9     &	 L     7   &	 �     7  &	 �    7    5	   
   6'     5
   
   6)     5   
   6'     5   
   6,   �� 5   
   mStatusImage��.R�5      �� $��16��6   $��16��6   $	��3,0q�6+   ��68   �� 8   5      �� 5   
   mPnaelImage��.R�5      �� -   5        
������ $��8��5   A   ��6Q   �� $ Cedula� 6t   ��  �� $ DataGridRowL�.��5      �� $��16��6   $��16��6#   $	��3,0q�6/   ��6<   �� 8   5      5      �� 5   
   mViewlImage��.R�5      �� -   5        
������ $��7��5   B   ��6R   �� $	 Ver� 6r   ��  �� $ DataGridRowL�.��5      �� $��16��6   $��16��6#   $	��3,0q�6/   ��6<   �� 8   5      5      5      .��5      � -   5        	 �Name$	 GridPersonas��5      $	��609��6"   $	��Top=�6/   .+�5   
   �� -   5        
 ��Name$

 Logo��5      $
��Left=�6    $��59��6;   $��	12,10,0,0q�6G   $	��Top=�6Z   $	��150��6r   &   System.Windows.Controls.DataGrid  5   
   -   5        $��DataGridPersonas��5         AutoGenerateColumns . $	��457��6F   $��
12,77,12,0q�6S      
IsReadOnly . $	��Top=�6y   �� 5   
   -   5        $��textBox1��5   M   $��23��6   $
��Left=�6   $��
873,49,0,0q�69   $	��Top=�6]   $	��209��6u   6�   �� 5   
   -   5        $��Agregar oferente��5      $	��Top=�6,   $��Right=�6D   $
��Bold"�6`   $��
0,46,277,0q�6�   $��26��6�   $	��105��6�   ��5       �� 5!       �� EndPoint$ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[   .��5"      �  � Color$ Black��6#   � 5#      $ White��6#    � Offset$
 0.13Q�61   5$       J� Effect 5&      3  -System.Windows.Media.Effects.DropShadowEffect  5'         Color$ 	#FF763D3D��6#   ��5)      �� 5*       �� 
TargetType" ��6"   .R�5+      ��  ��Name$ Border��6    �� CornerRadius$ 1,8,1,8��6-   $��2q�6D   ���	#FFDD1721���	#FFDD1721}�.  5,        5-      $ 	#FF873434��6/   ._�5/      �� $��2q�6+   $��Center=�66   $��Center=�6S   ��.  J� OpacityMask 50      �� 51   "   $ 0.5,1&�66   $ 0.5,0&�6G    � ColorInterpolationMode$ ScRgbLinearInterpolation=�6Z   .��52   &   � $ 	#FF700F0F��63   $ 0Q�6E   � 53   &   $ 	#FFE22E2E��63   $ 1Q�6E   54   #   56      57       �� Triggers 58      P� 59       P� Property �@J�IsKeyboardFocused P� Value . . �5:      ��  �� 
TargetName$ Border��6%    �� Property � �� �� Value
 �����6P   5;      P� 5<       �@J�IsMouseOver . . �5=      �� $ Border��6%    � ��
 �  ��6O   5>      P� 5?       � �� . . �5@      �� $ Border��6%    � �� �	#D79100006O   �� 5A      $ Border��6%    � �� �	#FF6E51516P   5B      5D      5F      �� 5G   
   -	   5         ��Name$ LebelUsuario��5G      $�� ��6&   $
��Left=�61   $��
896,10,0,0q�6L   $	��Top=�6`     J� RenderTransformOrigin$  
-0.5,0.654&�6x   $��16(�6�   $
��Bold"�6�   $��Italic$�6�   $	��186��6�   �� 5H   
   $��Buscar:��6   $
��Left=�6"   $��
822,49,0,0q�6=   $	��Top=�6Q   $��51��6i   $��23��6t   �� 5I   
   $$��Lista de oferentes registrados��6   $
��Left=�69   $��51��6T   $��
244,26,0,0q�6`   $	��Top=�6t   $	��418��6�   $��26(�6�   $
��Bold"�6�   $��MS Reference Sans Serif)�6�   �� 5J   
   -
   5        $
 	Logo_back��5J      $
��Left=�6%   $��80��6@   $��0,539,0,-10q�6L   $	��Top=�6a   $
��1094��6y   �� 5K   
   -   5        $��Sincronizar��5K      $
��Left=�6'   $��
698,12,0,0q�6B   $	��Top=�6V   $	��171��6n   $��26��6z   ��5L      �� 5M      $ 0.5,1&�6&   $ RelativeToBoundingBox=�67   $ 0.5,0&�6[   .��5N      � $ Black��6#   � 5O      $ White��6#   $
 0.13Q�61   5P       5R        5S      $ 	#FF763D3D��6#   ��5U      �� 5V      " ��6"   .R�5W      �� $ Border��6   $ 1,8,1,8��6-   $��2q�6D   ���	#FF188907���	#FF20A638}�.  5X        5Y      $ 	#FF873434��6/   ._�5[      �� $��2q�6+   $��Center=�66   $��Center=�6S   ��.  5\      �� 5]   "   $ 0.5,1&�66   $ 0.5,0&�6G   $ ScRgbLinearInterpolation=�6Z   .��5^   &   � $ 	#FF4BCD0E��63   $ 0Q�6E   � 5_   &   $ 	#FFB0D158��63   $ 1Q�6E   5`   #   5b      5c       5d      P� 5e       �@J�IsKeyboardFocused . . �5f      �� $ Border��6%    � ��
 �����6P   5g      P� 5h       �@J�IsMouseOver . . �5i      �� $ Border��6%    � ��
 � � �6O   5j      P� 5k       � �� . . �5l      �� $ Border��6%    � �� �	#D760A4396O   �� 5m      $ Border��6%    � �� �	#FF9DAE7E6P   5n      5p      5r      5s      5u      