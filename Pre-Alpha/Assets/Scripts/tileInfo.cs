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
        int[] oldXYZposition = new int[3];
        double[] newXYZposition = new double[3];
        
        oldXYZposition[0] = (int)unit.transform.position.x;
        oldXYZposition[1] = (int)unit.transform.position.y;
        oldXYZposition[2] = (int)unit.transform.position.z;
        position.y += 1;
        ManagerDummy.Instance.MoveUnit(unit.GetComponent<unitInfo>().unitID, ManagerDummy.Instance.GetTileByPosition(oldXYZposition), ManagerDummy.Instance.GetTileByIndex(gameObject.GetComponent<tileInfo>().tileID));
        
        

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
