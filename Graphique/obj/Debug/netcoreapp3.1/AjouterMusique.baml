   M S B A M L   `   `   `  ����D  @Graphique, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Graphique	Graphique  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      A =Modele, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/$clr-namespace:Modele;assembly=ModeleModele 5          Graphique.AjouterMusique   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Graphique     5      V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      0sys&clr-namespace:System;assembly=mscorlib  5      .pro$clr-namespace:Modele;assembly=Modele  5         MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      
������   MaterialDesignFont#���  5       � 	Resources 5       S� 
MethodName S� 
ObjectTypeU	 QSystem.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 	 System.Enum  TypeMusicaux S� MethodParameters M� TypeName��%{   &	       S� 5   
   $ 	GetValues��6   "  5       5      M� 5      $ pro:TypeMusicaux��6   5       5!      .��5#      �  � ColumnDefinitions 5$   
   �� 5%      $��* �6   �� 5&      $��2* �6   �� 5'      $��* �6    � RowDefinitions 5)   
   �� 5*      $��* �6   �� 5+      $��* �6   �� 5,      $��* �6   �� 5-      $��* �6   .+�5/   
   #  MaterialDesignThemes.Wpf.Card  $��1��6   $��10,25,10,25q�6/   .��50      �� -   5        	 ��Name$	 	TitrePage��50         MaterialDesignTitleTextBlock#���  6+   $��Ajouter une musique��6b   $��25(�6}   $��Center=�6�   $��Center=�6�   51      �� 55   
   $	��200��6   $��1��6"   $��1��62   $��3��6?   .+�56      �� $��Titre de la musique:��6   $��5,10,5,0q�64   �� 57      -   5        $��BoxNom��57   )   $��5,0,5,10q�6   6)   �� 58      $!��Lien youtube de la musique:��6   $��5,10,5,0q�6;   �� 59      -   5        $��BoxLien��59   )   $��5,0,5,10q�6   6)   �� 5:      $)��#A quel album la musique appartient:��6   $��5,10,5,0q�6C   �� 5;      -   5        $��	ListAlbum��5;      ��6(   �� *ListeAlbums+��5<      �� 5=      .R�5>      �� ��6$   �� *
NomAlbum+5?      5A      �� 5H      -   5        $��	Confirmer��5H      $
��0,15q�6@   �� 5I      -   5        $��
TextErreur��5I      $��15(�6*   $
��Wrap=�68   (  "System.Windows.Controls.DatePicker  5J      -   5        
  Name$
 ChoisirDate��5J      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Seletionnez une date��5K       $  MaterialDesignOutlinedDatePicker#��[ 5L      5N      �� 5P   
   $#��Quels artistes y participent:��6   $��5,0,5,0q�69   $
��Wrap=�6J   $��1��6^   �� 5Q   
   -   5        $��ListArtistes��5Q      $
��True��6J   $��1��6o   $��3��6|   $
��0,40q�6�   ��6&   �� *LesArtistes+��5R      �� 5S      .R�5T      �� $��CheckAr��6r   -	   5        ��5T      �� *
NomArtiste+6r   5U      5W      �� 5[   
   $��2��6   $��1��6%   $��3��62   .+�5\      �� $��Choisissez le style:��6   �� 5]      -
   5        $��
myComboBox��5]       �� SelectedIndex$ 0��6(   $��8q�6:   ��6E   ��  �� Source# [ ��5^      �� 5_      .R�5`      �� -   5        ��5`   #   �� 6P   5a      5d      5e      5i      5j      