using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnTiles : MonoBehaviour {
    int count;
    GameObject instantiateThis;
    GameObject instantiateCity;
    GameObject instantiateUnit;
    Vector3 clonePos;
	// Use this for initialization
	void Start () {
        ManagerDummy.Instance.initializeAll();
        instantiateThis = GameObject.Find("Tile");
        instantiateCity = GameObject.Find("CityLVL1");
        instantiateUnit = GameObject.Find("Orc");
        
        count = ManagerDummy.Instance.Count();
        for (int tilesIndex = 0; tilesIndex < count; tilesIndex++)
        {
            
            #region GetPosition
            double[] tilePosition = ManagerDummy.Instance.GetPosition(tilesIndex);
            float xPos = (float)tilePosition[0];
            float yPos = (float)tilePosition[1];
            float zPos = (float)tilePosition[2];
            clonePos = new Vector3(xPos, yPos, zPos);
            GameObject tileClone = Instantiate(instantiateThis, clonePos, Quaternion.Euler(-90,30,0)) as GameObject;
            tileClone.GetComponent<tileInfo>().Initialize(tilesIndex);
            #endregion
            #region GetColor
            switch (ManagerDummy.Instance.GetColor(tilesIndex))
            {
                case "Green":
                    tileClone.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case "Beige":
                    tileClone.GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                case "Blue":
                    tileClone.GetComponent<Renderer>().material.color = Color.blue;
                    break;
                default:
                    break;
            }
            #endregion
            #region GetCities
            int cityID = ManagerDummy.Instance.GetCityID(tilesIndex);
            if (cityID != -1)
            {
                GameObject cityClone = Instantiate(instantiateCity, clonePos, Quaternion.identity) as GameObject;
            }
            #endregion
            #region GetUnits
            List<int> unitsOnTile = new List<int>();
            unitsOnTile = ManagerDummy.Instance.GetUnitID(tilesIndex);
            if (unitsOnTile.Count > 0)
            {
                Vector3 unitPos = clonePos;
                unitPos.y += 1;
                instantiateUnit.GetComponent<unitInfo>().unitID = unitsOnTile[0];
                GameObject unitClone = Instantiate(instantiateUnit, unitPos, Quaternion.Euler(-90, 0, 0)) as GameObject;
                unitClone.GetComponent<unitInfo>().Initialize(unitsOnTile[0], tilesIndex);
                //unitClone.GetComponent<unitInfo>().unitID = unitsOnTile[0];
            }
            #endregion
        }
    }
}
