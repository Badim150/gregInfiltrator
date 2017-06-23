using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour {

    [SerializeField] private Rigidbody Target;
    public NavMeshAgent nav;

    // Use this for initialization
    void Start () {

       

    }
	
	// Update is called once per frame
	void Update () {
        FollowTarget();

    }

    public void FollowTarget()
    {
        float xPos = Target.transform.position.x;
        float zPos = Target.transform.position.z;


       Vector3 TargetPos = new Vector3(xPos, transform.position.y, zPos);

        nav.SetDestination(TargetPos);

    }
}
