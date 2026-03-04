using UnityEngine;

public class playerScript : MonoBehaviour
{
    Rigidbody2D rb;

    public float thrust = 1;
    public float rotationSpeed = 50;

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
    }
}
