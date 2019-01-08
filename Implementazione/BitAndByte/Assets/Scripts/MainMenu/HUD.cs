using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HUD : MonoBehaviour {

    public GameObject MenuPause;
    public GameObject DeathScreen;
    public GameObject WinScreen;
    public GameObject Blur;
    public AudioClip Error;
    public AudioClip WinAudio;

    private void Awake()
    {
        EventManager.StartListening("Pause", OpenMenuPause);
        EventManager.StartListening("GameOver", OpenDeath);
        EventManager.StartListening("Win", OpenWinScreen);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("Pause", OpenMenuPause);
        EventManager.StopListening("GameOver", OpenDeath);
        EventManager.StopListening("Win", OpenWinScreen);
    }


    public void ResumeGame()
    {
        Time.timeScale = 1;
        MenuPause.SetActive(false);
        Blur.SetActive(false);
        EventManager.TriggerEvent("ResumePlayer");
    }

    private void OpenWinScreen()
    {
        Time.timeScale = 0;
        EventManager.TriggerEvent("PausePlayer");
        WinScreen.SetActive(true);
        Blur.SetActive(true);
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(WinScreen.GetComponentsInChildren<UnityEngine.UI.Button>()[0].gameObject);
        SoundManager.instance.StopBackgroundMusic();
        SoundManager.instance.StartEffectMusic(WinAudio);
    }

    private void OpenDeath()
    {
        Time.timeScale = 0;
        EventManager.TriggerEvent("PausePlayer");
        StartCoroutine(OpenMenuAfter());
    }

    public void Continue()
    {
        Time.timeScale = 1;
        EventManager.TriggerEvent("NextLevel");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        EventManager.TriggerEvent("ResetLevel");
    }

    public void Menu()
    {
        Time.timeScale = 1;
        EventManager.TriggerEvent("Exit");
    }

    public void OpenMenuPause()
    {
        Time.timeScale = 0;
        EventManager.TriggerEvent("PausePlayer");
        MenuPause.SetActive(true);
        Blur.SetActive(true);
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(MenuPause.GetComponentsInChildren<UnityEngine.UI.Button>()[0].gameObject);
    }

    private IEnumerator OpenMenuAfter()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        DeathScreen.SetActive(true);
        Blur.SetActive(true);
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(DeathScreen.GetComponentsInChildren<UnityEngine.UI.Button>()[0].gameObject);
        SoundManager.instance.StopBackgroundMusic();
        SoundManager.instance.StartEffectMusic(Error);
        yield return null;
    }


}
