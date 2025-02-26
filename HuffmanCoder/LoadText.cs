using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanCoder
{
    internal class LoadText
    {
        public string LoadedText()
        {
            try
            {
                // Открываем диалог выбора файла
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt"; // Фильтр для текстовых файлов
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK) // Если файл выбран
                    {
                        using (var reader = new StreamReader(openFileDialog.FileName, Encoding.Default, true))
                        {
                            reader.Peek(); // Чтение для определения кодировки

                            // Читаем содержимое файла
                            string fileContent = File.ReadAllText(openFileDialog.FileName);

                            // Загружаем текст в TextBox
                            return fileContent;

                            if (reader.CurrentEncoding == Encoding.UTF8)
                            {
                                
                            }
                            else
                            {
                                throw new Exception("Неверная кодировка");
                            }

                        }

                    }
                    else
                    {
                        throw new Exception("Не удалось прочитать файл");
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок (например, если файл недоступен)
                MessageBox.Show($"Ошибка при загрузке файла с текстом: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }


        }


    }
}
