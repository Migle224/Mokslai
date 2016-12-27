﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour {

    public string[] items, itemsd;
    public enum TrainingType
    {
        Training    = 1,
        Time        = 2
    };

    public enum TaskType
    {
        LightsAddition  = 1,
        MemoryStackCall = 3,
        SFRegister      = 2
    };

    public GameObject scoreInfoPrefab;
    public GameObject infoHeader;

    string[][] scoreInfoDetails;

    GameObject scoreInfo, scoreInfoText;
    Text text;

    DateTime dateTime;
    int id, tasksDone, tasksDoneRight;
    float score, time;
    TaskType tasktype;
    TrainingType trainingType;
    string username;
    float textPositionDiference = 20;


    IEnumerator Start()
    {
        
        WWW itemsData = new WWW("localhost/computerarchitecture/highscoreData.php");
        float x = infoHeader.gameObject.transform.position.x, y = infoHeader.gameObject.transform.position.y;
        Transform prefabPosition = infoHeader.gameObject.transform;
        yield return itemsData;
        string itemsDataString = itemsData.text;

       // prefabPosition.transform.position = (infoHeader.transform.position);
        itemsDataString = itemsDataString.Replace("<br>", "");
        print(itemsDataString);
        items = itemsDataString.Split('|');
        for (int j = 0; j< 11; j++)
        {
            itemsd = items[j].Split(';');
            scoreInfo = (GameObject)Instantiate(scoreInfoPrefab, prefabPosition);
            scoreInfo.GetComponent<RectTransform>().localPosition = new Vector3(x, y);
            y -=textPositionDiference;

            for (int i = 0; i < itemsd.Length; i++)
            {
                scoreInfoText = scoreInfo.gameObject.transform.GetChild(i).gameObject;
                scoreInfoText.GetComponent<Text>().text = itemsd[i]; 
            }
        }

        infoHeader.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
    }

    public static IEnumerator GetNextId()
    {

        WWW itemsData = new WWW("localhost/computerarchitecture/idData.php");

        yield return itemsData;
        string itemsDataString = itemsData.text;

        // prefabPosition.transform.position = (infoHeader.transform.position);
        itemsDataString = itemsDataString.Replace("<br>", "");
        print(itemsDataString);
        /*items = itemsDataString.Split('|');
        for (int j = 0; j < 11; j++)
        {
            itemsd = items[j].Split(';');
            scoreInfo = (GameObject)Instantiate(scoreInfoPrefab, prefabPosition);
            scoreInfo.GetComponent<RectTransform>().localPosition = new Vector3(x, y);
            y -= textPositionDiference;

            for (int i = 0; i < itemsd.Length; i++)
            {
                scoreInfoText = scoreInfo.gameObject.transform.GetChild(i).gameObject;
                scoreInfoText.GetComponent<Text>().text = itemsd[i];
            }
        }

        infoHeader.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);*/
    }


    static public void  InsertHighScore(DateTime _date,int _ID,float _score, int _tasksDone,
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
