using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class pressanykey : MonoBehaviour
{
    public float blinkInterval = 0.5f;
    public Text textComponent;
    private bool isTextVisible = true;
    public AudioSource sound;
    public string Game;
    public int once;
    // Start is called before the first frame update
    void Start()
    {
        once = 0;
        StartCoroutine(BlinkText());
    }

    // Update is called once per frame
    void Update()
    {
        CheckKey();
    }

    async void CheckKey()
    {
        if (Input.anyKeyDown && !Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
        {
            if (once == 0)
            {
                once = 1;
                sound.Play();
                await Task.Delay(2600);
                SceneManager.LoadScene(Game);
            }
        }
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            // Inverter a visibilidade do texto (ligado/desligado)
            textComponent.enabled = isTextVisible;
            isTextVisible = !isTextVisible;

            // Esperar o intervalo de tempo definido
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
