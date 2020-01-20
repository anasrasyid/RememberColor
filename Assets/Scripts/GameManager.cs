using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int score = 0;
    public float time;
    private float _time;
    private bool _isGameOver = false;
    public bool isGameOver { get { return _isGameOver; } }
    private bool _isWin = false;
    public bool isWin { get { return _isWin; } }
    private bool _isCanClick;
    public bool isCanClick { set { _isCanClick = value; } get { return _isCanClick; } }

    public GameObject panelWin,panelLose;
    public Text scoreText;

    private float timeR;
    private int nColor;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            _time = time;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameWin()
    {
        if (_isGameOver)
            return;
        _isWin = true;
        score += 100;
        SetScore();
        panelWin.active = true;
    }

    public void GameOver()
    {
        if (_isWin)
            return;
        _isGameOver = true;
        panelLose.active = true;
    }

    public void NextLevel()
    {
        _isWin = false;
        _isGameOver = false;
        time = _time;
        timeR = Mathf.Clamp(timeR + 0.5f, 3f, 6f);
        nColor = Mathf.Clamp(nColor + 1, 2, 7);
        StartCoroutine(Timer.timeObj.TimePlay(nColor, timeR));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        score = 0;
        SetScore();
        timeR = 3f;
        nColor = 2;
        time = _time;
        _isGameOver = false;
        _isCanClick = false;
        StartCoroutine(Timer.timeObj.TimePlay(nColor, timeR));
    }

    public void SetScore()
    {
        scoreText.text = "Score : " + score.ToString();
    }
}
