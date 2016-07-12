using UnityEngine;
using System.Collections;

public class tileInfo : MonoBehaviour {
    public int tileID;
    SelectedUnit selectedUnit;
    GameObject tile;
	// Use this for initialization
	void Start () {

        GameObject temp = GameObject.Find("SelectedUnit");
        selectedUnit = temp.GetComponent<SelectedUnit>();
	}

    public void Initialize(int input)
    {
        tileID = input;
    }

    void OnMouseUp()
    {
        Vector3 position = gameObject.transform.position;
        int tile = gameObject.GetComponent<tileInfo>().tileID;
        GameObject unit = selectedUnit.GetComponent<SelectedUnit>().selectedUnit;
        ManagerDummy.Instance.MoveUnit(unit.GetComponent<unitInfo>().unitID, ManagerDummy.Instance.GetTile_AtLibraryCoordinates(ManagerDummy.Instance.GetLibraryCoordinates_AtUnitID(unit.GetComponent<unitInfo>().unitID)), ManagerDummy.Instance.GetTileByIndex(tile));
        selectedUnit.GetComponent<SelectedUnit>().selectedUnit.GetComponent<unitInfo>().UpdateUnitPosition(unit);
        selectedUnit.GetComponent<SelectedUnit>().UpdateInformation();
        //if (selectedUnit.GetComponent<SelectedUnit>().selectedUnit.GetComponent<unitInfo>().currentMovement != 0)
        //{

        //selectedUnit.GetComponent<SelectedUnit>().selectedUnit.transform.position = position;
        //}
    }

    // Update is called once per frame
    void Update () {
	
	}
}
