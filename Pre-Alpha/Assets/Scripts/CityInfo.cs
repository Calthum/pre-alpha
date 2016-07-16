using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityInfo : MonoBehaviour {
    public int CityID;
    GameObject selectedUnit;
    public bool IsClicked;
    public List<GameObject> tilesAssignedToCity;

    // Use this for initialization
    void Start () {
    tilesAssignedToCity = new List<GameObject>();
    selectedUnit = GameObject.Find("SelectedUnit");
        
    }
    public void Initialize(int input)
    {
        CityID = input;
    }

    void OnMouseDown()
    {
        IsClicked = true;
        selectedUnit.GetComponent<SelectedUnit>().SelectNewCity(gameObject);

    }
}
