using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WSMusic : MonoBehaviour
{
    public Image targetImage;
    public Sprite onMusic;
    public Sprite OffMusic;

    public AudioSource welcomeSMusic;

    public int musicGlobal;
    // Start is called before the first frame update
    void Start()
    {
        musicGlobal = 1;
        PlayerPrefs.SetInt("Music", musicGlobal);
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
            targetImage.sprite = OffMusic;
            welcomeSMusic.Stop();
        }
        else
        {
            targetImage.sprite = onMusic;
            welcomeSMusic.Play();
        }
    }

    public void OnOffMusic()
    {
        if (welcomeSMusic.isPlaying)
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
