   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   I EWpfTaskProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfTaskProjectWpfTaskProject 5   	      WpfTaskProject.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   .localclr-namespace:WpfTaskProject     5   	   $	��450��5	   4   $	��800��6A     � Title  6	   �� *WindowTitle+ �� Mode$ OneWay=� � DataContext 5
   	   �� *Main+   Locator �� Source# [  .��5      � .   (System.Windows.Interactivity.Interaction   Triggers 5   
   /   )System.Windows.Interactivity.EventTrigger  5         	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      6   0System.Windows.Interactivity.InvokeCommandAction     Command 6(   �� *loadCommand+5       � RowDefinitions 5   
   �� 5      $
��341* �6   �� 5      $	��80* �6   	 � ColumnDefinitions	 5   
   �� 5      $
��163* �6   �� 5      $
��163* �6   �� 5      $
��467* �6   .+�5   
   &   System.Windows.Controls.DataGrid  $��10q�6   
   AutoGenerateColumns
 .  $��3��6j   ��6   �� *personalInfoCollection+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6%      Header$ 
First Name��62   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6F   �� *	FirstName+  5      $
 Auto 6%   $ 	Last Name��62    6E   �� *
LastName+  5      $
 Auto 6%   $ Street Name��62    6G   �� *
StreetName+  5      $
 Auto 6%   $ House Number��62    6H   �� *HouseNumber+  5       $
 Auto 6%   $ Aparment Number��62    6K   �� *ApartmentNumber+  5!      $
 Auto 6%   $ Postal Code��62    6G   �� *
PostalCode+  5"      $
 Auto 6%   $ Phone Number��62    6H   �� *PhoneNumber+  5#      $
 Auto 6%   $ Date of birth��62    6I   �� *
DateString+  5$      $
 Auto 6%   $	 Age��62      
IsReadOnly .  6?   �� *Age+6W   5&      �� 5'   
   -   5         ��Name$ 
saveButton��5'   8   $��Zapisz zmiany��6L   $��10,10,10.2,10q�6d   $��1��6{   {�6   ��  �� Path$ ChangesMade� 5(        5)      $ Click��6!   . 5*         6,   �� *saveCommand+5+      5-      �� 5.   
   -   5        $ cancelButton��5.   8   $��Cancel��6N   $��1��6_   $��10q�6o   $��1��6{   {�6   �� $ ChangesMade� 5/        50      $ Click��6!   . 51         6,   �� *loadCommand+52      54      56      57      