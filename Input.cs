using System;

namespace Lab_1
{
  class Input
  {
    private static string input;
    private static int choice = 0;
    private enum Menu { keyboard = 1, rand, fromFile, close };
    private enum NextMenu { work = 1, save };
    private enum FinalMenu { end = 1, saveres };
    public static int GetChoice() { return choice; }
    public static void MainMenu()
    {
      CheckInput();
      switch (choice)
      {
        case (int)Menu.keyboard:
           Algorithm.CreateArray();
           Algorithm.ReadFromKeyboard(Algorithm.GetArraySize(), Algorithm.GetArray());
           Interface.ShowNextMenu("исходные");
           CheckNextChoice(Algorithm.GetArraySize(), Algorithm.GetArray());
           break;
        case (int)Menu.rand:
          Algorithm.CreateArray();
          Algorithm.RandArray(Algorithm.GetArraySize(), Algorithm.GetArray());
          Interface.ShowNextMenu("исходные");
          CheckNextChoice(Algorithm.GetArraySize(), Algorithm.GetArray());
          break;
        case (int)Menu.fromFile:
          {
            Files.ReadFile();
            break;
          }
        case (int)Menu.close: { break; }
      
        default:
            Console.WriteLine("Вы выбрали неверный пункт меню! Попробуйте ещё раз");
            MainMenu();
            break;
      }
    }
    public static void CheckNextChoice(int arraySize, int[]Array) 
    {
      CheckInput();
      switch(choice) 
      {
        case (int)NextMenu.work: 
        {
            Algorithm.ArrayShift(arraySize,GetNpos(), Array);
            Algorithm.ShowArray(arraySize, Array);
            Interface.ShowNextMenu("полученные");
            CheckFinalChoice(arraySize, Array);
            break;
        }
        case (int)NextMenu.save:
          {
            Files.GetFileWay((int)Files.SaveType.source);
            Algorithm.ArrayShift(arraySize,GetNpos(), Array);
            Algorithm.ShowArray(arraySize, Array);
            Interface.ShowNextMenu("полученные");
            CheckFinalChoice(arraySize, Array);
            break;
          }
        default:
        {
            Console.WriteLine("Вы выбрали неверный пункт меню! Попробуйте ещё раз");
            CheckNextChoice(arraySize, Array);
            break;
        }
      }
    }
    private static int GetNpos() {
      const int MIN_N = 0;
      int MAX_N = Algorithm.GetArraySize();
      Console.WriteLine("Введите значение сдвига вправо N");
      CheckInput();
      while(choice < MIN_N || choice > MAX_N) {
        Console.WriteLine("Значение N должно быть в пределах [" + MIN_N.ToString() + ";" + MAX_N.ToString() + "]");
        Console.WriteLine("Попробуйте ещё раз!");
        CheckInput();
      }
      return choice;
    }
    public static void CheckFinalChoice(int arraySize, int[] Array)
    {
      CheckInput();
      switch (choice)
      {
        case (int)FinalMenu.end:
          {
            Interface.UserVariants();
            MainMenu();
            break;
          }
        case (int)FinalMenu.saveres:
          {
            Files.GetFileWay((int)Files.SaveType.result);
            Interface.UserVariants();
            MainMenu();
            break;
          }
        default:
          {
            Console.WriteLine("Вы выбрали неверный пункт меню! Попробуйте ещё раз");
            CheckFinalChoice(arraySize, Array);
            break;
          }
      }
    }
    public static void CheckInput()
    {
      input = Console.ReadLine();
      ConvertToInt(input);
    }
    private static void ConvertToInt(string input)
    {
      if (!int.TryParse(input, out choice))
      {
        Console.WriteLine("Вы ввели некорректные данные. Попробуйте ещё раз!");
        CheckInput();
      }
    }
  }
}
