   M S B A M L   `   `   `  ����K  GRedEmpleoOffLine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:RedEmpleoOffLine.HelpersRedEmpleoOffLine.Helpers  5   @   ?$clr-namespace:RedEmpleoOffLine.ModelRedEmpleoOffLine.Model  5   
   ,    &RedEmpleoOffLine.ViewModel.EditPersona   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   :helpers&clr-namespace:RedEmpleoOffLine.Helpers     6@   6Model$clr-namespace:RedEmpleoOffLine.Model     5   
   -   5          �Name$  RedEmpleoOffLine��5   
    � WindowStartupLocation$ CenterScreen=�5   n   
������� � Title$% RedEmpleoOffLine Editar Persona��5   	   $��649.7��62   $
��1100��6A    � 
ResizeMode$ NoResize=�5   $    � 	Resources 5	         validationTemplate  ErrorTemplate �� 
TargetType �� Triggers P� Property P� Value	 �� Property
 �� Value7   1RedEmpleoOffLine.Helpers.ErrorsToMessageConverter  eToMConverter5   /RedEmpleoOffLine.Model.ErrorCollectionConverter  ErrorCollectionConverter  textBoxInError �� 	Resources �� Self �� RelativeSource �� Path �� 	Converter��%�  &	        &	 r     '�� �     &	 �    &	 �    &	 �    7  �� 5   
   .R�5      ]� .+�5      �� 
���  ��$��20(�6-   !6>   �� 5      5      5      �� 5   
   .R�5      ]� ��. .+�5      �� 
���  ��$��1q�6+   ._�5      �� 5      5      5      �� 5   
   " ��6    5      P� 5       �@J�IsMouseOver . . �5      �� 	 � ��
 �#FFDEDD63   5      P� 5       �@J�	IsFocused . . �5      �� 	 � ��
 �#FFDEDD63   5      5!        5"   
   6C     5#   
   6)   �� 5$   
   " ��6'    5%      ���� 5&      '��       " ��6   .�5'      �� 	 � ��
 5(      �� 5)      .R�5*   "   �� ��6,   �� *ErrorContent+5+      5-      5.      5/       50      P� 51       �@=�HasError . . �52      �� 	 �@�ToolTip
 60   �� # Z $2 ,(Validation.Errors).CurrentItem.ErrorContent�8   53      55      56      .��57      � $��Center=�6   $
��1090��6(    � DataContext 58   
   #   RedEmpleoOffLine.Model.Person  59      .+�5;   
   �� -   5         ��Name$
 Logo��5;      $
��Left=�6    $��59��6;   $	��Top=�6G   $	��150��6_   $��
571,17,0,0q�6k   �� 5<   
   $��SOLICITUD DE INSCRIPCIÓN��6   $
��Left=�63   $��	22,15,0,0q�6N   $	��Top=�6a   $	��199��6y   ���	#FFDD1721$��14(�6�   
�������6�   �� 5=   
   $��(*) campos obligatorios��6   $
��Left=�62   $��
374,19,0,0q�6M   $	��Top=�6a   $��25��6y   $	��134��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   �� 5>   
   $����Diligencie la ficha con los datos y presione en el botón enviar para confirmar el registro.
En caso de dificultad en el diligenciamiento de la información por favor contáctenos��6   $
��Left=�6�   $��	22,44,0,0q�6�   $	��Top=�6�   $	��487��6  $��48��6!  ���	#FFE4FDF5���	#FF0202026D  �� 5?   
   $��DATOS PERSONALES��6   $
��Left=�6+   $��	22,93,0,0q�6F   $	��Top=�6Y   $	��199��6q   ���	#FFDD1721$��14(�6�   
�������6�   �� 5@   
   $��Primer Nombre*��6   $
��Left=�6)   $��
22,131,0,0q�6D   $	��Top=�6X   $ -2.789,0.327&�6p   �� 5A   
   $��Segundo Nombre��6   $
��Left=�6)   $��
22,169,0,0q�6D   $	��Top=�6X   �� 5B   
   $��Primer Apellido*��6   $
��Left=�6+   $��
22,213,0,0q�6F   $	��Top=�6Z   �� 5C   
   $��Segundo Apellido��6   $
��Left=�6+   $��
22,251,0,0q�6F   $	��Top=�6Z   �� 5D   
   $��Sexo* ��6   $
��Left=�6!   $��
22,291,0,0q�6<   $	��Top=�6P   �� 5E   
   $��Tipo Documento*��6   $
��Left=�6*   $��
22,332,0,0q�6E   $	��Top=�6Y   �� 5F   
   $��Número Documento*��6   $
��Left=�6,   $��
22,379,0,0q�6G   $	��Top=�6[   �� 5G   
   $��Repetir Número*��6   $
��Left=�6*   $��
22,420,0,0q�6E   $	��Top=�6Y   �� 5H   
   $&�� Fecha de Nacimiento*(dd/mm/aaaa)��6   $
��Left=�6;   $��
22,466,0,0q�6V   $	��Top=�6j   �� 5I   
   $��Correo Electrónico*��6   $
��Left=�6.   $��563,381,0,0q�6I   $	��Top=�6^   �� 5J   
   $!��Repite Correo Electrónico*��6   $
��Left=�65   $��565,419,0,0q�6P   $	��Top=�6e   �� 5K   
   -   5        $��PrimerNombre��5K      $
��Left=�6�   $��20��6�   $��228,131,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��280��6  ��6&   �� *PrimerNombre+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors .  �� NotifyOnValidationError . 6  �� 5L   
   $��228,153,582,429q�6   
���  ��$
��Bold"�6?   ��6S   ��  �� ElementName$ PrimerNombre��$2 ,(Validation.Errors).CurrentItem.ErrorContent�# [ �� 5M   
   -   5        $��SegundoNombre��5M      $
��Left=�6�   $��20��6�   $��228,171,0,0q�6�   $
 Wrap=�6�   $	��Top=�6  $	��280��6  ��6'   �� *SegundoNombre+$ TwoWay=�$ PropertyChanged=� .  . 6  �� 5N   
   -   5        $��SegundoNombreError��5N      $��228,193,582,399q�6/   
���  ��$
��Bold"�6Z   ��6n   �� *.,(Validation.Errors).CurrentItem.ErrorContent+# [ $ SegundoNombre���� 5O   
   -   5        $��PrimerApellido��5O      $
��Left=�6�   $��20��6�   $��228,213,0,0q�6�   $
 Wrap=�6�   $	��Top=�6  $	��280��6  ��6(   �� *PrimerApellido+$ TwoWay=� . $ PropertyChanged=� . 6  �� 5P   
   $��228,235,582,357q�6   
���  ��$
��Bold"�6?   ��6S   �� $ PrimerApellido��$2 ,(Validation.Errors).CurrentItem.ErrorContent�# [ �� 5Q   
   -   5        $��SegundoApellido��5Q      $
��Left=�6�   $��20��6�   $��228,253,0,0q�6�   $
 Wrap=�6�   $	��Top=�6  $	��280��6   ��6*   �� *SegundoApellido+$ TwoWay=� . $ PropertyChanged=� . 6   �� 5R   
   -   5        $��SegundoApellidoError��5R      $��228,274,582,318q�61   
���  ��$
��Bold"�6\   ��6p   �� *.,(Validation.Errors).CurrentItem.ErrorContent+# [ $ SegundoApellido��	� 5S   
   -	   5        $��Femenino��5S       	� 	GroupName$
 Sexo��6&   $��Femenino��67   $
��Left=�6J   $��230,298,0,0q�6e   $	��Top=�6z   $ 	0.218,0.4&�6�   	� 5T   
   -
   5        $��	Masculino��5T      $
 Sexo��6'   $��	Masculino��68   $
��Left=�6L   $��334,298,0,0q�6g   $	��Top=�6|   $ 	0.218,0.4&�6�   �� 5U   
   -   5        $
��Sexo��5U      $��Campo sexo es obligatorio��6    $��228,315,0,0q�6A   $y�Hidden=�6V   
���  ��$
��Bold"�6|   �� 5V   
   -   5        $��TipoDocumento��5V      $
��Left=�6(   $��228,335,0,0q�6C   $	��Top=�6X   $	��280��6p    �� Text$ Seleccione Tipo Documento��6|   $��20��6�   .@�5W      �� 
 � Tag$ CC��6   $��CÉDULA DE CIUDADANÍA��6$   �� 5X      $ TI��6   $��TARJETA DE IDENTIDAD��6$   �� 5Y      $ PA��6   $��	PASAPORTE��6$   �� 5Z      $ CE��6   $��CÉDULA EXTRANJERÍA��6$   5[      �� 5\   
   -   5        $��TipoDocumentoError��5\      $)��#Campo Tipo Documento es obligatorio��6.   $��228,356,0,0q�6Y   $y�Hidden=�6n   
���  ��$
��Bold"�6�   �� 5]   
   -   5        $��NoDocumento��5]       �� 
IsReadOnly . $
��Left=�6�   $��20��6  $��228,380,0,0q�6  $
 Wrap=�6'  $	��Top=�6;  $	��280��6S  ��67   �� *NoDocumento+ . $ PropertyChanged=� �� NotifyOnTargetUpdated .  �� ValidatesOnExceptions .  . 6S  G� 5^   
   -   5        $��NoDocumentoPASS��5^      $y�Hidden=�6-   $
��Left=�6A   $��20��6\   $��228,380,0,0q�6h   $	��Top=�6}   $	��280��6�   6�   �� 5_   
   $��228,400,581,162q�6   
���  ��$
��Bold"�6?   ��6S   �� $ NoDocumento��$2 ,(Validation.Errors).CurrentItem.ErrorContent�# [ �� 5`   
   -   5        $��RepetirNoDocumento��5`      $
��Left=�6�   $��20��6  $��228,420,0,0q�6  $
 Wrap=�61  $	��Top=�6E  $	��280��6]   J� IsManipulationEnabled .  ��6-   �� *RepetirNoDocumento+$ TwoWay=� . $ PropertyChanged=� .  .  . .��6�  5a      �� 5b   
   -   5        $��RepetirNoDocumentoError��5b      $��228,441,582,149q�63   
���  ��$
��Bold"�6^   ��6r   �� $ RepetirNoDocumento��$2 ,(Validation.Errors).CurrentItem.ErrorContent�# [ (  "System.Windows.Controls.DatePicker  5c   
   -   5        $��FechaNacimiento��5c      $
��Left=�6,   $��229,466,0,0q�6G   $	��Top=�6\   $��26��6�   $	��176��6�   �� 5d   
   $��DATOS DE CONTACTO��6   $
��Left=�6,   $��
563,96,0,0q�6G   $	��Top=�6[   $	��199��6s   ���	#FFDD1721$��14(�6�   
�������6�   �� 5e   
   $��Departamento*��6   $
��Left=�6(   $��563,132,0,0q�6C   $	��Top=�6X   �� 5f   
   $��Ciudad*��6   $
��Left=�6"   $��563,175,0,0q�6=   $	��Top=�6R   �� 5g   
   $��Dirección*��6   $
��Left=�6%   $��563,220,0,0q�6@   $	��Top=�6U   $ 	0.5,0.096&�6m   �� 5h   
   $��Barrio��6   $
��Left=�6!   $��563,261,0,0q�6<   $	��Top=�6Q   �� 5i   
   $��Número de Teléfono*��6   $
��Left=�6.   $��563,302,0,0q�6I   $	��Top=�6^   �� 5j   
   $#��Número de Teléfono celular*��6   $
��Left=�66   $��563,341,0,0q�6Q   $	��Top=�6f   �� 5k   
   -   5        $��ListDepartamento��5k      $
��Left=�6,   $��770,132,0,0q�6G   $	��Top=�6\   $	��280��6t   $  ��6�   6�   �� 5l   
   -   5        $��DepartamentoError��5l      $��778,77,32,503q�6/   $y�Hidden=�6G   
���  ��$
��Bold"�6l   $&�� Campo departamento es obigatorio��6�   �� 5m   
   -   5        $��Ciudad��5m      $
��Left=�6!   $��770,176,0,0q�6<   $	��Top=�6Q   $	��280��6i   $  ��6u   �� 5n   
   -   5        $��CiudadError��5n      $y�Hidden=�6(   $��778,121,32,462q�6=   
���  ��$
��Bold"�6g   $ ��Campo ciudad es obigatorio��6{   �� 5o   
   -   5        $��	Direccion��5o      $
��Left=�6#   $��20��6>   $��770,220,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��280��6�   ��6�   �� *	Direccion+$ TwoWay=� . $ PropertyChanged=� .  .  . �� 5p   
   -   5        $��DireccionError��5p      $��770,241,43,338q�6+   
���  ��$
��Bold"�6U   ��6i   �� *.,(Validation.Errors).CurrentItem.ErrorContent+# [ $ 	Direccion���� 5q   
   -   5        $��Barrio��5q      $
��Left=�6    $��20��6;   $��770,261,0,0q�6G   $
 Wrap=�6\   $	��Top=�6p   $	��280��6�   ��6�   �� *Barrio+$ TwoWay=� . $ PropertyChanged=� .  .  . �� 5r   
   -   5        $��BarrioError��5r      $��770,282,40,305q�6(   
���  ��$
��Bold"�6R   ��6f   �� *.,(Validation.Errors).CurrentItem.ErrorContent+# [ $ Barrio���� 5s   
   -   5        $��Telefono��5s      $
��Left=�6"   $��20��6=   $��770,302,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��280��6�   ��6�   �� *
Telefono+$ TwoWay=� . $ PropertyChanged=� .  .  . �� 5t   
   -   5        $��TelefonoError��5t      $��731,321,40,266q�6*   
���  ��$
��Bold"�6T     =� ErrorTemplate#  [  6f   ��6�   �� *.,(Validation.Errors).CurrentItem.ErrorContent+# [ $ Telefono���� 5u   
   -   5        $��Celular��5u      $��20��6!   $��770,341,40,0q�6-   $
 Wrap=�6C   $	��Top=�6W   ��6p   �� *	Celular+$ TwoWay=� . $ PropertyChanged=� .  .  . �� 5v   
   -   5        $��CelularError��5v      $��770,362,40,220q�6)   
���  ��$
��Bold"�6S   ��6g   �� *.,(Validation.Errors).CurrentItem.ErrorContent+# [ $ Celular���� 5w   
   -   5        ! ��Name$! CorreoElectronico��5w      $
��Left=�6.   $��20��6I   $��770,382,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $	��280��6�   ��6�   �� *CorreoElectronico+$ TwoWay=�$ PropertyChanged=� .  . �� 5x   
   $��770,404,40,180q�6   
���  ��$
��Bold"�6>   ��6R   �� $ CorreoElectronico��$2 ,(Validation.Errors).CurrentItem.ErrorContent�# [ �� 5y   
   -    5        $��CorreoElectronicoRepeat��5y      $
��Left=�61   $��20��6L   $��770,422,0,0q�6X   $
 Wrap=�6m   $	��Top=�6�   $	��280��6�   ��6�   �� *CorreoElectronicoRepeat+$ TwoWay=�$ PropertyChanged=� .  . �� 5z   
   $��770,444,40,62q�6   
���  ��$
��Bold"�6=   ��6Q   �� $ CorreoElectronicoRepeat��$2 ,(Validation.Errors).CurrentItem.ErrorContent�# [ �� 5{   
   -!   5        $ 	Logo_back��5{      $
��Left=�6#   $��94��6>   $��
-3,526,0,0q�6J   $	��Top=�6^   $
��1090��6v   �� 5|   
   -"   5        " ��Name$" GuardarPersona��5|      $��Guardar Cambios��6)   $
��Left=�6C   $��573,484,0,0q�6^   $	��Top=�6s   $	��182��6�   $��42��6�   $��1q�6�   ���	#FFDD1721���	#FF400909��. $��RightToLeft=�6   $��Center=�6<  $��24(�6^  $��SemiCondensed&�6l  # � IsSharedSizeScope# . $��Arial)�6�  $
��Bold"�6�  &   System.Windows.Media.TextOptions$   TextFormattingMode$$ Display=�6�  }�. % J� SnapsToDevicePixels% . ��5}      �� 5~      & �� EndPoint$& 0.5,1&�6&   ' � MappingMode$' RelativeToBoundingBox=�67   ( �� 
StartPoint$( 0.5,0&�6[   .��5      � ) � Color$) Black��6#   � 5�      $) White��6#   * � Offset$
* 0.13Q�61   5�      + J� Effect+ 5�      3  -System.Windows.Media.Effects.DropShadowEffect  5�      ,   Color$, 	#FF763D3D��6#   ��5�      �� 5�      - �� 
TargetType"- ��6"   .R�5�      �� . ��Name$. Border��6   / �� CornerRadius$/ 1,8,1,8��6-   $��2q�6D   ���	#FFDD1721���	#FFDD1721}�. + 5�        5�      $, 	#FF873434��6/   ._�5�      �� $��2q�6+   $��Center=�66   $��Center=�6S   ��. 0 J� OpacityMask0 5�      �� 5�   "   $& 0.5,1&�66   $( 0.5,0&�6G   1 � ColorInterpolationMode$1 ScRgbLinearInterpolation=�6Z   .��5�   &   � $) 	#FF700F0F��63   $* 0Q�6E   � 5�   &   $) 	#FFE22E2E��63   $* 1Q�6E   5�   #   5�      5�      2 �� Triggers2 5�      P� 5�       �@J�IsKeyboardFocused . . �5�      �� 3 �� 
TargetName$3 Border��6%   	 � ��

 �����6P   5�      P� 5�       �@J�IsMouseOver . . �5�      �� $3 Border��6%   	 � ��

 �  ��6O   5�      P� 5�       � �� . . �5�      �� $3 Border��6%   	 � ��
 �	#D79100006O   �� 5�      $3 Border��6%   	 � ��
 �	#FF6E51516P   5�      5�      5�      �� 5�   
   -#   5        $��Volver al Listado��5�      $
��Left=�6.   $	��Top=�6J   $	��242��6b   $��23��6n   $��
22,514,0,0q�6{   ��5�      �� 5�      $& 0.5,1&�6&   $' RelativeToBoundingBox=�67   $( 0.5,0&�6[   .��5�      � $) Black��6#   � 5�      $) White��6#   $
* 0.13Q�61   5�      + 5�        5�      $, 	#FF763D3D��6#   ��5�      �� 5�      "- ��6"   .R�5�      �� $. Border��6   $/ 1,8,1,8��6-   $��2q�6D   ���	#FFDD1721���	#FFDD1721}�. + 5�        5�      $, 	#FF873434��6/   ._�5�      �� $��2q�6+   $��Center=�66   $��Center=�6S   ��. 0 5�      �� 5�   "   $& 0.5,1&�66   $( 0.5,0&�6G   $1 ScRgbLinearInterpolation=�6Z   .��5�   &   � $) 	#FF700F0F��63   $* 0Q�6E   � 5�   &   $) 	#FFE22E2E��63   $* 1Q�6E   5�   #   5�      5�      2 5�      P� 5�       �@J�IsKeyboardFocused . . �5�      �� $3 Border��6%   	 � ��

 �����6P   5�      P� 5�       �@J�IsMouseOver . . �5�      �� $3 Border��6%   	 � ��

 �  ��6O   5�      P� 5�       � �� . . �5�      �� $3 Border��6%   	 � ��
 �	#D79100006O   �� 5�      $3 Border��6%   	 � ��
 �	#FF6E51516P   5�      5�      5�      �� 5�   
   -$   5        $��Volver��5�   !   4 K� ZIndex$4 2��6   $��23��6/   $��63,516,1005,0q�6;   $	��Top=�6R   $ -18.125,0.5&�6j   5�      5�      