using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBoard : MonoBehaviour
{

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

  public void changeTaskboardText(string task)
  {
    TaskboardText.GetComponent<UnityEngine.UI.Text>().text = "Current Task: " + task;
  }

  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {

  }
}
