using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofres : MonoBehaviour
{
    public bool abierto;
    public GameObject[] Drop;

    
    // Start is called before the first frame update
    void Start()
    {
        abierto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (abierto==true)
        {
            Instantiate(gameObject[Random.Range()], transform.position, transform.rotation);//meter lo que dropea que solo dropee una vez
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            abierto = true;
        }
    }
}
