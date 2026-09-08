using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreManager : MonoBehaviour
{   
    public static System.Action OnScorePoint;
    public TextMeshProUGUI  scoreText;
    public TextMeshProUGUI  textInfo;
    [SerializeField] public int score = 0;
    
    private Coroutine  timeTextInfo;

    private void OnEnable() 
    {
        ChekTriggerPoint.OnChekTriggerPoint += ScorePoint;
        BirdCollisionHandler.OnChekCollisionEnter += ScoreSave;
    }
    private void OnDisable() 
    {
        ChekTriggerPoint.OnChekTriggerPoint -= ScorePoint;
        BirdCollisionHandler.OnChekCollisionEnter -= ScoreSave;
    }

    public void ScorePoint()
    {   
        score++;
        scoreText.text = score.ToString();
        
        if (score % 10 == 0)
        {   
            textInfo.gameObject.SetActive(true);
            textInfo.text = "Скорость увеличилась";
            if (timeTextInfo != null) 
            {
                StopCoroutine(timeTextInfo);
            }
            timeTextInfo = StartCoroutine(TimeTextInfo());
            OnScorePoint?.Invoke();
        }
    }

    private void ScoreSave()
    {
        textInfo.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        if (score > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", score);     
        }
    }

    private IEnumerator TimeTextInfo() 
    {
        yield return new WaitForSeconds(5f);
        textInfo.gameObject.SetActive(false);
        timeTextInfo = null;
        
    }



}
