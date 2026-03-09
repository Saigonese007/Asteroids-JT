using Unity.VisualScripting;
using UnityEngine;

public class meteorScript : MonoBehaviour
{

    public float HP = 2;
    public float scale = 3;

    public float startsVelocityScale = 5;

    public AudioClip ExplosionSounds;

    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();


        transform.localScale = new Vector3(scale, scale);
        HP = scale;

        GetComponent<Rigidbody2D>().linearVelocity = Random.insideUnitCircle * startsVelocityScale;

    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {

            if (scale >= 1.5f)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject newMeteor = Instantiate(gameObject, transform.position + new Vector3(i,i), Quaternion.identity);
                    meteorScript newMs = newMeteor.GetComponent<meteorScript>();
                    newMs.scale = scale - 1;
                }
            }


            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("missile"))
        {
            Instantiate(ExplosionSounds, transform.position, Quaternion.identity);

            audioSource.PlayOneShot(ExplosionSounds);

            HP--;
            Destroy(collision.gameObject);
        }
    }
}
