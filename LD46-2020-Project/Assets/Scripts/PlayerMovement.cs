using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;


    private Rigidbody m_riigidbody;
    private Vector3 change;

    private Animator m_animator;


     void Start()
    {
        m_riigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();


    }

    private void Update()
    {
        

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
