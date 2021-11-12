using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UICalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool newNumberInput = false;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void InputOperator(string op)
        {
            if (PreviousEntryWasNumber())
            {
                AddNumberToCalc();
            }
            inputDisplay.Content = op;
            newNumberInput = false;
        }

        private void InputNumber(float num)
        {
            if (!PreviousEntryWasNumber())
            {
                AddOperatorToCalc();
            }

            if (!newNumberInput)
            {
                inputDisplay.Content = num.ToString();
                newNumberInput = true;
            }
            else
            {
                inputDisplay.Content += num.ToString();
            }            
        }

        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            InputOperator("+");
        }

        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            InputOperator("-");
        }


        private void multiplyButton_Click(object sender, RoutedEventArgs e)
        {
            InputOperator("*");
        }

        private void divideButton_Click(object sender, RoutedEventArgs e)
        {
            InputOperator("/");
        }
        private void zeroButton_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(0);
        }

        private void oneButton_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(1);
        }

        private void twoButton_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(2);
        }

        private void threeButton_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(3);
        }

        private void fourButton_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(4);
        }

        private void fiveButton_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(5);
        }

        private void sixButton_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(6);
        }

        private void sevenButton_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(7);
        }

        private void eightButton_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(8);
        }

        private void nineButton_Click(object sender, RoutedEventArgs e)
        {
            InputNumber(9);
        }
        
        private float AddNumberToCalc()
        {
            float addition = float.Parse(inputDisplay.Content.ToString());
            CalculationsText.Content += inputDisplay.Content.ToString();
            return float.Parse(inputDisplay.Content.ToString());            
        }

        private void AddOperatorToCalc()
        {
            CalculationsText.Content += inputDisplay.Content.ToString();
        }

        private bool PreviousEntryWasNumber()
        {
            float num;
            return float.TryParse(inputDisplay.Content.ToString(), out num);
        }

        private float Calculate()
        {
            if (PreviousEntryWasNumber())
            {
                AddNumberToCalc();
            }            
            string calculateValue = CalculationsText.Content.ToString();
            string calculatedNumber = new DataTable().Compute(calculateValue, null).ToString();
            newNumberInput = false;
            CalculationsText.Content = "";

            return float.Parse(calculatedNumber);
        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            inputDisplay.Content = Calculate();
        }
    }
}
