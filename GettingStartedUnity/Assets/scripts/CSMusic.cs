using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSMusic : MonoBehaviour
{
    public AudioSource csMusic;
    public Image targetImage;
    public Sprite onMusic;
    public Sprite offMusic;

    public int musicGlobal;
    // Start is called before the first frame update
    void Start()
    {
        musicGlobal = PlayerPrefs.GetInt("Music");
        updateMusic(musicGlobal);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void updateMusic(int musicGlobal)
    {
        if (musicGlobal == 0)
        {
            targetImage.sprite = offMusic;
            csMusic.Stop();
        }
        else
        {
            targetImage.sprite = onMusic;
            csMusic.Play();
        }
    }

    public void OnOffMusic()
    {
        if (csMusic.isPlaying)
        {
            musicGlobal = 0;
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            musicGlobal = 1;
            PlayerPrefs.SetInt("Music", 1);
        }

        updateMusic(musicGlobal);
    }
}
