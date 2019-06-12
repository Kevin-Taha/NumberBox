/*
 * NumberBox Control Prototype
 * @author: Kevin Taha 
 * t-ketaha@microsoft.com
 * 
 * C# Prototype for UWP NumberBox (Microsoft XAML Controls Team)
 * 
*/


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
using System.Diagnostics;
using Windows.Globalization.NumberFormatting;

namespace NumberBox
{

    enum NumberBoxUpDownButtonsPlacementMode
    {
        Off,
        Inline
    };
    
    enum BoundState
    {
        InBounds,
        Under,
        Over
    };




    public sealed partial class NumberBox : TextBox
    {


        // Value Storage Properties
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(NumberBox), new PropertyMetadata((double) 0 ));



        // Validation properties
        public bool BasicValidationEnabled
        {
            get { return (bool)GetValue(BasicValidationEnabledProperty); }
            set { SetValue(BasicValidationEnabledProperty, value); }
        }
        public static readonly DependencyProperty BasicValidationEnabledProperty =
            DependencyProperty.Register("BasicValidationEnabled", typeof(bool), typeof(NumberBox), new PropertyMetadata( (bool) true ) );

        public bool IsInvalidInputOverwritten
        {
            get { return (bool)GetValue(IsInvalidInputOverwrittenProperty); }
            set { SetValue(IsInvalidInputOverwrittenProperty, value); }
        }
        public static readonly DependencyProperty IsInvalidInputOverwrittenProperty =
            DependencyProperty.Register("IsInvalidInputOverwritten", typeof(bool), typeof(NumberBox), new PropertyMetadata( (bool) false));
        public bool HasError
        {
            get { return (bool)GetValue(HasErrorProperty); }
            set { SetValue(HasErrorProperty, value); }
        }
        // Primary Handlers for switching error states (validation)
        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.Register("HasError", typeof(bool), typeof(NumberBox), new PropertyMetadata(false, HasErrorUpdated));



        // Stepping Properties


        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }
        public static readonly DependencyProperty MinValueProperty = 
            DependencyProperty.Register( "MinValue", typeof(double), typeof(NumberBox), new PropertyMetadata( (double) 0) );

        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register( "MaxValue", typeof(double), typeof(NumberBox), new PropertyMetadata( (double) 0) );






        // Executed on change of HasError Property
        private static void HasErrorUpdated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NumberBox numBox = d as NumberBox;
            if (numBox != null)
            {
                if (numBox.HasError)
                {
                    VisualStateManager.GoToState(numBox, "Invalid", false);
                }
                else
                {
                    VisualStateManager.GoToState(numBox, "Normal", false);
                }
            }
        }




        public NumberBox()
        {
            this.DefaultStyleKey = typeof(TextBox);
            this.LostFocus += new RoutedEventHandler(ValidateInput);
            this.PointerExited += new PointerEventHandler(RefreshErrorState);

        }












        // Uses DecimalFormatter to validate that input is compliant
        void ValidateInput(object sender, RoutedEventArgs e)
        {
            if ( !BasicValidationEnabled )
            {
                return;
            }

            DecimalFormatter df = new Windows.Globalization.NumberFormatting.DecimalFormatter();
            Nullable<double> parsedNum = df.ParseDouble(this.Text);

            // Give Validaton error if no match 
            if ( parsedNum == null )
            {
                SetErrorState(true);

            }
            else
            {
                SetErrorState(false);
                this.Value = (double)parsedNum;

            }
        }

        // Sets the Error State of the TextBox. 
        void SetErrorState(bool error)
        {
            if( error )
            {
                if ( this.HasError )
                {
                    VisualStateManager.GoToState(this, "Invalid", false);

                }
                else
                {
                    this.HasError = true;
                }
            }
            else
            {
                this.HasError = false;
            }
        }

        // Ensures that invalid state persists when pointer exits, rather than resetting to normal state.
        void RefreshErrorState(object sender, RoutedEventArgs e)
        {
            NumberBox numBox = (NumberBox) sender;

            if ( numBox.HasError )
            {
                VisualStateManager.GoToState(this, "Invalid", false);
            }
        }

        // Checks if value is in the min/max bounds set by user
        BoundState IsInBounds()
        {
            if ( this.Value < this.MinValue )
            {
                return BoundState.Under;
            }
            else if ( this.Value > this.MaxValue)
            {
                return BoundState.Over;
            }
            return BoundState.InBounds;
        }










    }
}
