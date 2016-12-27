using UnityEngine;
using System.Collections;

public class CheckSFTask : MonoBehaviour {

    void OnMouseDown()
    {
        this.gameObject.transform.parent.gameObject.GetComponent<SFRegisterController>().CheckResults();
    }
}
