using UnityEngine;
using System.Collections;

public class unitInfo : MonoBehaviour {
    public int unitID;
    public int tileIndex;
    public int maxHealth;
    public int currentHealth;
    public int maxCanAtk;
    public int currentCanAtk;
    public int maxAtk;
    public int currentAtk;
    public int maxMovement;
    public int currentMovement;
    GameObject selectedUnit;
    GameObject selectedTile;

	// Use this for initialization
	 void Start () {
        selectedUnit = GameObject.Find("SelectedUnit");

    }
    public void Initialize(int inputID, int indexInput)
    {
        unitID = inputID;
        tileIndex = indexInput;
        int[] healthInfo = ManagerDummy.Instance.GetUnitHealth(gameObject.GetComponent<unitInfo>().unitID);
        int[] attackInfo = ManagerDummy.Instance.GetUnitAtk(gameObject.GetComponent<unitInfo>().unitID);
        int[] movementInfo = ManagerDummy.Instance.GetUnitMovement(gameObject.GetComponent<unitInfo>().unitID);
        maxHealth = healthInfo[0];
        currentHealth = healthInfo[1];
        maxAtk = attackInfo[0];
        currentAtk = attackInfo[1];
        maxCanAtk = attackInfo[2];
        currentCanAtk = attackInfo[3];
        maxMovement = movementInfo[0];
        currentMovement = movementInfo[1];


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (gameObject.name == "Orc(Clone)")
        {

        selectedUnit.GetComponent<SelectedUnit>().SelectNewUnit(gameObject);
        }
    }

}
