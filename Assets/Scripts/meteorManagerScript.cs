using System.Collections;
using TMPro;
using UnityEngine;


public class meteorManagerScript : MonoBehaviour
{
    public float timeBetweenChecks = 3;
    public int minNumMeteors = 3;
    public GameObject meteor;

    public int kills = 0;

    public TextMeshProUGUI killstext;


// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        StartCoroutine("MeteorCheck");

        killstext.text = "Kills: 0";



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

    public void AddKill()
    {
        kills++;
        killstext.text = "Kills: " + kills;
    }
}
