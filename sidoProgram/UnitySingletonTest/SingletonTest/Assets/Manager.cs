using UnityEngine;
using System.Collections;

public class Manager : Singleton<Manager>
{
    protected Manager() { } // guarantee this will be always a singleton only - can't use the constructor!

    public int[] DataInts = new int[3] { 0, 3, 0 };
    public int counter = 0;

    public int GetNextInt()
    {
        int toReturn = DataInts[counter];
        DataInts[counter] = DataInts[counter] + 1;
        if (DataInts[counter] > 5)
        {
            DataInts[counter] = 0;
        }

        counter++;
        if (counter > 2)
        {
            counter = 0;
        }

        return toReturn;
    }
}