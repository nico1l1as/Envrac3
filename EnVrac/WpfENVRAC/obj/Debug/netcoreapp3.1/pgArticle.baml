   M S B A M L   `   `   `  ����D  @WpfENVRAC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfENVRAC	WpfENVRAC  5   	       WpfENVRAC.pgArticle   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WpfENVRAC     5   	     N� Title$  	pgArticle��5	   	   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $	��200 �6   .+�5   
   �� -   5        $��grpArticles��5      $��Liste des articles��6&   $��2q�6B   .��5      � .+�5      �� -   5        $��
lvArticles��5       �� SelectionMode$ Single=�6E   $��1q�6�   ��6-   ��  � 	Resources 5         	ctxOnItem��%�   &	        �� 5      .@�5      m� -   5        $'��!Supprimer l'article sélectionné��5   '   6P   m� 5      -   5        $��Ajouter un article��5   '   6C   5      5      ��5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property �@�ContextMenu �� Value# [  6<   5       � ContextMenu 5      �� 5       .@�5!      m� -   5        $��Ajouter un article��5!   '   6C   5"       �� View 5%      �� 5&      .P�5'      �� .��5(   "   �� -   5        $	��Nom��5(   7   
	 � Tag$		 Nom��6E   6O   
 �� CellTemplate
 5)   "   �� 5*   &   .R�5+   *   �� $	��125��6y   ��62   �� *Nom+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6y   5,   '   5.      �� 50      .��51   "   �� -   5        $��Quantite��51   7   $	 Quantite��6J   6Y   
 52   "   �� 53   &   .R�54   *   �� $	��350��6~   ��62   �� *
Quantite+$ TwoWay=�$ PropertyChanged=�6~   55   '   57      �� 59      .��5:   "   �� -   5        $��Unités��5:   7   $	 Unites��6H   6U   
 5;   "   �� 5<   &   .R�5=   *   �� $	��350��6   ��64   �� *Unites+$ TwoWay=�$ PropertyChanged=�6   5>   '   5@      �� 5B      .��5C   "   �� -	   5        $��PrixUnitaire��5C   7   $	 PrixU��6N   6Z   
 5D   "   �� 5E   &   .R�5F   *   (  "System.Windows.Controls.DatePicker  $	��100��6~      Text 65   �� *PrixU+$ TwoWay=�$ PropertyChanged=�6~   5G   '   5I      �� 5K      .��5L   "   �� -
   5        $��PrixKilo��5L   7   $	 PrixK��6J   6V   
 5M   "   �� 5N   &   .R�5O   *   �� $	��350��6~   ��64   �� *PrixK+$ TwoWay=�$ PropertyChanged=�6~   5P   '   5R      �� 5T      .��5U   "   �� -   5        $��
Peremption��5U   7   $	 
Peremption��6L   6]   
 5V   "   �� 5W   &   .R�5X   *   �� $	��350��6�   ��64   �� *
Peremption+$ TwoWay=�$ PropertyChanged=�6�   5Y   '   5[      �� 5]      .��5^   "   �� -   5        $��
Restockage��5^   7   $	 
Restockage��6L   6]   
 5_   "   �� 5`   &   .R�5a   *   �� $	��350��6�   ��64   �� *
Restockage+$ TwoWay=�$ PropertyChanged=�6�   5b   '   5d      �� 5f      .��5g   "   �� -   5        $��Remarque��5g   7   $	 Remarque��6J   6Y   
 5h   "   �� 5i   &   .R�5j   *   �� $	��350��6�   ��64   �� *
Remarque+$ TwoWay=�$ PropertyChanged=�6�   5k   '   5m      �� 5o      .��5p   "   �� -   5        $��Spécificité��5p   7   $	 Specificite��6M   6_   
 5q   "   �� 5r   &   .R�5s   *   �� $	��350��6�   ��64   �� *Specificite+$ TwoWay=�$ PropertyChanged=�6�   5t   '   5v      �� 5x      .��5y   "   �� -   5        $��Région��5y   7   $	 Region��6H   6U   
 5z   "   �� 5{   &   .R�5|   *   �� $	��350��6   ��64   �� *Region+$ TwoWay=�$ PropertyChanged=�6   5}   '   5      �� 5�      .��5�   "   �� -   5        $��Colonne��5�   7   $	 Colonne��6I   6W   
 5�   "   �� 5�   &   .R�5�   *   �� $	��350��6�   ��64   �� *	Colonne+$ TwoWay=�$ PropertyChanged=�6�   5�   '   5�      �� 5�      .��5�   "   �� -   5        $��Sous-catégorie��5�   7   $	 SousCategorie��6P   6d   
 5�   "   �� 5�   &   .R�5�   *   �� $	��350��6�   ��64   �� *SousCategorie+$ TwoWay=�$ PropertyChanged=�6�   5�   '   5�      �� 5�      .��5�   "   �� -   5        $��	Etagères��5�   7   $	 Etageres��6J   6Y   
 5�   "   �� 5�   &   .R�5�   *   �� $	��350��6�   ��64   �� *
Etageres+$ TwoWay=�$ PropertyChanged=�6�   5�   '   5�      �� 5�      .��5�   "   �� -   5        $
��Pays��5�   7   $
	 Pays��6F   6Q   
 5�   "   �� 5�   &   .R�5�   *   �� $	��350��6}   ��64   �� *Pays+$ TwoWay=�$ PropertyChanged=�6}   5�   '   5�      5�      5�      5�      5�      5�      5�      