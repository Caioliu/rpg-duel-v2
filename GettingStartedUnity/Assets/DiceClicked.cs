using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class DiceClicked : MonoBehaviour
{
    public GameObject diceInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void DiceClick()
    {
        diceInfo.SetActive(true);
        await Task.Delay(2000);
        diceInfo.SetActive(false);
    }
}
