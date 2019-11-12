using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class ship_move : MonoBehaviour {

    public GameObject bolt;

    public GameObject Shot_Spawn;

    public float fireRate;

    private float nextFire;

    public Vector3 distanceLR;

    public Vector3 distanceUD;

    public Boundary boundary;

    public float tilt;

    Rigidbody ship_rigid;

	void Start ()
    {

        ship_rigid = GetComponent<Rigidbody>();
	}

	void Update ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(distanceLR * Time.deltaTime);
            
        }
       
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-distanceLR * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(distanceUD * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-distanceUD * Time.deltaTime);
        }

        //Fire Rate for not to spam shots

        if (Input.GetKeyDown(KeyCode.Mouse0)&&Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate(bolt, Shot_Spawn.transform.position- new Vector3(0.2f,0,0), Quaternion.identity);
            
            Instantiate(bolt, Shot_Spawn.transform.position, Quaternion.identity);

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }

    }
    
    private void FixedUpdate()
    {

        ship_rigid.position = new Vector3
        (
            Mathf.Clamp(ship_rigid.position.x, boundary.xMin, boundary.xMax),

            Mathf.Clamp(ship_rigid.position.y, boundary.yMin, boundary.yMax),

             0.0f
        );
        //ship_rigid.rotation = Quaternion.Euler(-90.0f, 0.0f, ship_rigid.velocity.z * -tilt);
    }
}
