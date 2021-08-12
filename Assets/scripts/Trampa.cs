using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    public float CDtrampaAbajo;
    public bool trampaAbajo;
    public float CDtrampaArriba;
    private PlayerMov player;
    public GameObject pinchosArriba;
    public bool da�o;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMov>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trampaAbajo==true)
        {
            if (CDtrampaAbajo > 2)
            {
                pinchosArriba.SetActive(true);
                CDtrampaArriba = 0;
                trampaAbajo = false;
                
            }
            CDtrampaAbajo += Time.deltaTime;
        }
        else
        {
            if (CDtrampaArriba>2)
            {
                pinchosArriba.SetActive(false);
               
                CDtrampaAbajo = 0;
                trampaAbajo = true;
                
               
            }
            CDtrampaArriba += Time.deltaTime;
        }
        if (da�o==true)
        {
            player.vidas -= 1;
            player.barraVida.fillAmount = player.vidas / player.vidasMax;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag=="Player"&&trampaAbajo==false)
        {
            da�o = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && trampaAbajo == false)
        {
            da�o = false;
        }
    }
}
