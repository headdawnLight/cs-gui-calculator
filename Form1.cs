using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs_gui_calculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if ((textBoxNumbers.Text == "0") || (isOperationPerformed))
                textBoxNumbers.Clear();

            isOperationPerformed = false;

            Button Button = (Button)sender;
            textBoxNumbers.Text += Button.Text;
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button Button = (Button)sender;

            if (resultValue != 0)
            {
                EqualButton.PerformClick();
                operationPerformed = Button.Text;
                operationLabel.Text = resultValue + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = Button.Text;
                resultValue = Double.Parse(textBoxNumbers.Text);
                operationLabel.Text = resultValue + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            textBoxNumbers.Text = "0";
            operationLabel.Text = "0";
            resultValue = 0;
        }

        private void ClearEndButton_Click(object sender, EventArgs e)
        {
            textBoxNumbers.Text = "0";
        }

        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            if (textBoxNumbers.TextLength > 1)
            {
                textBoxNumbers.Text = textBoxNumbers.Text.Substring(0, (textBoxNumbers.Text.Length - 1));
            }
            else
            {
                textBoxNumbers.Text = "0";
            }
        }

        private void SignButton_Click(object sender, EventArgs e)
        {
            if (textBoxNumbers.Text.StartsWith("-"))
            {
                //It's negative now, so strip the `-` sign to make it positive
                textBoxNumbers.Text = textBoxNumbers.Text.Substring(1);
            }
            else if (!string.IsNullOrEmpty(textBoxNumbers.Text) && decimal.Parse(textBoxNumbers.Text) != 0)
            {
                //It's positive now, so prefix the value with the `-` sign to make it negative
                textBoxNumbers.Text = "-" + textBoxNumbers.Text;
            }
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    textBoxNumbers.Text = (resultValue + Double.Parse(textBoxNumbers.Text)).ToString();
                    break;
                case "-":
                    textBoxNumbers.Text = (resultValue - Double.Parse(textBoxNumbers.Text)).ToString();
                    break;
                case "*":
                    textBoxNumbers.Text = (resultValue * Double.Parse(textBoxNumbers.Text)).ToString();
                    break;
                case "/":
                    textBoxNumbers.Text = (resultValue / Double.Parse(textBoxNumbers.Text)).ToString();
                    break;
            }
            resultValue = Double.Parse(textBoxNumbers.Text);
            operationLabel.Text = resultValue + operationPerformed;
            textBoxNumbers.Text = "0";
            isOperationPerformed = true;
        }
    }
}