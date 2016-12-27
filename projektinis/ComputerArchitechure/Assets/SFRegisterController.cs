using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SFRegisterController : MonoBehaviour
{

    const int CARRY_FLAG = 0;
    const int PARITY_FLAG = 2;
    const int AUXILLIARY_FLAG = 4;
    const int ZERO_FLAG = 6;
    const int SIGN_FLAG = 7;
    const int TRAP_FALG = 8;
    const int INTERRUPT_FALG = 9;
    const int DIRECTION_FALG = 10;
    const int OVERFLOW_FALG =11;

    public GameObject lightsFirstLine, lightsSecondLine, lightsResult, lightsUserInput;
    int firstNumber, secondNumber, linesSum;
    public Text taskText;
    public int numberInPower = 9;

    public Material turnOnMaterial, turnOffMaterial, betweenMaterial, wrongLightMaterial;

    void Start()
    {
        this.InitTaskValues();
    }

    public void CheckResults()
    {
        lightsFirstLine.GetComponent<LightsController>().InitLightsWithMistakes(firstNumber);
        lightsSecondLine.GetComponent<LightsController>().InitLightsWithMistakes(secondNumber);
        lightsResult.GetComponent<LightsController>().InitLightsWithMistakes(linesSum);
        this.SetSFFlags();
        this.AnswerHasMistakes();
    }

    public void InitTaskValues()
    {
        lightsFirstLine.GetComponent<LightsController>().ResetLights();
        lightsSecondLine.GetComponent<LightsController>().ResetLights();
        lightsResult.GetComponent<LightsController>().ResetLights();
        lightsUserInput.GetComponent<LightsController>().ResetLights();

        firstNumber = Random.Range(1, (int)Mathf.Pow(2, numberInPower));
        secondNumber = Random.Range(1, (int)Mathf.Pow(2, numberInPower));
        linesSum = firstNumber + secondNumber;

        taskText.text = firstNumber + " + " + secondNumber;

       // lightsUserInput.GetComponent<LightsController>().InitLights();
    }

    void SetSFFlags()
    {
        this.SetCarryFlag();
        this.SetParityFlag();
        this.SetAuxilliaryFlag();
        this.SetZeroFlag();
        this.SetSignFlag();
        this.SetTrapFlag();
        this.SetInterruptFlag();
        this.SetDirrectionFlag();
        this.SetOverflowFlag();

    }

    void SetCarryFlag()
    {
        GameObject[] userLights = (GameObject[])lightsUserInput.GetComponent<LightsController>().Lights;

        //carry flag
        if (firstNumber + secondNumber > (int)Mathf.Pow(2, 16))
            if (true != userLights[CARRY_FLAG].GetComponent<LightInformation>().State)
                userLights[CARRY_FLAG].GetComponent<LightInformation>().setLight(true, wrongLightMaterial);
            else
            if (false != userLights[CARRY_FLAG].GetComponent<LightInformation>().State)
                userLights[CARRY_FLAG].GetComponent<LightInformation>().setLight(false, wrongLightMaterial);
    }

    void SetParityFlag()
    {
        GameObject[] userLights = (GameObject[])lightsUserInput.GetComponent<LightsController>().Lights;

        int paritySum = 0;
        bool state;

        for (int i = 0; i < 8; i++)
            paritySum += userLights[i].GetComponent<LightInformation>().State == true ? 1 : 0;

        state = (paritySum % 2) == 0 ? true : false; 

        if(userLights[PARITY_FLAG].GetComponent<LightInformation>().State !=  state)
            userLights[PARITY_FLAG].GetComponent<LightInformation>().setLight(state, wrongLightMaterial);
    }

    void SetAuxilliaryFlag()
    {
        GameObject[] userLights = (GameObject[])lightsUserInput.GetComponent<LightsController>().Lights;

        int firstNumberMod = firstNumber % 16, secondNumberMod = secondNumber % 16;

        bool state = ((firstNumberMod + secondNumberMod) > 16) ? true : false;

        if (userLights[AUXILLIARY_FLAG].GetComponent<LightInformation>().State != state)
            userLights[AUXILLIARY_FLAG].GetComponent<LightInformation>().setLight(state, wrongLightMaterial);
    }

    void SetZeroFlag()
    {
        GameObject[] userLights = (GameObject[])lightsUserInput.GetComponent<LightsController>().Lights;


        bool state = ((firstNumber + secondNumber) % (int)Mathf.Pow(2,16)  == 0) ? true : false;

        if (userLights[ZERO_FLAG].GetComponent<LightInformation>().State != state)
            userLights[ZERO_FLAG].GetComponent<LightInformation>().setLight(state, wrongLightMaterial);
    }

    void SetSignFlag()
    {
        GameObject[] userLights = (GameObject[])lightsUserInput.GetComponent<LightsController>().Lights;

        bool state = (int)((firstNumber + secondNumber) / (int)Mathf.Pow(2, 16)) == 1 ? true : false;

        if (userLights[SIGN_FLAG].GetComponent<LightInformation>().State != state)
            userLights[SIGN_FLAG].GetComponent<LightInformation>().setLight(state, wrongLightMaterial);
    }

    void SetTrapFlag()
    { }

    void SetInterruptFlag()
    { }

    void SetDirrectionFlag()
    { }

    void SetOverflowFlag()
    {
        GameObject[] userLights = (GameObject[])lightsUserInput.GetComponent<LightsController>().Lights;

        bool state = (int)((firstNumber + secondNumber) / (int)Mathf.Pow(2, 16)) == 1 ? true : false;

        if (userLights[OVERFLOW_FALG].GetComponent<LightInformation>().State != state)
            userLights[OVERFLOW_FALG].GetComponent<LightInformation>().setLight(state, wrongLightMaterial);
    }

    void setOthersFlags()
    {
        GameObject[] userLights = (GameObject[])lightsUserInput.GetComponent<LightsController>().Lights;

        for (int i = 0; i < userLights.Length; i++)
            if ((i != CARRY_FLAG || 
                i != PARITY_FLAG ||
                i != AUXILLIARY_FLAG ||
                i != ZERO_FLAG ||
                i != SIGN_FLAG ||
                i != TRAP_FALG ||
                i != INTERRUPT_FALG ||
                i != DIRECTION_FALG ||
                i != OVERFLOW_FALG )
                && userLights[i].GetComponent<LightInformation>().State )
            {
                userLights[i].GetComponent<LightInformation>().setLight(false, wrongLightMaterial);
            }
    }

    bool AnswerHasMistakes()
    {
        GameObject[] userLights = (GameObject[])lightsUserInput.GetComponent<LightsController>().Lights;

        foreach (GameObject light in userLights)
            if (light.GetComponent<LightInformation>().Material == wrongLightMaterial)
                return true;

        return false;
    }
}