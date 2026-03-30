using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Симулятор_простого_рестарана_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private Employee employee = new Employee();
        private object currentOrder;

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string menuItem = radioButton1.Checked ? "Chicken" : "Egg";
                int kolichestvo = int.Parse(textBox1.Text);

                currentOrder = employee.NewRequest(menuItem, kolichestvo);

                string inspectResult = employee.Inspect(currentOrder);

                textBox2.AppendText($"Новый запрос: {menuItem}, Кол-во: {kolichestvo}\r\n");
                textBox2.AppendText($"Инспекция: {inspectResult}\r\n\r\n");

                if (menuItem == "Egg")
                {
                    label2.Text = inspectResult; 
                }
                else
                {
                    label2.Text = "Chicken selected"; 
                }
            }
            catch (Exception ex)
            {
                textBox2.AppendText($"Error: {ex.Message}\r\n\r\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
       
                currentOrder = employee.CopyRequest();

                string inspectResult = employee.Inspect(currentOrder);

                textBox2.AppendText("Копия предыдущего заказа.\r\n");
                textBox2.AppendText($"Инспекция копии: {inspectResult}\r\n\r\n");

                label2.Text = inspectResult;
            }
            catch (Exception ex)
            {
                textBox2.AppendText($"Error: {ex.Message}\r\n\r\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentOrder != null)
                {
                    string result = employee.PrepareFood(currentOrder);
                    textBox2.AppendText(result + "\r\n\r\n");

     
                    currentOrder = null;
                    label2.Text = "Egg Quality: -";
                }
                else
                {
                    textBox2.AppendText("Нет заказа для приготовления!\r\n\r\n");
                }
            }
            catch (Exception ex)
            {
                textBox2.AppendText($"Error: {ex.Message}\r\n\r\n");
            }
        }
    }
}
