# NumberBox
Microsoft - Prototype for UWP NumberBox Control
## This prototype is no longer in development - see the official NumberBox control in WinUI3!


[Project Specs](https://github.com/microsoft/microsoft-ui-xaml-specs/blob/user/savoyschuler/numberbox/active/NumberBox/NumberBox.md)

[Proposal Thread](https://github.com/microsoft/microsoft-ui-xaml/issues/483)

[More about the Windows UI Library](https://docs.microsoft.com/en-us/uwp/toolkits/winui/)

## How To Compile/Run
1. Install Visual Studio 2019, you'll need any extensions for UWP Development.
2. Clone this directory and open the solution file through Visual Studio, or start a new Blank UWP Project and then clone the code to it.
3. On top, leave compile mode at Debug and set the correct processor type (Probably x64), and the Local Machine start button

The test page can be edited even at runtime by changing MainPage.xaml. Changing MainPage.xaml or the Converter code will not affect the NumberBox codebehind. NumberBox code is stored in NumberBox.cs and it's resource/style template, NumberBox.xaml.

NumberBox is a subclass of of [Textbox](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.TextBox), and thus implements all of TextBox's properties. 
