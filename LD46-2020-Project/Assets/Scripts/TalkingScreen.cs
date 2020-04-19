using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingScreen : MonoBehaviour
{

  public GameObject BossTextBox;
  public GameObject PlayerTextBox;

  

  public void SetConvoText(string bossText, string playerText)
  {
      BossTextBox.GetComponent<UnityEngine.UI.Text>().text = bossText;
      PlayerTextBox.GetComponent<UnityEngine.UI.Text>().text = playerText;
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
