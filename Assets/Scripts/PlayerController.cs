using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed;
    public float moveSpeed; 
    private Rigidbody rb;
    private float horizontalInput = 0;
    private GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = FindAnyObjectByType<GameManager>();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Checkpoint")
        {
            Debug.Log("Đã di chuyển vào checkpoint");
           
            // tạo mới 1 basicroad
            gm.CreateBasicRoad(true);

            gm.AddScore(1);
            // hủy basicroad chứa checkpoint này
            Destroy(other.transform.parent.gameObject, 1);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            Debug.Log("die");
            Destroy(transform.gameObject);
            // kết thúc game
            gm.GameOver();
        }
    }
}
