using System.Collections;
using UnityEngine;

public class meteorManagerScript : MonoBehaviour
{
    public float timeBetweenChecks = 3;
    public int minNumMeteors = 3;
    public GameObject meteor;

    meteorManagerScript manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("MeteorCheck");

        manager = FindFirstObjectByType<meteorManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MeteorCheck()
    {
        while (true)
        {
            GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");

            if (meteors.Length < minNumMeteors)
            {
                Instantiate(meteor, Vector3.zero, Quaternion.identity);
            }

            yield return new WaitForSeconds(timeBetweenChecks);
        }
    }
}
