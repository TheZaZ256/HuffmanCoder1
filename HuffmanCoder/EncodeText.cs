using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HuffmanCoder.TreeHuffman;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;

namespace HuffmanCoder
{
    internal class EncodeText
    {
        public Dictionary<int, string> DictionaryEncodeText(string text)
        {
            
            MessageBox.Show("Выберите место для хранения оригинального текста.");
            SaveOriginalText(text);
            Dictionary<char, int> symbolAndSymbolCountInText = CreateDictionarySymbolAndCountSymbol(text);

            string strSymbolAndSymbolCountInText = SymbolAndSymbolCountInTextToStr(symbolAndSymbolCountInText); //словарь с символом и его частотой в текстовое поле

            var huffmanTree = new TreeHuffman(); //создаем экземпляр класса
            UselOfTreeHaffman rootUselOfTreeHuffman = huffmanTree.BuildRootOfTreeHuffman(symbolAndSymbolCountInText); //создаем древо и получаем корневой узел

            //Вызываем метод для обхода узлов и кодирования элементов
            var codeTable = huffmanTree.EncodeTreeHuffman(rootUselOfTreeHuffman);
            MessageBox.Show("Укажите место для сохранения таблицы кодировки.");
            SaveDictionaryToExcel(codeTable);

            string strCodeTable = CodeTableToString(codeTable); //словарь с символами и кодировкой

            //Вызываем метод для обхода текста и его кодирования
            var encodedText = OriginalTextToEncodedText(text, codeTable);
            
            MessageBox.Show("Выберите место для хранения закодированного текста.");
            SaveEncodedText(encodedText);

            Dictionary<int, string> dictionaryEncodeText = new Dictionary<int, string>();
            dictionaryEncodeText.Add(0, text); // сохраняем оригинальный текст
            dictionaryEncodeText.Add(1, strSymbolAndSymbolCountInText); // сохраняем символы и их частоту
            dictionaryEncodeText.Add(2, strCodeTable); // сохраняем таблицу кодировки
            dictionaryEncodeText.Add(3, encodedText); // сохраняем закодированный текст

            return dictionaryEncodeText;
        }

        private void SaveOriginalText(string encodedText)
        {
            SaveFileDialog svf = new SaveFileDialog();

            svf.Filter = "Файлы txt (*.txt)|*.txt|Все файлы (*.*)|*.*";
            svf.FilterIndex = 1;
            svf.RestoreDirectory = true;

            if (svf.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(svf.FileName, encodedText);

            }
        }

        private Dictionary<char, int> CreateDictionarySymbolAndCountSymbol(string text)
        {//Создаем словарь с элементами и их частотой
            Dictionary<char, int> createdDictionarysymbolAndSymbolCountInText = new Dictionary<char, int>();

            foreach (char symbol in text)
            {

                // Проверяем, есть ли символ в словаре
                if (createdDictionarysymbolAndSymbolCountInText.TryGetValue(symbol, out int currentValue))
                {
                    // Если символ уже есть в словаре, увеличиваем его значение на 1
                    createdDictionarysymbolAndSymbolCountInText[symbol] = currentValue + 1;
                }
                else
                {
                    // Если символа нет в словаре, добавляем его с начальным значением 1
                    createdDictionarysymbolAndSymbolCountInText.Add(symbol, 1);
                }

            }
            return createdDictionarysymbolAndSymbolCountInText;

        }

        public string SymbolAndSymbolCountInTextToStr(Dictionary<char, int> myDictionary)
        {//Выводим словарь с количеством символов + их частота
            if (myDictionary == null || myDictionary.Count == 0)
            {
                MessageBox.Show("Словарь с символами и их частотой пуст.");
                return "Словарь пуст";
            }
            else
            {
                // Используем StringBuilder для эффективной конкатенации строк
                StringBuilder result = new StringBuilder();

                foreach (var element in myDictionary)
                {
                    result.AppendLine($"Символ: {element.Key}, Количество: {element.Value}"); ;
                }
                result.AppendLine("\n");
                return result.ToString();
            }

        }

