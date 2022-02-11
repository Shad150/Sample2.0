using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioRead : MonoBehaviour
{
    public AudioSource mainMusic;
    [SerializeField]
    float[] sonidosPara= new float[64];
    public Image imagen;
    public float multi=100, sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mainMusic.GetSpectrumData(sonidosPara, 0, FFTWindow.Rectangular);
        float average = 0;
        for (int i = 0; i < sonidosPara.Length; i++)
        {
            //Debug.Log(i+" "+sonidosPara[i]);
            average += sonidosPara[i];
        }
        average /= sonidosPara.Length;
        float value = Mathf.Clamp(average * multi, 0, 0.5f);
        imagen.transform.localScale = Vector3.Lerp(imagen.transform.localScale, Vector3.one + (Vector3.one * average * multi), Time.deltaTime * sensitivity);
    }
}
