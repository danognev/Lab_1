using System;

namespace Lab_1
{
  class Interface
  {
    public static void InfoMess() {
      Console.WriteLine("Программа выполнена студентом 494 группы Огневым Даниилом," +
      "\nЗадача программы: Осуществить циклический сдвиг массива вправо на N позиций");
      UserVariants();
    }
    public static void UserVariants() {
      Console.WriteLine("\n\nЧто вы хотите сделать далее?\n1. Ввести данные с клавиатуры\n2. Заполнить данные рандомно" +
      "\n3. Загрузить из файла\n4. Выйти из программы"); 
    }
    public static void ShowNextMenu(string type) {
      Console.WriteLine("\n\nЧто вы хотите сделать далее?\n1. Продолжить выполнение программы\n2. Сохранить " + type + " данные в файл");
    }
  }
}
