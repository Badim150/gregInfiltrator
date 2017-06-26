using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize : MonoBehaviour {

	[SerializeField] public float points;
    [SerializeField] private GameObject newGuard;
    [SerializeField] private Rigidbody player;
    private GameObject newG;
   
    private float timesCaught;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<MyPlayerController>())
        {
            other.transform.GetComponent<MyPlayerController>().score++;
            other.transform.GetComponent<ExplosionGun>().cooldown = 0;
            SpawnAnother();
        }
    }

    private void SpawnAnother()
    {
        float posX = Random.Range(-22, 22);
        float posZ = Random.Range(-22, 22);
        transform.position = new Vector3(posX, 0, posZ);

        timesCaught++;
        if (timesCaught % 3 == 0)
        {
            points++;
            newG = Instantiate(newGuard, transform.position, transform.rotation);
            newG.GetComponent<Guard>().NewTarget(player);
        }
    }
}
