using UnityEngine;
using System.Collections;

public class LightsAdditionController : MonoBehaviour {

    public GameObject lightsFirstLine, lightsSecondLine, lightsResult, lightsUserInput;

    public void CheckResults()
    {
        int sum = lightsFirstLine.GetComponent<LightsController>().LightsValue + lightsSecondLine.GetComponent<LightsController>().LightsValue;
        lightsResult.GetComponent<LightsController>().ShowLightsResult(sum);
     //   lightsUserInput.GetComponent<LightsController>().CheckUserInput(lightsResult.GetComponent<LightsController>().Lights);
    }

    public void ResetLightsAddition()
    {
        lightsFirstLine.GetComponent<LightsController>().InitLights();
        lightsSecondLine.GetComponent<LightsController>().InitLights();
        lightsResult.GetComponent<LightsController>().ResetLights();
        lightsUserInput.GetComponent<LightsController>().ResetLights();
    }
}
