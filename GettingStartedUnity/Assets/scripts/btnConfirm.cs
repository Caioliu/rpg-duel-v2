using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;


public class btnConfirm : MonoBehaviour
{
    public GameObject panelStatsP1;
    public GameObject panelStatsP2;
    public AudioSource finishTurn;
    public Button confirm;
    public AudioSource fightSound;
    public string Game;
    public Image escolher;
    public Sprite lutar;
    public Button[] btnP1;
    public Button[] btnP2;
    public int classP1;
    public int classP2;
    // Start is called before the first frame update
    void Start()
    {
        confirm = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void LockOn()
    {
        if ((classP1 == 0) || (classP2 == 0)) 
        { 
            if (btnP1[0].interactable == false)
            {
                panelStatsP2.SetActive(false);
                finishTurn.Play();
                btnP1[0].interactable = true;
                btnP1[1].interactable = true;
                btnP1[2].interactable = true;
                escolher.sprite = lutar;
                btnP2[0].interactable = false;
                btnP2[1].interactable = false;
                btnP2[2].interactable = false;
            }
            else if (btnP2[0].interactable == false)
            {
                panelStatsP1.SetActive(false);
                finishTurn.Play();
                btnP1[0].interactable = false;
                btnP1[1].interactable = false;
                btnP1[2].interactable = false;
                escolher.sprite = lutar;
                btnP2[0].interactable = true;
                btnP2[1].interactable = true;
                btnP2[2].interactable = true;
            }
        }
        else
        {
            confirm.interactable = false;
            fightSound.Play();
            await Task.Delay(2200);
            PlayerPrefs.SetInt("ClassP1", classP1);
            PlayerPrefs.SetInt("ClassP2", classP2);
            SceneManager.LoadScene(Game);
        }

    }
}
