using UnityEngine;

public class playerScript : MonoBehaviour
{
    Rigidbody2D rb;

    bool racecarPhysicsEnabled = false;

    public float thrust = 1;
    public float rotationSpeed = 300;
    public float maxSpeed = 15;

    [Header("Missile")]
    public GameObject missile;
    public float shotStrength = 50;
    public float missileLifetime = 2;
    public AudioClip[] missileSounds;

    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        rb.AddRelativeForceY(-thrust * yAxis);

        rb.rotation -= xAxis * rotationSpeed * Time.deltaTime;

        rb.angularVelocity = 0;

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (racecarPhysicsEnabled)
            {
                Debug.Log("race phys [OFF]");
                racecarPhysicsEnabled = false;
            }
            else
            {
                Debug.Log("race phys [ON]");
                racecarPhysicsEnabled = true;
            }
        }
       
        //racecar phys
        if (racecarPhysicsEnabled)
        {
            rb.linearVelocity = Quaternion.Euler(0, 0, rb.rotation) * Vector2.down * rb.linearVelocity.magnitude;
        }

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(missileSounds[Random.Range(0, missileSounds.Length)]);


            GameObject newMissile = Instantiate(missile, transform.position + -transform.up * 3, Quaternion.identity);
            Rigidbody2D mrb = newMissile.GetComponent<Rigidbody2D>();
            mrb.rotation = rb.rotation + 180;
            mrb.AddRelativeForceY(shotStrength, ForceMode2D.Impulse);

            Destroy(newMissile, missileLifetime);
        }
    }
}
