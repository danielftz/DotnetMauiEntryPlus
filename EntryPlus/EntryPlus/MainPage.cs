#nullable enable
using System.Diagnostics;

namespace EntryPlus
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            Grid g = new()
            {
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                },
            };

            BoxView b1 = new()
            {
                Color = Colors.Green,
                GestureRecognizers =
                {
                    new TapGestureRecognizer()
                    {
                        Command = new Command(() =>
                        {
                            Debug.WriteLine("box clicked");
                        })
                    }
                }
            };
            g.Add(b1, 0, 0);
            BoxView b2 = new()
            {
                Color = Colors.Blue,
            };
            g.Add(b2, 0, 1);

            BoxView b3 = new()
            {
                Color = Colors.Red,
                GestureRecognizers =
                {
                    new TapGestureRecognizer()
                    {
                        Command = new Command(() =>
                        {
                            Debug.WriteLine("box clicked");
                        })
                    }
                }
            };

            g.Add(b3, 0, 2);

            EntryPlus e1 = new()
            {
                BackgroundColor = Colors.Navy,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center,
            };
            g.Add(e1, 0, 0);

            EntryPlusBacking e2 = new()
            {
                Placeholder = "Try me",
                TextColor = Colors.White,
                VerticalOptions = LayoutOptions.Center
            };
            g.Add(e2, 0, 1);

           
            EntryPlusBacking e3 = new()
            {
                Placeholder = "Try me",
                TextColor = Colors.White,
                VerticalOptions = LayoutOptions.Center
            };
            g.Add(e3, 0, 2);

            Content = g;


            this.Loaded += (s, e) =>
            {
                //SetUpKeyboardHider
                Application.Current?.MainPage?.SetupKeyboardHider();
            };
        }
    }
}
