using UnityEngine;
using System.Collections;


public class PipeSpawner : MonoBehaviour
{       
    public static System.Action <float> OnInstantiatePipe;

    private BirdCollisionHandler birdCollisionHandler;
    private float spawnInterval  = 2f;
    private float positionY = 0f;
    private float lastPos = 0f;
    private int lastIndex = 0;
    [SerializeField] private GameObject[] pipePrefab;
    [SerializeField] private float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdCollisionHandler = FindFirstObjectByType<BirdCollisionHandler>();
        
        StartCoroutine(SpawnPipe());
    }

    IEnumerator SpawnPipe()
    { 
        while (birdCollisionHandler.isAlive == true){
            
            int index = Random.Range(0, pipePrefab.Length);
            if (lastIndex == 0 && lastPos > 3f && lastPos < 5f)
            {
                positionY = Random.Range(-7f, -9f); 
                index = 1;
                Debug.Log(index);
            } else if (lastIndex == 1 && lastPos < -3f && lastPos > -5f)
            {
                positionY = Random.Range(7f, 9f); 
                index = 0; 
                Debug.Log(index);       
            }else {
                positionY = Random.Range(3f, 9f);
                if (index == 1) 
                {   
                    
                    positionY = Random.Range(-3f, -9f);
                    
                }
            }
                
            Instantiate(pipePrefab[index], new Vector3(transform.position.x, positionY, 0), Quaternion.identity);
            lastPos = positionY;
            lastIndex = index;
            OnInstantiatePipe?.Invoke(speed);
        yield return new WaitForSeconds(spawnInterval );  
        }
        
    }

    private void OnEnable()
    {
        ScoreManager.OnScorePoint += SpawnTime;
    }

    private void OnDisable()
    {
        ScoreManager.OnScorePoint -= SpawnTime;
    }
    public void SpawnTime()
    {   
        speed += 1f;
        Debug.Log(speed);
        spawnInterval  = 10 / speed ;

    }
}
