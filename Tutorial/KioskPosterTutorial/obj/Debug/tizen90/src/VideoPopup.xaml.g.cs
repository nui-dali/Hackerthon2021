//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Tizen.NUI.Xaml.XamlResourceIdAttribute("KioskPosterTutorial.src.VideoPopup.xaml", "src/VideoPopup.xaml", typeof(global::KioskPosterTutorial.VideoPopup))]

namespace KioskPosterTutorial {
    
    
    [Tizen.NUI.Xaml.XamlFilePathAttribute("src\\VideoPopup.xaml")]
    [Tizen.NUI.Xaml.XamlCompilationAttribute(global::Tizen.NUI.Xaml.XamlCompilationOptions.Compile)]
    public partial class VideoPopup : global::Tizen.NUI.BaseComponents.View {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Tizen.NUI.Xaml.Build.Tasks.XamlG", "1.0.27.0")]
        public global::Tizen.NUI.BaseComponents.VideoView playerView;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Tizen.NUI.Xaml.Build.Tasks.XamlG", "1.0.27.0")]
        private void InitializeComponent() {
            global::Tizen.NUI.EXaml.EXamlExtensions.LoadFromEXamlByRelativePath(this, GetEXamlPath());
            playerView = global::Tizen.NUI.Binding.NameScopeExtensions.FindByName<global::Tizen.NUI.BaseComponents.VideoView>(this, "playerView");
        }
        
        private string GetEXamlPath() {
            return default(string);
        }
    }
}