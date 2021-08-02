# Style tutorial

NUI provides style classes which can decorate NUI components. Each component has correspoding style class, for example:
* [ViewStyle](https://docs.tizen.org/application/dotnet/api/TizenFX/API9/api/Tizen.NUI.BaseComponents.ViewStyle.html) for [View](https://docs.tizen.org/application/dotnet/api/TizenFX/API9/api/Tizen.NUI.BaseComponents.View.html)
* [ButtonStyle](https://docs.tizen.org/application/dotnet/api/TizenFX/API9/api/Tizen.NUI.Components.ButtonStyle.html) for [Button](https://docs.tizen.org/application/dotnet/api/TizenFX/API9/api/Tizen.NUI.Components.Button.html)/[CheckBox](https://docs.tizen.org/application/dotnet/api/TizenFX/API9/api/Tizen.NUI.Components.CheckBox.html)/[RadioButton](https://docs.tizen.org/application/dotnet/api/TizenFX/API9/api/Tizen.NUI.Components.RadioButton.html)/[Switch](https://docs.tizen.org/application/dotnet/api/TizenFX/API9/api/Tizen.NUI.Components.Switch.html)
* [SliderStyle](https://docs.tizen.org/application/dotnet/api/TizenFX/API9/api/Tizen.NUI.Components.SliderStyle.html) for [Slider](https://docs.tizen.org/application/dotnet/api/TizenFX/API9/api/Tizen.NUI.Components.Slider.html)


This example shows how to define styles in XAML and how to apply them to the components. <br/>
From the top of the screen:
* Button style with custom background color.
* Button style with custom text color.
* Button style with custom background image.
* Button style with custom icon.
* Checkbox style with custom check images.

<div style="text-align:center;width:100%;"><img src="./preview/preview.png" /></div>

## Check for Writing Style in XAML

### Style XAML file

In the NUI template, the [theme.xaml](./res/theme/theme.xaml) file is provided by default in the directory `res/theme/`.
The initial look of the file is:
```xml
<?xml version="1.0" encoding="UTF-8"?>
<Theme
  xmlns="http://tizen.org/Tizen.NUI/2018/XAML"
  xmlns:c="clr-namespace:Tizen.NUI.Components;assembly=Tizen.NUI.Components"
  xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
  Id="sampleTheme" >

  <!-- Put styles with x:Key here -->

</Theme>
```
You can define style objects in the `<Theme>` tag.
<br/>


### Activation code

It is needed to activate style XAML in the application code. <br/>
Based on the NUI template, please open `Scene1.cs` and uncomment the line `ThemeManager.ApplyTheme(...)` like below.
```C#
override protected void OnCreate()
{
    base.OnCreate();

    // NOTE To use theme.xaml, uncomment below line.
    ThemeManager.ApplyTheme(new Theme(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "theme/theme.xaml"));

    GetDefaultWindow().Add(new Scene1Page());
    GetDefaultWindow().KeyEvent += OnScene1KeyEvent;
}
```