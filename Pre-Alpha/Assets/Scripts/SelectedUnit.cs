using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectedUnit : MonoBehaviour {
    public GameObject selectedUnit;
    public Text text;
    public unitInfo unitinfo;
    public GameObject spellButton;
    
    // Use this for initialization
    void Start () {
        spellButton = GameObject.Find("SpellButton");
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
        if (ManagerDummy.Instance.UnitIsHero(selectedUnit.GetComponent<unitInfo>().unitID))
        {
            spellButton.SetActive(true);
        }
        else
        {
            spellButton.SetActive(false);
        }
    }
    public void DEATHUPONALL()
    {
        ManagerDummy.Instance.CastSpell(selectedUnit.GetComponent<unitInfo>().unitID);
        UpdateInformation();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
