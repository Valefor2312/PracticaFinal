using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monolito : MonoBehaviour
{
    public GameObject monolitoDes;
    private PlayerMov player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMov>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            monolitoDes.SetActive(false);
            player.llaves++;
        }
    }
}
