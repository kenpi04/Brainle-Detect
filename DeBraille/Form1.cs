using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeBraille
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
           textBox1.Text = DeBeailleToText(richTextBox1.Text);
        }
        private string DeBeailleToText(string text)
        {
            text = text.Replace(" ", string.Empty);
            text = Regex.Replace(text, @"\t|\n|\r", string.Empty);
            richTextBox1.Text = text;
            var chars = Split(text, 6);
            
            var result = new List<string>();
            foreach(var str in chars)
            {

                result.Add(ConvertbrailleToChar(str,true));
            }

           
            return string.Join("",result);
        }
        private string ConvertbrailleToChar(string code,bool isTextFromWeb=false)
        {
            //convert
            if(isTextFromWeb)
            {
               
                string left = "", right = "";
                for (int i = 0; i < code.Length; i++)
                {
                    char a = '1';
                    if (code[i] == '.')
                        a = '0';

                    if (i % 2 == 0)
                        left += a;
                    else
                        right += a;
                }
                code = left + right;
            }
           
            string keyCode=string.Empty;
            switch (code)
            {
                case "100000":
                    keyCode = "a";
                    break;
                case "110000":
                    keyCode = "b";
                    break;
                case "100100":
                    keyCode = "c";
                    break;
                case "100110":
                    keyCode = "d";
                    break;
                case "100010":
                    keyCode = "e";
                    break;
                case "110100":
                    keyCode = "f";
                    break;
                case "110110":
                    keyCode = "g";
                    break;
                case "110010":
                    keyCode = "h";
                    break;
                case "010100":
                    keyCode = "i";
                    break;
                case "010110":
                    keyCode = "j";
                    break;
                case "101000":
                    keyCode = "k";
                    break;
                case "111000":
                    keyCode = "l";
                    break;
                case "101100":
                    keyCode = "m";
                    break;
                case "101110":
                    keyCode = "n";
                    break;
                case "101010":
                    keyCode = "o";
                    break;
                case "111100":
                    keyCode = "p";
                    break;
                case "111110":
                    keyCode = "q";
                    break;
                case "111010":
                    keyCode = "r";
                    break;
                case "011100":
                    keyCode = "s";
                    break;
                case "011110":
                    keyCode = "t";
                    break;
                case "101001":
                    keyCode = "u";
                    break;
                case "111001":
                    keyCode = "v";
                    break;
                case "010111":
                    keyCode = "w";
                    break;
                case "101101":
                    keyCode = "x";
                    break;
                case "101111":
                    keyCode = "y";
                    break;
                case "101011":
                    keyCode = "z";
                    break;
                case "010000":
                    keyCode = "1";
                    break;
                case "011000":
                    keyCode = "2";
                    break;
                case "010010":
                    keyCode = "3";
                    break;
                case "010011":
                    keyCode = "4";
                    break;
                case "010001":
                    keyCode = "5";
                    break;
                case "011010":
                    keyCode = "6";
                    break;
                case "011011":
                    keyCode = "7";
                    break;
                case "011001":
                    keyCode = "8";
                    break;
                case "001010":
                    keyCode = "9";
                    break;
                case "001011":
                    keyCode = "0";
                    break;
                case "111101":
                    keyCode = "&";
                    break;
                case "111111":
                    keyCode = "=";
                    break;
                case "111011":
                    keyCode = "(";
                    break;
                case "011101":
                    keyCode = "!";
                    break;
                case "011111":
                    keyCode = ")";
                    break;
                case "100001":
                    keyCode = "*";
                    break;
                case "110001":
                    keyCode = "<";
                    break;
                case "100101":
                    keyCode = "%";
                    break;
                case "100111":
                    keyCode = "?";
                    break;
                case "100011":
                    keyCode = ":";
                    break;
                case "110101":
                    keyCode = "$";
                    break;
                case "110111":
                    keyCode = "]";
                    break;
                case "110011":
                    keyCode = "\\";
                    break;
                case "010101":
                    keyCode = "[";
                    break;
                case "001100":
                    keyCode = "/";
                    break;
                case "001101":
                    keyCode = "+";
                    break;
                case "001111":
                    keyCode = "#";
                    break;
                case "001110":
                    keyCode = ">";
                    break;
                case "001000":
                    keyCode = "'";
                    break;
                case "001001":
                    keyCode = "-";
                    break;
                case "000100":
                    keyCode = "@";
                    break;
                case "000110":
                    keyCode = "^";
                    break;
                case "000111":
                    keyCode = "_";
                    break;
                case "000010":
                    keyCode = "\"";
                    break;
                case "000101":
                    keyCode = ".";
                    break;
                case "000011":
                    keyCode = ";";
                    break;
                case "000001":
                    keyCode = ",";
                    break;
                case "000000":
                    keyCode = " ";
                    break;
            }
            return keyCode;
        }
        static IEnumerable<string> Split(string str, int chunkSize)
{
    return Enumerable.Range(0, str.Length / chunkSize)
        .Select(i => str.Substring(i * chunkSize, chunkSize));
}

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.D1:case Keys.NumPad1:
                    btn1.PerformClick();
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    btn2.PerformClick();
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    btn3.PerformClick();
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    btn4.PerformClick();
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    btn5.PerformClick();
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    btn6.PerformClick();
                    break;
                case Keys.Space:
                    btnOK.PerformClick();
                    break;
            }
        }
        private int[] code = new int[6] { 0, 0, 0, 0, 0, 0 };
        private void btn1_Click(object sender, EventArgs e)
        {
            var buttonClick = (Button)sender;
            int tag =(int) buttonClick.Tag;
            if(tag!=0)
            {
                code[tag - 1] = code[tag - 1] == 0 ? 1 : 0;
                if (code[tag - 1] == 0)
                    buttonClick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                else
                    buttonClick.BackColor = Color.Red;
            }
            else
            {
               
        
                foreach(Button b in groupBox1.Controls)
                    b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                textBox1.Text += ConvertbrailleToChar(string.Join("", code));
                code = new int[6] { 0, 0, 0, 0, 0, 0 };
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = DeBeailleToText(richTextBox1.Text);
        }
    }
}
