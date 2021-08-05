using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float speed = 2;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Mov();
        ;
    }
    public void Mov()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + new Vector3(0, 1, 0) * speed * Time.deltaTime;
            animator.SetBool("izq", false);
            animator.SetBool("derecha", false);
            animator.SetBool("abajo", false);
            animator.SetBool("arriba", true);

        }
        else
        {
            animator.SetBool("arriba", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(1, 0, 0) * speed * Time.deltaTime;
            animator.SetBool("derecha", true);
            animator.SetBool("arriba", false);
            animator.SetBool("izq", false);
            animator.SetBool("abajo", false);
        }
        else
        {
            animator.SetBool("derecha", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + new Vector3(0, -1, 0) * speed * Time.deltaTime;
            animator.SetBool("abajo", true);
            animator.SetBool("arriba", false);
            animator.SetBool("izq", false);
            animator.SetBool("derecha", false);
        }
        else
        {
            animator.SetBool("abajo", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            animator.SetBool("izq", true);
            animator.SetBool("arriba", false);
            animator.SetBool("derecha", false);
            animator.SetBool("abajo", false);
        }
        else
        {          
            animator.SetBool("izq", false);     
        }
    }
}
