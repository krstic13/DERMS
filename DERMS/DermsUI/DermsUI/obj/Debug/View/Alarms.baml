   M S B A M L   `   `   `  ����B  >DermsUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:DermsUI.ViewDermsUI.View  5      5clr-namespace:DermsUI.ViewModelDermsUI.ViewModel  5      1clr-namespace:dCom.ConvertersdCom.Converters  5          DermsUI.View.Alarms   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:DermsUI.View     5      5	ViewModelclr-namespace:DermsUI.ViewModel     5      4
convertersclr-namespace:dCom.Converters     5        � DataContext  5      '  !DermsUI.ViewModel.AlarmsViewModel  5   
   6&    � 	Resources 5      5   /dCom.Converters.ConnectionStateToColorConverter   ConnectionStateToColor1   +dCom.Converters.StringToVisibilityConverter  StringToVisibility5   /dCom.Converters.AlarmToBackgroundColorConverter  AlarmToBackgroundColor��%W   &	        &	      &	 &       5   
   65     5   
   61     5   
   65   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgPoints��5         SelectionMode$ Single=�5   2      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserResizeRows .     SelectionUnit$ FullRow=�5      ��5      �� *Points+	 �� SelectedItem	 5      �� *SelectedDataItem+
 J� InputBindings
 5      d� 5        d� MouseAction$ LeftDoubleClicke�6    �� Command 6=   �� *SelectedPointCommand+ �� CommandParameter 6f   �� *Points+6�      Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6^   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 63   �� *Name+6^     5$      $
 Type��6%    . $ * 6^    63   �� *Type+6^     5%      $ Address��6%    . $ * 6{    66   �� *	Address+ �� StringFormat$ {0:d5}��6{     5&      $ Value��6%    . $ * 6g    64   �� *DisplayValue+6g     5'      $ 	Raw Value��6%    . $ * 6g    68   �� *
RawValue+6g     5(      $ 	Timestamp��6%    . $ * 6h    68   �� *	Timestamp+6h     5)      $ Alarm��6%    . $ * 6`    64   �� *Alarm+6`     5*      $	 Gid��6%    . $ * 6\    62   �� *Gid+6\   5,      �� 5.   
   $��2��6   $��2��6!   .@�5/      �� .��50      ��  �� Orientation$ 
Horizontal=�6   .+�51      �� $��Current Time: ��6   �� 52      .��53      �� ��6$   ��  �� Path$ CurrentTime�$ {0:dd/MM/yyyy hh:mm:ss}��54      55      56      �� 57      .��58      �� $ 
Horizontal=�6   .+�59      �� $��Elapsed Time: ��6   �� 5:      .��5;      �� ��6$   �� $ ElapsedTime�5<      5=      5>      �� 5?      .��5@      ��  J� Opacity$	 0.9Q�6   ��6   �� *ConnectionState+ �� 	Converter# [  ._�5A      �� $ 
Horizontal=�6!   .+�5B      �� $��Connection status: ��6    $
��Bold"�6>   �� 5C      .��5D      �� $
��Bold"�6N   ��6(   �� $ ConnectionState�6N   5E      5F      5G      5H      5I      5J      5K      