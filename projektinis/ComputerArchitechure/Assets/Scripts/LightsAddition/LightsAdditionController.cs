using UnityEngine;
using System.Collections;

public class LightsAdditionController : MonoBehaviour {

    public GameObject lightsFirstLine, lightsSecondLine, lightsResult, lightsUserInput, lightsResultIndicator, userInformation;
    UserInformationLightController userInformationLightController;

    void Start()
    {
        userInformationLightController = userInformation.GetComponent<UserInformationLightController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            int sum = lightsFirstLine.GetComponent<LightsController>().LightsValue + lightsSecondLine.GetComponent<LightsController>().LightsValue;
            lightsResult.GetComponent<LightsController>().StopCoroutineResult(sum, lightsResultIndicator, lightsFirstLine, lightsSecondLine, lightsUserInput);
        }
}

    public void CheckResults()
    {
        int sum = lightsFirstLine.GetComponent<LightsController>().LightsValue + lightsSecondLine.GetComponent<LightsController>().LightsValue;
        lightsResult.GetComponent<LightsController>().ShowLightsResult(sum, lightsResultIndicator, lightsFirstLine, lightsSecondLine, lightsUserInput);

        if (!userInformationLightController.timeIsOver())
        {
            userInformationLightController.addTaskDone();

            Debug.Log(lightsResult.GetComponent<LightsController>().CalculateLightsValue());
            Debug.Log(lightsUserInput.GetComponent<LightsController>().CalculateLightsValue());
            Debug.Log(lightsFirstLine.GetComponent<LightsController>().CalculateLightsValue());
            Debug.Log(lightsSecondLine.GetComponent<LightsController>().CalculateLightsValue());

            if (lightsResult.GetComponent<LightsController>().CalculateLightsValue() == lightsUserInput.GetComponent<LightsController>().CalculateLightsValue())
                userInformationLightController.addTaskDoneRight();
        }

    }

    public void ResetLightsAddition()
    {
        lightsFirstLine.GetComponent<LightsController>().InitLights();
        lightsSecondLine.GetComponent<LightsController>().InitLights();
        lightsResult.GetComponent<LightsController>().ResetLights();
        lightsUserInput.GetComponent<LightsController>().ResetLights();
    }
}
