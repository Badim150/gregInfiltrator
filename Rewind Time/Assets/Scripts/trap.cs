using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<PlayerTimeBOdy>())
            other.transform.GetComponent<PlayerTimeBOdy>().PlayerDeath();
    }
}
