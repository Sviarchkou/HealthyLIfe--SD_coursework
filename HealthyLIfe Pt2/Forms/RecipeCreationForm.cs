using HealthyLife_Pt2.Controllers;
using HealthyLife_Pt2.Models;
using HealthyLIfe_Pt2.FormControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthyLIfe_Pt2.Forms
{
    public partial class RecipeCreationForm : Form
    {

        List<Product> products = new List<Product>();
        IEnumerable<Product> filteredProducts = new List<Product>();

        public RecipeCreationForm()
        {
            InitializeComponent();
            fillProducts();
            comboBox.DisplayMember = "name";

            
            comboBox.TextUpdate += delegate (object? sender, EventArgs e)
            {
                if (comboBox.Text != "")
                {
                    filteredProducts = from p in products where p.name.StartsWith(comboBox.Text) select p;
                }
                
            };
        }

        private async void fillProducts()
        {
            ProductController productController = new ProductController();
            products = await productController.select("SELECT * FROM products");

            filteredProducts = products;
            comboBox.DataSource = filteredProducts;

            igredientAddition1.products = products;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            // filteredProducts.First(p => p.id == igredientAddition1.comboBox.);
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {

        }

    }
}
