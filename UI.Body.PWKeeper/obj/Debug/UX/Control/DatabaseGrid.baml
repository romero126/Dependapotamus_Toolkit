   M S B A M L   `   `   `  ����M  IUI.Elements, Version=1.0.6463.29914, Culture=neutral, PublicKeyToken=nullD1clr-namespace:UI.Elements.UX;assembly=UI.ElementsUI.Elements.UX  5       UI.Body.PWKeeper.   (UI.Body.PWKeeper.UX.Control.DatabaseGrid   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ?T1clr-namespace:UI.Elements.UX;assembly=UI.Elements     5      .��5      � .+�5   
   ��   �� CornerRadius$  0,5,5,0��6   
������� J� Opacity$ 1Q�6?   ._�5   	   �  � RowDefinitions 5   
   �� 5	      $��30 �6   �� 5
      $��* �6   �� 5      $��40 �6   .+�5   
   � $��0��6   5      � 5   
   $��1��6   .+�5      �� 
���   �$��0,2,0,2q�6&   ._�5      &   System.Windows.Controls.DataGrid  -   5        $	��LOG��5         AutoGenerateColumns .     SelectionMode$ Single=�6=   $��Stretch=�6T   $��Stretch=�6r   $��0,0,0,0q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Title��6!      
IsReadOnly . 6E     5      $ Domain��6!    . 6E     5      $
 Name��6!    . 6C     5      $ Password��6!    . 6G     5      $	 URL��6!    . 6B     5      $ Email��6!    . 6D     5      $ Description��6!      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 66   6B     5      $ Comments��6!   $ * 63   6?   5       5!      5"      � 5#   
   $��2��6   .+�5$      �� 	 �� Orientation$	 
Horizontal=�6   $��Center=�6/   $��5q�6L   .+�5%         UI.Elements.UX.FlatButton  $��75��6   
   Text$

 Edit��6$      BackgroundColor
 � � �6J   � 5&      $��10��6     5'      $��75��6   $
 	SmartClip��6$   
 � � �6O   5(      5)      5*   
   5+   	   5-      5.      