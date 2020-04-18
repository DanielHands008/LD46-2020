using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    private Rigidbody m_rigidbody;
    private Vector3 change;

    //private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        //m_animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        //showing the float number of the getaxisraw input.
        //Debug.Log(change);

        //UpdateAnimationAndMove();
      
    }
    //void UpdateAnimationAndMove()
    //{
    //    if (change != Vector3.zero)
    //    {
    //        MoveCharacter();
    //        m_animator.SetFloat("moveX", change.x);
    //        m_animator.SetFloat("moveY", change.y);
    //        m_animator.SetBool("moving", true);
    //    }
    //    else
    //    {
    //        m_animator.SetBool("moving", false);
    //    }

    //}

    void MoveCharacter()
    {

        m_rigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);

    }
}
