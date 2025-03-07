using Newtonsoft.Json.Linq;

namespace WinFormsApp2.Interfaces;

public interface IAddControls
{
    public void AddLabel(FlowLayoutPanel flowLayoutPanel, List<JProperty> sourceList, List<Control> controlsToRemove);
    public void AddImmutableTextBox(FlowLayoutPanel flowLayoutPanel, List<JProperty> sourceList, List<Control> controlsToRemove);
    public void AddTextBox(FlowLayoutPanel flowLayoutPanel, List<JProperty> translatedList, List<Control> controlsToRemove);
}

