using UnityEngine;
using System.Collections;

public class CheckButtonController : MonoBehaviour {

    void OnMouseDown()
    {
        this.gameObject.transform.parent.gameObject.GetComponent<LightsAdditionController>().CheckResults();
    }
}
