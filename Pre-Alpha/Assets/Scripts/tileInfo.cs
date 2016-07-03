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
        position.y += 1;

        selectedUnit.GetComponent<SelectedUnit>().selectedUnit.transform.position = position;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
