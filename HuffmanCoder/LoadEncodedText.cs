using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanCoder
{
    internal class LoadEncodedText
    {
        public string StrLoadEncodedText()
        {
            // Открываем диалог выбора файла
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Бинарный файлы (*.bin)|*.bin"; // Фильтр для бинарных файлов
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) // Если файл выбран
                {
                    try
                    {
                        using (var reader = new BinaryReader(File.Open(openFileDialog.FileName, FileMode.Open)))
                        {//Если длина закодированого текста не кратна 8  
                            //При преобразовании строки из 0 и 1 в байты, если количество бит не кратно 8, .
                            //оставшиеся биты дополняются нулями, чтобы получить полный байт
                            // поэтому сохраняем и читаем длину строки
                            // Читаем длину текста (в битах)
                            int length = reader.ReadInt32();

                            // Читаем байты
                            byte[] bytes = reader.ReadBytes((length + 7) / 8);

                            // Преобразуем байты обратно в строку из "0" и "1"
                            var encodedText = new StringBuilder();
                            for (int i = 0; i < length; i++)
                            {
                                int byteIndex = i / 8;
                                int bitIndex = 7 - (i % 8);
                                encodedText.Append((bytes[byteIndex] & (1 << bitIndex)) != 0 ? '1' : '0');
                            }
                            return encodedText.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Обработка ошибок (например, если файл недоступен)
                        MessageBox.Show($"Ошибка при загрузке бинарного файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return null;
            }
        }

    }
}
