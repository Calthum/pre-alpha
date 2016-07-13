using UnityEngine;
using System.Collections;

public class CityInfo : MonoBehaviour {
    GameObject selectedUnit;
    public bool IsClicked;
	// Use this for initialization
	void Start () {
        selectedUnit = GameObject.Find("SelectedUnit");
    }

    void OnMouseDown()
    {
        IsClicked = true;
        if (gameObject.name == "CityLVL1")
        {

            selectedUnit.GetComponent<SelectedUnit>().SelectNewCity(gameObject);
        }

    }
}
