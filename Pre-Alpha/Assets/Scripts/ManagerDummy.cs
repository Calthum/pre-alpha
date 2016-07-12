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
    private cityLibs cityLibrary;
    private unitLib unitLibrary;
    private tile tile;
    

    public int Count()
    {
        return tilesLibrary.Count;
    }
    public int UnitCount()
    {
        return unitLibrary.unitList.Count;
    }

    public void initializeAll()
    {
        infoLibrary = new infoLib();
        tilesLibrary = new tileLib();
        playerLibrary = new playerLib();
        cityLibrary = new cityLibs(tilesLibrary);
        unitLibrary = new unitLib(tilesLibrary);
        tile = new tile();
    }

    public double[] GetPosition(int index)
    {

        return tilesLibrary.WorldCoordinates_AtIndex(index);
    }

    public string GetColor(int index)
    {

        return tilesLibrary.Color_AtIndex(index);
    }
    public string GetTileType(int index)
    {

        return tilesLibrary.Tile_AtIndex(index).TileTypeString;
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

    public void MoveUnit(int unitID, tile tileAT, tile tileTo)
    {
        int x;
        tilesLibrary.MoveUnit(unitID, tileAT, tileTo, unitLibrary);

    }

    public tile GetTileByIndex(int index)
    {

        return tilesLibrary.Tile_AtIndex(index);
    }

    public tile GetTileByPosition(int[]XYZ_coordinates)
    {
        return tilesLibrary.FindTile_AtLibraryCoordinates(XYZ_coordinates);
    }

    public int[] GetLibraryCoordinates_AtUnitID(int unitID)
    {
        for (int i = 0; i < tilesLibrary.Count; i++)
        {
            if (tilesLibrary.Tile_AtIndex(i).unitExists(unitID))
            {
                return tilesLibrary.LibraryCoordinates_AtIndex(i);
            }
        }
        return new tile().XYZLibraryCoordinates();
    }
    public double[] SearchWorldCoords(int unitID)
    { 
            for (int i = 0; i < tilesLibrary.Count; i++)
            {
                if (tilesLibrary.Tile_AtIndex(i).unitExists(unitID))
                {
                    return tilesLibrary.Tile_AtIndex(i).XYZUnityCoordinates();
                }
            }
        return new tile().XYZUnityCoordinates();   
    }
    public tile GetTile_AtLibraryCoordinates(int[] coord)
    {
        for (int i = 0; i < tilesLibrary.Count; i++)
        {
            if (tilesLibrary.Tile_AtIndex(i).XYZLibraryCoordinates()[0] == coord[0] &&
                tilesLibrary.Tile_AtIndex(i).XYZLibraryCoordinates()[1] == coord[1] &&
                tilesLibrary.Tile_AtIndex(i).XYZLibraryCoordinates()[2] == coord[2])
            {
                return tilesLibrary.Tile_AtIndex(i);
            }
        }
        return new tile();
    }

    public int GetIndexAtTile(tile tile)
    {
       return tilesLibrary.FindIndex_AtTile(tile);
    }
    public bool IsUnitOnTile(int tileIndex, tile tile)
    {
        if (tile.unitExists(tileIndex) == true)
        {
            return true;

        }
        else
        {
            return false;
        }
    }
    public void FIGHT(unit u1, unit u2)
    {
        unitLibrary.FIGHT(u1, u2, tilesLibrary);
    }
    public unit GetUnitByID(int ID)
    {

        return unitLibrary.unitList[UnitIndex(ID)];
    }
    public bool IsUnitDead(int ID)
    {
        for (int i = 0; i < unitLibrary.unitList.Count; i++)
        {

        if (unitLibrary.unitList[i].unitID == ID)
        {
                return false;
        }
        }
        return true;
    }
    public bool IsInRange(int id1, int id2)
    {

        return tilesLibrary.Tile_IsAdjacentTo(tilesLibrary.FindTile_AtUnitID(id1), tilesLibrary.FindTile_AtUnitID(id2));
    }
}