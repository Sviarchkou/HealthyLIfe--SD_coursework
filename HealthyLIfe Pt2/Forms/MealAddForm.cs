using HealthyLife_Pt2.Controllers;
using HealthyLife_Pt2.FormControls;
using HealthyLife_Pt2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthyLife_Pt2.Forms
{
    public partial class MealAddForm : Form
    {
        private List<Recipe> recipes = new List<Recipe>();
        private Point recipeStartPoint = new Point(47,107);
        private Point plusStartPoint = new Point(481, 130);
        private int step = 110;

        List<RecipeButton> recipeButtons = new List<RecipeButton>();
        List<MyPanel> myPanels = new List<MyPanel>();

        Recipe recipe;
        
        public MealAddForm(Recipe recipe)
        {
            InitializeComponent();
            createButton.Text = "Создать блюдо";
            this.recipe = recipe;

            fillForm();
        }


        private async void fillForm()
        {

            RecipeController recipeController = new RecipeController();
            recipes = await recipeController.select("SELECT * FROM recipes");

            for (int i = 0; i < recipes.Count; i++)
            {
                RecipeButton recipeButton = new RecipeButton();
                recipeButton.LabelText = recipes[i].name;
                recipeButton.DescriptionText = recipes[i].description;
                recipeButton.Location = new Point(recipeStartPoint.X, recipeStartPoint.Y + i * step);
                recipeButtons.Add(recipeButton);

                MyPanel myPanel = new MyPanel();
                myPanel.BackColor = Color.Gainsboro;
                myPanel.BorderColor = Color.Transparent;
                myPanel.Font = new Font("Verdana", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
                myPanel.ForeColor = Color.DarkViolet;
                myPanel.Text = "+";
                myPanel.Location = new Point(plusStartPoint.X, plusStartPoint.Y + i*step);
                myPanel.PanelColor = Color.LavenderBlush;
                myPanel.Rad = 60;
                myPanel.Size = new Size(60, 60);
                myPanels.Add(myPanel);

                Controls.Add(recipeButton);
                Controls.Add(myPanel);
                myPanel.BringToFront();
            }
        }

        private void myPanel_Click(object sender, EventArgs e)
        {
            int i = myPanels.IndexOf((MyPanel) sender);
            recipe = recipes[i];
            recipeButtons[i].BackColor = Color.YellowGreen;

        }

        private void MealAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void recipeAddButton_Load(object sender, EventArgs e)
        {
                    
        }



        private void createButton_Load(object sender, EventArgs e)
        {

        }
    }
}
