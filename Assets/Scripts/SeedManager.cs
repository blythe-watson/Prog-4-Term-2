using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class SeedManager : MonoBehaviour
{
    public bool hasSeed;

    public float toolKitRadius;
    public LayerMask toolLayer;

    public float plantingRadius;
    public LayerMask plantableLayer;

    public int score;
    public TextMeshProUGUI scoreText;

    NavMeshAgent agent;

    public MeshRenderer sprout;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        hasSeed = false;

        score = 0;
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

        Collider[] plantables = Physics.OverlapSphere(agent.transform.position, plantingRadius, plantableLayer);
        foreach (Collider plot in plantables)
        {
            bool planted = plot.GetComponent<SproutManager>().planted;
            bool harvestable = plot.GetComponent<SproutManager>().harvestable;

            if (hasSeed)
            {
                if (planted == false)
                {
                    plot.GetComponent<SproutManager>().planted = true;
                    hasSeed = false;
                    Debug.Log("planted sprout");
                }
                else
                {
                    Debug.Log("This plot is full");
                }
            }

            if (harvestable)
            {
                plot.GetComponent<SproutManager>().harvestable = false;

                score++;
                scoreText.text = "Score:" + score;

                Debug.Log("crop harvested");
            }
        }

    }
}
