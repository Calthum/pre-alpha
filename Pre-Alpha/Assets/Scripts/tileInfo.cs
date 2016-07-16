using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class tileInfo : MonoBehaviour {
    public int tileIndex;
    SelectedUnit selectedUnit;
    GameObject tile;
    Color originalColor;
    public bool isAssigned;
    public int isAssignedTo;
	// Use this for initialization
	void Start () {

        GameObject temp = GameObject.Find("SelectedUnit");
        selectedUnit = temp.GetComponent<SelectedUnit>();
        isAssignedTo = -1;
        isAssigned = false;
	}

    public void Initialize(int input)
    {
        tileIndex = input;
    }

    void OnMouseUp()
    {
        Vector3 position = gameObject.transform.position;
        int tile = gameObject.GetComponent<tileInfo>().tileIndex;
        GameObject unit = selectedUnit.GetComponent<SelectedUnit>().selectedUnit;
        #region UnitSelected
        if (selectedUnit.GetComponent<SelectedUnit>().CityOrUnit == "Unit")
        {

        if (ManagerDummy.Instance.GetUnitID(tile).Count == 0)
        {
        ManagerDummy.Instance.MoveUnit(unit.GetComponent<unitInfo>().unitID, ManagerDummy.Instance.GetTile_AtLibraryCoordinates(ManagerDummy.Instance.GetLibraryCoordinates_AtUnitID(unit.GetComponent<unitInfo>().unitID)), ManagerDummy.Instance.GetTileByIndex(tile));
        selectedUnit.GetComponent<SelectedUnit>().selectedUnit.GetComponent<unitInfo>().UpdateUnitPosition(unit);
        selectedUnit.GetComponent<SelectedUnit>().UpdateInformation();
        }
        else if ((ManagerDummy.Instance.GetUnitID(tile).Count > 0))
        {
            
            List<int> tileIndex = ManagerDummy.Instance.GetUnitID(tile);
            int tileIndexSingle = tileIndex[0];
            if (ManagerDummy.Instance.IsInRange(unit.GetComponent<unitInfo>().unitID, tileIndexSingle))
            {
            ManagerDummy.Instance.FIGHT(ManagerDummy.Instance.GetUnitByID(unit.GetComponent<unitInfo>().unitID), ManagerDummy.Instance.GetUnitByID(tileIndexSingle));
            }
            unit.GetComponent<unitInfo>().UpdateUnitPosition(unit);
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Orc"))
            {
                go.GetComponent<unitInfo>().Death();
            }
            selectedUnit.UpdateInformation();
            if (ManagerDummy.Instance.GetUnitID(tile).Count == 0)
            {
                ManagerDummy.Instance.MoveUnit(unit.GetComponent<unitInfo>().unitID, ManagerDummy.Instance.GetTile_AtLibraryCoordinates(ManagerDummy.Instance.GetLibraryCoordinates_AtUnitID(unit.GetComponent<unitInfo>().unitID)), ManagerDummy.Instance.GetTileByIndex(tile));
                selectedUnit.GetComponent<SelectedUnit>().selectedUnit.GetComponent<unitInfo>().UpdateUnitPosition(unit);
                selectedUnit.GetComponent<SelectedUnit>().UpdateInformation();
            }
        }
        }
        #endregion
        #region CitySelected
        if (selectedUnit.GetComponent<SelectedUnit>().CityOrUnit == "City")
        {
            if (isAssigned == true)
            {
                Debug.Log("This did do");
                if (ManagerDummy.Instance.AssignTile(selectedUnit.GetComponent<SelectedUnit>().selectedUnit.GetComponent<CityInfo>().CityID, tile, -1))
                {
                    isAssignedTo = -1;
                isAssigned = false;
                    switch (ManagerDummy.Instance.GetColor(tile))
                    {
                        case "Green":
                            gameObject.GetComponent<Renderer>().material.color = Color.green;
                            break;
                        case "Beige":
                            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                            break;
                        case "Blue":
                            gameObject.GetComponent<Renderer>().material.color = Color.blue;
                            break;
                        default:
                            break;
                    }

                }
            }
            else if (isAssigned == false)
            {
                if (ManagerDummy.Instance.AssignTile(selectedUnit.GetComponent<SelectedUnit>().selectedUnit.GetComponent<CityInfo>().CityID, tile, 1))
                {
                    isAssignedTo = unit.GetComponent<CityInfo>().CityID;
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    isAssigned = true;
                    
                }
            
            }

        }
        #endregion



    }
    public void ChangeColor(int CityID)
    {
        if (isAssignedTo == CityID)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
    public void ChangeColorBack()
    {
        switch (ManagerDummy.Instance.GetColor(tileIndex))
        {
            case "Green":
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
            case "Beige":
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case "Blue":
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
