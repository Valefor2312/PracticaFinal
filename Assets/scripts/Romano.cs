using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Romano : MonoBehaviour
{
    public float speed = 2;
    public int value;
    public bool izquierda, abajo, derecha, arriba;
    GameObject player;
    public float rangoDeVision = 2;
    // Start is called before the first frame update
    void Start()
    {
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
        if (collision.tag=="player")
        {
            //ataque al jugador
        }
    }
}
