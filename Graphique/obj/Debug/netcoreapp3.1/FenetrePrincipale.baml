   M S B A M L   `   `   `  ����D  @Graphique, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Graphique	Graphique  5   	   ;"clr-namespace:Graphique.convertersGraphique.converters  5   	   !    Graphique.FenetrePrincipale   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Graphique     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   2	converter"clr-namespace:Graphique.converters  5   	   -   5          � Title$  Application��5   	   $	��480��6   $	��800��6*   $	��480��66   $	��800��6F   ���#EDF2F4   MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � 	Resources 5      (  "Graphique.converters.StringToImage  stringToImage��%   &	         5   
   6"   5      .��5      � -   5         �Name$ grille��5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��4* �6   .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      $
��Auto �6    �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    �� 5$      $��* �6    .+�5(      �� $��7��6    J� RenderTransformOrigin$ 0.5,0.5&�6*   $��0,0,0,0q�6J   z�5)      V� 5*      .~�5+      T�  T� X$ 0Q�6-   5-      ��5/      �� 50        ValidationErrorColor	 �� Color#	 �  6&   52      A� 57      -   5        $��photoProfil��57      $��
40,20,40,5q�6)   
���   �$	��180��6L   ��6[   �� *ActualWidth+
 �� ElementName$
 photoProfil�� �� Mode$ OneWay=���58      �� 59       j� Stretch$
 Fill=�6p    �� ImageSource 6!   �� *ImageArtiste+ �� 	Converter# [ 6�   5;      �� 5?      $��	40,2,40,2q�6   $
��Bold"�6H   $
��Wrap=�6Z    �� TextAlignment$ Center=�6n   $��1��6�   $��Center=�6�   $��Center=�6�   ��6,   �� *
NomArtiste+6�   �� 5D      -   5         ��Name$ accueilButton��5D      $��Accueil��6,   $��2��6>   $��40��6K     
BoutonMenu#��[ 6s   $��	30,5,30,5q�6�   �� 5G      -   5        $ playlistButton��5G      $��	Playlists��6-   $��3��6A   #��[ 6k   �� 5I      -   5        $ artisteButton��5I      $��Artistes��6,   $��4��6?   #��[ 6h   �� 5K      -   5        $ musiqueButton��5K      $��Musiques��6,   $��5��6?   #��[ 6h   5N      �� 5P   
   -   5         ��Name$ contentControl��5P   )   $��1��6   5R      5T      5U      