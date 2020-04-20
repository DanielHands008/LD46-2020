using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerScript : MonoBehaviour
{
    public TaskBoard m_taskboard;
    GameObject ConvoCanvas;
    GameObject ConvoBossText;
    GameObject ConvoPlayerText;
    private string[] bossDialog = { "The bathroom need to be cleaned, go clean it!", "Now wash those hands!", "Go organize those shelves!", "Bob’s been uppity lately, go beat his high score in Tetris!", "Some one has been making a mess in the breakroom, the microwave is a mess. Clean it.", "Someone left a carton of milk on the table in the break room, put it back in the fridge!", "Dont give it to me put it back into the fridge.", "There is an email that needs to be responded to on that computer!", "The elevator doors are smudged, go clean them!", "Water the plant on my desk!", "The plant over there needs to be watered!", "I need the file for the big account!", "Good work, thats all I have for you right now."};
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
