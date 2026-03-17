using UnityEngine;
using UnityEngine.Audio;

public class MusicManagerScript : MonoBehaviour
{
    public AudioClip Ljud1;
    public AudioClip Ljud2;

    AudioSource LjudSource;
    int currentTrack = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("MusicManager").Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }

        LjudSource = GetComponent<AudioSource>();

        LjudSource.clip = Ljud1;
        LjudSource.loop = true;
        LjudSource.Play();




    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

            LjudSource.Stop();

            if (currentTrack == 1)
            {
                LjudSource.clip = Ljud2;
                currentTrack = 2;
            }

            else if(currentTrack == 2)
            {
                LjudSource.clip = Ljud1;
                currentTrack = 1;
            }
            LjudSource.Play();

        }
    }


}
