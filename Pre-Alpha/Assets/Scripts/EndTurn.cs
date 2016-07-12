using UnityEngine;
using System.Collections;

public class EndTurn : MonoBehaviour {

    public void EndTurnNow()
    {
        ManagerDummy.Instance.EndTurn();
        GameObject.Find("SelectedUnit").GetComponent<SelectedUnit>().UpdateInformation();
    }

}
