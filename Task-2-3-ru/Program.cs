using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_3_ru
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Инициализация переменных
            int direction = 0; // 0: направление неизвестно, 1: вверх, -1: вниз
            uint changes = 0;  // Счетчик смен направления
            int new_direction = direction; // Новое направление
            uint prev, current; // Номер этажа, на котором остановился лифт
            bool b_done = false; // Флаговая переменная условие выхода из цикла
            Console.WriteLine("Введите номера этажей, где останавливался лифт.");
            Console.WriteLine("0 - Конец ввода данных");
            // Считываем первый этаж
            uint.TryParse(Console.ReadLine(), out prev);
            b_done = (prev == 0);
            // Цикл ввода и анализа входных данных
            // Данные вводятся до тех пор пока не будет получено число 0
            while (!b_done)
            {
                uint.TryParse(Console.ReadLine(), out current); // Вводим остальные этажи
                b_done = (current == 0); // Выходим из цикла, если введен 0
                // Если этажи совпадают, направление не меняется,
                // просто пропускаем
                if (!b_done && current != prev)
                {
                    // Определяем новое текущее направление
                    // между prev и current
                    new_direction = 1;
                    if (current > prev)
                        new_direction = -1;
                }
                // Если до этого направление уже было известно (не 0)
                // и оно не совпадает с новым направлением, значит произошла смена
                if (!b_done && direction != 0 && new_direction != direction)
                    changes += 1;
                // Обновляем историю для следующего шага
                direction = new_direction;
                prev = current;
            }
            //--- Вывод информации на экран ----
            Console.WriteLine($"Количество смен направления лифтом: {changes}");
            Console.Read(); // Задержка вывода до нажатия клавиши "Ввод"
        }
    }
}
