using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

    [SerializeField]
    private float lifeTime = 2f;

	
	void Update () {
        lifeTime -= Time.deltaTime;
        if (lifeTime<0)
        {
            Destroy(gameObject);
        }
	}
}
