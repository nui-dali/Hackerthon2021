using System.Text.RegularExpressions;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUILoginView
{
    public partial class Scene1Page : View
    {
        public Scene1Page()
        {
            InitializeComponent();

            SetFocusEvent(emailField, emailUnderline);
            SetFocusEvent(passwordField, passwordUnderline);

            SetCheckBoxStyle(checkBox);
            SetButtonStyle(button);

            SetEmailField(emailField);
            SetPasswordField(passwordField);
        }

        private void SetEmailField(TextField field)
        {
            InputMethod inputMethod = new InputMethod();
            inputMethod.PanelLayout = InputMethod.PanelLayoutType.Email;
            field.InputMethodSettings = inputMethod.OutputMap;

            field.MaxLength = 30;
            field.MaxLengthReached += (s, e) =>
            {
                Tizen.Log.Info("NUI", "MaxLength " + e.TextField.MaxLength + "\n");
            };
        }

        private void SetPasswordField(TextField field)
        {
            PropertyMap passwordMap = new PropertyMap();
            passwordMap.Add(HiddenInputProperty.Mode, new PropertyValue((int)HiddenInputModeType.HideAll));
            passwordMap.Add(HiddenInputProperty.SubstituteCharacter, new PropertyValue(0x2022));
            field.HiddenInputSettings = passwordMap;

            InputMethod inputMethod = new InputMethod();
            inputMethod.PanelLayout = InputMethod.PanelLayoutType.Password;
            field.InputMethodSettings = inputMethod.OutputMap;

            field.TextChanged += (s, e) =>
            {
                string str = Regex.Replace(e.TextField.Text, @"[\W_]", "");
                e.TextField.Text = str;
            };
        }

        private void SetFocusEvent(TextField field, View underline)
        {
            field.FocusGained += (s, e) =>
            {
                field.TextColor = new Color("#339FFF");
                underline.BackgroundColor = new Color("#339FFF");
            };

            field.FocusLost += (s, e) =>
            {
                field.TextColor = new Color("#DDDDDD");
                underline.BackgroundColor = new Color("#DDDDDD");
            };
        }

        private void SetCheckBoxStyle(CheckBox check)
        {
            check.TextLabel.PixelSize = 25.0f;            
        }

        private void SetButtonStyle(Button button)
        {
            button.TextLabel.PixelSize = 25.0f;
        }
    }
}
