using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBoard : MonoBehaviour
{

public GameObject ConvoCanvas;
  void OnTriggerEnter(Collider other)
  {
      if (other.gameObject.tag == "Player") {
          ConvoCanvas.SetActive(true);
          Debug.Log("Player has entered.");
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
