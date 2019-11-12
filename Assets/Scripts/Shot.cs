using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    public Vector3 bolt_v=new Vector3(0,1,0);
    Rigidbody a;
    

	// Use this for initialization
	void Start ()
    {
        a = GetComponent<Rigidbody>();
        a.velocity = bolt_v;    
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
