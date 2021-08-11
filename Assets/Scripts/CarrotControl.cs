using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Obtain a reference to the Player's PlayerController
        PlayerController playerController =
          collision.gameObject.GetComponent<PlayerController>();

        // Register damage with player
        playerController.AddHealth();
        Global.score += Global.bonus;
        AudioManager.Instance.Play("金币");
        Destroy(gameObject);
    }
}
