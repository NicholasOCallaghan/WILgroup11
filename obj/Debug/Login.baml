   M S B A M L   `   `   `  ����O  KPayroll Appplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Payroll_AppplicationPayroll_Appplication  5   	        Payroll_Appplication.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Payroll_Appplication     5   	     � Title$  Login��5   	   $
��1920��5	   	   $
��1080��5
      
������� � WindowState$ 	Maximized=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��/9496184.png��6   $��516,68,0,-57q�6&   $��2��6<   �� 5   
   $��0��6   ���#42ab49$	��100��63   ._�5      �� .+�5      �� $��Welcome��6   $��Center=�6+   $��Center=�6H   $��50(�6c   $
��Bold"�6q   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6+      	Direction$	 320Q�69      ShadowDepth$ 5Q�6I      Opacity$	 0.5Q�6Y   5      5      5      �� 5"   
   $#��Please log in to your account��6   $��Center=�69   $��0,228,0,586q�6V   
���   �$��30(�6~   $��1��6�   ��5#      �� 5$       �� 
TargetType" ��6   	 �� Triggers	 5%      �� 5&      
 �� Binding
 6&   �� *IsRetracted+ �� Value True6F   .a�5'      ��  �� Property � y� �� Value$ 	Collapsed=�6;   5(      5*      5,      �� 5/   
   $��1��6   ���#c9cba3$��953,334,653,258q�63    �� CornerRadius$ 	0,10,10,0��6L    50        51      $
 Gray��6#   $	 320Q�60   $ 5Q�6@   $	 0.5Q�6P   ._�53      � $��20q�6    54      �� 55      $
��Auto �6$   �� 56      $
��Auto �6$   .+�5:      �� $��Username��6   $��18(�6,   $
��Bold"�6:   $��0,5,0,5q�6L   �� 5;      -   5         ��Name$ txtUsername��5;      $��0��6/   $�� ��6<   $	��Top=�6D   $��16(�6\   $��5q�6j   $��0,37,0,0q�6v   �� 5>      $��Password��6   $��18(�6,   $
��Bold"�6:   $��
0,100,0,10q�6L   G� 5?      -   5         G�Name$ txtPassword��5?      $��1��63   $	��Top=�6@   $��16(�6X   $��5q�6f   $��0,10,0,0q�6r   �� 5A      -   5        $��Login��5A      $��Center=�6C   $��0,98,0,0q�6`   $	��150��6r   $��40��6~   $	��Top=�6�   $��1��6�   ��5B      �� 5C       �� 
TargetType" ��6*   .R�5D      �� $ 10��6%   #��z��67   #��z��6a   #��z��6�   ._�5E   "   �� $��Center=�63   $��Center=�6P   5F       �� Triggers 5G      P� 5H   "    P� Property �@J�IsMouseOver P� Value . . �5I   &   ��  � ��
 �   �6C   5J   #   5L      ��5N      �� 5O      " ��6    .�5P      ��  � �� �#4143466;   �� 5Q       � ��
 �����6;   5R      5T      5U      5V      �� 5W   
   $��1��6   ���#c9cba3$��646,334,960,258q�63   $ 	10,0,0,10��6L    5X        5Y      $
 Gray��6#   $	 230Q�60   $ 5Q�6@   $	 0.5Q�6P   ._�5[      �� $��/My first design (1).png��6   $��0,0,0,0q�66   5\      5]      5^      