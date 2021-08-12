using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobo : MonoBehaviour
{
    public Animator animator;
    private PlayerMov playermov;
    GameObject player;
    public float speed = 5;
    public float rangoDeVision = 3;
    public int vidas=4;
    public int dañoDeAtaque = 3;
    public float cdActual;
    public float cdAtaque = 2;
    // Start is called before the first frame update
    void Start()
    {
        playermov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMov>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) <= rangoDeVision)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            animator.SetBool("dentroDeRango", true);
        }
        else
        {
            animator.SetBool("dentroDeRango", false);
            
        }
        if (vidas <= 0)
        {
            //anim muerte
            Destroy(this.gameObject);
        }
      
        cdActual += Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
                if (cdActual > cdAtaque)
                {
                    cdActual = 0;
                    playermov.vidas -= dañoDeAtaque;
                    animator.SetBool("ataque", true);
                    //anim daño player
                }
                else
                {
                animator.SetBool("ataque", false);
                }
        }
    }
}
