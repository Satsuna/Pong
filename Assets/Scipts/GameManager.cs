using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Ball")]
    public GameObject Ball;
    public float ballSpeed;
    public float ballCurrentSpeed;

    [Header("Players")]
    public float playerSpeed;
    public float playerSprintSpeed;
    public float playerCurrentSpeed;

    [Header("Player 1")]
    public GameObject Player1;
    public GameObject Player1Goal;

    [Header("Player 2")]
    public GameObject Player2;
    public GameObject Player2Goal;

    [Header("Score UI")]
    public GameObject Player1Text;
    public GameObject Player2Text;

    private int p1Score;
    private int p2Score;

    public void p1Scored() {
        p1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = p1Score.ToString();
        resetPosition();
    }

    public void p2Scored() {
        p2Score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = p2Score.ToString();
        resetPosition();
    }

    private void resetPosition() {
        Ball.GetComponent<Ball>().Reset();
        Player1.GetComponent<Player>().Reset();
        Player2.GetComponent<Player>().Reset();
    }
}
