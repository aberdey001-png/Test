using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static System.Action RecordDeleted;
    
    public void PlayGame()   
    {   
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    public void DeleteRecord()
    {
        PlayerPrefs.DeleteAll();
        RecordDeleted?.Invoke();
    }


}
