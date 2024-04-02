using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class ChangeImageArcher : MonoBehaviour
{
    public Image image;
    public Sprite[] frames;
    public float frameRate = 0.1f;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void Update()
    {

    }

    public async void playGif()
    {
            for (int i = 0; i <= 4; i++)
            {
                image.sprite = frames[i];
                await Task.Delay(100);
            }
    }
}