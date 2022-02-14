using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button _play, _settings, _exit;
    [SerializeField] private AudioManager _AM;
    private bool controlsOpen;
    [SerializeField] private GameObject controlsPanel;

    private void Start()
    {
        _AM = FindObjectOfType<AudioManager>();
        controlsPanel.SetActive(false);
    }

    public void PlayButton()
    {
        _AM.Boton();
        StartCoroutine(PlayButtonCR());
    }

    public void SettingsButton()
    {
        _AM.Boton();
        StartCoroutine(SettingsButtonCR());
    }

    public void ExtitButton()
    {
        _AM.Boton();
        StartCoroutine(ExitButtonCR());
    }

    public void ControlsButton()
    {
        _AM.Boton();

        if (!controlsOpen)
        {
            controlsPanel.SetActive(true);
            controlsOpen = true;
        }
        else
        {
            controlsPanel.SetActive(false);
            controlsOpen = false;
        }
    }

    private IEnumerator PlayButtonCR()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main");

    }

    private IEnumerator SettingsButtonCR()
    {
        yield return new WaitForSeconds(1f);

    }

    private IEnumerator ExitButtonCR()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}
