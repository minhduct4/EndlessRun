using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 offset; // khoảng cách từ camera tới player
    public GameObject target;
    void Start()
    {
        offset =  target.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        transform.position = target.transform.position - offset;
    }
}
