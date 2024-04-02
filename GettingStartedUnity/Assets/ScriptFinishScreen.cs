using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptFinishScreen : MonoBehaviour
{
    public float blinkInterval = 0.5f;
    public Text textComponent;
    private bool isTextVisible = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlinkText());
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
