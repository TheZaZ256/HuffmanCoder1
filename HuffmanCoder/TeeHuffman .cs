using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuffmanCoder
{
    internal class TreeHuffman
    {//Древо Хаффмана
       
        public class UselOfTreeHaffman : IComparable<UselOfTreeHaffman>
        {//Узел дерева
            public int countUsel { get; set; } //частота узла
            public char symbol { get; set; } //символ

            public UselOfTreeHaffman leftUsel { get; set; } //Левый узел
            public UselOfTreeHaffman rightUsel { get; set; } //Правый узел
            public UselOfTreeHaffman parrentUsel { get; set; } //Родительский узел

            // Реализация интерфейса IComparable для сравнения узлов по частоте
            public int CompareTo(UselOfTreeHaffman other)
            {
                //т.к. мы используем сортируемые элементы, нам нужно указать, как нам сравнивать узлы

                if (other == null) return 1; // Текущий объект больше, если other равен null

                // Сначала сравниваем по count
                if (this.countUsel != other.countUsel)
                {
                    return this.countUsel - other.countUsel;
                }
                else if (this.symbol != other.symbol)
                {
                    // Если count одинаковый, сравниваем по symbol
                    return this.symbol.CompareTo(other.symbol);
                }
                return 0;
            }
        }

        public UselOfTreeHaffman BuildRootOfTreeHuffman(Dictionary<char, int> myDictionary)
        {//строим дерево
            var priorityQueue = new SortedSet<UselOfTreeHaffman>();
            try
            {
                foreach (var element in myDictionary)
                {//добавляем узлы в словарь с узлами

                    priorityQueue.Add(new UselOfTreeHaffman
                    {
                        symbol = element.Key,
                        countUsel = element.Value,
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при построении приоритетной очереди: {ex.Message}"); ;
            }

            int idParrentUsel = 0;
            //ПОСКОЛЬКУ УЗЛЫ НУЖНО СРАВНИВАТЬ
            //РЕАЛИЗОВАНО СРАВНЕНИЕ ПО ID
            //НАСКОЛЬКО КОРРЕКТНО ДАННОЕ РЕШЕНИЕ?
            while (priorityQueue.Count > 1)
            {
                // Извлекаем два узла с наименьшей частотой
                var usel1 = priorityQueue.Min;
                priorityQueue.Remove(usel1);

                var usel2 = priorityQueue.Min;
                priorityQueue.Remove(usel2);

                // Создаем новый узел, объединяя два извлеченных узла
                var parentUsel = new UselOfTreeHaffman
                {
                    symbol = Convert.ToChar(idParrentUsel), // Внутренний узел не содержит символа
                    countUsel = usel1.countUsel + usel2.countUsel,
                    leftUsel = usel1,
                    rightUsel = usel2
                };

                // Добавляем новый узел обратно в очередь
                priorityQueue.Add(parentUsel);
                idParrentUsel++;
            }
            // Корень дерева Хаффмана
            var rootUsel = priorityQueue.Min;
            //по итогу остается один узел, содержащий информацию о всех узлах
            return rootUsel;
        }

        public Dictionary<char, string> EncodeTreeHuffman(UselOfTreeHaffman rootUselForEncode)
        {
            var codeTable = new Dictionary<char, string>(); // Таблица для хранения кодов

            if (rootUselForEncode == null) return codeTable; // Если дерево пустое, возвращаем пустую таблицу

            var stack = new Stack<(UselOfTreeHaffman node, string code)>(); // Стек для обхода дерева
            stack.Push((rootUselForEncode, "")); // Добавляем в стек корень 
            // самый первый узел - его код пустой

            while (stack.Count > 0)
            {//пока в сетеке есть узел

                var (currentUsel, currentCode) = stack.Pop(); //извлекаем из стека узел и его код и передаем его в переменную

                if (currentUsel.leftUsel != null || currentUsel.rightUsel != null)
                {//если у узла есть левый и правый узел

                    if (currentUsel.leftUsel != null)
                    {//Если есть левый узел

                        stack.Push((currentUsel.leftUsel, currentCode + "0"));
                        //добавляем в стек узел и его код
                    }
                    if (currentUsel.rightUsel != null)
                    {//Если есть правый узел

                        stack.Push((currentUsel.rightUsel, currentCode + "1"));
                        //добавляем в стек узел и его код

                    }
                }
                else
                {//если у узла нет левых и правых узлов - лист - кончный узел 
                    //если дошли до конечного элемента в дереве
                    // то присваиваем код этому элементу
                    // 0 - если двигались влево от корня
                    // 1 если двигались вправо
                    // ПРИМЕР: 0 - левый от корня 1 - правый от корня
                    // 00 - два раза влево, 11- два раза вправо
                    // 01 - сначала влево пошли, потом вправо 10 - сначала вправо, потом влево
                    // в стек не добавляем элемент обратно
                    // поэтому количество узлов в стеке уменьшилось
                    // у каждого узла уже есть код
                    // поэтому когда мы последний элемент добавили в таблицу кодирования
                    // берем следующий узел, который теперь тоже стал конечным
                    // и переходим сюда
                    // и currentCode этого узла уже содержит какое-то значение
                    try
                    {//Метод Add может вызвать исключение, если в таблице кодирования уже есть символ
                        //на всякий случай обработаем, вдруг что-то пойдет не так...
                        codeTable.Add(currentUsel.symbol, currentCode);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Что-то пошло не так при построении таблицы кодирования:");
                    }
                }
            }
            return codeTable;
        }

        
    }
}

