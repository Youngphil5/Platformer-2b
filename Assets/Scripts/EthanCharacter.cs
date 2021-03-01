using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class EthanCharacter : MonoBehaviour
{
  public GameObject box;
  private Animator animator;
  public Rigidbody rb;
  public float modifier = 1;
  public float jumpForce = 1;
  [Range(-2, 2)] public float speed = 0;
  private bool jump = false;
  public Points points;
  public Coin coin;
  public Credit creditPoints;

  void Awake()
  {
    animator = GetComponent<Animator>();
  }

  void Update()
  {
    float horizontal = Input.GetAxis("Horizontal");
    //horizontal = speed;

    //Set character rotation
    if (Input.GetButton("Horizontal"))
    {
      float y = (horizontal < 0) ? 270 : 90;
      Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, y, transform.rotation.eulerAngles.z);
      transform.rotation = newRotation;
      if (Input.GetKeyDown(KeyCode.Z))
      {
        speed = 3;
        animator.speed = 2;
      }
      else
      {
        speed = 1;
        animator.speed = 1;
      }
    }
    //Set character animation
    animator.SetFloat("Speed", Mathf.Abs(horizontal));

    //move character
    transform.Translate(-transform.right * horizontal * modifier* Time.deltaTime* speed);
  }

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == "box")
    {
      if (other.gameObject.transform.position.y > transform.position.y)
      {
        Destroy(other.gameObject);
        points.GivePoints(100);
      }
    }
  }

  private void OnCollisionStay(Collision other)
  {
    animator.SetBool("Jump", false); //SO it cuts of the animation when you hit the ground
    if (Input.GetKeyDown(KeyCode.Space))
    {
      jump = true;
    }
  }

  private void OnCollisionExit(Collision other)
  {
    animator.SetBool("Jump", true);
    jump = false;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Coin")
    {
      Destroy(other.gameObject);
      coin.GivePoints(1);
      creditPoints.GivePoints(100);
    }
  }

  void FixedUpdate()
  {
    if (jump) rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
  }
}
