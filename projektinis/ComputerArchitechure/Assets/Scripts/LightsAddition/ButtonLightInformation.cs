using UnityEngine;
using System.Collections;

public class ButtonLightInformation : MonoBehaviour {

    private int position;
    static public bool timeIsOver = false;

    public int Position
    {
        get { return this.position; }
        set { this.position = value; }
    }

    void OnMouseDown()
    {
        if (!timeIsOver)
            this.gameObject.transform.parent.gameObject.GetComponent<ButtonsLightsController>().ButtonPress(this.position);
    }
}
