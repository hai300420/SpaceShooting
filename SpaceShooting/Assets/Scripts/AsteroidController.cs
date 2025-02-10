using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
    }

    private void Move()
    {

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        if (transform.position.y <= min.y)
        {
            Destroy(gameObject);
        }
        transform.position = position;
    }




}
