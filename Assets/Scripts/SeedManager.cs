using UnityEngine;
using UnityEngine.AI;

public class SeedManager : MonoBehaviour
{

    public bool hasSeed;

    public float toolKitRadius;
    public LayerMask toolLayer;

    public float plantingRadius;
    public LayerMask plantableLayer;

    NavMeshAgent agent;

    public MeshRenderer sprout;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        hasSeed = false;
    }

    // Update is called once per frame
    void Update()
    {
        sprout.enabled = hasSeed;

        Collider[] colliders = Physics.OverlapSphere(agent.transform.position, toolKitRadius, toolLayer);
        foreach (Collider collider in colliders)
        {
            hasSeed = true;
            Debug.Log("got sprout");
        }

        if (hasSeed)
        {
            Collider[] plantables = Physics.OverlapSphere(agent.transform.position, plantingRadius, plantableLayer);
            foreach (Collider collider in plantables)
            {
                hasSeed = false;
                Debug.Log("planted sprout");
            }
        }
    }
}
