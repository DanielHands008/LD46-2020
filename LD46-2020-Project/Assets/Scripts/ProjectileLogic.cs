using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{
    public bool StopProjectileOnAnyCollision;
  private int time = 0;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    time++;
    if (time == 500)
    {
      Destroy(gameObject);
    }
  }

  void OnCollisionEnter(Collision collision)
  {
    foreach (ContactPoint contact in collision.contacts)
    {
      Debug.DrawRay(contact.point, contact.normal, Color.white);
    }
    if (StopProjectileOnAnyCollision || collision.gameObject.tag == "Wall")
    {
      GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
    }
  }
}
