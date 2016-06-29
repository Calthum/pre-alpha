using UnityEngine;
using System.Collections;
using preAlphaLibrary;
using System.Collections.Generic;

public class ManagerDummy : Singleton<ManagerDummy>
{
    protected ManagerDummy() { } // guarantee this will be always a singleton only - can't use the constructor!

    private tileLib Tiles = new tileLib();
    
    public int Count()
    {
        return Tiles.Count;
        
    }

    public double[] GetPosition(int index)
    {

        return Tiles.WorldCoordinates_AtIndex(index, 1.05);
    }

    public string GetColor(int index)
    {

        return Tiles.Color_AtIndex(index);
    }
    public int GetCityID(int index)
    {

        return Tiles.CityID_AtIndex(index);
    }
    public List<int> GetUnitID(int index)
    {

        return Tiles.UnitList_AtIndex(index);
    }
    
}