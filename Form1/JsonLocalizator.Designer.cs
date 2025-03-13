﻿namespace WinFormsApp2;

partial class JsonLocalizator
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        button3 = new System.Windows.Forms.Button();
        comboBox1 = new System.Windows.Forms.ComboBox();
        button2 = new System.Windows.Forms.Button();
        button4 = new System.Windows.Forms.Button();
        button1 = new System.Windows.Forms.Button();
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        panel1 = new System.Windows.Forms.Panel();
        panel2 = new System.Windows.Forms.Panel();
        label3 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label1 = new System.Windows.Forms.Label();
        tableLayoutPanel1.SuspendLayout();
        panel2.SuspendLayout();
        SuspendLayout();
        // 
        // button3
        // 
        button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        button3.AutoSize = true;
        button3.Font = new System.Drawing.Font("Segoe UI", 12F);
        button3.Location = new System.Drawing.Point(1140, 753);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(121, 34);
        button3.FlatStyle = FlatStyle.Flat;
        button3.FlatAppearance.BorderColor = Color.FromArgb(255, 102, 0);
        button3.FlatAppearance.BorderSize = 2;
        button3.BackColor = Color.White;
        button3.TabIndex = 6;
        button3.Text = "Сохранить";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // comboBox1
        // 
        comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
        comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
        comboBox1.Items.AddRange(new object[] { "Английский", "Белорусский" });
        comboBox1.Location = new System.Drawing.Point(1140, 42);
        comboBox1.Name = "comboBox1";
        comboBox1.SelectedIndex = 1;
        comboBox1.SelectedItem = 1;
        comboBox1.Size = new System.Drawing.Size(121, 23);
        comboBox1.TabIndex = 5;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // button2
        // 
        button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        button2.AutoSize = true;
        button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        button2.Font = new System.Drawing.Font("Segoe UI", 12F);
        button2.Location = new System.Drawing.Point(1140, 3);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(121, 33);
        button2.FlatStyle = FlatStyle.Flat;
        button2.FlatAppearance.BorderColor = Color.FromArgb(255, 102, 0);
        button2.FlatAppearance.BorderSize = 2;
        button2.BackColor = Color.White;
        button2.TabIndex = 2;
        button2.Text = "Перевести";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button4
        // 
        button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        button4.AutoSize = true;
        button4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        button4.Font = new System.Drawing.Font("Segoe UI", 12F);
        button4.Location = new System.Drawing.Point(3, 753);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(120, 34);
        button4.FlatStyle = FlatStyle.Flat;
        button4.FlatAppearance.BorderColor = Color.FromArgb(255, 102, 0);
        button4.FlatAppearance.BorderSize = 2;
        button4.BackColor = Color.White;
        button4.TabIndex = 7;
        button4.Text = "Очистить";
        button4.UseVisualStyleBackColor = true;
        button4.Click += button4_Click;
        // 
        // button1
        // 
        button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        button1.AutoSize = true;
        button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        button1.Font = new System.Drawing.Font("Segoe UI", 12F);
        button1.Location = new System.Drawing.Point(3, 3);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(120, 33);
        button1.FlatStyle = FlatStyle.Flat;
        button1.FlatAppearance.BorderColor = Color.FromArgb(255, 102, 0);
        button1.FlatAppearance.BorderSize = 1;
        button1.BackColor = Color.White;
        button1.TabIndex = 0;
        button1.Text = "Выбрать файл";
        button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        
        button1.MouseEnter += (s, e) =>
        {
            button1.BackColor = Color.FromArgb(255, 102, 0);
            button1.FlatAppearance.BorderColor = Color.FromArgb(153,51, 0);
            button1.ForeColor = Color.White;
            button1.Refresh(); // Перерисовываем кнопку
        };
        button1.MouseLeave += (s, e) =>
        {
            button1.BackColor = Color.White;    
            button1.FlatAppearance.BorderColor = Color.FromArgb(255, 102, 0);
            button1.ForeColor = Color.Black;
            button1.Refresh(); // Перерисовываем кнопку
        };
        button2.MouseEnter += (s, e) =>
        {
            button2.BackColor = Color.FromArgb(255, 102, 0);
            button2.FlatAppearance.BorderColor = Color.FromArgb(153,51, 0);
            button2.ForeColor = Color.White;
            button2.Refresh(); // Перерисовываем кнопку
        };
        button2.MouseLeave += (s, e) =>
        {
            button2.BackColor = Color.White;    
            button2.FlatAppearance.BorderColor = Color.FromArgb(255, 102, 0);
            button2.ForeColor = Color.Black;
            button2.Refresh(); // Перерисовываем кнопку
        };
        button3.MouseEnter += (s, e) =>
        {
            button3.BackColor = Color.FromArgb(255,51,0);
            button3.FlatAppearance.BorderColor = Color.FromArgb(153,51, 0);
            button3.ForeColor = Color.White;
            button3.Refresh(); // Перерисовываем кнопку
        };
        button3.MouseLeave += (s, e) =>
        {
            button3.BackColor = Color.White;    
            button3.FlatAppearance.BorderColor = Color.FromArgb(255, 102, 0);
            button3.ForeColor = Color.Black;
            button3.Refresh(); // Перерисовываем кнопку
        };
        button4.MouseEnter += (s, e) =>
        {
            button4.BackColor = Color.FromArgb(255, 102, 0);
            button4.FlatAppearance.BorderColor = Color.FromArgb(153,51, 0);
            button4.ForeColor = Color.White;
            button4.Refresh(); // Перерисовываем кнопку
        };
        button4.MouseLeave += (s, e) =>
        {
            button4.BackColor = Color.White;    
            button4.FlatAppearance.BorderColor = Color.FromArgb(255, 102, 0);
            button4.ForeColor = Color.Black;
            button4.Refresh(); // Перерисовываем кнопку
        };
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.AutoSize = true;
        tableLayoutPanel1.BackColor = Color.FromArgb(255,204,153);
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
        tableLayoutPanel1.Controls.Add(button3, 2, 2);
        tableLayoutPanel1.Controls.Add(button1, 0, 0);
        tableLayoutPanel1.Controls.Add(button4, 0, 2);
        tableLayoutPanel1.Controls.Add(button2, 2, 0);
        tableLayoutPanel1.Controls.Add(comboBox1, 2, 1);
        tableLayoutPanel1.Controls.Add(panel1, 1, 1);
        tableLayoutPanel1.Controls.Add(panel2, 1, 0);
        tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 3;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
        tableLayoutPanel1.Size = new System.Drawing.Size(1264, 790);
        tableLayoutPanel1.TabIndex = 9;
        // 
        // panel1
        // 
        panel1.AutoScroll = true;
        panel1.AutoScrollMinSize = new Size(0, panel1.Height);
        panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        panel1.AutoSize = true;
        panel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
        panel1.Dock = System.Windows.Forms.DockStyle.Fill;
        panel1.Location = new System.Drawing.Point(129, 42);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(1005, 705);
        panel1.TabIndex = 9;
        // 
        // panel2
        // 
        panel2.Controls.Add(label3);
        panel2.Controls.Add(label2);
        panel2.Controls.Add(label1);
        panel2.Dock = System.Windows.Forms.DockStyle.Fill;
        panel2.Location = new System.Drawing.Point(129, 3);
        panel2.Name = "panel2";
        panel2.Size = new System.Drawing.Size(1005, 33);
        panel2.TabIndex = 10;
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.Location = new System.Drawing.Point((int)(panel2.Width * 0.52), 0);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size((int)(panel2.Width * 0.30), 23);
        label3.TabIndex = 2;
        label3.Text = "Переведенное значение";
        label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0)); label2.Location = new System.Drawing.Point((int)(panel2.Width * 0.2), 0);   
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size((int)(panel2.Width * 0.30), 23);
        label2.TabIndex = 1;
        label2.Text = "Исходное значение";
        label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(0, 0);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size((int)(panel2.Width * 0.18), 23);
        label1.TabIndex = 0;
        label1.Text = "Ключ";
        label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        
        this.Resize += (s, e) =>
        { 
            panel1.AutoScrollPosition = new Point(0, 0);
            if (translatedList.Count > 0)
            {
                for (int i = 0; i < textBoxList.Count; i++)
                {
                    _updateList.UpdateList(translatedList, textBoxList[i], i);
                }
                _clearControls.RemoveControls(textBoxList, panel1);
                _addControls.AddTextBox(panel1, translatedList, textBoxList);
            }
            var  y = 0;
            var y1 = 0;
            var y2 = 0;
            foreach (Control label in labelList)
            {
                label.Location = new Point(0, y);
                label.Size = new Size((int)(panel1.Width * 0.18), 70);
                y += 80;
            }
            foreach (Control iTextBox in immutTextBoxList)
            {
                iTextBox.Location = new Point((int)(panel1.Width * 0.2), y1);
                iTextBox.Size = new Size((int)(panel1.Width * 0.30), 70);
                y1 += 80;
            }
            foreach (Control textBox in textBoxList)
            {
                textBox.Location = new Point((int)(panel1.Width * 0.52), y2);
                textBox.Size = new Size((int)(panel1.Width * 0.30), 70);
                y2 += 80;
            }
            label1.Size = new System.Drawing.Size((int)(panel2.Width * 0.18), 23);
            label2.Size = new System.Drawing.Size((int)(panel2.Width * 0.30), 23);
            label3.Size = new System.Drawing.Size((int)(panel2.Width * 0.30), 23);
            label2.Location = new System.Drawing.Point((int)(panel2.Width * 0.2), 0);
            label3.Location = new System.Drawing.Point((int)(panel2.Width * 0.52), 0);
        }
        ;
        // 
        // JsonLocalizator
        // 
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
        AutoScroll = true;
        AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        BackColor = Color.FromArgb(255,204,153);
        Text = "Локализатор json-структур";
        ClientSize = new System.Drawing.Size(1264, 790);
        Controls.Add(tableLayoutPanel1);
        KeyPreview = true;
        Location = new System.Drawing.Point(15, 15);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Load += JsonTranslator_Load;
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        panel2.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Panel panel2;

    private System.Windows.Forms.Panel panel1;
    
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    private System.Windows.Forms.Button button4;

    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.ComboBox comboBox1;

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.Button button1;

    #endregion
}