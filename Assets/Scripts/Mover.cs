using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public GameObject hazard;
    private Vector3 speed= new Vector3(0,-1,0);

    void Update()
    {
        hazard.GetComponent<Rigidbody>().velocity = Random.Range(1,5)* speed;
    }
}