   M S B A M L   `   `   `  ����G  CCaptura.Core, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullM6clr-namespace:Captura.ViewModels;assembly=Captura.CoreCaptura.ViewModels  5   	   
 51live$   Captura.Views.FFMpegDownloader   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Evm6clr-namespace:Captura.ViewModels;assembly=Captura.Core     5   	     � Title$  FFMpeg Downloader��5   	   $	��400��5   	   $	��600��5   	    � 
ResizeMode$ NoResize=�5   	      WindowBackground#���   5	   	    � DataContext 5
      0   *Captura.ViewModels.FFMpegDownloadViewModel  5   
   .��5      ]� $��5q�6   .+�5   
   ]� $	��Top=�6   $��15q�5      .+�5      �� $��0,0,10,0q�6   $��Download Progress��5       �� ContentStringFormat$
 {0}:��5      � 5      $��10��5       � Value 5      �� *
Progress+ �� Mode$ OneWay=�5      5      �� 5   
   $	��Top=�5      $
��0,10q�5      $��Center=�5      $ Status: {0}��5      ��5      �� *Status+5      �� 5   
   $	��Top=�6   $	��0,5q�5       �� TextAlignment$ Center=�5        	TextColor#��[ 5       97FFMpeg adds support for more output formats to Captura.�� 5!   E   OMLatest build of FFMpeg is downloaded. This can also be used to update FFMpeg.�� 5"   [   $"The Download size is nearly 30 MB.5$      ]� 5&   
   $��Bottom=�6   $	��0,5q�5'      .+�5(      �� $��Target Folder��6   $ {0}: ��5)      �� 5*      $��Right=�6   ��5+      �� *SelectFolderCommand+.��5,      F� ���	#B7000000 �� Stretch$ UniformToFill=�5-      $��4��5.      $��16��5/        	Icon_More#��[ 50      51      �� 52       �� 
IsReadOnly . ��53      �� *TargetFolder+$ OneWay=�54      �� 56   
   $��Center=�58      $��Center=�59      ��56      �� *ActionDescription+��57      �� *StartCommand+59      5:      5;      