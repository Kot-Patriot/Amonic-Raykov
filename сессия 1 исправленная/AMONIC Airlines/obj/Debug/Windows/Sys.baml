   M S B A M L   `   `   `  ����J  FAMONIC Airlines, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AMONIC_Airlines.WindowsAMONIC_Airlines.Windows  5   	   !    AMONIC_Airlines.Windows.Sys   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:AMONIC_Airlines.Windows     5   	     � Title$'  !AMONIC Airlines Automation System��5   	   $	��450��63   $	��800��6@    � 
ResizeMode$ NoResize=�6L    � WindowStartupLocation$ CenterScreen=�6b   .��5	      � .+�5
   
   o� $��Tex Gyre Adventor)�6   .@�5      m� -   5         m�Name$ 
AddUser_MI��5      $��Add user��6+   {�. 6R   m� 5      -   5        $
��Exit��5      6%   5      �� 5   
   $
��Wrap=�6   $��Offices:��6(   $��	10,29,0,0q�68   $��19��6K   $	��Top=�6W   $
��Left=�6o   $��60��6�   $��Tex Gyre Adventor)�6�   �� 5   
   -   5         ��Name$ 
CB_Offices��5       �� DisplayMemberPath$ Title��6B   $	��120��6\   $��	75,26,0,0q�6h   $
��Left=�6{   $��25��6�   $	��Top=�6�   $��Tex Gyre Adventor)�6�   �� 5   
   -   5        $��Change Role��5      $��25,0,675,24q�6>   $��22��6S   $��Bottom=�6_   $��Tex Gyre Adventor)�6z   �� 5   
   -   5        $��Enable/Disable Login��5      $��176,0,469,24q�6I   $��22��6_   $��Bottom=�6k   $��Tex Gyre Adventor)�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DGrid��5      $��25,63,25,61q�6"      AutoGenerateColumns .     
IsReadOnly . $��Tex Gyre Adventor)�6f   ��5      �� 5      	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  6   
 �� Triggers
 5      �� 5       �� Binding 6&   �� *RoleID+ �� Value 16A   .a�5      ��  �� Property � �� �� Value
 ����6;   5      �� 5       6&   �� *Active+	 False6A   .a�5      ��  � ��
 �����6;   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *	FirstName+  5!      $ 	Last Name��6%   $ 73 68    6C   �� *
LastName+  5"      $ Birthday��6%   $ 67 67    6B   �� *	Birthdate+ �� StringFormat$ {0:dd.}{0:MM.}{0:yyyy}��  5#      $ 	User Role��6%   $	 150 68    6D   �� *Roles.Title+  5$      $ Email Address��6%   $	 266 6<    6H   �� *Email+  5%      $ Office��6%   $	 100 65    6A   �� *Offices.Title+5(      5)      5*      