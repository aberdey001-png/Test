using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        PipeSpawner.OnInstantiatePipe += ApplySpeed;
    }

    private void OnDisable()
    {
        PipeSpawner.OnInstantiatePipe -= ApplySpeed;
    }
    private void ApplySpeed(float speed)
    {
        _speed = speed;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    
}
