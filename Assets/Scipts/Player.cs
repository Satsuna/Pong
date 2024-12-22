using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //References
    public Vector2 startPosition;
    public Rigidbody2D rb;

    //Abilities
    public KeyCode ability1;
    public KeyCode ability2;

    //Misc
    public bool isP1;
    public KeyCode Dash;
    private float movement;

    [SerializeField] private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        //Sets the Start Position
        startPosition = transform.position;
    }

    void Update()
    {
        if (isP1) {
            movement = Input.GetAxisRaw("Vertical");

            if (Input.GetKey(Dash)) {
                gameManager.player1CurrentSpeed = gameManager.playerSprintSpeed;
            }
            else {
                gameManager.player1CurrentSpeed = gameManager.player1Speed;
            }
        }
        else {
            movement = Input.GetAxisRaw("Vertical2");

            if (Input.GetKey(Dash)) {
                gameManager.player2CurrentSpeed = gameManager.playerSprintSpeed;
            }
            else {
                gameManager.player2CurrentSpeed = gameManager.player2Speed;
            }
        }
        Ability();
    }

    void FixedUpdate() {
        if (isP1) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, movement * gameManager.player1CurrentSpeed);
        }
        else {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, movement * gameManager.player2CurrentSpeed);
        }
    }

    public void Reset() {
        rb.linearVelocity = Vector2.zero;
        transform.position = startPosition;
    }

    public virtual void Ability() {
        //ability 1
        float speed = 8f;
        if (Input.GetKey(ability1)) {
            gameManager.ballCurrentSpeed += speed;
        }
        else {
            gameManager.ballCurrentSpeed = gameManager.ballSpeed;
        }

        //ability 2
        if (Input.GetKey(ability2)) {
            transform.localScale = new Vector2(1, 6);
        }
        else {
            transform.localScale = new Vector2(1, 3);
        }
    }
}
