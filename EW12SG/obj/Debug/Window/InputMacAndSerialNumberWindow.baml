   M S B A M L   `   `   `  ����A  =EW12SG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:EW12SGEW12SG  5   	   *    $EW12SG.InputMacAndSerialNumberWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:EW12SG     5   	     � Title$M  GNhập địa chỉ mac và serial number của sản phẩm cần test��5   	   $	��300��6I   $	��500��6V    � WindowStartupLocation$ CenterScreen=�6b    � 
ResizeMode$ NoResize=�6�    � 	Resources 5
       �� 
TargetType �� Property �� Value �� Triggers P� Property	 P� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��
 �����6+    5      P� 5       �@J�	IsFocused	 . . �5      ��  � ��
 � ���63   5      5      5      .��5      �� $��5q�6   .+�5   
   �� $��15(�6   $
��Wrap=�6"   ${��uVui lòng nhập địa chỉ MAC, Serial Number của sản phẩm cần kiểm tra vào textbox bên dưới đây.��66   �� 5   
   
����  �$��0,5,0,0q�6"   $��Nhập địa chỉ MAC:��63   $��SemiBold"�6O   �� 5   
   -   5        
 ��Name$
 txtID��5      $��30��6!   $��Center=�6-   $
��Left=�6O   $��20(�6q   $��SemiBold"�6   ��5      ��  �� Path$ MacEthernet� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   
����  �$��0,5,0,0q�6"   $ ��Nhập số Serial Number:��63   $��SemiBold"�6T   �� 5   
   -   5        $
 txtSN��5      $��30��6!   $��Center=�6-   $
��Left=�6O   $��20(�6q   $��SemiBold"�6   ��5      �� $ SerialNumber�$ PropertyChanged=��� 5    
   
����  �$��0,0,0,0q�6"   $��Message:��63   $��SemiBold"�6F   �� 5!   
   $
��Wrap=�6   
���  ����69   �� $ Error�$ PropertyChanged=�5"      5$      