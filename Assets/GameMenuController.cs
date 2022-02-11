using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour
{

    [SerializeField]
    private Button _restart, _mainMenu;
    [SerializeField] private AudioManager _AM;
    [SerializeField] private GameObject _GO, _PP;
    private bool isPaused;

    private void Start()
    {
        //_GO.active = false;
        _PP.gameObject.SetActive(false);
        isPaused = false;
        _AM = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                isPaused = true;
                _PP.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                isPaused = false;
                _PP.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void ContinueButton()
    {
        _AM.Boton();
        Time.timeScale = 1;
        isPaused = false;
        _PP.SetActive(false);
    }

    public void RestartButton()
    {
        _AM.Boton();
        StartCoroutine(RestartButtonCR());
    }

    public void MainMenuButton()
    {
        _AM.Boton();
        StartCoroutine(MainMenuButtonCR());
    }

    private IEnumerator RestartButtonCR()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main");
    }

    private IEnumerator MainMenuButtonCR()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main Menu");
    }


}
