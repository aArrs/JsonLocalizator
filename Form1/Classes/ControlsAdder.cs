using Newtonsoft.Json.Linq;
using WinFormsApp2.Interfaces;

namespace WinFormsApp2.Classes;

public class ControlsAdder : IAddControls
{
    public void AddLabel(FlowLayoutPanel flowLayoutPanel, List<JProperty> sourceList, List<Control> controlsToRemove)
    {
        flowLayoutPanel.SuspendLayout();

        foreach (var item in sourceList)
        {
            TextBox textBox = new TextBox();
            controlsToRemove.Add(textBox);
            textBox.Text = item.Name;
            textBox.Font = new Font("Arial", 12);
            textBox.AutoSize = false;
            textBox.Size = new Size(flowLayoutPanel.Width - 30, 60);
            textBox.Margin = new Padding(5);
            textBox.TextAlign = HorizontalAlignment.Right;
            //textBox.BorderStyle = BorderStyle.None;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = SystemColors.Info;
            textBox.ReadOnly = true;
            flowLayoutPanel.Controls.Add(textBox);
        }
        flowLayoutPanel.ResumeLayout();
    }
    public void AddImmutableTextBox(FlowLayoutPanel flowLayoutPanel, List<JProperty> sourceList, List<Control> controlsToRemove)
    {
        flowLayoutPanel.SuspendLayout();
        
        foreach (var item in sourceList)
        {
            TextBox textBox = new TextBox();
            controlsToRemove.Add(textBox);
            textBox.Text = item.Value.ToString();
            textBox.Font = new Font("Arial", 12);
            textBox.AutoSize = false;
            textBox.Size = new Size(flowLayoutPanel.Width - 30, 60);
            textBox.Multiline = true;
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.Margin = new Padding(5);
           // textBox.BorderStyle = BorderStyle.None;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.ReadOnly = true;
            flowLayoutPanel.Controls.Add(textBox);
        }
        
        flowLayoutPanel.ResumeLayout();
    }
    public void AddTextBox(FlowLayoutPanel flowLayoutPanel, List<JProperty> translatedList, List<Control> controlsToRemove)
    {
        flowLayoutPanel.ResumeLayout();
        
        foreach (var item in translatedList)    
        {
            TextBox textBox = new TextBox();
            controlsToRemove.Add(textBox);
            textBox.Text = item.Value.ToString();
            textBox.Font = new Font("Arial", 12);
            textBox.AutoSize = false;
            textBox.Size = new Size(flowLayoutPanel.Width - 30, 60);
            textBox.Multiline = true;
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.Margin = new Padding(5);
            //textBox.BorderStyle = BorderStyle.None;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = SystemColors.Window;
            flowLayoutPanel.Controls.Add(textBox);
        }
    }
}