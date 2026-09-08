using UnityEngine;
using System.Collections;

public class BirdCollisionHandler : MonoBehaviour
{
    public static System.Action OnChekCollisionEnter;

    public bool isAlive = true;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        
        OnChekCollisionEnter?.Invoke();
       
        isAlive = false;
        Time.timeScale = 0.1f;
        StartCoroutine(StopGame());
        StartCoroutine(FadeOutMusic(4f));
    }

    IEnumerator StopGame()
    {   
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 0f;
        // показ результата и сцены конец игры
    }
    IEnumerator FadeOutMusic(float duration)
    {
        float startPitch = audioSource.pitch;
        float startVolume = audioSource.volume;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime; // Используем реальное время (независимо от Time.timeScale)
            audioSource.pitch = Mathf.Lerp(startPitch, 0f, timer / duration);
            audioSource.volume = Mathf.Lerp(startVolume, 0f, timer / duration);
            yield return null;
        }

        audioSource.Stop();
        audioSource.pitch = startPitch; // Сбрасываем громкость для рестарта
        audioSource.volume = startVolume;
    }
}
