   M S B A M L   `   `   `  ????>  :LMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:LMSLMS  5      !    LMS.UserControlAddBorrowing   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:LMS     5      $	??708??5       $
??1182??6-     ? 	Resources  5         textboxstyle ?? 
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
??1162??6:   $??	0,-4,10,0q?6G   $	??702??6Z   $	??Top=?6g    ? ColumnDefinitions 5)   
   ?? 5*      .+?5-   
   ?? -   5         ??Name$ borrwing??5-      $??
0,56,570,0q?6%    J? RenderTransformOrigin$ 0.5,0.5&?69   $??13(?6Z   $??Microsoft JhengHei UI)?6h   $??10q?6?   $	??214??6?   $	??Top=?6?   $??Right=?6?   $	??571??6?   $??0q?6?   ??5.      ? 5/       ? RowDefinitions 50      ?? 51      $??20 ?6(   53      .+?55      ?? $??0??6    $??Right=?6-   $!??بيانات الإعارة??6I   $??0,0,7,0q?6_   6r   56      z?58      V? 59      .~?5:      ??  ?? ScaleY$ 1Q?6%   	 ?? ScaleX$	 1Q?60   ?? 5;      
 ?? AngleY$
 0Q?6$    ?? AngleX$ 0Q?6/   ?? 5<       ?? Angle$ 0Q?6&   T? 5=      5>      .??5@      ?? $??0,0,0,10q?6   $	??544??6'   .+?5A      ?? $??رقم الإعارة??6   $??Right=?6.   $	??Top=?6J   $??77??6b   #??[ 6m    ?? Left$	 468??6?   
 ?? Top$ 7??6?   ?? 5B      $??*??6   $	 459??6$   $ 10??66   #??[ 6H   ?? 5C      -   5         ??Name$ txt_borrowingnumber??5C      $??25??67   $	 314??6D   $ 10??6W   $	??128??6g    ?? 
IsReadOnly . {?.  
???????#??[  6?   
???   ?6?   ?? 5D      $??وصف الإعارة??6   $??Right=?6.   $	??Top=?6J   $	??100??6b   #??[ 6n   $	 442??6?   $ 57??6?   ?? 5E      -   5        $ txt_BorrDisc??5E      $	??104??60   $ 40??6>   $	??128??6N   
???   ?#??[  6m    ?? TextWrapping$
 Wrap=?6?   $	 314??6?   ?? 5F      $??اسم المعير??6   $??Right=?6-   $	??Top=?6I   $??83??6a   #??[ 6l   $	 464??6?   $	 143??6?   ?? 5G      -   5        $ txt_LibClerck??5G      {?.  $??25??6D   $	 314??6R   $	 149??6e   $	??128??6v   
???????$?? ??6?   #??[  6?   
???   ?6?   ?? 5H      $??تاريخ الإعارة??6   $??Right=?60   $	??Top=?6L   $??90??6d   #??[ 6o   $	 146??6?   $ 10??6?   ?? 5I      $??*??6   $	 133??6$   $ 15??66   #??[ 6H   ?? 5J      $??*??6   $	 442??6%   $	 149??67   #??[ 6J   $??17??6z   $ 0.682,0.593&?6?     5K      -   5          Name$ date_borrowingdate??5K      $ 5??6:   $ 10??6J   $	??128??6Z      IsDropDownOpen .  {?.  $	??0 0q?6?   #??[ 6?      IsTodayHighlighted . 6?   ?? 5L      $??تاريخ الإعارة??6   $??Right=?60   $	??Top=?6L   $??90??6d   #??[ 6o   $	 146??6?   $ 73??6?   ?? 5M      $??*??6   $	 133??6$   $ 78??66   #??[ 6H     5N      -   5        $ date_return??5N      $ 5??62   $ 73??6B   $	??128??6R    .  {?.  $	??0 0q?6?   #??[ 6?   ?? 5O      -   5        $ 
txt_period??5O      
???????$??27??6B    . {?. $ 5??6r   $	??128??6?   #??[  6?   $	 140??6?   ?? 5P      
???   ?$??مدة الإعارة??6,   $??Center=?6B   $??Center=?6]   $??92??6?   #??[ 6?   $	 146??6?   $ 0.475,1&?6?   $	 136??6?   ?? 5Q      $??*??6   $	 133??6$   $	 143??66   #??[ 6I   5R      5U      ?? 5V   
   $??إعارة نسخة??6   $??Right=?6%   $??	0,-1,19,0q?6A   $	??Top=?6T   $ -0.533,0.577&?6l   $	??125??6?   $??40??6?   $??22(?6?   $??Segoe UI Semibold)?6?   ?? 5W   
   -   5        $ borrower??5W      $??	0,56,13,0q?6%   $ 0.5,0.5&?68   $??13(?6Y   $??Microsoft JhengHei UI)?6g   $??10q?6?   $	??214??6?   $	??Top=?6?   $??Right=?6?   $	??557??6?   $??0q?6?   ??5X      ? 5Y       5Z      ?? 5[      $??20 ?6(   .+?5]      ?? $??0??6    $??Right=?6-   $#??بيانات المستعير??6I   $??0,0,7,0q?6`   5^      z?5`      V? 5a      .~?5b      ?? $ 1Q?6%   $	 1Q?60   ?? 5c      $
 0Q?6$   $ 0Q?6/   ?? 5d      $ 0Q?6&   T? 5e      5f      .??5h      ?? $??0,0,0,11q?6   $	??530??6'   .+?5i      ?? $??رقم التسجيل??6   $??Right=?6.   $	??Top=?6J   $	??100??6b   #??[ 6n   $	 434??6?   $ 3??6?   ?? 5j      $??*??6   $	 406??6$   $ 7??66   #??[ 6G   $??26??6w   ?? 5k      -	   5        $ txt_borrowernumber??5k      $??25??66   $	 218??6C   $ 7??6V   $	??188??6e    . #??[  6?   
???   ?6?   ?? 5l      $??اسم المستعير??6   $??Right=?6/   $	??Top=?6K   $	??100??6c   #??[ 6o   $	 434??6?   $ 45??6?   ?? 5m      $??*??6   $	 406??6$   $ 45??66   #??[ 6H   $??26??6x   ?? 5n      -
   5        $ txt_borrowername??5n   -   
???   ?$??27??6G   $	 218??6T   $ 45??6g   $	??188??6w    . #??[  6?   $
 Wrap=?6?   ?? 5o      $(??" البريد الإلكتروني??6   $??Right=?65   $	??Top=?6Q   $	??124??6i   #??[ 6u   $	 412??6?   $	 121??6?   ?? 5p      -   5        $ 	txt_email??5p   -   
???   ?$??25??6@   $	 218??6M   $	 127??6`   $	??186??6q    . #??[  6?   ?? 5q      $??رقم الهاتف??6   $??Right=?6-   $	??Top=?6I   $??89??6a   #??[ 6l   $	 445??6?   $ 82??6?   ?? 5r      -   5        $ 	txt_phone??5r   -   
???   ?$??25??6@   $	 218??6M   $ 79??6`   $	??188??6p    . #??[  6?   ?? 5s      $??*??6   $	 406??6$   $ 82??66   #??[ 6H   $??26??6x   ?? 5t      -   5        $??txt_bornmae??5t      $??25??6-   $ 56??6:   $	??119??6K   
???   ?$ -1??6?   ?? 5u      -   5         ??Name$ list1??5u      $	??213??6)   $	??146??65   $ 27??6B   
???   ?
???????$??5q?6?     5v        data??%   &	       ?? 5w      66   5x      5y      ?? 5{      $D??>C:\Users\Omer Abdulhamid\Desktop\icons\search_filled_100px.png??6   $??22??6`   $??27??6l   $ 5??6w   $ 24??6?   6?   5~      5?      ?? 5?   
   -   5        $ books??5?      $??
