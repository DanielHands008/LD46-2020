using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
  public TaskBoard m_taskboard;
  public float speed;
  public Transform Bullet;
  public float ProjectileSpeed;
  public int FireRate;
  public int RoundsPerClip = 10;
  public int ReloadSpeed = 100;

  private int timeBetweenShots = 0;
  private int currentAmmo;
  private int reloadTimer = 0;

  private Rigidbody m_riigidbody;
  private Vector3 change;

  private float angle;


  IEnumerator Start()
  {
    m_riigidbody = GetComponent<Rigidbody>();
    currentAmmo = RoundsPerClip;
    yield return new WaitForSeconds(.05f);
    m_taskboard.updateAmmoText(currentAmmo.ToString());
  }

  private void Update()
  {
    if (currentAmmo != RoundsPerClip && reloadTimer == 0 && Input.GetKeyDown("r"))
    {
      currentAmmo = 0;
      reloadTimer = 1;
    }

    //Get the Screen positions of the object
    Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);


    //Get the Screen position of the mouse
    Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
   

    //Get the angle between the points
    angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

    //Ta Daaa
    transform.rotation = Quaternion.Euler(new Vector3(-90f, -90f, -angle));
    Debug.DrawLine(transform.position, transform.up * 1000, Color.white);

  }

  void Shoot()
  {
    if (timeBetweenShots == 0 && currentAmmo > 0)
    {
      //Creating the bullet and shooting it
      var pel = Instantiate(Bullet, transform.position, Quaternion.Euler(-90, 0, -angle - 90));
      pel.GetComponent<Rigidbody>().AddForce(transform.up * ProjectileSpeed);
      currentAmmo--;
      timeBetweenShots = 1;
      try
      {
        m_taskboard.updateAmmoText(currentAmmo.ToString());
      }
      catch (Exception e) {

      }
      if (currentAmmo == 0)
      {
        reloadTimer = 1;
      }
    }
  }

  float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
  {
    return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
  }

  private void FixedUpdate()
  {
    if (Input.GetMouseButton(0))
    {
      Shoot();
    }
    if (timeBetweenShots > 0)
    {
      timeBetweenShots++;
    }
    if (timeBetweenShots >= FireRate)
    {
      timeBetweenShots = 0;
    }
    if (reloadTimer > 0)
    {
      reloadTimer++;
      try
      {
        m_taskboard.updateAmmoText("Reloading");
      }
      catch (Exception e) {

      }
      
    }
    if (reloadTimer >= ReloadSpeed)
    {
      reloadTimer = 0;
      currentAmmo = RoundsPerClip;
            try
      {
        m_taskboard.updateAmmoText(currentAmmo.ToString());
      }
      catch (Exception e) {

      }
    }
    change = Vector3.zero;
    change.x = Input.GetAxisRaw("Horizontal");
    change.z = Input.GetAxisRaw("Vertical");
    //Debug.Log(change);

    MoveCharacter();
  }


  void MoveCharacter()
  {
    m_riigidbody.MovePosition(transform.position + -change * speed * Time.deltaTime);

  }






}
