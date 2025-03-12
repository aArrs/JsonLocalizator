using WinFormsApp2.Interfaces;

namespace WinFormsApp2.Classes;

public class ControlsCleaner : IClearControls
{
    //очистка панели от элементов контроля
    public void RemoveControls(List<Control> controlsToRemove, Panel panel)
    {
        panel.SuspendLayout();
        foreach (Control control in controlsToRemove)
        {
            control.Dispose();
        }
        controlsToRemove.Clear();
        controlsToRemove.TrimExcess();
        panel.ResumeLayout();
    }
}