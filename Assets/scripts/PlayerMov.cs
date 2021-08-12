using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMov : MonoBehaviour
{
    public float speed = 2;
    public Animator animator;
    public int llaves;
    public bool ataque;
    public int vidas = 10;
    public int vidasMax;
    public Image barraVida;
    public int da�oDeAtaque = 3;
    private Romaano romano;
    private Lobo lobo;
    public float cdActual;
    public float cdAtaque = 1.5f;
    public int comida = 0;
    public int monedas = 0;
    public GameObject muerte;
    public bool muerto;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-18, -10.5f);
        lobo = GameObject.FindGameObjectWithTag("Lobo").GetComponent<Lobo>();
        vidasMax = vidas;
       barraVida.fillAmount = vidas / vidasMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (muerto == false)
        {
            Mov();
            Ataque();
        }

        if (vidas <= 0)
        {
            Instantiate(muerte, this.transform.position, this.transform.rotation);
            muerto = true;
        }
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
    public void Ataque()
    {
        
        cdActual += Time.deltaTime;
        if (cdActual >= cdAtaque)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                cdActual = 0;
                ataque = true;
                //anim da�o de ataque
            }

             
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Salida")
        {
            if (llaves == 2)
            {
                //salir/ganar
                llaves = 0;
            }
        }
        if (collision.tag == "Comida")
        {
            comida++;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Monedas")
        {
            monedas++;
            Destroy(collision.gameObject);
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Lobo" && ataque == true)
        {
            lobo.vidas -= da�oDeAtaque;
            //anim da�o enemigo
        }
    }
}
