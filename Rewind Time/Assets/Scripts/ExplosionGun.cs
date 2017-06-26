using System.Collections;
using UnityEngine;

public class ExplosionGun : MonoBehaviour {

	public GameObject explosion;	// The explosion prefab
	public Camera cam;              // Reference to the Player camera

    public float cooldown =0;
    private TimeBody[] timeBList;
    public GameObject map;
    private GameObject exp;

    private void Start()
    {
        timeBList = map.GetComponentsInChildren<TimeBody>();
    }
    
    void Update ()
	{		
		if (Input.GetKeyDown(KeyCode.Space) && cooldown < Time.time)
        {
			Shoot();
            cooldown = Time.time + 5;
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
	
		if (Physics.Raycast(transform.position, transform.forward, out _hitInfo))
		{
			exp = Instantiate(explosion, _hitInfo.point, Quaternion.LookRotation(_hitInfo.normal));
        }
        StartCoroutine(playerWait());
    }

    IEnumerator playerWait()
    {
        yield return new  WaitForFixedUpdate();
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(exp.gameObject);
    }
    
}
