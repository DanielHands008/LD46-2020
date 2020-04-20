using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerScript : MonoBehaviour
{
    public TaskBoard m_taskboard;
    public GameObject ConvoCanvas;
    public GameObject ConvoBossText;
    public GameObject ConvoPlayerText;
    private string[] bossDialog = { "I need you to clean the microwave in the break room.", "Can you file these documents for me, thanks.", "Pineapples"};
  void OnTriggerEnter(Collider other)
  {
      Debug.Log("Boss Entered");
    if (other.gameObject.tag == "Player")
    {
        m_taskboard.bossFound();
        ConvoBossText.GetComponent<UnityEngine.UI.Text>().text = bossDialog[m_taskboard.getCurrentTaskNumber() - 1];
        ConvoCanvas.SetActive(true);
    }

  }
  void OnTriggerExit(Collider other)
  {
      Debug.Log("Boss Exited");
    if (other.gameObject.tag == "Player")
    {
        ConvoCanvas.SetActive(false);
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
