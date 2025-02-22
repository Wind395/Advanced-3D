using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject loading;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingMenu;
    [SerializeField] private Button _play;
    [SerializeField] private Button _setting;
    [SerializeField] private Button _exit;

    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _play.onClick.AddListener(() => PlayBtn(1));
        _setting.onClick.AddListener(SettingBtn);
        _exit.onClick.AddListener(ExitBtn);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayBtn(int sceneID)
    {
        SoundManager.Instance.PlaySFX("Click");
        loading.SetActive(true);
        mainMenu.SetActive(false);
        StartCoroutine(LoadSceneAsync(sceneID));
    }

    void SettingBtn()
    {
        SoundManager.Instance.PlaySFX("Click");
        settingMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    void ExitBtn()
    {
        SoundManager.Instance.PlaySFX("Click");
        Debug.Log("Exit Button Clicked");
        Application.Quit();
    }

    private IEnumerator LoadSceneAsync(int sceneID)
    {
        yield return new WaitForSeconds(1);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneID);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }


    public void MusicSlider()
    {
        SoundManager.Instance.audioSource.volume = _musicSlider.value;
    }

    public void SFXSlider()
    {
        SoundManager.Instance.sfxSource.volume = _sfxSlider.value;
    }
}
