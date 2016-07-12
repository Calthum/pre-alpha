using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectedUnit : MonoBehaviour {
    public GameObject selectedUnit;
    public Text text;
    public unitInfo unitinfo;
    // Use this for initialization
    void Start () {
       
    }

    public void SelectNewUnit(GameObject unit)
    {
        selectedUnit = unit;
        text = GameObject.Find("MaxHpText").GetComponent<Text>();
        unitinfo = unit.GetComponent<unitInfo>();
        UpdateInformation();
        

            

    }
    public void UpdateInformation()
    {
        selectedUnit.GetComponent<unitInfo>().UpdateUnitInfo();
        text.text = "Health: " +
            unitinfo.currentHealth.ToString() + "/" + unitinfo.maxHealth.ToString() + "    " +
            "Movement: " +
            unitinfo.currentMovement.ToString() + "/" + unitinfo.maxMovement.ToString() + "    " +
            "Attack: " + unitinfo.currentAtk.ToString() + "/" + unitinfo.maxAtk.ToString() + "  " +
            unitinfo.currentCanAtk.ToString() + "/" + unitinfo.maxCanAtk.ToString();
    }

    //public void MoveUnit(GameObject unit, int tile)
    //{
    //    double[] positionArray = ManagerDummy.Instance.GetPosition(tile);
    //    float xPos = (float)positionArray[0];
    //    float yPos = (float)positionArray[1];
    //    float zPos = (float)positionArray[2];
    //    Vector3 tilePosition = new Vector3(xPos, yPos, zPos);
    //    selectedUnit.GetComponent<unitInfo>().transform.position = tilePosition;
    //    ManagerDummy.Instance.MoveUnit(unit.GetComponent<unitInfo>().unitID, ManagerDummy.Instance.GetTileByIndex(tile))
    //}
	
	// Update is called once per frame
	void Update () {
	
	}
}
