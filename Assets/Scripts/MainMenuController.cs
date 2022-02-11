using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button _play, _settings, _exit;
    [SerializeField] private AudioManager _AM;

    private void Start()
    {
        _AM = FindObjectOfType<AudioManager>();
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
