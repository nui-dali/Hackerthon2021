//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Tizen.NUI.Xaml.XamlResourceIdAttribute("NUIKioskCafeteria.src.page.SelectPage.xaml", "src/page/SelectPage.xaml", typeof(global::NUIKioskCafeteria.SelectPage))]

namespace NUIKioskCafeteria {
    
    
    [Tizen.NUI.Xaml.XamlFilePathAttribute("src\\page\\SelectPage.xaml")]
    [Tizen.NUI.Xaml.XamlCompilationAttribute(global::Tizen.NUI.Xaml.XamlCompilationOptions.Compile)]
    public partial class SelectPage : global::NUIKioskCafeteria.ContentControlPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Tizen.NUI.Xaml.Build.Tasks.XamlG", "1.0.27.0")]
        public global::Tizen.NUI.GaussianBlurView contentView;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Tizen.NUI.Xaml.Build.Tasks.XamlG", "1.0.27.0")]
        public global::Tizen.NUI.BaseComponents.TextLabel startover;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Tizen.NUI.Xaml.Build.Tasks.XamlG", "1.0.27.0")]
        public global::Tizen.NUI.Components.Navigator selectNavigator;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Tizen.NUI.Xaml.Build.Tasks.XamlG", "1.0.27.0")]
        private void InitializeComponent() {
            global::Tizen.NUI.EXaml.EXamlExtensions.LoadFromEXamlByRelativePath(this, GetEXamlPath());
            contentView = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<global::Tizen.NUI.GaussianBlurView>(this, "contentView");
            startover = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<global::Tizen.NUI.BaseComponents.TextLabel>(this, "startover");
            selectNavigator = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<global::Tizen.NUI.Components.Navigator>(this, "selectNavigator");
        }
        
        private string GetEXamlPath() {
            return default(string);
        }
    }
}
