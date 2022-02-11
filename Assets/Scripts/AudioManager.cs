using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _as;
    [SerializeField] private AudioClip[] _clips;

    void Start()
    {
        _as = GetComponent<AudioSource>();
    }


    public void Error()
    {
        _as.PlayOneShot(_clips[0]);
    }

    public void Giro()
    {
        _as.PlayOneShot(_clips[1]);

    }

    public void Acierto()
    {
        _as.PlayOneShot(_clips[2]);

    }

    public void Boton()
    {
        _as.PlayOneShot(_clips[3]);

    }
}
