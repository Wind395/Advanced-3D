using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] private Button _play;
    [SerializeField] private Button _exit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _play.onClick.AddListener(PlayBtn);
        _exit.onClick.AddListener(ExitBtn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayBtn()
    {
        Debug.Log("Play Button Clicked");
        SceneManager.LoadScene("InGame");
    }

    void ExitBtn()
    {
        Debug.Log("Exit Button Clicked");
        Application.Quit();
    }
}
