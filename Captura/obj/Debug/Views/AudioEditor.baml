   M S B A M L   `   `   `  ����A  =51live, Version=4.2.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CapturaCaptura  5   	       Captura.AudioEditor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   !localclr-namespace:Captura  5   	     � Title$
  Crop��5   	   $	��300��5   	   $	��300��5   	    � DataContext 5	      "   Captura.AudioEditorViewModel  5
   
    � 	Resources 5      (   "Captura.TimeSpanToSecondsConverter   TimeSpanToSecondsConverter��%   &	          5   
   6+   5      .��5      �� $��5q�6   .+�5   
   ��  �� ContentStringFormat$ Duration: {0}��5      ��5      �� *
Duration+5      #  Xceed.Wpf.Toolkit.RangeSlider  5   
   $	��0,5q�5         
LowerValue 5      �� *Begin+ �� Mode$ TwoWay=� �� 	Converter# [     HigherValue 5      �� *End+$ TwoWay=�# [     Maximum 5      �� *
Duration+$ TwoWay=�# [  5      ]� 5   
   $	��0,5q�6   ��.  .+�5      �� ��6   �� *Begin+�� 5      $��Right=�5      ��5      �� *End+5      5      � 5   
   	 � ColumnDefinitions	 5       �� 5!      �� 5"      .+�5%      �� $��5q�6   $��Reset��5&      ��5'      �� *ResetCommand+�� 5)      $��5q�6   $
��Crop��5*      $��1��5,      ��5+      �� *CropCommand+5,      5-      5.      5/      