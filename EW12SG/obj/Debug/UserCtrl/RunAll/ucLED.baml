   M S B A M L   `   `   `  ����A  =EW12SG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:EW12SG.UserCtrlEW12SG.UserCtrl  5          EW12SG.UserCtrl.ucLED   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:EW12SG.UserCtrl     5      
�������.��5
      �� ���#777777$��1,1,1,1q�6#   ._�5   
   �� $��	10,20,5,5q�6     � 	Resources  5       �� 
TargetType �� Property �� Value��%�   '	�       �� 5      " 	�6   .�5      ��  � ��$ 15(�61   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ Center=�6:   -   5        5      5      .+�5      �� ���#777777$��0,0,0,1q�6+   $��0,10,0,5q�6E   ��5      �� 5      " ��6   .�5      ��  � ��
 �����67    �� Triggers 5      �� 5       �� Binding 6*   ��  �� Path$ ValidateLed� �� Value
 Passed6O   .a�5   "   ��  � �� �#18de3d6?   5      �� 5       6*   �� $ ValidateLed�
 Failed6O   .a�5   "   ��  � �� �#de4a186?   5       5"      ._�5$      � .+�5%      �� $��15(�6   $��KIỂM TRA LED WAN��6*   $	��200��6E   $��SemiBold"�6Q   � 5&      $��	-60,0,0,0q�6    $	��130��63   .+�5'      �� $��15(�6    $��0,0,0,0q�6.   $��( ��6?   $��SemiBold"�6L   �� 5(      $��15(�6    $��-7,0,0,0q�6.   
���  ��$��SemiBold"�6�   ��6Q   �� $ TimeOutValidateLedWan� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5)      $��15(�6    $��-7,0,0,0q�6.   $�� sec )��6@   $��SemiBold"�6Q   5*      	� 5+      -   5        	 	�Name$	 rbPassed��5+   "   {�. 

 � Tag$
 ledwan_passed��6E   $��30,0,0,0q�6Y   $��Passed��6k   	� 5,      -   5        $	 rbFailed��5,   "   {�. $
 ledwan_failed��6E   $��30,0,0,0q�6Y   $��Failed��6k   5-      5.      �� 5/      .+�50      �� $��0,10,0,0q�6   
��� ���$
��Wrap=�6B   $��13(�6V   $"Quan sát trạng thái đèn WAN:52      �� 53       �� 
IsReadOnly . $��0q�6,   
��� ��� �� TextWrapping$
 Wrap=�6T   $��10,7,0,0q�6h   $��13(�6{   $N��H- Nếu đèn WAN đổi màu tắt, xanh, đỏ => click chọn Passed.��54      �� 55       . $��0q�6,   
��� ���$
 Wrap=�6T   $��	10,0,0,10q�6h   $��13(�6|   $?��9- Các trường hợp còn lại => click chọn Failed.��56      58      5;      5<      5>      