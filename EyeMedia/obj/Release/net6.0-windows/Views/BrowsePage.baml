   M S B A M L   `   `   `  ????   EyeMedia    EyeMedia.Views.BrowsePage   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .???   ? RowDefinitions  ?? $??50???? .+?o?  o? 
IsMainMenu$
 True?????	#FFFAFAFA.@?m? $??_File??.@?m? -   $	??New??m? $
??Open?? m? Command ?? *OpenFileCommand+?? m? -   $
??Save?? m? Icon 0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ ContentSave=?m? -   $??Save as???? m? -   $
??Exit?? m? InputGestureText$ Ctrl+E??   $ 	ExitToApp=?m? $??_Edit??.@?m? $??Add file??   $ FilePlus=? ?? *AddFileCommand+m? $??
Add folder??   $ 
FolderPlus=? ?? *AddFolderCommand+m? $??_View??.@?m?  m? IsCheckable$
 True??$??Tiles??m? $
 True?? m? 	IsChecked$
 True??$??Small icons??m? $
 True??$??Details??m? $??_About??.@?m? -   $??About??   $ Information=?#  MaterialDesignThemes.Wpf.Card  -   $??1?? J? 	AllowDrop$
 True??.????  *  &MaterialDesignNavigationRailTabControl#??[  3  -MaterialDesignThemes.Wpf.NavigationRailAssist	   ShowSelectionBackground$
	 True??
 J? SnapsToDevicePixels$

 True?? ?? TabStripPlacement$
 Left=?.@??? *  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ MouseUp??*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command ?? *GoToImageItemsCommand+???? $
??auto??$
??auto??.+?'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Images=?  BusinessColor#??[ $??Center=?$??24??$??24???? $??Photos??
???   ?$??Center=?.???? $??Visible=?.???? $
 True?????? *Images+ ?? Mode$ TwoWay=????? .R?? ???? .R??? $??imageBorder??$	??125??$	??170?? ?? CornerRadius$ 30??$??5q?????  ?? ImageSource ?? *Icon+._??? 
?????? $??0q?$
??auto??$
??auto?? J? InputBindings d?  d? Gesture$ LeftDoubleClicka? ?? Command ??  ?? RelativeSource ??  ?? AncestorType Page ?? Mode$ FindAncestor=? ?? Path$" DataContext.OpenImageCommand? ?? CommandParameter ??  ?? ElementName$ imageBorder????    $ MouseUp??.    ?? *GoToVideoItemsCommand+???? $
??auto??$
??auto??.+?  $ Video=?#??[ $??Center=?$??24??$??24???? $??Videos??
???   ?$??Center=?.???? $??Visible=?.???? $
 True?????? *Videos+$ TwoWay=????? .R?? ???? .R??? $??videoBorder??$	??125??$	??170??$ 30??$??5q?????  ?? *Icon+._??? 
?????? $??0q?$
??auto??$
??auto?? d? $ LeftDoubleClicka? ??  ??  Page$ FindAncestor=?$" DataContext.OpenVideoCommand? ?? $ videoBorder??