        public static void SaveDictionaryToExcel(Dictionary<char, string> dictionary)
        {
            SaveFileDialog svf = new SaveFileDialog();

            svf.Filter = "Exel файлы (*.xlsx)|*.xlsx|Exel файлы (*.xlx)|*.xlx|Файлы txt (*.txt)|*.txt|Все файлы (*.*)|*.*";
            svf.FilterIndex = 1;
            svf.RestoreDirectory = true;

            if (svf.ShowDialog() == DialogResult.OK)
            {
                // Настройка контекста лицензии (EPPlus требует этого для некоммерческого использования)
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                // Создаем новый Excel-пакет
                using (var package = new ExcelPackage())
                {
                    // Добавляем лист в книгу
                    var worksheet = package.Workbook.Worksheets.Add("Huffman Codes");

                    // Заголовки столбцов
                    worksheet.Cells[1, 1].Value = "Символ";
                    worksheet.Cells[1, 2].Value = "Код";

                    // Заполняем данные
                    int row = 2;
                    foreach (var kvp in dictionary)
                    {
                        worksheet.Cells[row, 1].Value = kvp.Key.ToString();
                        worksheet.Cells[row, 2].Value = kvp.Value;
                        row++;
                    }

                    // Сохраняем файл
                    package.SaveAs(new FileInfo(svf.FileName));
                }
            }
        }

        public string CodeTableToString(Dictionary<char, string> codeTable)
        {//выводим словарь с элементом + его код
            // Используем StringBuilder для эффективной конкатенации строк
            StringBuilder result = new StringBuilder();
            foreach (var element in codeTable)
            {
                result.AppendLine($"\nСимвол: {element.Key}, Его код: {element.Value}"); ;
            }
            result.AppendLine("\n");
            return result.ToString();
        }

        public string OriginalTextToEncodedText(string originalText, Dictionary<char, string> codeTable)
        {
            // Используем StringBuilder для эффективной конкатенации строк
            var encodedText = new StringBuilder();
            foreach (char symbol in originalText)
            {
                // Если символ есть в словаре, добавляем его код
                if (codeTable.ContainsKey(symbol))
                {
                    encodedText.Append(codeTable[symbol]);
                }
                else
                {
                    // Если символа нет в словаре, можно выбросить исключение или обработать иначе
                    throw new Exception($"Символ '{symbol}' отсутствует в словаре кодов.");
                }
            }

            return encodedText.ToString();
        }

        private void SaveEncodedText(string encodedText)
        {

            // Создаем SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Бинарные файлы (*.bin)|*.bin|Все файлы (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                Title = "Сохранить закодированный текст"
            };

            // Открываем диалог выбора файла
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Преобразуем строку из "0" и "1" в массив байтов
                    int length = encodedText.Length;
                    int byteLength = (length + 7) / 8; // Вычисляем количество байтов
                    byte[] bytes = new byte[byteLength];

                    for (int i = 0; i < length; i++)
                    {
                        if (encodedText[i] == '1')
                        {
                            bytes[i / 8] |= (byte)(1 << (7 - (i % 8))); // Устанавливаем бит
                        }
                    }

                    // Записываем байты в файл
                    using (var writer = new BinaryWriter(File.Open(saveFileDialog.FileName, FileMode.Create)))
                    {//Если длина закодированого текста не кратна 8  
                     //При преобразовании строки из 0 и 1 в байты, если количество бит не кратно 8, .
                     //оставшиеся биты дополняются нулями, чтобы получить полный байт
                     // поэтому сохраняем и читаем длину строки
                        writer.Write(length); // Сохраняем длину текста (в битах)
                        writer.Write(bytes); // Записываем массив байтов

                    }

                    MessageBox.Show("Файл успешно сохранен в процессе кодирования.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла в процессе кодирования: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
