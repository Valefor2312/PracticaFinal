using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    public float CDtrampaAbajo;
    public bool trampaAbajo;
    public float CDtrampaArriba;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trampaAbajo==true)
        {
            if (CDtrampaAbajo > 2)
            {
                animator.SetBool("abajo", false);
                CDtrampaAbajo = 0;
                trampaAbajo = false;
                
            }
            CDtrampaAbajo += Time.deltaTime;
        }
        else
        {
            if (CDtrampaArriba>2)
            {
                animator.SetBool("abajo", true);
                CDtrampaArriba = 0;
                trampaAbajo = true;
               
            }
            CDtrampaArriba += Time.deltaTime;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player"&&trampaAbajo==false)
        {
            //Hacer daño
        }
    }
}
