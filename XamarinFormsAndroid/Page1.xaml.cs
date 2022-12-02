using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        int status = 1;
        string operacao;
        double n1, n2;

        public Page1()
        {
            InitializeComponent();
            OnClear(new object(), new EventArgs());
        }

        private void OnClear(object sender, EventArgs e)
        {
            n1 = 0;
            n2 = 0;
            status = 0;
            this.resultTexto.Text = "0";
        }

        private void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string press = button.Text;

            if (this.resultTexto.Text == "0" || status < 0)
            {
                this.resultTexto.Text = "";
                if (status < 0)
                {
                    status *= -1;
                }
            }

            this.resultTexto.Text += press;

            double numero;
            if (double.TryParse(this.resultTexto.Text, out numero)) 
            {
                this.resultTexto.Text = numero.ToString("N0");
                if (status == 1)
                {
                    n1 = numero;
                }
                else
                {
                    n2 = numero;
                }
            }
        }

        private void OnSelectOperador(object sender, EventArgs e)
        {
            status = -2;
            Button button = (Button)sender;
            string press = button.Text;
            operacao = press;
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            if (status == 2)
            {
                double result = 0;
                if (operacao == "+")
                {
                    result = n1 + n2;
                }
                else if (operacao == "-")
                {
                    result = n1 - n2;
                }
                else if (operacao == "X")
                {
                    result = n1 * n2;
                }
                else if (operacao == "/")
                {
                    result = n1 / n2;
                }

                //this.resultTexto.Text = result.ToString();
                this.resultTexto.Text = result.ToString("N0");
                n1 = result;
                status = -1;
            }
        }
    }
}