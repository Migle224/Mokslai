using UnityEngine;
using System.Collections;

public class ButtonLightInformation : MonoBehaviour {

    private int position;

    public int Position
    {
        get { return this.position; }
        set { this.position = value; }
    }

    void OnMouseDown()
    {
        this.gameObject.transform.parent.gameObject.GetComponent<ButtonsLightsController>().ButtonPress(this.position);
    }
}
