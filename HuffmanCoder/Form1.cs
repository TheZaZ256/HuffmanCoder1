using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using OfficeOpenXml;
using System.IO;
using static HuffmanCoder.TreeHuffman;
using static HuffmanCoder.EncodeText;
using static HuffmanCoder.Decode;
using static HuffmanCoder.LoadEncodedText;
using System.Runtime.InteropServices.ComTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Messaging;

namespace HuffmanCoder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }


        private void Coding_Click(object sender, EventArgs e)
        {
            string text = txtInput.Text;

            if (rbDecode.Checked == false & rbEncode.Checked == false)
            {
                MessageBox.Show("Выберите 'Закодировать' или 'Раскодировать'.");
                return;
            }
            if (string.IsNullOrEmpty(text))
            {//если поле пустое
                MessageBox.Show("Введите текст или загрузите файл для кодирования/раскодирования.");
                return;
            }

            if (rbEncode.Checked == true)
            {//Если выбрана кнопка "Закодировать"
                EncodeText encodeText = new EncodeText();
                Dictionary<int, string> encodedText = encodeText.DictionaryEncodeText(txtInput.Text);

                txtInput.Text += Environment.NewLine + "символы и их частота:" + Environment.NewLine + encodedText[1]; //выводим словарь в строке с символами и их частотой
                txtInput.Text += "Символы и их кодировка:" + Environment.NewLine + encodedText[2] + Environment.NewLine; //выводим словарь в строке с символами и их кодировкой
                txtInput.Text += "Закодированный текст:" + Environment.NewLine + encodedText[3] + Environment.NewLine; // выводим строку с закодированным текстом
                PrintResultEncodingText(encodedText[0], encodedText[3]); //сравниваем оригинальный текст и закодированный

            }

            if (rbDecode.Checked == true)
            {//Если выбрана кнопка "Раскодировать"
                Decode decodeText = new Decode();
                var decodingText = decodeText.DecodeText(text);

                PrintEncodedText(decodingText);
            }
            
        }

        private void BtnLoadText_Click(object sender, EventArgs e)
        {
            LoadText text = new LoadText();
            string loadedText = text.LoadedText();
            txtInput.Text = loadedText;
        }

        private void BtnLoadBinary_Click(object sender, EventArgs e)
        {
            LoadEncodedText encodedtext = new LoadEncodedText();
            txtInput.Text = encodedtext.StrLoadEncodedText();
        }

        
        public void PrintEncodedText(string encodedText)
        {
            txtInput.Text += Environment.NewLine + "Закодированный текст:" + Environment.NewLine;
            txtInput.Text += encodedText.ToString();
            txtInput.Text += Environment.NewLine;
        }
        
        private void PrintResultEncodingText(string originalText, string encodedText)
        {
            float sizeOriginalText = originalText.Length * 2; //char весит 2 байта

            float sizeEncodedlText = (encodedText.Length + 7) / 8; // Округление вверх
            //потому что если в файле 7 бит, их округляют до байта, заполняя 000000
            sizeEncodedlText = sizeEncodedlText + 4; //в первые 4 байта мы записываем длину строки
            //поэтому 4 - постоянное количество байт в нашем бинарном файле
            // + количество байт текста

            float compression = (sizeOriginalText - sizeEncodedlText) / sizeOriginalText;

            txtInput.Text += Environment.NewLine + "Оригинальный текст весит:(в байтах) " + sizeOriginalText + Environment.NewLine;
            txtInput.Text += "Закодированный текст весит:(в байтах) " + sizeEncodedlText + Environment.NewLine;
            txtInput.Text += "Коэфициент сжатия равен: " + compression;
        }


    }
}
