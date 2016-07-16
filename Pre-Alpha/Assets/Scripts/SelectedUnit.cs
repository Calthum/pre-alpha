using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SelectedUnit : MonoBehaviour {
    public GameObject selectedUnit;
    public Text text;
    public unitInfo unitinfo;
    public GameObject spellButton;
    public string CityOrUnit;
    
    
    // Use this for initialization
    void Start () {
        spellButton = GameObject.Find("SpellButton");
    }

    public void SelectNewUnit(GameObject unit)
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Tile"))
        {
            go.GetComponent<tileInfo>().ChangeColorBack();
        }
        CityOrUnit = "Unit";
        if (selectedUnit != null)
        {
        selectedUnit.GetComponent<Renderer>().material.color = Color.gray;

        }
        selectedUnit = unit;
        text = GameObject.Find("MaxHpText").GetComponent<Text>();
        selectedUnit.GetComponent<Renderer>().material.color = Color.red;
        unitinfo = unit.GetComponent<unitInfo>();
        UpdateInformation();
        }

    public void SelectNewCity(GameObject city)
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Tile"))
        {
            go.GetComponent<tileInfo>().ChangeColorBack();
        }
        CityOrUnit = "City";
        if (selectedUnit != null)
        {
            selectedUnit.GetComponent<Renderer>().material.color = Color.gray;
        }
            selectedUnit = city;
            selectedUnit.GetComponent<Renderer>().material.color = Color.red;

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Tile"))
        {
            go.GetComponent<tileInfo>().ChangeColor(selectedUnit.GetComponent<CityInfo>().CityID);
        }
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

    public void HighlightAssignedTiles()
    {
        List<GameObject> tiles = selectedUnit.GetComponent<CityInfo>().tilesAssignedToCity;
        for (int i = 0; i < tiles.Count; i++)
        {
            tiles[i].GetComponent<Renderer>().material.color = Color.red;
        }

    }

	// Update is called once per frame
	void Update () {
	
	}
}
