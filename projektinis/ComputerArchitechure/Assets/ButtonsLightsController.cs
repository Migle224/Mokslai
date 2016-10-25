using UnityEngine;
using System.Collections;

public class ButtonsLightsController : MonoBehaviour
{

    public GameObject button0, button1, button2, button3, button4, button5, button6, button7,
                        button8, button9, button10, button11, button12, button13, button14, button15;

    GameObject[] buttons = new GameObject[16];

    public GameObject userInputLightsController;

    // Use this for initialization
    void Start()
    {
        this.AssignButtons();
    }

    public void ButtonPress(int _buttonPosition)
    {
        userInputLightsController.GetComponent<LightsController>().ChangeLightState(_buttonPosition);
    }

    void AssignButtons()
    {
        int position = 0;

        buttons[0] = button0;
        buttons[1] = button1;
        buttons[2] = button2;
        buttons[3] = button3;
        buttons[4] = button4;
        buttons[5] = button5;
        buttons[6] = button6;
        buttons[7] = button7;
        buttons[8] = button8;
        buttons[9] = button9;
        buttons[10] = button10;
        buttons[11] = button11;
        buttons[12] = button12;
        buttons[13] = button13;
        buttons[14] = button14;
        buttons[15] = button15;

        foreach (GameObject button in buttons)
        {
            button.GetComponent<ButtonLightInformation>().Position = position;
            position++;
        }

    }
}
