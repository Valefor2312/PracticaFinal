using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour
{
    public bool abierto;
    public GameObject[] Drop;
    public Animator animator;
    public bool dropped;


    // Start is called before the first frame update
    void Start()
    {
        abierto = false;
        animator.SetBool("abierto", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (abierto == true&&dropped==false)
        {
            Instantiate(Drop[Random.Range(0, Drop.Length)], transform.position, transform.rotation);//meter el drop desde el editor
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
}
