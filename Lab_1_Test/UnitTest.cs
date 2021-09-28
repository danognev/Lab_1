using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Lab_1_Test
{
  [TestClass]
  public class UnitTest
  {
    [TestMethod]
    public void TestMethod_1()
    {
      const int ARR_SIZE = 5, N_POS = 3;
      int[] SourceArr = { 1, 2, 3, 4, 5 };
      Lab_1.Algorithm.SetArray(ARR_SIZE,SourceArr);
      Lab_1.Algorithm.ArrayShift(ARR_SIZE, N_POS, Lab_1.Algorithm.GetArray());
      int[] ResultArrExpected = { 3, 4, 5, 1, 2 };
      int[] ResultArrActual = Lab_1.Algorithm.GetArray();
      for(int i=0; i < ARR_SIZE; i++)
        Assert.AreEqual(ResultArrExpected[i],ResultArrActual[i]);
    }
    [TestMethod]
    public void TestMethod_2()
    {
      const int ARR_SIZE = 15, N_POS = 10;
      int[] SourceArr = { 1, 2, 3, 4, 5,6,7,8,9,10,11,12,13,14,15 };
      Lab_1.Algorithm.SetArray(ARR_SIZE, SourceArr);
      Lab_1.Algorithm.ArrayShift(ARR_SIZE, N_POS, Lab_1.Algorithm.GetArray());
      int[] ResultArrExpected = { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 1, 2, 3, 4, 5 };
      int[] ResultArrActual = Lab_1.Algorithm.GetArray();
      for (int i = 0; i < ARR_SIZE; i++)
        Assert.AreEqual(ResultArrExpected[i], ResultArrActual[i]);
    }
    [TestMethod]
    public void TestMethod_3()
    {
      const int ARR_SIZE = 3, N_POS = 3;
      int[] SourceArr = { 1, 2, 3 };
      Lab_1.Algorithm.SetArray(ARR_SIZE, SourceArr);
      Lab_1.Algorithm.ArrayShift(ARR_SIZE, N_POS, Lab_1.Algorithm.GetArray());
      int[] ResultArrExpected = { 1,2,3 };
      int[] ResultArrActual = Lab_1.Algorithm.GetArray();
      for (int i = 0; i < ARR_SIZE; i++)
        Assert.AreEqual(ResultArrExpected[i], ResultArrActual[i]);
    }
  }
}
