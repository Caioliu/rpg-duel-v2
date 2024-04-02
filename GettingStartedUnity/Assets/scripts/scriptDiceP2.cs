using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class scriptDiceP2 : MonoBehaviour
{
    public rollDado dadoP1;
    public Button[] btnP1;
    public Button[] btnP2;
    public Button btnDadoP1;
    public Button btnDadoP2;
    public Button btnConfirm;
    public Image dadoIdle;
    public Sprite[] rollingDice;
    public Sprite[] allFacesDice;
    public int randomv2;
    private int randomv1;

    // Start is called before the first frame update
    void Start()
    {
        dadoIdle = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void rollDice()
    {
        btnDadoP2.interactable = false;
        //play gif
        for (int cont = 0; cont <= 1; cont++)
        {
            for (int i = 0; i <= 5; i++)
            {
                dadoIdle.sprite = rollingDice[i];
                await Task.Delay(100);
            }
        }
        //random number 1-20
        randomv1 = dadoP1.randomP1;
        randomv2 = Random.Range(1, 21);
        dadoIdle.sprite = allFacesDice[randomv2 - 1];
      
        
        detectWinner();
    }

    public void detectWinner()
    {
        
        if (randomv1 > randomv2)
        {
            btnP1[0].interactable = true;
            btnP1[1].interactable = true;
            btnP1[2].interactable = true;
        }
        else if (randomv1 < randomv2)
        {
            btnP2[0].interactable = true;
            btnP2[1].interactable = true;
            btnP2[2].interactable = true;
        } 
        else
        {
            btnDadoP1.interactable = true;
            btnDadoP2.interactable = false;
        }
    }
}
