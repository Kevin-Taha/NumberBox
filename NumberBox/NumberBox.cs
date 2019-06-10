using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using System.Text.RegularExpressions;

namespace NumberBox
{
    public sealed partial class NumberBox : TextBox
    {

        public double value { get; set; }
        public Boolean HasError { get; set; }

        public NumberBox()
        {
            this.DefaultStyleKey = typeof(TextBox);

            


        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            Regex rx = new Regex("\\d+.?\\d+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Give Validaton error if no match 
            if( !rx.IsMatch(this.Text) )
            {
                RaiseValidationError();
            }
            else
            {
                UpdateValidationBox();
            }

        }


        private void RaiseValidationError()
        {
            this.HasError = true;
            

        }

        private void UpdateValidationBox()
        {
            if ( this.HasError)
            {
                this.HasError = false;
                
                //TODO: Update Visual States
            }
        }


        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.Register("HasError", typeof(bool), typeof(NumberBox), new PropertyMetadata(false, HasErrorUpdated));

        private static void HasErrorUpdated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NumberBox numBox = d as NumberBox;

            if ( numBox != null )
            {
                if ( numBox.HasError )
                {
                    VisualStateManager.GoToState(numBox, "InvalidState", false);
                }
                else
                {
                    VisualStateManager.GoToState(numBox, "ValidState", false);
                }
            }
        }
     







    }
}
