   M S B A M L   `   `   `  ����A  =51live, Version=4.2.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CapturaCaptura  5          Captura.AboutView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      'localclr-namespace:Captura     5        � DataContext  5         Captura.AboutViewModel  5   
   .��5      �  � 	Resources 5	   
    �� 
TargetType �� BasedOn �� Property �� Value��%x   '��       7���� 5
      " ��6   8   .�5      ��  �@��Command 6,   �� *HyperlinkCommand+5      5      .+�5   
   �� .��5      �� $	��150��6   $��10q�5      .+�5      �� $
��Wrap=�6    �� 
LineHeight$ 30��5         	TextColor#��[  5      �� 5      $��20(�6   �6(      Captura.Loc  *	AppName+ �� 6F   �6J   �� *
AppVersion+ �� Mode$ OneWay=��� 6u   	(c) 2017 �� 5       �� CommandParameter$% https://github.com/MathewSachin��6)   .�6\   Mathew Sachin6k   5      ]� 5      $��0,0,0,10q�6   .+�5      �� $��Bottom=�6    $��Right=�5       �� 5      $> 8https://github.com/MathewSachin/Captura/wiki/Translation��6$   .�6p   .�5      �� �6"     *WantToTranslate+5      5      �� 5      	 �� ContentStringFormat$
	 {0}:��5       $��0,0,16,5q�5!      ��5        *
Language+5!      �� 5"      $��Center=�6   $��0,0,0,5q�5#      
 �� DisplayMemberPath$
 DisplayName��5&      ��5$      �� *	Languages+ �� SelectedValue 5%      �� *
Language+$ TwoWay=�5&      5'      � 5)      $
��0,10q�6    � ColumnDefinitions 5*      �� 5+      �� 5,      �� 5-      .+�5/      �� $.��(https://github.com/MathewSachin/Captura/��50      $��3q�52      ��5/      �� *HyperlinkCommand+��51        *Source+52      �� 53      $<��6https://github.com/MathewSachin/Captura/wiki/Changelog��54      $��1��56      $��3q�57      ��53      �� *HyperlinkCommand+��55        *	Changelog+57      �� 58      $9��3https://github.com/MathewSachin/Captura/wiki/Donate��59      $��2��5;      $��3q�5<      ��58      �� *HyperlinkCommand+��5:        *Donate+5<      5=      �� 5?      $
��Wrap=�6   $
��0,10q�5@      #��[  5A      Powered by �� 5B   (   $, &https://github.com/MathewSachin/Screna��62   .�6l   Screna6t   5C      5D      5E      5F      5G      