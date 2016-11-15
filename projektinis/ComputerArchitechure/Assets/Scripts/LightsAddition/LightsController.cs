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

    public float animationTime = 0.1f;

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
        int counter = 1;
        LightInformation lightInformation;

        lightsValue = 0;
        foreach (GameObject light in lights)
        {
            lightInformation = light.GetComponent<LightInformation>();

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

    public void ShowLightsResult(int _result, 
                                GameObject _lightsResultIndicator, 
                                GameObject _lightsFirstLine, 
                                GameObject _lightsSecondLine,
                                GameObject _lightsResult)
    {
        StartCoroutine(ShowLightsResultWithAnimation(_result, _lightsResultIndicator, _lightsFirstLine, _lightsSecondLine, _lightsResult));
    }

    private IEnumerator ShowLightsResultWithAnimation(int _result,
                                GameObject _lightsResultIndicator,
                                GameObject _lightsFirstLine,
                                GameObject _lightsSecondLine,
                                GameObject _lightsResult)
    {
        int lightsValueLocal    = _result;
        LightInformation lightInformation;
        int nextLight = 0, firstLight = 0, secondLight = 0, lightsSum = 0;

        lights = _lightsResult.GetComponent<LightsController>().Lights;


        for (int i = 0; i < lights.Length; i++)
        {
            lightInformation = lights[i].GetComponent<LightInformation>();

            yield return new WaitForSeconds(animationTime);
            //lightInformation.setLight(false, betweenMaterial);
            _lightsResultIndicator.gameObject.transform.position = new Vector3(lights[i].gameObject.transform.position.x + lights[i].gameObject.GetComponent<Renderer>().bounds.size.x/2,
                                                                                _lightsResultIndicator.gameObject.transform.position.y,
                                                                                _lightsResultIndicator.gameObject.transform.position.z);
            yield return new WaitForSeconds(animationTime);

            firstLight = (_lightsFirstLine.gameObject.GetComponent<LightsController>().lights[i].GetComponent<LightInformation>().State == true)? 1: 0;
            secondLight = (_lightsSecondLine.gameObject.GetComponent<LightsController>().lights[i].GetComponent<LightInformation>().State == true) ? 1 : 0;

            lightsSum = nextLight + firstLight + secondLight;

            switch (lightsSum)
            {
                case 0:
                    lightInformation.setLight(false, turnOffMaterial);
                    break;
                case 1:
                    lightInformation.setLight(true, turnOnMaterial);
                    nextLight = 0;
                    break;
                case 2:
                    lightInformation.setLight(false, turnOffMaterial);
                    nextLight = 1;
                    if (i + 1 < lights.Length)
                        lights[i+1].GetComponent<LightInformation>().setLight(true, turnOnMaterial);
                    break;
                case 3:
                    lightInformation.setLight(true, turnOnMaterial);
                    nextLight = 1;
                    if(i+1 < lights.Length)
                        lights[i + 1].GetComponent<LightInformation>().setLight(true, turnOnMaterial);
                    break;
            }

            /*  if (lightsValueLocal % 2 == 1)
                  lightInformation.setLight(true, turnOnMaterial);
              else
                  lightInformation.setLight(false, turnOffMaterial);
              lightsValueLocal = lightsValueLocal / 2;*/
        }

    }

    public int CalculateLightsValue()
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

        return this.lightsValue;

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
