using UnityEngine;
using System.Collections;

public class ResetButtonController : MonoBehaviour {
    static public  bool timeIsOver = false;

    void OnMouseDown()
    {
        if (!timeIsOver)
            this.gameObject.transform.parent.gameObject.GetComponent<LightsAdditionController>().ResetLightsAddition();
    }
}
