   M S B A M L   `   `   `  ????>  :LMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:LMSLMS  5      #    LMS.UserControlLoanManagement   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:LMS     5      $	??708??5      $
??1182??6,   $??Stretch=?69   $??Stretch=?6W     ? 	Resources  5         textboxstyle ?? 
TargetType ?? Property ?? Value  
startstyle  comboboxtstyle  	textstyle  	datestyle(  "System.Windows.Controls.DatePicker  buttonstyle??%?  &	        &	 ?     &	 h    &	 ?    &	 b    &	 ?    ?? 5
   
   " ??6%   .?5      ??  ? ??$	 189??6&   64   ?? 5       ? ??
 ?   ?6;   ?? 5       ? ??$ 25??6'   64   5      ?? 5   
   " ??6#   .?5      ??  ? ?? ?	#FFFF01016@   ?? 5       ? ??$ 14(?6)   66   ?? 5       ? ??$ 27??6'   64   ?? 5       ? ??$ 27??6&   63   5      ?? 5   
   " ??6'   .?5      ??  ? ??
 ?   ?6;   5      ?? 5   
   " ??6"   .?5      ??  ? ??$ 16(?6)   66   ?? 5       ? ??$ Segoe UI Semibold)?6+   6G   ?? 5       ? ??$
 Bold"?6+   6;   5      ?? 5   
   "  6"   .?5      ??  ? ??
 ?   ?6;   5      ?? 5    
   " ??6%   .?5!      ??  ? ?? ?	#FF2196F35"      ?? 5#       ? ?? ?	#FF2196F36@   ?? 5$       ? ?? ?	#FFFFFFFF6?   ?? 5%       ? ??$ 17(?6)   66   5&      5'      .??5(      ? 
???????$??Right=?6   $
??1162??6:   $??	0,10,10,0q?6G   $	??692??6Z   $	??Top=?6g    ? ColumnDefinitions 5)   
   ?? 5*      .+?5-   
   ?? -   5         ??Name$ borrwing??5-      $??	0,42,18,0q?6%    J? RenderTransformOrigin$ 0.5,0.5&?68   $??13(?6Y   $??Microsoft JhengHei UI)?6g   $??10q?6?   $	??155??6?   $	??Top=?6?   $??Right=?6?   $
??1134??6?   $??0q?6?   ??5.      ? 5/       ? RowDefinitions 50      ?? 51      $??20 ?6(   53      .+?55      ?? $??0??6    $??Right=?6-   $!??بيانات الإعارة??6I   $??0,0,7,0q?6_   6r   56      z?58      V? 59      .~?5:      ??  ?? ScaleY$ 1Q?6%   	 ?? ScaleX$	 1Q?60   ?? 5;      
 ?? AngleY$
 0Q?6$    ?? AngleX$ 0Q?6/   ?? 5<       ?? Angle$ 0Q?6&   T? 5=      5>      .??5@      ?? $??0,0,0,10q?6   $	??472??6'   .+?5A      ?? $??رقم الإعارة??6   $??Right=?6.   $	??Top=?6J   $??77??6b   #??[ 6m    ?? Left$	 693??6?   
 ?? Top$ 9??6?   ?? 5B      $??*??6   $	 684??6$   $ 12??66   #??[ 6H   ?? 5C      -   5         ??Name$ txt_borrowingnumber??5C      $??25??67   $	 532??6D   $ 7??6W   $	??128??6f    ?? 
IsReadOnly . 
???????#??[  6?   
???   ?6?   ?? 5D      $??وصف الإعارة??6   $??Right=?6.   $	??Top=?6J   $	??100??6b   #??[ 6n   $	 670??6?   $ 74??6?   ?? 5E      -   5        $ txt_BorrDisc??5E      $??82??60   $ 37??6=   $	??128??6M   
???   ?#??[  6l    ?? TextWrapping$
 Wrap=?6?   $	 532??6?   ?? 5F      $??اسم المُعير??6   $??Right=?6.   $	??Top=?6J   $??83??6b   #??[ 6m   $	 413??6?   $ 74??6?   ?? 5G      -   5        $ txt_LibClerck??5G      $??25??63    . $	 263??6R   $ 78??6e   $	??128??6u   
???????#??[  6?   
???   ?6?   ?? 5H      $??تاريخ الإعارة??6   $??Right=?60   $	??Top=?6L   $	??108??6d   #??[ 6p   $	 404??6?   $ 7??6?   ?? 5I      $??*??6   $	 391??6$   $ 12??66   #??[ 6H   ?? 5J      $??*??6   $	 404??6%   $ 80??67   #??[ 6I   $??17??6y   $ 0.682,0.593&?6?     5K      -   5          Name$ date_borrowingdate??5K      $	 263??69   $ 7??6K   $	??128??6Z      IsDropDownOpen .  {?.  $	??0 0q?6?   #??[ 6?   ?? 5L      $??تاريخ الإرجاع??6   $??Right=?60   $	??Top=?6L   $??90??6d   #??[ 6o   $	 109??6?   $ 7??6?   ?? 5M      $??*??6   $ 96??6$   $ 18??65   #??[ 6G     5N      -   5        $ date_return??5N      $	 -39??62   $ 9??6D   $	??128??6S    .  {?.  $	??0 0q?6?   #??[ 6?   ?? 5O      -   5        $ 
txt_period??5O       ?? 	UndoLimit$ 1??6.    ?? MaxLines$ 1??6<   $??27??6J   $	??110??6V    .  #??[  6?   $ 78??6?   $
 -306??6?   ?? 5P      
???   ?$??مدة الإعارة??6,   $??Center=?6B   $??Center=?6]   $??92??6?   #??[ 6?   $
 -178??6?   $ 0.475,1&?6?   $ 74??6?   ?? 5Q      $??*??6   $
 -190??6$   $ 78??67   #??[ 6I   $??28??6y   ?? 5R      -   5        $ txt_qty??5R      
???????$??27??6?   $
 -306??6L   $	??110??6_    . #??[  6}   $ 11??6?   ?? 5S      
???   ?$??الكمية??6,   $??Center=?6=   $??Center=?6X   $??92??6}   #??[ 6?   $
 -190??6?   $ 0.475,1&?6?   $ 9??6?   ?? 5T      $??*??6   $
 -190??6$   $ 16??67   #??[ 6I   $??28??6y   ?? 5U      $??اسم المستعير??6   $??Right=?6/   $	??Top=?6K   $	??101??6c   #??[ 6o   $	 113??6?   $ 74??6?   ?? 5V      -	   5        $ txt_borrower_name??5V       . $??25??6H   $	 -39??6U   $ 82??6h   $	??128??6x   
???????#??[  6?   
???   ?6?   ?? 5W      $??*??6   $	 104??6%   $ 80??67   #??[ 6I   $??17??6y   $ 0.682,0.593&?6?   5X      5[      ?? 5\   
   $!??إدارة الإعارات??6   $??Right=?6)   $??	0,-3,18,0q?6E   $	??Top=?6X   $ -0.533,0.577&?6p   $	??125??6?   $??40??6?   $??22(?6?   $??Segoe UI Semibold)?6?   ?? 5]   
   -
   5         ??Name$ 
btn_update??5]      $??
تعديل??6&   $
??Left=?66   $??12(?6Q   $	??Top=?6_   $??83??6w   $??38??6?   $??	664,2,0,0q?6?   ?? 5^   
   -   5        $ 
btn_cancel??5^      $??
الغاء??6&   $
??Left=?66   $??12(?6Q   $	??Top=?6_   $??84??6w   $??38??6?   $??	448,2,0,0q?6?   &   System.Windows.Controls.DataGrid  5_   
   -   5          Name$ dg_loanlist??5_         
IsReadOnly . $?? RightToLeft=?6;   $??448,243,10,0q?6X   6n   ?? 5`   
   $D??>C:\Users\Omer Abdulhamid\Desktop\icons\search_filled_100px.png??6   $??775,219,251,471q?6X   $ 2.05,-1.845&?6q     5a   
   -   5        $ dg_detailes??5a       . $?? RightToLeft=?6=   $??3,243,716,0q?6[   ???	#FFE9F4FD
???   ?6?   ?? 5b   
   -   5        $ txt_search_borr_name??5b      #??[  62   
???   ?$??884,202,168,454q?6z   $
??Auto??6?   $
??Auto??6?   ?? 5c   
   -   5         ??Name$ txt_block1_Copy??5c   H   
???   ?$??10(?6(   $
??Bold"?66   $,??&:ابحث بتاريخ الارجاع ??6a   $??713,218,365,456q?6~     5d   
   -   5        $??date_searching??5d      #??[ 6+   
???   ?$??584,202,454,454q?6?   ?? 5e   
   -   5        $ txt_block1_Copy1??5e   H   
???   ?$??10(?6'   $
??Bold"?65   $)??#:ابحث باسم المستعير??6b   $??1006,218,68,456q?6}   ?? 5f   
   -   5        $ btn_return_loan??5f      $&?? إعادة الى المكتبة??6+   $
??Left=?6G   $??12(?6b   $	??Top=?6p   $	??122??6?   $??38??6?   $??	537,2,0,0q?6?   5g      5h      