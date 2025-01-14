using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject basicRoad; 
    private Vector3 startPosition;
    private Vector3 nextPosition;
    public int numOfBasicRoad = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = new Vector3(0, 0, 0);
        nextPosition = startPosition;
        for (int i = 0; i < numOfBasicRoad; i++) // Tạo trước một số basicRoad
        {
            CreateBasicRoad();
        } 
    } 

    public void CreateBasicRoad()
    {  
        var newBasicRoad = Instantiate(basicRoad, nextPosition, Quaternion.identity);
        nextPosition = newBasicRoad.transform.Find("NextRoadPosition").transform.position; // cập nhật vị trí tạo basicRoad tiếp theo bằng cách lấy vị trí NextRoadPosition của basicRoad hiện tại

    }
}