0,270,13,0q?6"   $ 0.5,0.5&?66   $??13(?6W   $??Microsoft JhengHei UI)?6e   $??10q?6?   $	??422??6?   $	??Top=?6?   $??Right=?6?   $
??1128??6?   $??0q?6?   ??5?      ? 5?      $??26??6    5?      ?? 5?      $??20 ?6(   .+?5?      ?? $??0??6    $??Right=?6-   $??الوثائق??6I   $??0,0,7,0q?6X   5?      z?5?      V? 5?      .~?5?      ?? $ 1Q?6%   $	 1Q?60   ?? 5?      $
 0Q?6$   $ 0Q?6/   ?? 5?      $ 0Q?6&   T? 5?      5?      .??5?      ?? $??0,0,0,12q?6   $
??1099??6'   .+?5?      &   System.Windows.Controls.DataGrid  -   5          Name$ dg_copylist??5?         
IsReadOnly . $??RightToLeft=?6B   $ 29??6^   $	??754??6n   $	??345??6z   $	 343??6?   ?? 5?      
???   ?$??اختيار نسخة??6-   $??Right=?6C   $	??Top=?6_   $	??101??6w   #??[ 6?   $	 998??6?   $ -2??6?   ?? 5?      -   5        $ txt_copynumber??5?       . 
???????
???   ?$??97??6j   $	 246??6u   $ 34??6?   $??37??6?   $?? ??6?   6?   ?? 5?      -   5        $ txt_copyname??5?   /   
???????$??38??6E   $ 99??6R   $ 33??6d   $	??147??6t    . #??[  6?   $
 Wrap=?6?   ?? 5?      $??1q?6   
???   ?$??رقم النسخة??6@   $??Right=?6U   $??Center=?6q   $??Center=?6?   $??97??6?   #??[ 6?   $	 244??6?   $??33??6?   ?? 5?      $??1q?6   
???   ?$??عنوان النسخة??6A   $??Center=?6X   $??Center=?6s   $	??147??6?   #??[ 6?   $ 99??6?   $??33??6?   $ 1??6?   ?? 5?      $??1q?6   
???   ?$??رقم الإصدار??6@   $??Center=?6V   $??Center=?6q   $??99??6?   #??[ 6?   $??33??6?   ?? 5?      -   5         ??Name$ 
btn_update??5?      {?.  $(??"تعديل السطر المحدد??6X   $
??Left=?6u   $??12(?6?   $	??Top=?6?   $	??134??6?   $??38??6?   $	 180??6?   $	 336??6?     5?      -   5        $ gd_bookbrorrowed??5?       .  $??RightToLeft=?6H   $ 74??6d   $	??342??6t   $	??114??6?   ???	#FFE9F4FD$ -1??6?   6?   ?? 5?      -   5        $ btn_deleting??5?      {?.  $$??حذف السطر المحدد??6A   $
??Left=?6\   $??12(?6w   $	??Top=?6?   $	??134??6?   $??38??6?   $ 36??6?   $	 336??6?   6?   ?? 5?      -   5         ??Name$ 	txt_block??5?   =   
???   ?$??10(?6/   $3??-ابحث عن الوثيقة المطلوبة??6P   $	 736??6p   $ 10??6?   $	??118??6?   6?   ?? 5?      $D??>C:\Users\Omer Abdulhamid\Desktop\icons\search_filled_100px.png??6   $??29??6`   $??20??6l   $	 702??6w   $ 2??6?   6?   ?? 5?      -   5        $ txt_booknamesearching??5?      $	??151??6;   $	 722??6G   
???   ?$??29??6?   $ -5??6?   ?? 5?      -   5        $ 
listbooks_??5?      $	??151??6.   $	??345??6:   $ 29??6G   
???   ?
???????$??5q?6?   $	 722??6?     5?      ??%   &	       ?? 5?      6'   5?      5?      ?? 5?      -   5        $ txt_edition??5?   /   
???????$??38??6D   $ 33??6Q   $??99??6a    . #??[  6~   $
 Wrap=?6?   6?   5?      5?      ?? 5?   
   -   5        $ btn_addborrowing??5?      $??إعارة جديد??6,   $
??Left=?6A   $??12(?6\   $	??Top=?6j   $??83??6?   $??38??6?   $??
912,10,0,0q?6?   6?   ?? 5?   
   -   5        $ btn_saveborrowing??5?      $??حفظ الإعارة??6,   $
??Left=?6B   $??12(?6]   $	??Top=?6k   $??93??6?   $??38??6?   $??
816,10,0,0q?6?   6?   ?? 5?   
   $??
الغاء??6   $
??Left=?6!   $??12(?6<   $	??Top=?6J   $??58??6b   $??38??6m   $??
753,10,0,0q?6z   5?      5?      