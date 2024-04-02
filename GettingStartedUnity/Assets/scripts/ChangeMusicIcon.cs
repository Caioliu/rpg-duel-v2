using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public AudioSource audioSource;
    public Image btnImage;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    public bool isMuted = false;

    public int musicGlobal;
    // Start is called before the first frame update
    void Start()
    {
        musicGlobal = PlayerPrefs.GetInt("Music");
        if (musicGlobal == 0)
        {
            isMuted = true;
        }
        else
        {
            audioSource.Play();
        }
        UpdateButtonImage();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void OnButtonClick()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            PlayerPrefs.SetInt("Music", 1);
        }
         else
        {
            PlayerPrefs.SetInt("Music", 0);
        }
        UpdateButtonImage();
    }

    private void UpdateButtonImage()
    {
        

        if (isMuted)
        {
            btnImage.sprite = soundOffSprite;
        }
        else
        {
            btnImage.sprite = soundOnSprite;
        }

    }
}
