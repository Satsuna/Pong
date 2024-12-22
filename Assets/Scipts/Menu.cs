using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ChangeScene() {
        SceneManager.LoadScene("Game");
    }

    public void Quit() {
        Application.Quit();
    }
}
