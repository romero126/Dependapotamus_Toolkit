   M S B A M L   `   `   `  ����M  IUI.Elements, Version=1.0.6463.29914, Culture=neutral, PublicKeyToken=nullD1clr-namespace:UI.Elements.UX;assembly=UI.ElementsUI.Elements.UX  5       UI.Body.PSHostUI+   %UI.Body.PSHostUI.UX.Settings.PSCmdlet   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ?T1clr-namespace:UI.Elements.UX;assembly=UI.Elements     5      -   5        .��5      � .+�5         UI.Elements.UX.Settings  -   5           Name$  Settings��5         Title$ Commandlet Options��5	      $y�Visible=�6*      Children. 5      "   UI.Elements.UX.Settings_Page     guid$ 1��6      Title$ Settings��5         Icon$, &..\..\Images\Light\appbar.settings.png��5         Children. 5      �� .+�5      �� ��6   �� *ID+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�    UI.Elements.UX.TextControl  5      	   Text$	 Name:��6   
   value
 6"   �� *NAME+$ TwoWay=�$ PropertyChanged=�  5      $	 Description:��6   
 6)   �� *DESC+$ TwoWay=�$ PropertyChanged=��� 5      $��Center=�6    �� Orientation$ 
Horizontal=�6/   .+�5         UI.Elements.UX.FlatButton  -   5        $	��150��5         Text$
 Save��6!      BackgroundColor
 � � �   HoverBackgroundColor
 � d �6f   � 5      $��20��6     5      -   5        $	��150��5      $ Delete��6!   
 �  ��
 �  ��6d   5      5      5        5      $ 2��6   $ Script Editor��6   $+ %..\..\Images\Light\appbar.console.png��64   . 5      �� $��25,25,25,25q�5      
����=H� �� CornerRadius$ 5,5,5,5��5      ._�5      � $��10,10,10,10q�5      .+�5       �� 
����=H�
����=H�
������� �� AcceptsReturn . ��5"      �� *SCRIPT+$ TwoWay=�$ PropertyChanged=�5%      5&      5'      5(      5)      5*      5+      