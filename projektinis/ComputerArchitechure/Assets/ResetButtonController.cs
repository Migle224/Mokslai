using UnityEngine;
using System.Collections;

public class ResetButtonController : MonoBehaviour {

    void OnMouseDown()
    {
        this.gameObject.transform.parent.gameObject.GetComponent<LightsAdditionController>().ResetLightsAddition();
    }
}
