const int QUANTITY = 4; // создаем константу для того что-бы не было magic number.

Console.WriteLine("\n" +
                    "Написать программу, которая из имеющегося массива строк " +
                    "формирует массив из строк, длина которых меньше либо равна 3 символа. " +
                    "Первоначальный массив можно ввести с клавиатуры, " +
                    "либо задать на старте выполнения алгоритма. " +
                    "При решение не рекомендуется пользоваться коллекциями, " +
                    "лучше обойтись исключительно массивами" +
                    "\n");

int GetArraySizeFromUser()
{
    int size = 0; // переменная по умолчанию
    while(size < 1) // цикл
    {
    try // код в котором может быть ошибка
        {   
            Console.Write("Какое количество элементов будет в массиве: "); // спрашиваем длину массива
            size = Convert.ToInt32(Console.ReadLine()); // сохраняем в переменную size

            if(size < 1) Console.WriteLine("Введенное значение введенно меньше единицы, попробуйте снова"); // начинаем заново
        }
    catch (System.FormatException) // в случае ошибки
        {
            Console.WriteLine("Вы ввели не число, давайте попробуем еще раз"); // выводим сообщение
        }
    }
     return size;
}

string[] CreateArray() // создаем метод
{
    int size = GetArraySizeFromUser(); // применяем метод с размером
    string[] newarray = new string[size]; // создаем новый массив
    for(int i = 0; i < size; i++)
    {
        Console.Write($"Введите {i + 1} элемент массива: "); // вводим значение в массив
        string? text_array = Console.ReadLine(); // записываем, переписываем переменную (знак вопроса что бы не выдавал предупреждение)

        if(text_array == null) newarray[i] = string.Empty; // делаем что не ругался на NULL терминал
        else newarray[i] = text_array; // в другом случае присваиваем текст
    }
    return newarray; // возвращаем результат
}

string[] LessThanFourArray(string[] newarray) // создаем отдельный метод string
{
    string[] array_two = new string[newarray.Length]; // создаем новый массив с такой же длинной
    for(int i = 0; i < newarray.Length; i++)
    {
        if(newarray[i].Length < QUANTITY) array_two[i] = newarray[i]; // если условия соблюдены, записываем
    }
    return array_two; // возврат
}

void ShowArray(string[] newarray) // объявляем метод
{
    for(int i = 0; i < newarray.Length; i++)
    {
        if (newarray[i] != null) // выводим только в случае если массив не пустой
        {
            if(i == newarray.Length - 1) Console.Write($"[{newarray[i]}]"); // последняя строка без запятой
            else Console.Write($"[{newarray[i]}], ");
        }
    }
    Console.WriteLine(); // пустая строка
}


string[] MyArray = CreateArray();
Console.Write($"Первый массив выглядит так: ");
ShowArray(MyArray);
Console.Write($"Второй массив выглядит так: ");
ShowArray(LessThanFourArray(MyArray));