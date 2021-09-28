using System;
using System.IO;

namespace Lab_1
{
  class Files
  {
    enum SaveVar { rewrite = 1, newfile };
    public enum SaveType { source = 1, result };
    public static void ReadFile()
    {
      string way;
      while (true)
      {
        Console.WriteLine("Введите путь по которому расположен необходимый файл");
        way = Console.ReadLine();
        if (!File.Exists(way))
        {
          Console.WriteLine("Ошибка! По данному пути не найден файл. Попробуйте ещё раз!");
          continue;
        }
        else { break; }
      }
      try
      {
        using (StreamReader rfile = new StreamReader(way))
        {
          ConvertLineToArray(rfile.ReadToEnd());
        }
      }
      catch (Exception)
      {
        Console.WriteLine("Возникла ошибка при чтении файла!");
        Interface.UserVariants();
        Input.MainMenu();
      }
    }
    public static void GetFileWay(int type)
    {
      Console.WriteLine("Введите путь для сохранения файла");
      string way = Console.ReadLine();
      if (File.Exists(way))
      {
        Console.WriteLine("Файл по такому пути уже существует!\nЧто вы хотите сделать далее?");
        Console.WriteLine("1. Перезаписать в файл\n2. Создать новый");
        Input.CheckInput();
        while (Input.GetChoice() < (int)SaveVar.rewrite || Input.GetChoice() > (int)SaveVar.newfile)
        {
          Console.WriteLine("Ошибка! Вы ввели неверный пункт меню. Попробуйте ещё раз!");
          Input.CheckInput();
        }
        switch (Input.GetChoice())
        {
          case (int)SaveVar.rewrite:
            {
              TryToSaveFile(type, way, Algorithm.GetArraySize(), Algorithm.GetArray());
              break;
            }
          case (int)SaveVar.newfile:
            {
              GetFileWay(type);
              break;
            }
        }
      }
      else
        TryToSaveFile(type, way, Algorithm.GetArraySize(), Algorithm.GetArray());
    }
    public static void TryToSaveFile(int type, string way, int ArraySize, int[] Array)
    {
      try
      {
        using (StreamWriter file = new StreamWriter(way, false))
        {
          switch(type) {
            case (int)SaveType.source: {
                file.Write(ArraySize + " ");
                for (int i = 0; i < ArraySize; i++)
                  file.Write(Array[i] + " ");
                file.Close();
                break; 
            }
            case (int)SaveType.result: {
                file.Write("Полученные данные\n\nМассив из " + ArraySize + " элементов\n");
                for (int i = 0; i < ArraySize; i++)
                  file.Write(Array[i] + " ");
                file.Close();
                break; 
            }
          }
        }
        Console.WriteLine("Запись успешно выполнена по пути: " + way);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Попробуйте ещё раз!");
        GetFileWay(type);
      }
    }
    private static void ConvertLineToArray(string text)
    {
      const int ArrSize = 0;
      int Size;
      bool stop = false;
      string[] textArr = text.Split(' ');
      if (!Int32.TryParse(textArr[ArrSize], out Size) || Size < (int)Algorithm.Arr.min || Size > (int)Algorithm.Arr.max)
      {
        Console.WriteLine("Возникла ошибка при чтении файла!");
        Interface.UserVariants();
        Input.MainMenu();
      }
      else
      {
        int[] value = new int[Size];
        for (int i = 0; i < Size; i++)
        {
          if (!Int32.TryParse(textArr[i + 1], out value[i]))
          {
            Console.WriteLine("Возникла ошибка при чтении файла!");
            Interface.UserVariants();
            Input.MainMenu();
            stop = true;
            break;
          }
        }
        if (!stop)
        {
          Algorithm.SetArray(Size, value);
          Console.WriteLine("Файл успешно загружен!");
          Interface.ShowNextMenu("исходные");
          Input.CheckNextChoice(Algorithm.GetArraySize(), Algorithm.GetArray());
        }
      }
    }
  }
}
