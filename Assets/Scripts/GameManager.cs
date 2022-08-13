using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject Startbtn;
    public GameObject Restartbtn;
    public GameObject NextLevelBtn;


    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] TextMeshProUGUI Level;

    public int SceneNo = 0;
    public int MainScore = 0;
    private void Start()
    {
        Time.timeScale = 0;
        SceneNo = SceneManager.GetActiveScene().buildIndex;
        Level.text = "" + SceneManager.GetActiveScene().name;
    }
    public void Restart()
    {

        SceneManager.LoadScene(0);
        Startbtn.SetActive(false);
        Time.timeScale = 1;

    }
    public void StartBtn()
    {
        Time.timeScale = 1;
        Startbtn.SetActive(false);
        Score.gameObject.SetActive(true);

    }

    public void NextLevel()
    {

        if (SceneNo >= SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
            Debug.Log("All The Levels Are Completed You ");
        }
        if (SceneNo < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneNo++;
            SceneManager.LoadScene(SceneNo);
        }
        Startbtn.SetActive(false);
        Time.timeScale = 1;
    }

    public void NextLevelIni()
    {
        NextLevelBtn.SetActive(true);
    }

    public void Button_exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void GameOver()
    {
        Debug.Log("GameManager: GameOver");
        Restartbtn.SetActive(true);
        
    }

    public void Win()
    {
        Debug.Log("GameManager: Won");
    }

    public void ScoreManager( int Scoreint)
    {
        MainScore = MainScore + Scoreint;
        Score.text = "" + MainScore;
    }
}
