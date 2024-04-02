using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class rollDado : MonoBehaviour
{
    public Button btnDadoP1;
    public Button btnDadoP2;
    public Image dadoIdle;
    public Sprite[] rollingDice;
    public Sprite[] allFacesDice;
    public int randomP1;


    private void Start()
    {
        dadoIdle = GetComponent<Image>();
    }

    public void Update()
    {

    }

    public async void rollDice()
    {
        btnDadoP1.interactable = false;
        btnDadoP2.interactable = true;

        for (int cont = 0; cont <= 1; cont++)
        {
            for (int i = 0; i <= 5; i++)
            {
            dadoIdle.sprite = rollingDice[i];
            await Task.Delay(100);
            }
        }

        randomP1 = Random.Range(1, 21);
        dadoIdle.sprite = allFacesDice[randomP1 - 1];

    }
}
