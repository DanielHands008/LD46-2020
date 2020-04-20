using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerScript : MonoBehaviour
{
    public TaskBoard m_taskboard;
    GameObject ConvoCanvas;
    GameObject ConvoBossText;
    GameObject ConvoPlayerText;
    private string[] bossDialog = { "I need you to clean the microwave in the break room.", "Can you file these documents for me, thanks.", "Someone left the milk out, get it and put it back in the fridge.", "Don't give it to me, put it in the fridge.", "All done! Great work."};
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
    ConvoCanvas = gameObject.transform.GetChild(0).gameObject;
    ConvoBossText = ConvoCanvas.transform.GetChild(0).gameObject;
    ConvoPlayerText = ConvoCanvas.transform.GetChild(1).gameObject;
    GetComponent<Renderer>().enabled = false;
  }

  // Update is called once per frame
  void Update()
  {

  }
}
