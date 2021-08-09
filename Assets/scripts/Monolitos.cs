using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monolitos : MonoBehaviour

{
    public PlayerMov player;
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
        if (collision.tag=="Player")
        {
            player.llaves++;
        }
    }
}
