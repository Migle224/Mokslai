using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UserInformationLightController : MonoBehaviour
{

    float timeLeft, score;
    public float timeForTask;
    public Text timeLeftText, scoreText, tasksDoneText, tasksDoneRightText;
    string timeLeftString = "Time left: ", scoreTextString = "Score: ", tasksDoneString = "Tasks done: ", tasksDoneRightString = "Task done right: ";
    int tasksDone = 0, tasksDoneRight = 0;

    // Use this for initialization
    void Start()
    {
        timeLeft = timeForTask;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft >= 0)
                timeLeftText.text = timeLeftString + timeLeft.ToString("F1");
            else
                timeLeftText.text = timeLeftString + "0";
        }
    }

    public void addTaskDone()
    {
        tasksDoneText.text = tasksDoneString + ++tasksDone;
    }

    public void addTaskDoneRight()
    {
        tasksDoneRightText.text = tasksDoneRightString + ++tasksDoneRight;
        this.calcScores();
    }

    void calcScores()
    {
        score = (timeForTask * tasksDoneRight) / (tasksDone * tasksDone) ;
        scoreText.text = scoreTextString + score;
    }

    public bool timeIsOver()
    {
        return (timeLeft < 0) ? true : false;
    }
}
