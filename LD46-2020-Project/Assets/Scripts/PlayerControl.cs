using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
  public float speed;

  public Transform Bullet;
  public float ProjectileSpeed;


  private Rigidbody m_riigidbody;
  private Vector3 change;

  private Animator m_animator;

  private float angle;


  void Start()
  {
    m_riigidbody = GetComponent<Rigidbody>();
    m_animator = GetComponent<Animator>();
  }

  private void Update()
  {

    //Get the Screen positions of the object
    Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

    //Get the Screen position of the mouse
    Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

    //Get the angle between the points
    angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

    //Ta Daaa
    transform.rotation = Quaternion.Euler(new Vector3(-90f, -90f, -angle));
Debug.DrawLine(transform.position, transform.up * 1000, Color.white);
    if (Input.GetMouseButton(0))
    {
      
      Shoot();
    }

  }

  void Shoot()
  {
    //Creating the bullet and shooting it
    var pel = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, angle));
    pel.GetComponent<Rigidbody>().AddForce(transform.up * ProjectileSpeed);
  }

  float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
  {
    return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
  }

  private void FixedUpdate()
  {
    change = Vector3.zero;
    change.x = Input.GetAxisRaw("Horizontal");
    change.z = Input.GetAxisRaw("Vertical");

    MoveCharacter();
  }


  void MoveCharacter()
  {
    m_riigidbody.MovePosition(transform.position + -change * speed * Time.deltaTime);

  }








}
