using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1
{
	public class Page1 : ContentPage
	{
        Label current_number;
        decimal multiplier = 1;

		public Page1 ()
		{
            current_number = new Label {
                Text = "0",
                TextColor = Color.FromHex("#FF1493"), //Sexy pink
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 50
            };

            Button button = new Button {
                Text = "HIT ME BABY!",
                WidthRequest = 200,
                HeightRequest = 200,
                BackgroundColor = Color.FromHex("#cc0066"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            button.Clicked += Increase_Number;

            Button upgrade1 = new Button {
                Text = "2x click value! (10$)",
                WidthRequest = 100,
                HeightRequest = 100,
                BackgroundColor = Color.FromHex("#cc0066"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            upgrade1.Clicked += Upgrade_Multiplier;

            var layout = new StackLayout();
            layout.BackgroundColor = Color.FromHex("#000000");
            layout.Children.Add(current_number);
            layout.Children.Add(button);
            layout.Children.Add(upgrade1);
            
            Content = layout;
		}

        void Increase_Number(object sender, EventArgs e)
        {
            decimal num = decimal.Parse(current_number.Text);
            try
            {
                num += (decimal)(1 * multiplier);
            }catch(OverflowException ex)
            {
                Console.WriteLine(ex);
                return;
            }
            current_number.Text = num.ToString();
        }

        void Upgrade_Multiplier(object sender, EventArgs e)
        {
            decimal num = decimal.Parse(current_number.Text);
            if(num >= 10)
            {
                num -= 10;
                current_number.Text = num.ToString();
                try
                {
                    multiplier *= 2;
                }catch(ArithmeticException ex)
                {
                    num += 10;
                    Console.WriteLine(ex);
                    current_number.Text = num.ToString();
                }
                
            }
        }
	}
}