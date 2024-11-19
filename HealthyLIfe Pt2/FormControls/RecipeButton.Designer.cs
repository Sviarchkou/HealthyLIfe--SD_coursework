namespace HealthyLife_Pt2.FormControls
{
    partial class RecipeButton
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

        public int Rad
        {
            get => recipePanel.Rad;
            set
            {
                if (value < 1)
                    value = 1;
                if (value > 90)
                    value = 90;
                recipePanel.Rad = value;
            }
        }
        public string LabelText
        {
            get => recipeLabel.Text;
            set => recipeLabel.Text = value;
        }

        public string DescriptionText
        {
            get => recipeDiscription.Text;
            set => recipeDiscription.Text = value;
        }

        public Image RecipeImage
        {
            get => recipePicture.BackgroundImage;
            set => recipePicture.BackgroundImage = value;
        }

        public Color PanelColor
        {
            get => recipePanel.PanelColor;
            set => recipePanel.PanelColor = value;
        }


        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            recipeLabel = new Label();
            recipeDiscription = new Label();
            recipePanel = new MyPanel();
            recipePicture = new Panel();
            SuspendLayout();
            // 
            // recipeLabel
            // 
            recipeLabel.AutoSize = true;
            recipeLabel.BackColor = Color.Gainsboro;
            recipeLabel.Enabled = false;
            recipeLabel.Font = new Font("Verdana", 13.8F, FontStyle.Bold);
            recipeLabel.Location = new Point(133, 25);
            recipeLabel.MaximumSize = new Size(280, 30);
            recipeLabel.Name = "recipeLabel";
            recipeLabel.Size = new Size(257, 28);
            recipeLabel.TabIndex = 22;
            recipeLabel.Text = "Запечёная курица";
            // 
            // recipeDiscription
            // 
            recipeDiscription.AutoSize = true;
            recipeDiscription.BackColor = Color.Gainsboro;
            recipeDiscription.Enabled = false;
            recipeDiscription.Font = new Font("Verdana", 10F);
            recipeDiscription.Location = new Point(133, 53);
            recipeDiscription.MaximumSize = new Size(280, 20);
            recipeDiscription.Name = "recipeDiscription";
            recipeDiscription.Size = new Size(274, 20);
            recipeDiscription.TabIndex = 24;
            recipeDiscription.Text = "Рекомендуется 470 ккал . . . .";
            // 
            // recipePanel
            // 
            recipePanel.BackColor = Color.Transparent;
            recipePanel.BorderColor = Color.Transparent;
            recipePanel.Location = new Point(3, 3);
            recipePanel.Name = "recipePanel";
            recipePanel.PanelColor = Color.Gainsboro;
            recipePanel.Rad = 15;
            recipePanel.Size = new Size(520, 100);
            recipePanel.TabIndex = 26;
            // 
            // recipePicture
            // 
            recipePicture.BackColor = Color.Gainsboro;
            recipePicture.BackgroundImage = Properties.Resources.Brakfast_1;
            recipePicture.BackgroundImageLayout = ImageLayout.Stretch;
            recipePicture.Enabled = false;
            recipePicture.Location = new Point(23, 11);
            recipePicture.Name = "recipePicture";
            recipePicture.Size = new Size(85, 85);
            recipePicture.TabIndex = 27;
            // 
            // RecipeButton
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(recipePicture);
            Controls.Add(recipeDiscription);
            Controls.Add(recipeLabel);
            Controls.Add(recipePanel);
            MaximumSize = new Size(525, 105);
            MinimumSize = new Size(525, 105);
            Name = "RecipeButton";
            Size = new Size(525, 105);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label recipeLabel;
        private Label recipeDiscription;
        private MyPanel recipePanel;
        private Panel recipePicture;
    }
}
