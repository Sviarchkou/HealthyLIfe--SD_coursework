using HealthyLife_Pt2.Controllers;
using HealthyLife_Pt2.Models;
using HealthyLIfe_Pt2.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthyLIfe_Pt2.FormControls
{
    public partial class IgredientAddition : UserControl
    {

        public List<Product> products = new List<Product>();
        public IEnumerable<Product> filteredProducts = new List<Product>();
        Dictionary<Button, Product> buttonProducts = new Dictionary<Button, Product>();
        Dictionary<Button, Product> buttonInfoProducts = new Dictionary<Button, Product>();
        List<Button> productButtonsList = new List<Button>();
        List<Button> productInfoButtonsList = new List<Button>();

        public IgredientAddition()
        {
            InitializeComponent();

            textBox1.TextChanged += delegate (object? sender, EventArgs e)
            {
                if (textBox1.Text != "")
                {
                    filteredProducts = from p in products where p.name.StartsWith(textBox1.Text) select p;
                }

            };

            addButton.Text = "Добавить";
            addButton.MouseEnter += (object? sender, EventArgs e) => addButton.PanelColor = Color.Aqua;
            addButton.MouseLeave += (object? sender, EventArgs e) => addButton.PanelColor = Color.LavenderBlush;

        }


        private void loadData()
        {
            flowLayoutPanel1.Controls.Clear();
            buttonInfoProducts.Clear();
            buttonProducts.Clear();
            //productButtonsList.Clear();
            //productInfoButtonsList.Clear();

            List<Product> temp;
            if (textBox1.Text == "")
                temp = products;
            else
                temp = filteredProducts.ToList();

            int i = 0;
            foreach (Product product in temp)
            {
                flowLayoutPanel1.Controls.Add(createProductButton(product));
                flowLayoutPanel1.Controls.Add(createInfoButton(product));
                i++;
                if (i >= 10) return;
            }

            flowLayoutPanel1.Height = buttonProducts.Count * 25;
        }

        private Button createProductButton(Product product)
        {
            Button button = new Button();
            button.Size = new Size(188, 25);
            button.Text = product.name;
            button.Location = new Point(0, flowLayoutPanel1.Height);
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Font = new Font("Verdana", 8.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonProducts.Add(button, product);
            //productButtonsList.Add(button);
            button.Click += buttonClick;
            button.Padding = new Padding(0, 0, 0, 0);
            button.Margin = new Padding(0, 0, 0, 0);
            return button;
        }
        private Button createInfoButton(Product product)
        {
            Button button = new Button();
            button.Size = new Size(25, 25);
            button.Text = "i";
            button.Location = new Point(188, flowLayoutPanel1.Height);
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.Font = new Font("Verdana", 8.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonInfoProducts.Add(button, product);
            //productInfoButtonsList.Add(button);
            button.Click += infoButtonClick;
            button.Padding = new Padding(0, 0, 0, 0);
            button.Margin = new Padding(0, 0, 0, 0);
            return button;
        }

        private void buttonClick(object sender, EventArgs e)
        {
            buttonProducts.TryGetValue((Button)sender, out Product? p);
            textBox1.Text = p == null ? "" : p.name;
            element.Text = p == null ? "" : p.element.ToString();
            flowLayoutPanel1.Height = 0;
        }

        private void infoButtonClick(object sender, EventArgs e)
        {
            buttonInfoProducts.TryGetValue((Button)sender, out Product? p);
            StringBuilder sb = new StringBuilder(
                $"{p.description}" +
                $"\n\nКалории - {p.element.calories} ккал." +
                $"\nБелки - {p.element.proteins} г." +
                $"\nЖиры - {p.element.fats} г." +
                $"\nУглеводы - {p.element.carbohydrates} г.");

            if (p.element.minerals != null && p.element.minerals != "")
            {
                sb.Append($"\nМинералы - {p.element.minerals}");
            }
            if (p.element.vitamins != null && p.element.vitamins != "")
            {
                sb.Append($"\nВитамины - {p.element.vitamins}");
            }

            MyMessageBox mb = new MyMessageBox();
            mb.LabelText = sb.ToString();
            mb.ShowDialog();
            //MessageBox.Show(sb.ToString());
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            flowLayoutPanel1.Height = 0;
            if (textBox1.Text == "")
                element.Text = "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ProductCreationForm productCreationForm = new ProductCreationForm();
            productCreationForm.existedProducts = products;
            productCreationForm.ShowDialog();
        }

        private void IgredientAddition_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Height = 0;
            if (textBox1.Text == "")
                element.Text = "";
        }

        private void IgredientAddition_MouseLeave(object sender, EventArgs e)
        {
            flowLayoutPanel1.Height = 0;
            if (textBox1.Text == "")
                element.Text = "";
        }
    }
}
