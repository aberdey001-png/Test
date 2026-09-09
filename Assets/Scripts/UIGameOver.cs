using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    private ScoreManager scoreManager;
    public CanvasGroup panelGameOver;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI recordText;
    private void Start() 
    {
        scoreManager = GetComponent<ScoreManager>();
        panelGameOver.alpha = 0;
        panelGameOver.interactable = false;
        panelGameOver.blocksRaycasts = false;
    }
   
    private void OnEnable() 
    {
        BirdCollisionHandler.OnChekCollisionEnter += GameOver;
        
    }
    private void OnDisable() 
    {
        BirdCollisionHandler.OnChekCollisionEnter -= GameOver;
        
    }

    private void GameOver() 
    {   
       StartCoroutine(CuratinGameOver(3f));
       scoreText.text = "Ваш счёт: " + scoreManager.score.ToString();
       recordText.text = "Рекорд: " + PlayerPrefs.GetInt("Score").ToString(); 
    }


    IEnumerator CuratinGameOver(float duration) 
    {
        
        float startAlpha = panelGameOver.alpha;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime ; // Используем реальное время (независимо от Time.timeScale)
            panelGameOver.alpha = Mathf.Lerp(startAlpha, 1f, timer / duration);
            yield return null;
        }
        panelGameOver.interactable = true;
        panelGameOver.blocksRaycasts = true;
        
    }

    public void ButtonRestartGame() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
    
    public void ButtonMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
