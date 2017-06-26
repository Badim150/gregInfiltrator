using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Guard : MonoBehaviour {

    [SerializeField] private Rigidbody Target;
    public NavMeshAgent nav;

	void Update ()
    {
        FollowTarget();
    }

    public void FollowTarget()
    {
        float xPos = Target.transform.position.x;
        float zPos = Target.transform.position.z;

        Vector3 TargetPos = new Vector3(xPos, transform.position.y, zPos);
        nav.SetDestination(TargetPos);
    }

    public void NewTarget(Rigidbody player)
    {
        Target = player;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MyPlayerController>())
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
