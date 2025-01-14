using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed;
    public float moveSpeed; 
    private Rigidbody rb;
    private float horizontalInput = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    } 
    private void FixedUpdate()
    {
        // Giữ vận tốc cố định 
        rb.linearVelocity = Vector3.forward * moveSpeed + new Vector3(horizontalInput * turnSpeed, rb.linearVelocity.y, 0);  
    } 
}
