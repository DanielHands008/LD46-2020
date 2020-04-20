using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBoard : MonoBehaviour
{
  public bool AlwaysShowTask;
  public GameObject TaskboardCanvas;
  public GameObject TaskboardText;
  private bool findBoss = true;
  private int currentTask = 1;
  private string[] tasks = { "Find the Boss.", "Clean the microwave.", "File Papers.", "Get the milk.", "Put the milk in the fridge.", "Done!" };
  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player" && !AlwaysShowTask)
    {
      TaskboardCanvas.SetActive(true);
    }

  }
  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "Player" && !AlwaysShowTask)
    {
      TaskboardCanvas.SetActive(false);
    }

  }

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

  public string getTaskName(int taskNumber)
  {
    return tasks[taskNumber];
  }

  public void changeTaskboardText(int taskNumber)
  {
    TaskboardText.GetComponent<UnityEngine.UI.Text>().text = "Current Task: " + tasks[taskNumber];
  }

  // Start is called before the first frame update
  void Start()
  {
    if(AlwaysShowTask) {
      TaskboardCanvas.SetActive(true);
    }
    else {
      TaskboardCanvas.SetActive(false);
    }
    TaskboardText.GetComponent<UnityEngine.UI.Text>().text = "Current Task: " + tasks[0];
  }

  // Update is called once per frame
  void Update()
  {

  }
}
