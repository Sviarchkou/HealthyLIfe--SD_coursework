namespace HealthyLIfe_Pt2.FormControls
{
    partial class IgredientAddition
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            myPanel1 = new HealthyLife_Pt2.FormControls.MyPanel();
            element = new Label();
            addButton = new HealthyLife_Pt2.FormControls.MyPanel();
            textBox1 = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // myPanel1
            // 
            myPanel1.BackColor = Color.Transparent;
            myPanel1.BorderColor = Color.DarkGray;
            myPanel1.Enabled = false;
            myPanel1.Location = new Point(3, 3);
            myPanel1.Name = "myPanel1";
            myPanel1.PanelColor = Color.Gainsboro;
            myPanel1.Rad = 30;
            myPanel1.Size = new Size(377, 85);
            myPanel1.TabIndex = 0;
            // 
            // element
            // 
            element.BackColor = Color.Gainsboro;
            element.Enabled = false;
            element.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            element.Location = new Point(28, 52);
            element.Name = "element";
            element.Size = new Size(311, 21);
            element.TabIndex = 48;
            element.Text = "кбжу";
            // 
            // addButton
            // 
            addButton.BackColor = Color.Gainsboro;
            addButton.BorderColor = Color.Transparent;
            addButton.Font = new Font("Verdana", 8.800001F, FontStyle.Bold, GraphicsUnit.Point, 204);
            addButton.ForeColor = Color.DarkViolet;
            addButton.Location = new Point(267, 19);
            addButton.Name = "addButton";
            addButton.PanelColor = Color.FloralWhite;
            addButton.Rad = 30;
            addButton.Size = new Size(94, 28);
            addButton.TabIndex = 74;
            addButton.Click += addButton_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Location = new Point(28, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(213, 28);
            textBox1.TabIndex = 75;
            textBox1.Click += textBox1_Click;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(28, 52);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(213, 5);
            flowLayoutPanel1.TabIndex = 76;
            // 
            // IgredientAddition
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(textBox1);
            Controls.Add(addButton);
            Controls.Add(element);
            Controls.Add(myPanel1);
            Name = "IgredientAddition";
            Size = new Size(383, 93);
            Click += IgredientAddition_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private HealthyLife_Pt2.FormControls.MyPanel myPanel1;
        private Label element;
        private HealthyLife_Pt2.FormControls.MyPanel addButton;
        private TextBox textBox1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
