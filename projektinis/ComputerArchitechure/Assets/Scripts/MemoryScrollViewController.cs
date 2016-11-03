using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MemoryScrollViewController : MonoBehaviour {

    public GameObject memoryInfoPrefab;

    GameObject memoryInfo;
    GameObject content;
    int buttonAmount = 30;
    RectTransform rt;
    float buttonHeight;

    // Use this for initialization
    void Start () {

        buttonHeight = memoryInfoPrefab.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta.y;

        content = this.gameObject.transform.parent.gameObject;
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(content.GetComponent<RectTransform>().sizeDelta.x, buttonHeight * buttonAmount);

        this.gameObject.transform.position = new Vector2(this.gameObject.GetComponent<RectTransform>().position.x, 
                                                          content.transform.position.y - content.GetComponent<RectTransform>().sizeDelta.y / buttonHeight + buttonAmount - buttonHeight/2);

        for (int i = 0; i < buttonAmount; i++)
        {
            memoryInfo = (GameObject)Instantiate(memoryInfoPrefab, this.gameObject.transform);
            memoryInfo.GetComponent<RectTransform>().localPosition = new Vector3(0, 0 - buttonHeight * i);
            memoryInfo.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "test " + i;
        }

        this.initTask();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void initTask()
    {
        Button button;
        button = memoryInfo.transform.GetChild(0).gameObject.GetComponent<Button>();
        button.transform.GetChild(0).GetComponent<Text>().text = "FFFF ";
        button.image.color = Color.green;

    }
}
