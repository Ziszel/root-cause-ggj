using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSceneManager : MonoBehaviour
{
    [SerializeField] Button startGameBtn;
    [SerializeField] Button quitGameBtn;
    private bool _isWebGl;

    void Start()
    {
        _isWebGl = DetectPlatform();
        startGameBtn.onClick.AddListener(StartGame);
        if (_isWebGl)
        {
            quitGameBtn.interactable = false;
        }
        else
        {
            quitGameBtn.onClick.AddListener(QuitGame);
            quitGameBtn.onClick.AddListener(QuitGame);
        }

    }


    private bool DetectPlatform()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
            //if (Application.platform == RuntimePlatform.OSXEditor) testing
        {
            return true;
        }

        return false;
    }

    private void StartGame()
    {
        SceneManager.LoadScene("RoomExample");
    }

    private void QuitGame()
    {
        Application.Quit(); // in standalone build
        UnityEditor.EditorApplication.isPlaying = false; // in the editor
    }

}
