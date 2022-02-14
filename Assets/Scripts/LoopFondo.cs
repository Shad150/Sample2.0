using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoopFondo : MonoBehaviour
{
    private AudioManager _AM;
    public Canvas main;
    public Image forma;
    public Sprite[] imagenes;
    public Vector3[] rotaciones;
    public float degress=180, maxDegrees;
    public GameObject scaler;
    public GameObject rotator;
    int cont = 0;
    int puntos=0;
    public Text puntuacion;
    public Color azul;
    public Color rojo;
    public float scaleMult=1;
    public GameObject ko;
    public ShapeController controles;
    private bool deadSoundPlayed;
    // Start is called before the first frame update
    void Start()
    {
        _AM = FindObjectOfType<AudioManager>();
        deadSoundPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (cont<=3)
        {
            forma.color = new Color(0.9490196f, 0.2352941f, 0.3529412f);
        }else if (cont <= 7)
        {
            Debug.Log("wtf");
            forma.color = azul;
        }
        else if (cont <= 11)
        {
            forma.color = azul;
        }
        else if (cont <= 15)
        {
            forma.color = new Color(0.9490196f, 0.2352941f, 0.3529412f);
        }
        else if (cont <= 19)
        {
            forma.color = new Color(0.9490196f, 0.2352941f, 0.3529412f);
            Debug.Log("wtf");
        }
        else
        {
            forma.color = azul;
        }
        //main.transform.Rotate(0, 0, degress*Time.deltaTime);
        //Debug.Log("1 " + Mathf.Abs(main.transform.rotation.eulerAngles.z));
        //Debug.Log("2 " + maxDegrees);
        if (Mathf.Abs(main.transform.localRotation.eulerAngles.z) >= maxDegrees)
        {
            degress *= -1;
        }
        Debug.Log("asd"+rotator.transform.rotation.eulerAngles);
        //scaler.transform.localScale -= Vector3.one * Time.deltaTime * ((cont + 1) * scaleMult);
        scaler.transform.localScale -= Vector3.one*Time.deltaTime*0.3f;

        if(scaler.transform.localScale.x <= 0.08f)
        {
            //if (Quaternion.Euler(rotaciones[cont])==rotator.transform.rotation && cont< imagenes.Length)
            if(Quaternion.Angle(Quaternion.Euler(rotaciones[cont]), rotator.transform.rotation) <= 1)
            {
                scaler.transform.localScale = Vector3.one;
                cont = (int)Random.RandomRange(0, rotaciones.Length);
                puntos++;
                _AM.Acierto();
                puntuacion.text = ""+puntos;
                forma.sprite = imagenes[cont];
            }
            else
            {
                if (!deadSoundPlayed)
                {
                    ShapeDead();
                }
                
                ko.SetActive(true);
                controles.controlActive = false;
                //print("// "+Quaternion.Angle(Quaternion.Euler(rotaciones[cont]), rotator.transform.rotation));

                //cont = 0;
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
        }
        
    }

    private void ShapeDead()
    {
        _AM.Error();
        deadSoundPlayed = true;
    }

}
