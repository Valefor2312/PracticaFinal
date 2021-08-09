using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofres : MonoBehaviour
{
    public bool abierto;
    public GameObject[] drop;
    public Animator animator;
    bool dropped;

    // Start is called before the first frame update
    void Start()
    {
        abierto = false;
        animator.SetBool("abierto", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (abierto == true && dropped == false)
        {

            Invoke("Drop", 1.2f);

            dropped = true;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            abierto = true;
            animator.SetBool("abierto", true);
        }
    }
    public void Drop()
    {
        Instantiate(drop[Random.Range(0, drop.Length)], transform.position, transform.rotation);
    }
}
