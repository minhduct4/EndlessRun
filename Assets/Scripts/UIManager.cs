using UnityEngine;

using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    private GameManager gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
    } 
    public void ShowHideGameOverPanel(bool isShow)
    {
        gameOverPanel.SetActive(isShow);
    }
    public void PlayAgainBtnClick()
    {
        // chơi lại game từ đầu
        gm.PlayAgain();
    }
    public void ShowScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
