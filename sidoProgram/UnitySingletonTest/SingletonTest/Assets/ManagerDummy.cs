using UnityEngine;
using System.Collections;
using dummyLibrary;

public class ManagerDummy : Singleton<ManagerDummy>
{
    protected ManagerDummy() { } // guarantee this will be always a singleton only - can't use the constructor!

    private tilesLib Tiles = new tilesLib();
    private int counter = 0;

    public int GetNextInt()
    {
        counter++;
        return Tiles.LibraryCoordinates_AtIndex(counter)[1];
    }
}