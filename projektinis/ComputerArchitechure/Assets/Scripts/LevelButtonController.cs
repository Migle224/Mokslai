using UnityEngine;
using System.Collections;

public class LevelButtonController : MonoBehaviour {

    public bool isActive = false;
    public string levelName;

	// Use this for initialization
	void Start () {
        gameObject.active = isActive;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeVisibility()
    {
        isActive = isActive == true ? false : true;
        gameObject.active = isActive;
    }

    public void LoadTaskLevel()
    {
        Application.LoadLevel(levelName);
    }
}
