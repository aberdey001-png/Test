using UnityEngine;
using TMPro;

public class UIMainMenu : MonoBehaviour
{
    public TextMeshProUGUI  recordText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.GetInt("Score") > 0) 
        {
            recordText.text = PlayerPrefs.GetInt("Score").ToString();
        } else 
        {
            recordText.text = "0";
        }
    }

    private void OnEnable () 
    {
        MainMenu.RecordDeleted += UpdateScore;
    }

    private void OnDisable () 
    {
        MainMenu.RecordDeleted -= UpdateScore;
    }
    
    private void UpdateScore () 
    {
        recordText.text = "0";
    }
}
