using UnityEngine;
using System.Collections;
using preAlphaLibrary;
using System.Collections.Generic;

public class ManagerDummy : Singleton<ManagerDummy>
{
    protected ManagerDummy() { } // guarantee this will be always a singleton only - can't use the constructor!
    
    private infoLib infoLibrary;
    private tileLib tilesLibrary;
    private playerLib playerLibrary;
    private cityLib cityLibrary;
    private unitLib unitLibrary;

    public int Count()
    {
        return tilesLibrary.Count;
    }

    public void initializeAll()
    {
        infoLibrary = new infoLib();
        tilesLibrary = new tileLib();
        playerLibrary = new playerLib();
        cityLibrary = new cityLib(tilesLibrary);
        unitLibrary = new unitLib(tilesLibrary);
    }

    public double[] GetPosition(int index)
    {

        return tilesLibrary.WorldCoordinates_AtIndex(index, 1.05);
    }

    public string GetColor(int index)
    {

        return tilesLibrary.Color_AtIndex(index);
    }
    public int GetCityID(int index)
    {

        return tilesLibrary.CityID_AtIndex(index);
    }
    public List<int> GetUnitID(int index)
    {

        return tilesLibrary.UnitList_AtIndex(index);
    }
    
}