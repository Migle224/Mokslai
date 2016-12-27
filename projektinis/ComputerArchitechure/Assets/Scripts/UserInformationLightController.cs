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

    public int taskType, trainingType;

    public GameObject timeIsOverText;

    // Use this for initialization
    void Start()
    {
        timeLeft = timeForTask;
        timeIsOverText.active = false;
        Invoke("EndLevel", timeForTask);
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

    public void EndLevel()
    {
        ResetButtonController.timeIsOver = true;
        CheckButtonController.timeIsOver = true;
        ButtonLightInformation.timeIsOver = true;

        timeIsOverText.active = true;
    }

    public void SaveLevelInformation()
    {
        ResetButtonController.timeIsOver = false;
        CheckButtonController.timeIsOver = false;
        ButtonLightInformation.timeIsOver = false;

        ScoreController.GetNextId();
     /*   WWWForm form = new WWWForm();

        form.AddField("datePost", System.DateTime.Now.ToShortDateString());
        form.AddField("iDPost", _ID);
        form.AddField("scorePost", score.ToString());
        form.AddField("tasksDonePost", tasksDone);
        form.AddField("tasksDoneRightPost", tasksDoneRight);
        form.AddField("taskTypePost", taskType.ToString());
        form.AddField("timePost", timeForTask.ToString());
        form.AddField("trainingTypePost", trainingType.ToString());
        form.AddField("userNamePost", _userName);

        WWW itemsData = new WWW("localhost/computerarchitecture/highscoreInsert.php", form);*/
    }
}
