using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEnabler : MonoBehaviour {

    Collider Aoe;

    private void Start()
    {
       Aoe = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponentInChildren<TimeBody>())
        {
            other.GetComponentInChildren<Rigidbody>().isKinematic = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.GetComponentInChildren<TimeBody>())
        {
            other.GetComponentInChildren<Rigidbody>().isKinematic = true;
        }
    }

}
