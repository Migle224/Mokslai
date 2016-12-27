using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MemoryRegistersController : MonoBehaviour {

    public Text axValue, bxValue, cxValue, dxValue, csValue, ipValue,
        ssValue, spValue, bpValue, siValue, diValue, dsValue, esValue;
    // Use this for initialization
    void Start () {
        this.initTask();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /*Valdymo perdavimas [4]Besąlyginis valdymo perdavimas [3]UŽDAVINYS NR.1
     * Uždavinio sąlyga:Registras SS=ABCD, registras SP=0002, 
     * registras BP=AF00, registras CX=0010. 
     * Kokia bus stekosegmento baito su adresu FFFE reikšmė šešioliktainėje sistemoje, 
     * įvykdžius komandą:1234 9A EBFE6789call text (1234 yra poslinkis kodo segmente)*/
    void initTask()
    {
        ssValue.text = "ABCD";
        spValue.text = "0002";
        bpValue.text = "AF00";
        cxValue.text = "0010";
    }
}
