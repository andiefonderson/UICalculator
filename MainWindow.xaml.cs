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
        private bool finalCalculation = false;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void InputOperator(string op)
        {
            if (EntryIsANumber())
            {
                AddNumberToCalc();
            }
            inputDisplay.Content = op;
            newNumberInput = false;
        }

        private void InputNumber(float num)
        {
            if (!EntryIsANumber())
            {
                AddOperatorToCalc();
            }

            if (inputDisplay.Content.ToString().Length < 10)
            {
                if (!newNumberInput)
                {
                    inputDisplay.Content = num.ToString();
                    newNumberInput = true;
                    finalCalculation = false;
                }
                else
                {
                    inputDisplay.Content += num.ToString();
                }
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
            inputHistory.Content += inputDisplay.Content.ToString();
            return float.Parse(inputDisplay.Content.ToString());            
        }

        private void AddOperatorToCalc()
        {
            inputHistory.Content += inputDisplay.Content.ToString();
        }

        private bool EntryIsANumber()
        {
            float num;
            return float.TryParse(inputDisplay.Content.ToString(), out num);
        }

        private string Calculate()
        {
            if (EntryIsANumber())
            {
                AddNumberToCalc();
            }            
            string calculateValue = inputHistory.Content.ToString();
            string calculatedNumber;
            try
            {
                calculatedNumber = new DataTable().Compute(calculateValue, null).ToString();
            }
            catch (Exception) { return "ERROR"; }
            
            newNumberInput = false;
            inputHistory.Content = "";
            finalCalculation = true;

            return ErrorCheck(calculatedNumber);
        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            inputDisplay.Content = Calculate();
        }

        private void backSpaceButton_Click(object sender, RoutedEventArgs e)
        {
            string inputString = inputDisplay.Content.ToString();

            if (EntryIsANumber() && !finalCalculation)
            {
                if (inputDisplay.Content.ToString() != "0")
                {
                    if(inputString.Length != 1)
                    {
                        inputDisplay.Content = inputString.Remove(inputString.Length - 1);
                    }
                    else
                    {
                        ClearDisplay();
                    }
                    
                }
            }
            
        }

        private void clearEntryButton_Click(object sender, RoutedEventArgs e)
        {
            if (EntryIsANumber())
            {
                ClearDisplay();
            }
        }

        private void clearAllButton_Click(object sender, RoutedEventArgs e)
        {
            inputDisplay.Content = "0";
            inputHistory.Content = "";
            newNumberInput = false;
        }

        private void ClearDisplay()
        {
            inputDisplay.Content = "0";
            newNumberInput = false;
        }
        
        private string ErrorCheck(string numString)
        {
            if(numString == float.PositiveInfinity.ToString() || 
                numString == float.NegativeInfinity.ToString() || 
                float.Parse(numString) > 999999999)
            {
                return "ERROR";
            }
            else
            {
                return RoundNumber(numString);
            }
        }

        private string RoundNumber(string numString)
        {            
            try
            {
                if (numString.Length > 10 && (float.Parse(numString) < 100000000))
                {
                    return numString.Substring(0, 10);
                }
                else
                {
                    return numString;
                }
            }
            catch (Exception ex)
            {
                return "ERROR";
                throw;
            }
        }

        private void dotButton_Click(object sender, RoutedEventArgs e)
        {
            if (!inputDisplay.Content.ToString().Contains("."))
            {
                inputDisplay.Content += ".";
                if (!newNumberInput)
                {
                    newNumberInput = true;
                }
            }
        }
    }
}
