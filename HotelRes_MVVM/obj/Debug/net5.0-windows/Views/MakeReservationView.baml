   M S B A M L   `   `   `  ����H  DHotelRes_MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HotelRes_MVVM.ViewsHotelRes_MVVM.Views  5      -    'HotelRes_MVVM.Views.MakeReservationView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:HotelRes_MVVM.Views     5      .��5	      �   � IsSharedSizeScope$
  True��6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��1��6   $��Make Reservation��5       
  Header#��[  5      � 5   
   $��1��6   $��0,45,0,0q�6    5      �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��0��6   $��Username��6%   �� 5      $��1��6   $��0,5,0,0q�5      ��5       �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5!      � 5#   
   $��2��6   $��0,10,0,0q�6    5$      �� 5%      $
��auto �6    �� 5&      $
��auto �6     � ColumnDefinitions 5(      �� 5)      $
��auto �6#    z� SharedSizeGroup$ FirstColumn��60   �� 5*      $
��auto �6#   $ SecondColumn��60   .+�5-      �� $��0��6   $��0��5.      $��	Floor No.��5/      �� 50      $��1��6   $��0��51      $��0,5,0,0q�53      ��52      �� *FloorNumber+$ PropertyChanged=�53      �� 55      $��0��6   $��1��56      $��10,0,0,0q�57      $��Room No.��58      �� 59      $��1��6   $��1��5:      $��10,5,0,0q�5<      ��5;      �� *
RoomNumber+$ PropertyChanged=�5<      5>      � 5@   
   $��3��6   $��0,10,0,0q�6    5A      �� 5B      $
��auto �6    �� 5C      $
��auto �6     5E      �� 5F      $
��auto �6#   $ FirstColumn��60   �� 5G      $
��auto �6#   $ SecondColumn��60   .+�5J      �� $��0��6   $��0��5K      $��
Start Date��5L      (  "System.Windows.Controls.DatePicker  5M      $��1��6   $��0��5N      $��0,5,0,0q�5O         SelectedDate 5P      �� *	StartDate+$ PropertyChanged=��� 5R      $��0��6   $��1��5S      $��10,0,0,0q�5T      $��End Date��5U        5V      $��1��6   $��1��5W      $��10,5,0,0q�5X       5Y      �� *	EndDate+$ PropertyChanged=�5[      �� 5]   
    �� Orientation$ 
Horizontal=�6   $��0,25,0,0q�5^      $��4��5_      .+�5`      �� $��Submit��6   ��5a      �� *SubmitCommand+�� 5b      $��10,0,0,0q�6   $��Cancel��5c      ��5d      �� *CancelCommand+5e      5i      5j      