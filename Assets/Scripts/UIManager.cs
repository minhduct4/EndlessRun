using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    private GameManager gm;
    [SerializeField] private GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
    }
    public void PlayAgainBtnClick()
    {
        gm.PlayAgain();
    }
    public void showHideGameOverUI(bool isShow)
    {
        gameOverPanel.SetActive(isShow);
    }
     
    public void UpdateGameScore()
    {
        scoreText.text = gm.GetGameScore().ToString();
    }
}
