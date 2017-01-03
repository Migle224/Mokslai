using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MemoryScrollViewController : MonoBehaviour {

    public GameObject memoryInfoPrefab, memoryResultPrefab;

    GameObject memoryInfo;
    GameObject content;
    int buttonAmount = 8;
    RectTransform rt;
    float buttonHeight;

    InputField inputField;

    // Use this for initialization

    public string GetInput()
    {
        return inputField.text;
    }


    public void SetInputColor(bool _isRightAnswer)
    {
        if (_isRightAnswer)
            inputField.image.color = Color.green;
        else
            inputField.image.color = Color.red;

    }

    public void initTask(int _SPValue)
    {

        int startSpValue = _SPValue - 2 * buttonAmount - 4;

        buttonHeight = memoryInfoPrefab.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta.y;

        content = this.gameObject.transform.parent.gameObject;
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(content.GetComponent<RectTransform>().sizeDelta.x, buttonHeight * (buttonAmount + 1));

        this.gameObject.transform.position = new Vector2(this.gameObject.GetComponent<RectTransform>().position.x,
                                                          content.transform.position.y - content.GetComponent<RectTransform>().sizeDelta.y / buttonHeight + buttonAmount - buttonHeight / 2);

        for (int i = 0; i < buttonAmount; i++)
        {
            memoryInfo = (GameObject)Instantiate(memoryInfoPrefab, this.gameObject.transform);
            memoryInfo.GetComponent<RectTransform>().localPosition = new Vector3(0, 0 - buttonHeight * i);
            memoryInfo.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = startSpValue.ToString("X");
            memoryInfo.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = Random.Range(16, (int)(Mathf.Pow(2, 8))).ToString("X");

            memoryInfo.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().color = Color.yellow;
            memoryInfo.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().color = Color.yellow;

            startSpValue += 2;
        }

        memoryInfo = (GameObject)Instantiate(memoryResultPrefab, this.gameObject.transform);
        memoryInfo.GetComponent<RectTransform>().localPosition = new Vector3(0, 0 - buttonHeight * buttonAmount);
        memoryInfo.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = Random.Range(16, (int)(Mathf.Pow(2, 8))).ToString("X");

        Button button;
       
        button = memoryInfo.transform.GetChild(0).gameObject.GetComponent<Button>();
        button.transform.GetChild(0).GetComponent<Text>().text = startSpValue.ToString("X");
        //  button.image.color = Color.green;
      //  button.transform.GetChild(0).GetComponent<Text>().color = Color.red;

        inputField = memoryInfo.transform.GetChild(1).gameObject.GetComponent<InputField>();
        inputField.text = "result";
    //    inputField.GetComponent<Text>().color = Color.red;
        //  inputField.image.color = Color.green;

    }
}
