using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject basicRoad;
    public GameObject obstacle;
    private Vector3 startPosition;
    private Vector3 nextPosition;
    public int numOfBasicRoad = 10;
    private UIManager um;
    private int score = 0;
    public PlayerController playerController; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        um = FindAnyObjectByType<UIManager>();
        startPosition = new Vector3(0, 0, 0);
        nextPosition = startPosition;
        for (int i = 0; i < numOfBasicRoad; i++) // Tạo trước một số basicRoad
        {
            CreateBasicRoad(i > 4);
        } 
    } 

    public void CreateBasicRoad(bool createObstalce)
    {  
        var newBasicRoad = Instantiate(basicRoad, nextPosition, Quaternion.identity);
        nextPosition = newBasicRoad.transform.Find("NextRoadPosition").transform.position; // cập nhật vị trí tạo basicRoad tiếp theo bằng cách lấy vị trí NextRoadPosition của basicRoad hiện tại

        if (createObstalce)
        {
            int randomNumber = Random.Range(0, 3);
            Vector3 obstaclePosition = randomNumber == 0 ? newBasicRoad.transform.Find("CenterPosition").transform.position :
                randomNumber == 1 ? newBasicRoad.transform.Find("LeftPosition").transform.position : newBasicRoad.transform.Find("RightPosition").transform.position;

            GameObject obstacleObj = Instantiate(obstacle, obstaclePosition, Quaternion.identity);
            obstacleObj.transform.SetParent(newBasicRoad.transform);
        }
       
    }
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        um.ShowScore(score);
        // xữ lý tăng độ tốc độ player
        if (score % 20 == 1 && score > 1)
        {
            // tăng tốc move speed của player
            playerController.moveSpeed++; 
        }


    }

    public void GameOver()
    {
        um.ShowHideGameOverPanel(true);
    }

    public void PlayAgain()
    {
        string sceneName = SceneManager.GetActiveScene().name ;
        SceneManager.LoadScene(sceneName);
    }
}
