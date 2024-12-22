using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 startPosition;

    [SerializeField] private GameManager gameManager;
    
    void Start()
    {
        //Sets the Start Position
        startPosition = transform.position;
        gameManager.ballCurrentSpeed = gameManager.ballSpeed;
        Launch();
    }

    void Update() {
        UpdateBallSpeed();
    }

    private void Launch() {
        float x = Random.Range(0, 2);
        float y = Random.Range(0, 2); 

        //I did not used ternary operator for readable code xD
        if (x == 0 ) {
            x = -1;
        }
        else {
            x = 1;
        }

        if (y == 0 ) {
            y = -1;
        }
        else {
            y = 1;
        }

        rb.linearVelocity = new Vector2(gameManager.ballCurrentSpeed * x, gameManager.ballCurrentSpeed * y);
    }

    public void Reset() {
        rb.linearVelocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }

    private void UpdateBallSpeed() {
        if (gameManager.ballCurrentSpeed != gameManager.ballSpeed) {
            rb.linearVelocity = rb.linearVelocity.normalized * gameManager.ballCurrentSpeed;
        }
        else {
            rb.linearVelocity = rb.linearVelocity.normalized * gameManager.ballSpeed;
        }
    }
}
