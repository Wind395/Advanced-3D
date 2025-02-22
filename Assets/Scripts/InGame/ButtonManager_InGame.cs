using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager_InGame : MonoBehaviour
{

    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private Button _resume;
    [SerializeField] private Button _exit;

    private bool _isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _resume.onClick.AddListener(ResumeBtn);
        _exit.onClick.AddListener(ExitBtn);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isPaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _isPaused = true;
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _isPaused)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _isPaused = false;
            _pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ResumeBtn()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitBtn()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("Exit Button Clicked");
        SceneManager.LoadScene(0);
    }
}
