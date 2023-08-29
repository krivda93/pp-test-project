using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Player playerPrefub;
    [SerializeField] private Player player;

    [Header("ScoreUi")]
    [SerializeField] private TMP_Text m_labelScore;
    [SerializeField] private int m_score;

    [Header("UiBtns")]
    [SerializeField] private GameObject m_btnPlay;
    [SerializeField] private GameObject m_gameOver;
    [SerializeField] private GameObject m_gameReady;

    private void Awake()
    {
        Application.targetFrameRate= 60;
        Pause();
    }
    public void Play()
    {
        player = Instantiate(playerPrefub.gameObject, Vector2.zero, Quaternion.identity).GetComponent<Player>();
        m_score = 0;
        m_labelScore.text = m_score.ToString();

        m_gameOver.SetActive(false);
        m_gameReady.SetActive(false);
        m_btnPlay.SetActive(false);

        Time.timeScale = 1;
        foreach (Pipse item in FindObjectsOfType<Pipse>())
            Destroy(item.gameObject);
        foreach (PointScore item in FindObjectsOfType<PointScore>())
            Destroy(item.gameObject);
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void GameOver()
    {
        m_gameOver.SetActive(true);
        m_gameReady.SetActive(false);
        m_btnPlay.SetActive(true);
        Destroy(player.gameObject);
        Pause();
    }
    public void IncScore()
    {
        m_score++;
        m_labelScore.text = m_score.ToString();
    }
}
