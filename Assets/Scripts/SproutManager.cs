using UnityEngine;

public class SproutManager : MonoBehaviour
{
    public GameObject sprout;
    public GameObject crop;

    public bool planted;
    public bool harvestable;

    public float timePlanted;
    public float growingTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sprout.SetActive(planted);
        crop.SetActive(harvestable);

        if (planted)
        {
            timePlanted += Time.deltaTime;
        }
        else
        {
            timePlanted = 0;
        }

        if(timePlanted >= growingTime)
        {
            planted = false;
            harvestable = true;
        }
    }
}
