using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class playerScript : MonoBehaviour
{
    Rigidbody2D rb;

    public float thrust = 1;
    public float rotationSpeed = 300;
    public float maxSpeed = 15;

    bool racecarPhysicsEnabled = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            rb.linearVelocity = Quaternion.EulerAngles(0, 0, rb.rotation) * Vector2.down * rb.linearVelocity.magnitude;
        }

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}
