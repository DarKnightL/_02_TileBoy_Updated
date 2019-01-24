using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnRespawn : MonoBehaviour {

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 startLocalScale;	

	void Start () {
        startPosition = transform.position;
        startRotation = transform.rotation;
        startLocalScale = transform.localScale;
	}
	
	
	void Update () {
		
	}

    public void ResetStatus() {
        transform.position = startPosition;
        transform.rotation = startRotation;
        transform.localScale = startLocalScale;
    }
}
