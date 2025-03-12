using Newtonsoft.Json.Linq;

namespace WinFormsApp2.Interfaces;

public interface IAddControls
{
    public void AddLabel(Panel panel, List<JProperty> sourceList, List<Control> controlsToRemove);
    public void AddImmutableTextBox(Panel panel, List<JProperty> sourceList, List<Control> controlsToRemove);
    public void AddTextBox(Panel panel, List<JProperty> translatedList, List<Control> controlsToRemove);
}

