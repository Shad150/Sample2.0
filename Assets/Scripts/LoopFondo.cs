using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoopFondo : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //main.transform.Rotate(0, 0, degress*Time.deltaTime);
        //Debug.Log("1 " + Mathf.Abs(main.transform.rotation.eulerAngles.z));
        //Debug.Log("2 " + maxDegrees);
        if (Mathf.Abs(main.transform.localRotation.eulerAngles.z) >= maxDegrees)
        {
            degress *= -1;
        }


        scaler.transform.localScale -= new Vector3(.1f,.1f,.1f)*Time.deltaTime;

        if(scaler.transform.localScale.x <= 0.08f)
        {
            if (rotaciones[cont]==rotator.transform.rotation.eulerAngles && cont< imagenes.Length-1)
            {
                scaler.transform.localScale = Vector3.one;
                cont++;
                puntos++;
                puntuacion.text = ""+puntos;
                forma.sprite = imagenes[cont];
            }
            else
            {
                cont = 0;
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
        }
        //if ()
        //{

        //}

        
    }
}
