﻿using UnityEngine;
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

    public int[] GetUnitHealth(int id)
    {
        int[] hpArray = new int[2];
        hpArray[0] = unitLibrary.unitList[UnitIndex(id)].MaxHp;
        hpArray[1] = unitLibrary.unitList[UnitIndex(id)].CurrentHp;
        return hpArray;
    }
    public int[] GetUnitMovement(int id)
    {
        int[] movementArray = new int[2];
        movementArray[0] = unitLibrary.unitList[UnitIndex(id)].MaxMovePoints;
        movementArray[1] = unitLibrary.unitList[UnitIndex(id)].CurrentMovePoints;
        return movementArray;
    }
    public int[] GetUnitAtk(int id)
    {
        int[] attackArray = new int[4];
        attackArray[0] = unitLibrary.unitList[UnitIndex(id)].MaxAtk;
        attackArray[1] = unitLibrary.unitList[UnitIndex(id)].CurrentAtk;
        attackArray[2] = unitLibrary.unitList[UnitIndex(id)].MaxCanAtk;
        attackArray[3] = unitLibrary.unitList[UnitIndex(id)].CurrentCanAtk;
        return attackArray;
    }
    private int UnitIndex(int id)
    {
       return unitLibrary.FindIndexOfUnit_AtUnitID(id);
    }

    
}