using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destroy_by_Contact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scorevalue;
    private Game_Controller gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <Game_Controller> ();
        }
        if(gameController==null)
        {
            Debug.Log("Cannot find 'Game Controller' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(scorevalue);
        Destroy(other.gameObject);
        Destroy(gameObject);
        
    }
}