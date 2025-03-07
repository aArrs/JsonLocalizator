namespace WinFormsApp2.Interfaces;

public interface IClearControls
{
    public void RemoveControls(List<Control> controlsToRemove, FlowLayoutPanel flowLayoutPanel);
}