using Newtonsoft.Json.Linq;

namespace WinFormsApp2.Interfaces;

public interface IAddControls
{
    public void AddLabel(Panel panel, List<JProperty> sourceList, List<Control> labelList);
    public void AddResxLabel(Panel panel, List<KeyValuePair<string, string>> sourceList, List<Control> controlsToRemove);
    public void AddImmutableTextBox(Panel panel, List<JProperty> sourceList, List<Control> controlsToRemove);
    public void AddResxImmutableTextBox(Panel panel, List<KeyValuePair<string, string>> sourceList, List<Control> controlsToRemove);
    public void AddTextBox(Panel panel, List<JProperty> translatedList, List<Control> controlsToRemove);
    public void AddResxTextBox(Panel panel, List<KeyValuePair<string, string>> sourceList, List<Control> controlsToRemove);
}

