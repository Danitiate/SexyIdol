using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        int multiplier;
        public MainPage()
        {
            InitializeComponent();
        }

        void Increase_Number(object sender, EventArgs e)
        {
            int num = int.Parse(Number.Text);

            Number.Text = num.ToString();
        }
    }
}
