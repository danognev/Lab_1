using System;

namespace Lab_1
{
  public class Algorithm
  {
    private static int arraySize;
    private static int[] Array;
    public enum Arr { min = 1, max = 100 };
    public static void CreateArray()
    {
      Console.WriteLine("Введите размер массива N:");
      Input.CheckInput();
      while (Input.GetChoice() < (int)Arr.min || Input.GetChoice() > (int)Arr.max)
      {
        Console.WriteLine("Допустимый размер массива от " + (int)Arr.min + " до " + (int)Arr.max);
        Input.CheckInput();
      }
      Array = new int[Input.GetChoice()];
      arraySize = Input.GetChoice();
      Console.WriteLine("Массив на N = " + arraySize + " успешно создан!");
    }
    public static int[] GetArray()
    {
      return Array;
    }
    public static void SetArray(int size, int[] value)
    {
      Array = new int[size];
      arraySize = size;
      for (int i = 0; i < arraySize; i++)
        Array[i] = value[i];
      ShowArray(size, Array);
    }
    public static int GetArraySize() 
    {
      return arraySize;
    }
   public static void ReadFromKeyboard(int arraySize, int []Array) 
   {
      for(int i = 0; i < arraySize; i++) 
      {
        Console.WriteLine("Введите " + (i + 1) + "-й элемент из " + arraySize + " элементов массива");
        Input.CheckInput();
        Array[i] = Input.GetChoice();
      }
      ShowArray(arraySize, Array);
    }
    public static void ShowArray(int arraySize, int []Array) 
    {
      Console.BackgroundColor = ConsoleColor.Red;
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("\n\nСодержимое массива:");
      for (int i = 0; i < arraySize; i++)
        Console.Write(Array[i] + " ");
      Console.Write("\n");
      Console.ForegroundColor = ConsoleColor.Gray;
      Console.BackgroundColor = ConsoleColor.Black;
    }
    public static void ArrayShift(int arraySize,int n, int []Array)
    {
      int pos;
      int[] sArray = new int[arraySize];
      sArray = (int[])Array.Clone();
      for(int i=0; i < arraySize; i++) {
        if (i + n >= arraySize)
          pos = i + n - arraySize;
        else
          pos = i + n;
        Array[pos] = sArray[i];
      }
    }
    public static void RandArray(int arraySize, int[]Array) 
    {
      Random rand = new Random();
      for (int i = 0; i < arraySize; i++)
        Array[i] = rand.Next()%1000;
      ShowArray(arraySize, Array);
    }
  }
}
