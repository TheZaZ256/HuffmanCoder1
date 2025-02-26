using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanCoder
{
    internal class Decode
    {
        public string DecodeText(string encodedtext)
        {
            MessageBox.Show("Укажите место хранения таблицы кодировки.");
            Dictionary<char, string> codeTable = LoadDictionaryFromExcel();
            //PrintCodeTable(codeTable);

            string strDecodingText = StrDecodeText(encodedtext, codeTable);

            

            return strDecodingText;
        }

        public Dictionary<char, string> LoadDictionaryFromExcel()
        {
            var dictionary = new Dictionary<char, string>();

            // Создаем OpenFileDialog
            // Открываем диалог выбора файла
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openFileDialog.Title = "Выберите файл с кодами Хаффмана";

                // Открываем диалог выбора файла
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Настройка контекста лицензии (EPPlus требует этого для некоммерческого использования)
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        // Открываем Excel-файл
                        using (var package = new ExcelPackage(new FileInfo(openFileDialog.FileName)))
                        {
                            var worksheet = package.Workbook.Worksheets[0]; // Первый лист

                            int row = 2; // Начинаем с первой строки данных (после заголовков)
                            while (worksheet.Cells[row, 1].Text != "")
                            {
                                char symbol = worksheet.Cells[row, 1].Text[0]; // Символ
                                string code = worksheet.Cells[row, 2].Text;    // Код
                                dictionary[symbol] = code;
                                row++;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке файла в процессе декодирования: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }


            return dictionary;
        }

        public string StrDecodeText(string encodedText, Dictionary<char, string> codeTable)
        {
            // Создаем обратный словарь: код->символ

            var reverseCodes = new Dictionary<string, char>();
            foreach (var kvp in codeTable)
            {
                reverseCodes[kvp.Value] = kvp.Key;
            }
            var decodedText = new StringBuilder();
            string currentCode = "";

            foreach (char symbol in encodedText)
            {
                currentCode += symbol;

                // Если текущий код найден в словаре, добавляем символ в результат
                if (reverseCodes.ContainsKey(currentCode))
                {
                    decodedText.Append(reverseCodes[currentCode]);
                    currentCode = ""; // Сбрасываем текущий код
                }
            }

            // Если остались необработанные биты
            if (!string.IsNullOrEmpty(currentCode))
            {
                decodedText.Append("?"); // Заменяем нераспознанный код на "?"
                MessageBox.Show("Вероятно, что-то пошло не так в процессе раскодирования. Проверьте таблицу для декодировки/закодированный текст");
                return decodedText.ToString();
            }
            // Показываем сообщение об успешном завершении
            MessageBox.Show("Текст успешно декодирован.");
            return decodedText.ToString();
        }


    }
}
