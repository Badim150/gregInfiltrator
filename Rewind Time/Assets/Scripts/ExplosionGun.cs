using System.Collections;
using UnityEngine;

public class ExplosionGun : MonoBehaviour {

	public GameObject explosion;	// The explosion prefab
	public Camera cam;              // Reference to the Player camera

    private float recharge = 0;
    private TimeBody[] timeBList;
    public GameObject map;

    private void Start()
    {
        timeBList = map.GetComponentsInChildren<TimeBody>();
    }


    void Update ()
	{
		// If the player presses fire
		if (Input.GetKeyDown(KeyCode.Space) && recharge <= 0)
        {
			Shoot();
            StartCoroutine(Rewind());
        }
            
	}

    IEnumerator Rewind()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < timeBList.Length; i++)
        {
            timeBList[i].StartRewind();
        }
    }

	void Shoot ()
	{
        GetComponent<Rigidbody>().isKinematic = true;
		RaycastHit _hitInfo;
		// If we hit something
		if (Physics.Raycast(transform.position, transform.forward, out _hitInfo))
		{
			// Create an explosion at the impact point
			Instantiate(explosion, _hitInfo.point, Quaternion.LookRotation(_hitInfo.normal));
        }
        StartCoroutine(playerWait());
    }

    IEnumerator playerWait()
    {
        yield return new  WaitForFixedUpdate();
        GetComponent<Rigidbody>().isKinematic = false;
    }
   
}
