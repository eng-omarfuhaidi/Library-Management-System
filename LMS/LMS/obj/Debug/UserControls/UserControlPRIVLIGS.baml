   M S B A M L   `   `   `  ????>  :LMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:LMSLMS  5          LMS.UserControlPRIVLIGS   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:LMS     5      $??398.705??5      $??932.902??60     ? 	Resources  5         	textstyle ?? 
TargetType ?? Property ?? Value  
startstyle  buttonstyle??%G  &	        &	 ?     &	 ]    ?? 5	   
   " ??6"   .?5
      ??  ? ??$ 16(?6)   ?? 5       ? ??$ Segoe UI Semibold)?6+   ?? 5       ? ??$
 Bold"?6+   5      ?? 5   
   " ??6#   .?5      ??  ? ?? ?	#FFFF01016,   ?? 5       ? ??$ 14(?6)   ?? 5       ? ??$ 27??6'   ?? 5       ? ??$ 27??6&   5      ?? 5   
   " ??6%   .?5      ??  ? ?? ?	#FF2196F36+   ?? 5       ? ?? ?	#FF2196F36,   ?? 5       ? ?? ?	#FFFFFFFF6+   ?? 5       ? ??$ 17(?6)   5      5      .??5      ? $
??Left=?6   $	??907??6&   $	??422??62   $	??Top=?6?   $??
10,0,0,-23q?6W   .+?5   
   ?? $??13(?6   $??Microsoft JhengHei UI)?6"   $??10q?6E   $??737,10,0,105q?6Z   $
??Left=?6p   $	??160??6?   ??5      ? 5        ? RowDefinitions 5!      ?? 5"      $??20 ?6(   5$      .+?5&      ?? $??0??6    $??Right=?6-   $%??القائمة الأساسية??6I   $??0,0,7,0q?6a   6t   5'      z?5)      V? 5*      .~?5+      ??  ?? ScaleY$ 1Q?6%    ?? ScaleX$ 1Q?60   ?? 5,       ?? AngleY$ 0Q?6$    ?? AngleX$ 0Q?6/   ?? 5-      	 ?? Angle$	 0Q?6&   T? 5.      5/      .??51      ?? -   5        
 ??Name$
 list_show_list??51   "   $	??138??6   ???	#FFE7E8EC6;   52      ?? 53   
   $??حفظ الصلاحيات??6   $
??Left=?6)   $??454,333,0,0q?6D   $	??Top=?6Y   $	??184??6q   $??47??6}   #??[ 6?   ?? 54   
   $??13(?6   $??Microsoft JhengHei UI)?6"   $??10q?6E   $??10,10,0,105q?6Z   $
??Left=?6o   $	??163??6?   ??55      ? 56       57      ?? 58      $??20 ?6(   .+?5:      ?? $??0??6    $??Right=?6-   $??بحث عن مستخدم??6I   $??0,0,7,0q?6^   5;      z?5=      V? 5>      .~?5?      ?? $ 1Q?6%   $ 1Q?60   ?? 5@      $ 0Q?6$   $ 0Q?6/   ?? 5A      $	 0Q?6&   T? 5B      5C      .??5E      ?? $??0,-9,0,0q?6   .+?5F      ?? -   5         ??Name$ text_search??5F   N   $	??125??6    ?? Left$ 10??6&   ???	#FFE1E6EC6N   ?? 5G      -   5        $
 	list_user??5G   S   $	??143??6   $	??218??6&   $ 2??63   
 ?? Top$ 32??6C   ???	#FFEAEBEE6g   5H      5I      &   System.Windows.Controls.DataGrid  5J   
   -   5          Name$ gr_privlages??5J   ?   $
??Left=?6   $	??307??6.   $??
173,10,0,0q?6;   $	??Top=?6O   $	??564??6g   ???	#FFC2C3C9   Columns 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn   Header$ اسم الشاشة??6F      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ?? *Screen_name+6h     5M      $ عرض??6G    6%   ?? *Priv_Display+6V     5N      $ إضـافة??6C    6%   ?? *
Priv_Add+6U     5O      $ 
تعديل??6D    6%   ?? *	Priv_Edit+6U     5P      $ حذف??6G    6%   ?? *Priv_Delete+6V   5R      ?? 5S   
   $??خروج??6   $
??Left=?6    $??334,333,0,0q?6;   $	??Top=?6P   $	??102??6h   $??47??6t   #??[ 6?   5U      5V      