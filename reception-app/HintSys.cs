using System.Drawing;
using System.Windows.Forms;

namespace reception_app
{
    public static class HintSys
    {

        public static void Init(this TextBox textBox, string prompt)
        {
            textBox.Text = prompt;
            textBox.ForeColor = Color.Gray;
            textBox.GotFocus += (source, ex) =>
            {
                if (((TextBox)source).ForeColor == Color.Black)
                    return;
                if (textBox.ForeColor!=Color.Black)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (source, ex) =>
            {
                TextBox t = ((TextBox)source);
                if (t.Text.Length == 0)
                {
                    t.Text = prompt;
                    t.ForeColor = Color.Gray;
                    return;
                }
                if (textBox.ForeColor==Color.Black && string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Text = prompt;
                    textBox.ForeColor = Color.Gray;
                }
            };
            textBox.TextChanged += (source, ex) =>
            {
                if (((TextBox)source).Text.Length > 0)
                {
                    textBox.ForeColor = Color.Black;
                }
            };
        }
    }
   }
