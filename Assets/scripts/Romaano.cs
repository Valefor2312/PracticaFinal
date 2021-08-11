using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Romaano : MonoBehaviour
{
    public float speed = 2;
    public int value;
    public bool izquierda, abajo, derecha, arriba;
    GameObject player;
    private PlayerMov playermov;
    public float rangoDeVision = 2;
    public int vidas = 4;
    public int dañoDeAtaque = 2;
    public float cdActual;
    public float cdAtaque = 2;
    // Start is called before the first frame update
    void Start()
    {
        playermov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMov>();
        player = GameObject.FindGameObjectWithTag("Player");
        value = Random.Range(0, 4);

        if (value == 0)
        {
            arriba = true;
        }
        else if (value == 1)
        {
            abajo = true;
        }
        else if (value == 2)
        {
            izquierda = true;
        }
        else
        {
            derecha = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        cdActual += Time.deltaTime;
        if (Vector3.Distance(this.transform.position, player.transform.position) <= rangoDeVision)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {

            if (arriba == true)
            {
                transform.position = transform.position + new Vector3(0, 1, 0) * Time.deltaTime * speed;
            }
            else if (abajo == true)
            {
                transform.position = transform.position + new Vector3(0, -1, 0) * Time.deltaTime * speed;
            }
            else if (izquierda == true)
            {
                transform.position = transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }
            else if (derecha == true)
            {
                transform.position = transform.position + new Vector3(1, 0, 0) * Time.deltaTime * speed;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "pared")
        {


            if (arriba == true)
            {
                arriba = false;

                abajo = true;
            }
            else if (abajo == true)
            {
                abajo = false;
                arriba = true;
            }
            else if (izquierda == true)
            {
                izquierda = false;
                derecha = true;
            }
            else if (derecha == true)
            {
                derecha = false;
                izquierda = true;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            if (cdActual>cdAtaque)
            {
                cdActual = 0;
                playermov.vidas -= dañoDeAtaque;
                //anim de ataque
                //anim daño player
            }
           

        }
        
    }
}
