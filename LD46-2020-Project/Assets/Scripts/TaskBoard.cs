using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBoard : MonoBehaviour
{
  GameObject tmp;
  GameObject TaskboardCanvas;
  GameObject AmmoCounterText;
  GameObject TaskboardText;
  private bool findBoss = true;
  private int currentTask = 1;
  private string[] tasks = { "Find the Boss.", "Clean the bathroom.", "Wash Hands.", "Reorganize the storage room.", "Beat Bob’s high score in Tetris.", "Clean the breakroom microwave.", "Pickup milk.", "Put the milk in the fridge.", "Answer an email.", "Clean the elevator doors.", "Water the boss’s plant.", "Water the office plant.", "Grab file from the filing cabinet.", "All done!" };

  public void bossFound() {
    findBoss = false;
    TaskboardText.GetComponent<UnityEngine.UI.Text>().text = "Current Task: " + tasks[currentTask];
  }

  public void nextTask(bool skipBoss)
  {
    currentTask++;
    if(!skipBoss) {
      findBoss = true;
      TaskboardText.GetComponent<UnityEngine.UI.Text>().text = "Current Task: " + tasks[0];
    }
    else {
      TaskboardText.GetComponent<UnityEngine.UI.Text>().text = "Current Task: " + tasks[currentTask];
    }
  }

  public int getCurrentTaskNumber()
  {
    if (findBoss)
    {
      return 0;
    }
    else
    {
      return currentTask;
    }
  }

  public bool haveToFindBos() {
    return findBoss;
  }

  public string getTaskName(int taskNumber)
  {
    return tasks[taskNumber];
  }

  public void changeTaskboardText(int taskNumber)
  {
    TaskboardText.GetComponent<UnityEngine.UI.Text>().text = "Current Task: " + tasks[taskNumber];
  }

  public void updateAmmoText(string text) {
    AmmoCounterText.GetComponent<UnityEngine.UI.Text>().text = text;
  }

  // Start is called before the first frame update
  void Start()
  {
    TaskboardCanvas = GameObject.Find("TaskboardCanvas");
    AmmoCounterText = GameObject.Find("AmmoCounterText");
    TaskboardText = GameObject.Find("TaskboardText");
    TaskboardText.GetComponent<UnityEngine.UI.Text>().text = "Current Task: " + tasks[0];
  }

  // Update is called once per frame
  void Update()
  {

  }
}
