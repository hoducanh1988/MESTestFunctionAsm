   M S B A M L   `   `   `  ����A  =EW30SX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:EW30SX.UserCtrlEW30SX.UserCtrl  5      !    EW30SX.UserCtrl.ucButtonWps   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:EW30SX.UserCtrl     5      
�������.��5
      �� ���#777777$��1,1,1,1q�6#   ._�5   
   �� 
�������$��	10,20,5,5q�6(     � 	Resources  5         
radiostyle �� 
TargetType �� Property �� Value��%�   &	        �� 5      " 	�6+   .�5      ��  � ��$ 15(�61   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ Center=�6:   �� 5       � {� . 62   -   5        5      5      .+�5      �� ���#777777$��0,0,0,1q�6+   $��0,0,0,5q�6E   ��5      �� 5      " ��6   .�5      ��  � ��
 �����67    �� Triggers 5      �� 5       �� Binding 6*   ��  �� Path$ 	ButtonWps� �� Value
 Passed6M   .a�5   "   ��  � �� �#18de3d6?   5      �� 5        6*   �� $ 	ButtonWps�
 Failed6M   .a�5!   "   ��  � �� �#de4a186?   5"      5$      ._�5&      � .+�5'      �� $��15(�6   $	��210��6*   $ ��KIỂM TRA NÚT NHẤN WPS��66   $��SemiBold"�6V   � 5(      $��	-10,0,0,0q�6    $��90��63   .+�5)      �� $��15(�6    $��0,0,0,0q�6.   $��( ��6?   $��SemiBold"�6L   �� 5*      $��15(�6    $��-7,0,0,0q�6.   
���  ��$��SemiBold"�6�   ��6Q   �� $ TimeOutValidateButtonWps� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5+      $��15(�6    $��-7,0,0,0q�6.   $�� sec )��6@   $��SemiBold"�6Q   5,      	� 5-      
	 � Tag$	 buttonwps_passed��6"   $��10,0,0,0q�69   $��Passed��6K   ��5.      �� 5/      
 �� BasedOn#
 [  6$   " 	�6J   .�50   "   ��  �@d�	IsChecked$ FalseY�6>    51   "   �� 52   &    62   �� $ 	ButtonWps�
 Passed6U   .a�53   *   ��  �@d�	IsChecked$
 TrueY�6F   54   '   �� 55   &    62   �� $ 	ButtonWps�
 Failed6U   .a�56   *   ��  �@d�	IsChecked$ FalseY�6F   57   '   59      5;      	� 5<      $	 buttonwps_failed��6"   $��30,0,0,0q�69   $��Failed��6K   ��5=      �� 5>      #
 [  6$   " 	�6J   .�5?   "   ��  �@d�	IsChecked$ FalseY�6>    5@   "   �� 5A   &    62   �� $ 	ButtonWps�
 Passed6U   .a�5B   *   ��  �@d�	IsChecked$ FalseY�6F   5C   '   �� 5D   &    62   �� $ 	ButtonWps�
 Failed6U   .a�5E   *   ��  �@d�	IsChecked$
 TrueY�6F   5F   '   5H      5J      5K      5L      �� 5M      $��13(�6    �� 
IsReadOnly . $��0q�66   $��0,10,0,0q�6J   
��� ��� �� TextWrapping$
 Wrap=�6p   $c��]Vui lòng nhấn và nhả nút WPS của sản phẩm và quan sát trạng thái đèn WAN.��5N      �� 5O      $��13(�6    . $��0q�66   
��� ���$
 Wrap=�6^   $��10,7,0,0q�6r   $>��8- Đèn WAN nhấp nháy màu cam => Click chọn Passed��5P      �� 5Q      $��13(�6    . $��0q�66   
��� ���$
 Wrap=�6^   $��	10,0,0,10q�6r   $E��?- Đèn WAN không nhấp nháy màu cam => Click chọn Failed��5R      5S      5T      5V      