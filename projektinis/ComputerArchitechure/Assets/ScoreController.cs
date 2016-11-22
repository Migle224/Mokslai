using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour {

    public string[] items, itemsd;
    public enum TrainingType
    {
        Training    = 0,
        Time        = 1
    };

    public enum TaskType
    {
        LightsAddition  = 0,
        MemoryStackCall = 1,
        SFRegister      = 2
    };

    public GameObject scoreInfoPrefab;

    string[][] scoreInfoDetails;

    GameObject scoreInfo, scoreInfoText;
    Text text;

    DateTime dateTime;
    int id, tasksDone, tasksDoneRight;
    float score, time;
    TaskType tasktype;
    TrainingType trainingType;
    string username;


    IEnumerator Start()
    {
        
        WWW itemsData = new WWW("localhost/computerarchitecture/highscoreData.php");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        itemsDataString = itemsDataString.Replace("<br>", "");
        print(itemsDataString);
        items = itemsDataString.Split('|');
        foreach (string item in items)
        {
            itemsd = item.Split(';');
            scoreInfo = (GameObject)Instantiate(scoreInfoPrefab, this.gameObject.transform);

            for (int i = 0; i < itemsd.Length; i++)
            {
                scoreInfoText = scoreInfo.gameObject.transform.GetChild(i).gameObject;
                scoreInfoText.GetComponent<Text>().text = itemsd[i]; 
            }
        }
    }



    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space))
            InsertHighScore(dateTime, id, score, tasksDone, tasksDoneRight, tasktype, time, trainingType, username);
    }



    public void  InsertHighScore(DateTime _date,int _ID,float _score, int _tasksDone,
                                 int _tasksDoneRight, TaskType  _taskType, float _time, 
                                 TrainingType _trainingType, string _userName)
    {
        WWWForm form = new WWWForm();

        form.AddField("datePost", _date.ToShortDateString());
        form.AddField("iDPost", _ID);
        form.AddField("scorePost", _score.ToString());
        form.AddField("tasksDonePost", _tasksDone);
        form.AddField("tasksDoneRightPost", _tasksDoneRight);
        form.AddField("taskTypePost", _taskType.ToString());
        form.AddField("timePost", _time.ToString());
        form.AddField("trainingTypePost", _trainingType.ToString());
        form.AddField("userNamePost", _userName);

        WWW itemsData = new WWW("localhost/computerarchitecture/highscoreInsert.php", form);

        
    }

	
}
