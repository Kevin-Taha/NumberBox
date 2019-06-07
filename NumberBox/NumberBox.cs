using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace NumberBox
{
    public sealed partial class NumberBox : TextBox
    {

        public double value{ get; set; }
        
        public NumberBox()
        {
            this.DefaultStyleKey = typeof(TextBox);

            


        }


        /* Fix this
        private void OnLostFocus()
        {
            this.Text = "LOST FOCUS";

        }*/

        
        
       




    }
}
