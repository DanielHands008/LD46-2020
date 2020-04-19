using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTask : MonoBehaviour
{
    public TaskBoard m_taskboard;

      void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
        m_taskboard.changeTaskboardText("The new task.");
    }

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
