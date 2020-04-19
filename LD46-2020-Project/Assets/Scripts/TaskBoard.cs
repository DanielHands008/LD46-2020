using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBoard : MonoBehaviour
{
  private int currentTask = 1;
private string[] tasks = {"Clean the microwave.", "File Papers.", "All Done!"};
  public GameObject TaskboardCanvas;
  public GameObject TaskboardText;
  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      TaskboardCanvas.SetActive(true);
      Debug.Log("Player has entered.");
    }

  }
  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      TaskboardCanvas.SetActive(false);
      Debug.Log("Player has left.");
    }

  }

  public void nextTask() {
    currentTask++;
    TaskboardText.GetComponent<UnityEngine.UI.Text>().text = "Current Task: " + tasks[currentTask-1];
  }

  public int getCurrentTaskNumber() {
    return currentTask;
  }

  public string getTaskName(int taskNumber) {
      return tasks[taskNumber-1];
  }

  public void changeTaskboardText(int taskNumber)
  {
    TaskboardText.GetComponent<UnityEngine.UI.Text>().text = "Current Task: " + tasks[taskNumber-1];
  }

  // Start is called before the first frame update
  void Start()
  {
    TaskboardText.GetComponent<UnityEngine.UI.Text>().text = "Current Task: " + tasks[0];
  }

  // Update is called once per frame
  void Update()
  {

  }
}
