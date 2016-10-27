using UnityEngine;
using System.Collections;

public class LightInformation : MonoBehaviour {

    private bool state;
    private Material material;

	public bool State
    {
        get { return this.state; }
        set { this.state = value; }
    }

    public Material Material
    {
        get { return this.material; }
        set { this.material = value; }
    }

    public void setLight(bool _turnOn, Material _material)
    {
        this.material = _material;
        this.gameObject.GetComponent<Renderer>().material = this.material;
        this.state = _turnOn;

    }

}
