using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text hirituText;
    [SerializeField] Map map;
    [SerializeField] Image timerImage;
    [SerializeField] float plaingTime;
    [SerializeField] GameObject gameoverPanel;
    float seconds = 0f;
    public static GameManager I;
    public int chipsCount,turnCount;
    
    public enum GAMEMODE
    {
        PLAY,
        GAMEOVER
    }

    public GAMEMODE gameMode;

    private void Awake()
    {
        if (I == null)
        {
            I = this;
        }
        
    }

    private void Update()
    {
        timerImage.fillAmount = _updateTimer();
        if(timerImage.fillAmount >= 1 && gameMode == GAMEMODE.PLAY)
        {
            gameMode = GAMEMODE.GAMEOVER;
            gameoverPanel.SetActive(true);
            hirituText.gameObject.transform.SetParent(gameoverPanel.transform);
            hirituText.gameObject.transform.localPosition = new Vector3(0f, -150f);
            //naichilab.RankingLoader.Instance.SendScoreAndShowRanking((float)turnCount / chipsCount * 100);

        }
    }

    public void UpdateHiritu()
    {
        hirituText.text = ((float)turnCount / chipsCount).ToString("P");
    }


    float _updateTimer()
    {
        seconds += Time.deltaTime;
        float timer = seconds / plaingTime;
        return timer;
    }

    public void Retry()
    {
        SceneManager.LoadScene("Main");
    }
}
