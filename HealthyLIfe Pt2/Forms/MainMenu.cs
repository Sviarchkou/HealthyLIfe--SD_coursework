using HealthyLife_Pt2.Controllers;
using HealthyLife_Pt2.FormControls;
using HealthyLife_Pt2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthyLife_Pt2.Forms
{
    public partial class MainMenu : Form
    {
        private User user;
        private Element requiredElements;
        private Element currentElement;
        private DailyElement dailyElement;
        private DailyMeal dailyMeal;
        public MainMenu(User user)
        {
            InitializeComponent();

            this.user = user;
            initForm();

            caloriesValueLabel.Text = "";
            proteinValueLabel.Text = "";
            fatValueLabel.Text = "";
            carboValueLabel.Text = "";
            breakfastAddButton.Text = "+";
            lunchAddButton.Text = "+";
            dinnerAddButton.Text = "+";
            extrafoodAddButton.Text = "+";

        }


        private async void initForm()
        {
            UserController userController = new UserController();
            try
            {
                requiredElements = await userController.selectRequiredElement(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникли проблемы при обработке данных");
            }

            DailyElementControler dailyElementControler = new DailyElementControler();
            try
            {
                dailyElement = await dailyElementControler.findToday(user.id.ToString());
                currentElement = dailyElement.element;

            }
            catch (Exception ex)
            {
                currentElement = new Element();
                ElementController elementController = new ElementController();
                currentElement.id = await elementController.insertElement(currentElement);

                dailyElement = await dailyElementControler.insertDailyElement(user, currentElement);
            }

            DailyMealController dailyMealController = new DailyMealController();
            try
            {
                dailyMeal = await dailyMealController.findToday(user.id.ToString());
            }
            catch (Exception ex)
            {
                Meal meal = new Meal();
                ElementController elementController = new ElementController();
                meal.element.id = await elementController.insertElement(meal.element);
                
                MealController mealController = new MealController();
                meal.id = await mealController.insertMeal(meal);

               dailyMeal = await dailyMealController.insertTodayDailyMeal(user, meal);

            }
            

            fillForm();
        }

        private void fillForm()
        {
            caloriesValueLabel.Text = $"Цель - {requiredElements.calories} ккал";
            proteinValueLabel.Text = $"{(int)currentElement.proteins} / {(int)requiredElements.proteins} г";
            fatValueLabel.Text = $"{(int)currentElement.fats} / {(int)requiredElements.fats} г";
            carboValueLabel.Text = $"{(int)currentElement.carbohydrates} / {(int)requiredElements.carbohydrates} г";

            caloriesBar.Text = currentElement.calories.ToString();
            caloriesBar.ValueSize = currentElement.calories * 100 / requiredElements.calories;
            proteinBar.Value = (int)(currentElement.proteins * 100 / requiredElements.proteins);
            fatBar.Value = (int)(currentElement.fats * 100 / requiredElements.fats);
            carbohydratesBar.Value = (int)(currentElement.carbohydrates * 100 / requiredElements.carbohydrates);

            if (dailyMeal.meal.breakfast != null)
                breakfastsDiscription.Text = dailyMeal.meal.breakfast.name;

            if (dailyMeal.meal.lunch != null)
                breakfastsDiscription.Text = dailyMeal.meal.lunch.name;

            if (dailyMeal.meal.dinner != null)
                breakfastsDiscription.Text = dailyMeal.meal.dinner.name;

            if (dailyMeal.meal.extraFood != null)
                breakfastsDiscription.Text = dailyMeal.meal.extraFood.ToString();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void breakfastAddButton_MouseEnter(object sender, EventArgs e)
        {
            breakfastAddButton.PanelColor = Color.White;
        }

        private void breakfastAddButton_MouseLeave(object sender, EventArgs e)
        {
            breakfastAddButton.PanelColor = Color.LavenderBlush;
        }

        private void breakfastAddButton_Click(object sender, EventArgs e)
        {
            if (dailyMeal.meal.breakfast == null)
                dailyMeal.meal.breakfast = new Recipe();
            MealAddForm mealAddition = new MealAddForm(dailyMeal.meal.breakfast);
            mealAddition.Show();
        }

        private void lunchAddButton_Click(object sender, EventArgs e)
        {

            if (dailyMeal.meal.lunch == null)
                dailyMeal.meal.lunch = new Recipe();
            MealAddForm mealAddForm = new MealAddForm(dailyMeal.meal.lunch);
            mealAddForm.Show();
        }

        private void dinnerAddButton_Click(object sender, EventArgs e)
        {

            if (dailyMeal.meal.dinner == null)
                dailyMeal.meal.dinner = new Recipe();
            MealAddForm mealAddForm = new MealAddForm(dailyMeal.meal.dinner);
            mealAddForm.Show();
        }
    }
}
