using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyThrow : MonoBehaviour
{
    [HideInInspector]public Transform player;
    public GameObject objectToThrow;
    public float throwingRange = 10f;
    public float throwForce = 10f;
    public float throwInterval = 10f;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private bool canThrow = true;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < throwingRange && canThrow)
        {
            StartCoroutine(ThrowObject());
        }
    }

    IEnumerator ThrowObject()
    {
        // Set canThrow to false to prevent throwing more objects while coroutine is running
        canThrow = false;

        // Play the throwing animation
        animator.SetTrigger("Throw");

        // Wait for the animation to finish playing before throwing the object
        yield return new WaitForSeconds(0.75f);

        GameObject thrownObject = Instantiate(objectToThrow, transform.position + transform.forward, Quaternion.identity);
        Rigidbody thrownObjectRigidbody = thrownObject.GetComponent<Rigidbody>();
        Vector3 throwDirection = (player.transform.position - transform.position).normalized;
        thrownObjectRigidbody.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        // Wait for the throw interval before allowing the enemy to throw another object
        yield return new WaitForSeconds(throwInterval);

        // Set canThrow back to true to allow throwing another object
        canThrow = true;
    }
}
