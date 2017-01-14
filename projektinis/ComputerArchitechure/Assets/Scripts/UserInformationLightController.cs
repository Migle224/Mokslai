﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UserInformationLightController : MonoBehaviour
{

    float timeLeft, score;
    public float timeForTask;
    public Text timeLeftText, scoreText, tasksDoneText, tasksDoneRightText;
    string timeLeftString = "Time: ", scoreTextString = "Score: ", tasksDoneString = "Tasks done: ", tasksDoneRightString = "Task done right: ";
    int tasksDone = 0, tasksDoneRight = 0;
    


   /* public enum TrainingType
    {
        Training = 1,
        Time = 2
    };

    public enum TaskType
    {
        LightsAddition = 1,
        MemoryStackCall = 3,
        SFRegister = 2
    };*/

    public ScoreController.TrainingType trainingType;

    public ScoreController.TaskType taskType;

    public GameObject timeIsOverText;

    public Text userName, timeOverText;

    // Use this for initialization
    void Start()
    {
        tasksDoneRightText.text = tasksDoneRightString + "0";
        tasksDoneText.text = tasksDoneString + "0";
        scoreText.text = scoreTextString + "0";
       // timeLeft = timeForTask;
        timeIsOverText.SetActive(false);
       // Invoke("EndLevel", timeForTask);
    }

    // Update is called once per frame
    void Update()
    {

        timeLeft = Time.timeSinceLevelLoad;

        timeLeftText.text = timeLeftString + timeLeft.ToString("F1");

    }

    public void addTaskDone()
    {
        StopAllCoroutines();
        tasksDoneText.text = tasksDoneString + ++tasksDone;
        this.calcScores();
        if (tasksDone >= 10)
            this.EndLevel();
    }

    public void addTaskDoneRight()
    {
        tasksDoneRightText.text = tasksDoneRightString + ++tasksDoneRight;
        this.calcScores();
    }

    void calcScores()
    {
        score = (int)(timeForTask * tasksDoneRight * 1000 / (tasksDone * timeLeft)) ;
        scoreText.text = scoreTextString + score;
    }

    public bool timeIsOver()
    {
        return (timeLeft < 0) ? true : false;
    }

    public void EndLevel()
    {
        ResetButtonController.timeIsOver = true;
        CheckButtonController.timeIsOver = true;
        ButtonLightInformation.timeIsOver = true;

        timeIsOverText.SetActive(true);
        timeOverText.text = "Your score: " + score;
    }

    public void SaveLevelInformation()
    {
        ResetButtonController.timeIsOver = false;
        CheckButtonController.timeIsOver = false;
        ButtonLightInformation.timeIsOver = false;

        ScoreController.InsertHighScore(System.DateTime.Now, score, tasksDone, tasksDoneRight, taskType, timeForTask, trainingType, 
            userName.text);
        
        Application.LoadLevel("HighScore");
        

    }
}
