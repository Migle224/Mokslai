using UnityEngine;
using System.Collections;

public class LightsController : MonoBehaviour {

    public GameObject light0, light1, light2, light3;

    private Color turnOn = Color.yellow, turnOf = Color.black;


    // Use this for initialization
    void Start () {

        light0.GetComponent<Renderer>().material.color = (Random.value > 0.5)? turnOn :turnOf;
        light1.GetComponent<Renderer>().material.color = (Random.value > 0.5) ? turnOn : turnOf;
        light2.GetComponent<Renderer>().material.color = (Random.value > 0.5) ? turnOn : turnOf;
        light3.GetComponent<Renderer>().material.color = (Random.value > 0.5) ? turnOn : turnOf;

        Debug.Log(this.getNumber());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getNumber()
    {
        int i = 0;

        i += (light0.GetComponent<Renderer>().material.color == turnOn) ? 1 : 0;
        i += (light1.GetComponent<Renderer>().material.color == turnOn) ? 2 : 0;
        i += (light2.GetComponent<Renderer>().material.color == turnOn) ? 4 : 0;
        i += (light3.GetComponent<Renderer>().material.color == turnOn) ? 8 : 0;

        return i;
    }
}
