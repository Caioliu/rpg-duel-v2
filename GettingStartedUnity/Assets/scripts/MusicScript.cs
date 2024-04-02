using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    [SerializeField] AudioSource music;
    public int musicGlobal;

    void Start()
    {
        musicGlobal = 1;
    }

    void Update()
    {
        PlayerPrefs.SetInt("Music", musicGlobal);
    }

    public void OnOffMusic()
    {
        if (music.isPlaying == false) {
            musicGlobal = 1;
            music.Play();
        }       
        else
        {
            musicGlobal = 0;
            music.Stop();
        }
    }
    
}
