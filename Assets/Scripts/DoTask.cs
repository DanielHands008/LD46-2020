﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoTask : MonoBehaviour
{
  [SerializeField] GameObject LinkedObject;
  [SerializeField] string LinkedObjectAction;
  public int TimeToComplete = 100;
  public int taskNumber;
  public bool SkipBossAfter;
  public GameObject DoingTaskCanvas;
  GameObject DoingTaskText;
  GameObject DoingTaskPercent;
  //public GameObject DoingTaskText;
  //public GameObject DoingTaskPercent;
  public TaskBoard m_taskboard;
  private bool taskDone = false;
  private int timer = 0;
  private bool doingTask = false;
  void OnTriggerEnter(Collider other)
  {
    if (!taskDone && m_taskboard.getCurrentTaskNumber() == taskNumber && other.gameObject.tag == "Player")
    {
      DoingTaskText.GetComponent<UnityEngine.UI.Text>().text = m_taskboard.getTaskName(taskNumber);
      timer = 0;
      doingTask = true;
      DoingTaskCanvas.SetActive(true);
    }

  }
  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      doingTask = false;
      DoingTaskCanvas.SetActive(false);
    }

  }

  void changeTask()
  {
    m_taskboard.changeTaskboardText(2);
  }
  // Start is called before the first frame update
  void Start()
  {
    DoingTaskText = DoingTaskCanvas.transform.GetChild(0).gameObject;
    DoingTaskPercent = DoingTaskCanvas.transform.GetChild(1).gameObject;
    if (m_taskboard.getCurrentTaskNumber() != taskNumber)
    {
      GetComponent<Renderer>().enabled = false;
    }
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (m_taskboard.getCurrentTaskNumber() == taskNumber)
    {
      GetComponent<Renderer>().enabled = true;
    }
    else
    {
      GetComponent<Renderer>().enabled = false;
    }
    if (doingTask)
    {
      timer++;
      DoingTaskPercent.GetComponent<UnityEngine.UI.Text>().text = Math.Round(((float)timer / (float)TimeToComplete) * 100).ToString() + "%";
      if (timer > TimeToComplete)
      {
        try
        {
          LinkedObject.GetComponent<AfterTaskActions>().doAction(LinkedObjectAction);
        }
        catch (Exception e)
        {

        }
        taskDone = true;
        m_taskboard.nextTask(SkipBossAfter);
        doingTask = false;
        DoingTaskPercent.GetComponent<UnityEngine.UI.Text>().text = "Complete!";
      }
    }
  }

}
