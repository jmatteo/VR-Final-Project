using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    float horizontal = 0, vertical = 0;
    Animator animator;
    Rigidbody physic;
    public GameObject head_cam;
    Vector3 cam_distance;
    RaycastHit hit;


    float headrotupdown = 0, headrotrightleft = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        physic = GetComponent<Rigidbody>();
        cam_distance = head_cam.transform.position - transform.position;
    }

    void FixedUpdate()
    {
        //Movement();
        Rotation();

        //animator.SetFloat("Horizontal", horizontal);
        //animator.SetFloat("Vertical", vertical);

    }
    void Movement()
    {
        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");

        ////Debug.Log("Horizontal value = " + horizontal + " Vertical value" + vertical);

        //Vector3 vec = new Vector3(horizontal, 0, vertical);
        //vec = transform.TransformDirection(vec);
        //physic.position += vec * Time.fixedDeltaTime * 3;
        ////transform.Translate(vec * Time.deltaTime * 2);

    }
    void Rotation()
    {
        head_cam.transform.position = transform.position + cam_distance;
        headrotupdown += Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * -150;
        headrotrightleft += Input.GetAxis("Mouse X") * Time.fixedDeltaTime * 150;
        headrotupdown = Mathf.Clamp(headrotupdown, -20, 20);
        head_cam.transform.rotation = Quaternion.Euler(headrotupdown, headrotrightleft, transform.eulerAngles.z);

        //if (horizontal != 0 || vertical != 0)
        //{
        //    Physics.Raycast(Vector3.zero, head_cam.transform.GetChild(0).forward, out hit);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(hit.point.x, 0, hit.point.z)), 0.1f);
        //    Debug.DrawLine(Vector3.zero, hit.point);
        //}
    }

}
