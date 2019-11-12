using UnityEngine;
using System.Collections;

public class Random_Rotator : MonoBehaviour
{
    public GameObject hazard;
    public float tumble;

    void Start()
    {
        hazard.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble*Random.Range(4,12);
    }
}