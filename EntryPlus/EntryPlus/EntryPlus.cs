using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPlus
{
    public class EntryPlus : Border
    {
        public EntryPlus()
        {
            Padding = 1;
            StrokeThickness = 1;
            Stroke = new SolidColorBrush(Colors.Turquoise);
            StrokeShape = new RectangleGeometry();
            BackgroundColor = Colors.Navy;
            Grid g = new Grid()
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition(){},
                    new ColumnDefinition(){ Width = new GridLength(25, GridUnitType.Absolute)},
                },
                BackgroundColor = Colors.Transparent,
            };

            g.Add(new EntryPlusBacking()
            {
                Placeholder = "Try me",
                PlaceholderColor = Colors.White,
                TextColor = Colors.White,
                VerticalOptions = HorizontalOptions = LayoutOptions.Fill,

                BackgroundColor = Colors.Transparent,
            }, 0, 0);

            g.Add(new BoxView
            {
                Color = Colors.Black,
                GestureRecognizers =
                {
                    new TapGestureRecognizer()
                    {
                        Command = new Command(()=>Debug.WriteLine("Clear!"))
                    }
                }

            },1,0);

            Content = g;
        }
    }
}
