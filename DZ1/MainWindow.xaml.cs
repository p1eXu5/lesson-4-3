using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HelloWorldClassDLL;
using System.Threading;

namespace DZ1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            m_bExit.Click += delegate { Close(); };
        }

        private void m_tbNumb_KeyUp(object sender, KeyEventArgs e)
        {
            string numbstr = m_tbNumb.Text;

            if (!string.IsNullOrEmpty(numbstr)) {

                if (Int32.TryParse(numbstr, out int n)) {

                    m_tbFact.FontStyle = FontStyles.Normal;
                    m_tbSumm.FontStyle = FontStyles.Normal;

                    string str1 = "", str2 = "";
                    Thread t1 = new Thread(() => str1 = $"n! = {HelloWorldClass.FactorialN(n)?.ToString() ?? "? // Число слишком большое"}");
                    t1.Start();
                    Thread t2 = new Thread(() => str2 = $"Σn = {HelloWorldClass.SummN(n)?.ToString() ?? "? Число слишком большое"}");
                    t2.Start();

                    t1.Join();
                    t2.Join();

                    m_tbFact.Text = str1;
                    m_tbSumm.Text = str2;
                }
                else {
                    m_tbFact.Text = "Некорректное число";
                    m_tbSumm.Text = "";
                    m_tbFact.FontStyle = FontStyles.Italic;
                    m_tbSumm.FontStyle = FontStyles.Italic;
                }
            }
            else {
                m_tbFact.Text = "Число n не задано";
                m_tbSumm.Text = "";
                m_tbFact.FontStyle = FontStyles.Italic;
                m_tbSumm.FontStyle = FontStyles.Italic;
            }
        }

    }
}
