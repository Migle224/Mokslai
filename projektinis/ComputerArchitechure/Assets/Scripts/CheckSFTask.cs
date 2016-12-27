using UnityEngine;
using System.Collections;

public class CheckSFTask : MonoBehaviour {

    static public bool timeIsOver = false; 

    void OnMouseDown()
    {
        if(!timeIsOver)
            this.gameObject.transform.parent.gameObject.GetComponent<SFRegisterController>().CheckResults();
    }
}
