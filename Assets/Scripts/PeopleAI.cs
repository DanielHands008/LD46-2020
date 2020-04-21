using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleAI : MonoBehaviour
{
public float speed = 0.05f; 
  // Start is called before the first frame update
  void Start()
  {

  }

  void FixedUpdate()
  {
    transform.Translate(Vector3.up * speed);
  }
private int tmp = 0;
  void OnCollisionEnter(Collision collision)
  {
      
    foreach (ContactPoint contact in collision.contacts)
    {
      Debug.DrawRay(contact.point, contact.normal, Color.white, 1);
      
    }
    if (collision.gameObject.tag != "Projectiles" && collision.gameObject.tag != "Floor" && collision.gameObject.tag != "Player")
    {
        tmp++;
        Debug.Log(collision.contacts[0].normal.z);
        float diff = Vector2.Angle(new Vector2(collision.contacts[0].point.x, collision.contacts[0].point.z), new Vector2(transform.position.x, transform.position.z));
        float rand = Random.Range(-15.0f, 15.0f);
        float dir = collision.contacts[0].normal.z;
        float dir2 = transform.rotation.eulerAngles.z;
        if (dir == 0) {
            dir = 0.000001f;
        }
        if (dir2 == 0) {
            dir2 = 0.000001f;
        }
        transform.Rotate(0.0f, 0.0f, (collision.contacts[0].normal.z + transform.rotation.eulerAngles.z) * (180 + rand), Space.Self);
    }
    else
    {
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
