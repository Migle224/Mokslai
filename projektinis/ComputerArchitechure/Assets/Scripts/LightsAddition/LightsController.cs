using UnityEngine;
using System.Collections;

public class LightsController : MonoBehaviour {

    const int CONTROLLER_ADDITION = 0;
    const int CONTROLLER_RESULT = 1;
    const int CONTROLLER_USER_INPUT = 2;

    public enum ControllerType
    {
        Addition = CONTROLLER_ADDITION,
        Result = CONTROLLER_RESULT,
        UserInput = CONTROLLER_USER_INPUT

    }

    public ControllerType controllerType;

    public GameObject light0, light1, light2, light3, light4, light5, light6, light7,
                        light8, light9, light10, light11, light12, light13, light14, light15;


    private int lightsValue;

    public Material turnOnMaterial, turnOffMaterial, betweenMaterial, wrongLightMaterial;

    public float animationTime = 0.01f;

    GameObject[] lights = new GameObject[16];
    // Use this for initialization
    void Start() {
        this.AssignLights();

        switch (controllerType)
        {
            case ControllerType.Addition:
                this.InitLights();
                break;
            case ControllerType.Result:
            case ControllerType.UserInput:
                this.ResetLights();
                break;
        }

    }

    public GameObject[] Lights
    {
        get { return this.lights; }
        set { this.lights = value; }
    }

    public void CheckUserInput(GameObject[] _result)
    {
        StartCoroutine(CheckUserInputWithAnimation(_result));
    }

    IEnumerator CheckUserInputWithAnimation(GameObject[] _result)
    {
        int                 counter = 0;
        LightInformation    lightInformation, lightInformationResult;
        Material            lastMaterial;
        bool                lastState;

        foreach (GameObject light in lights)
        {
            lightInformation = light.GetComponent<LightInformation>();
            lightInformationResult = _result[counter].GetComponent<LightInformation>();

            lastMaterial = lightInformation.Material;
            lastState = lightInformation.State;
            Debug.Log( lightInformationResult.State + " " + counter);
            yield return new WaitForSeconds(animationTime);
            lightInformation.setLight(false, betweenMaterial);
            yield return new WaitForSeconds(animationTime);

            if (lightInformation.State == lightInformationResult.State)
            {
                lightInformation.setLight(lastState, lastMaterial);
            }
            else
            {
                lightInformation.setLight(lastState, wrongLightMaterial);
            }
           
            counter++;
        }

    }

    public void InitLights()
    {
        StartCoroutine(InitLightsWithAnimation());
    } 

    IEnumerator InitLightsWithAnimation()
    {
        int counter = 1;
        LightInformation lightInformation;

        lightsValue = 0;
        foreach (GameObject light in lights)
        {
            lightInformation = light.GetComponent<LightInformation>();

            yield return new WaitForSeconds(animationTime);
            lightInformation.setLight(false, betweenMaterial);
            yield return new WaitForSeconds(animationTime);

            if (Random.value < 0.5)
            {
                lightInformation.setLight(false, turnOffMaterial);
            }
            else
            {
                lightInformation.setLight(true, turnOnMaterial);
                lightsValue += counter;
            }

            counter *= 2;
        }
    }

    public void ChangeLightState(int _position)
    {
        LightInformation lightInformation = lights[_position].GetComponent<LightInformation>();
        if (lightInformation.State)
            lightInformation.setLight(false, turnOffMaterial);
        else
            lightInformation.setLight(true, turnOnMaterial);
    }

    public int LightsValue
    {
        get { return this.lightsValue; }
        set { this.lightsValue = value; }

    }

    public void ShowLightsResult(int _result)
    {
        StartCoroutine(ShowLightsResultWithAnimation(_result));
    }

    private IEnumerator ShowLightsResultWithAnimation(int _result)
    {
        int lightsValueLocal    = _result;
        LightInformation lightInformation;

        foreach (GameObject light in lights)
        {
            lightInformation = light.GetComponent<LightInformation>();

            yield return new WaitForSeconds(animationTime);
            lightInformation.setLight(false, betweenMaterial);
            yield return new WaitForSeconds(animationTime);

            if (lightsValueLocal % 2 == 1)
                lightInformation.setLight(true, turnOnMaterial);
            else
                lightInformation.setLight(false, turnOffMaterial);
            lightsValueLocal = lightsValueLocal / 2;
        }

    }

    void CalculateLightsValue()
    {
        int counter = 1;
        int sum     = 0;

        foreach (GameObject light in lights)
        {
            if (light.GetComponent<LightInformation>().State)
                sum += counter;
            counter *= 2;
        }

        this.lightsValue = sum; 

    }

    public void ResetLights()
    {
        foreach (GameObject light in lights)
            light.GetComponent<LightInformation>().setLight(false, turnOffMaterial);
        lightsValue = 0;

    }

    void AssignLights()
    {
        lights[0] = light0;
        lights[1] = light1;
        lights[2] = light2;
        lights[3] = light3;
        lights[4] = light4;
        lights[5] = light5;
        lights[6] = light6;
        lights[7] = light7;
        lights[8] = light8;
        lights[9] = light9;
        lights[10] = light10;
        lights[11] = light11;
        lights[12] = light12;
        lights[13] = light13;
        lights[14] = light14;
        lights[15] = light15;

    }
}
