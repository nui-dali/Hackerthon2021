using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace ButtonsTutorial
{
  public partial class Scene1Page : View
  {
    public Scene1Page() : base()
    {
      InitializeComponent();
      Radio1.ItemGroup.SelectedChanged += OnRadioGroupChanged;
    }

    void OnButtonClicked(object sender, EventArgs args)
    {
      OutputText.Text += $"\nbutton clicked!";
    }

    void OnCheckBoxChanged(object sender, EventArgs args)
    {
      if (sender is CheckBox checkBox)
      {
        string state = checkBox.IsSelected ? "checked" : "unchecked";
        OutputText.Text += $"\n{checkBox.Text} is {state}!";   
      }
    }

    void OnRadioGroupChanged(object sender, EventArgs args)
    {
      if (sender is RadioButtonGroup group)
      {
        OutputText.Text += $"\n{group.GetSelectedItem().Text} is selected!";
      }
    }

    void OnSwitchChanged(object sender, EventArgs args)
    {
      if (sender is Switch switchButton)
      {
        string state = switchButton.IsSelected ? "on" : "off";
        OutputText.Text += $"\n{switchButton.Text} is {state}!";
      }
    }
  }
}
