using Newtonsoft.Json.Linq;
using WinFormsApp2.Interfaces;

namespace WinFormsApp2.Classes;

public class ControlsAdder : IAddControls
{
    public void AddLabel(Panel panel, List<JProperty> sourceList, List<Control> labelList)
    {
        panel.SuspendLayout();
        var y = 0;
        foreach (var item in sourceList)
        {
            TextBox textBox = new TextBox();
            labelList.Add(textBox);
            textBox.Text = item.Name;
            textBox.Location = new Point(0, y);
            textBox.Font = new Font("Arial", 12, FontStyle.Underline);
            textBox.AutoSize = false;
            textBox.Size = new Size((int)(panel.Width * 0.18), 70);
            textBox.Margin = new Padding(5);
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.BorderStyle = BorderStyle.None;
            //textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.FromArgb(255,204,153);
            textBox.ReadOnly = true;
            y += 80;
            panel.Controls.Add(textBox);
        }
        panel.ResumeLayout();
    }
    public void AddImmutableTextBox(Panel panel, List<JProperty> sourceList, List<Control> immutTextboxList)
    {
        panel.SuspendLayout();
        var y = 0;
        foreach (var item in sourceList)
        {
            TextBox textBox = new TextBox();
            immutTextboxList.Add(textBox);
            textBox.Text = item.Value.ToString();
            textBox.Location = new Point((int)(panel.Width * 0.2), y);
            textBox.Font = new Font("Arial", 12);
            textBox.AutoSize = false;
            textBox.Size = new Size((int)(panel.Width * 0.30), 70);
            textBox.Multiline = true;
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.Margin = new Padding(5);
           // textBox.BorderStyle = BorderStyle.None;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.ReadOnly = true;
            y += 80;
            panel.Controls.Add(textBox);
        }
        
        panel.ResumeLayout();
    }
    public void AddTextBox(Panel panel, List<JProperty> translatedList, List<Control> controlsToRemove)
    {
        panel.ResumeLayout();
        var y = 0;
        foreach (var item in translatedList)    
        {
            TextBox textBox = new TextBox();
            controlsToRemove.Add(textBox);
            textBox.Text = item.Value.ToString();
            textBox.Location = new Point((int)(panel.Width * 0.52), y);
            textBox.Font = new Font("Arial", 12);
            textBox.AutoSize = false;
            textBox.Size = new Size((int)(panel.Width * 0.3), 70);
            textBox.Multiline = true;
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.Margin = new Padding(5);
            //textBox.BorderStyle = BorderStyle.None;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = SystemColors.Window;
            y += 80;
            panel.Controls.Add(textBox);
        }   
    }
}