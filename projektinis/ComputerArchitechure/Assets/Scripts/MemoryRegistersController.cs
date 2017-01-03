using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MemoryRegistersController : MonoBehaviour {

    public Text axValue, bxValue, cxValue, dxValue, csValue, ipValue,
        ssValue, spValue, bpValue, siValue, diValue, dsValue, esValue;

    public Text codeSegmentMainLine, codeSegmentUpLine, codeSegmentDownLine;

    public GameObject memoryController, userInformation;

    UserInformationLightController userInformationLightController;
    MemoryScrollViewController memoryScrollViewController;

    int ipDecValue, ipNewDecValue, spDecValue;
    // Use this for initialization
    void Start () {
        userInformationLightController = userInformation.GetComponent<UserInformationLightController>();
        memoryScrollViewController = memoryController.GetComponent<MemoryScrollViewController>();

        this.InitTask();
	}

    public void CheckTask()
    {
        Debug.Log((ipNewDecValue % 256).ToString("X") + " " + memoryScrollViewController.GetInput());
        if ((ipNewDecValue % 256).ToString("X") == memoryScrollViewController.GetInput())
        {
            memoryScrollViewController.SetInputColor(true);
            userInformationLightController.addTaskDoneRight();
        }
        else
            memoryScrollViewController.SetInputColor(false);
    }

    /*Valdymo perdavimas [4]Besąlyginis valdymo perdavimas [3]UŽDAVINYS NR.1
     * Uždavinio sąlyga:Registras SS=ABCD, registras SP=0002, 
     * registras BP=AF00, registras CX=0010. 
     * Kokia bus stekosegmento baito su adresu FFFE reikšmė šešioliktainėje sistemoje, 
     * įvykdžius komandą:1234 9A EBFE6789call text (1234 yra poslinkis kodo segmente)*/
    public void InitTask()
    {
        ipDecValue = Random.Range(4096, (int)(Mathf.Pow(2, 16)));
        ipNewDecValue = ipDecValue + 5;

        spDecValue = Random.Range(4096, (int)(Mathf.Pow(2, 16)));


        axValue.text = Random.Range(4096, (int)(Mathf.Pow(2, 16))).ToString("X");
        bxValue.text = Random.Range(4096, (int)(Mathf.Pow(2, 16))).ToString("X");
        cxValue.text = Random.Range(4096, (int)(Mathf.Pow(2, 16))).ToString("X");
        dxValue.text = Random.Range(4096, (int)(Mathf.Pow(2, 16))).ToString("X");
        csValue.text = Random.Range(4096, (int)(Mathf.Pow(2, 16))).ToString("X");    
        ssValue.text = Random.Range(4096, (int)(Mathf.Pow(2, 16))).ToString("X");
        spValue.text = spDecValue.ToString("X");
        bpValue.text = Random.Range(4096, (int)(Mathf.Pow(2, 16))).ToString("X");
        siValue.text = Random.Range(4096, (int)(Mathf.Pow(2, 16))).ToString("X");
        diValue.text = Random.Range(4096, (int)(Mathf.Pow(2, 16))).ToString("X");
        dsValue.text = Random.Range(4096, (int)(Mathf.Pow(2, 16))).ToString("X");
        esValue.text = Random.Range(4096, (int)(Mathf.Pow(2, 16))).ToString("X");

        ipValue.text = ipDecValue.ToString("X") ;


        codeSegmentMainLine.text = ipDecValue.ToString("X") + ": 9A " + Random.Range(16, (int)(Mathf.Pow(2, 8))).ToString("X")
            + " " + Random.Range(16, (int)(Mathf.Pow(2, 8))).ToString("X")
            + " " + Random.Range(16, (int)(Mathf.Pow(2, 8))).ToString("X")
            + " " + Random.Range(16, (int)(Mathf.Pow(2, 8))).ToString("X")
            + " " + Random.Range(16, (int)(Mathf.Pow(2, 8))).ToString("X")
            + " " + Random.Range(16, (int)(Mathf.Pow(2, 8))).ToString("X")
            + " " + Random.Range(16, (int)(Mathf.Pow(2, 8))).ToString("X");

        codeSegmentUpLine.text = (ipDecValue - 8).ToString("X") + ": ?? ?? ?? ?? ?? ?? ?? ??";
        codeSegmentDownLine.text = (ipDecValue + 8).ToString("X") + ": ?? ?? ?? ?? ?? ?? ?? ??";

        memoryScrollViewController.initTask(spDecValue);

        userInformationLightController.addTaskDone();

    }
}
