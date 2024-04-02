using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmDialog : MonoBehaviour
{
    public int button;
    public Color cAttack;
    public Color cDefense;
    public Color cHeal;

    public int round;
    public int classP2;
    public Text currentManaP2;
    public Text txtP2Log;
    public string whatWasWritten;
    public string whatWasMana;

    public Image attackDefenceHealIcon;
    public Sprite attackIcon;
    public Sprite defenceIcon;
    public Sprite healIcon;
    public Text minValue;
    public Text maxValue;
    public Text txtP2Manacost;

    public GameObject skillInfo;
    public GameObject p2Manacost;

    // Start is called before the first frame update
    void Start()
    {
        skillInfo.SetActive(false);
        p2Manacost.SetActive(false);
        classP2 = PlayerPrefs.GetInt("ClassP2");
    }

    public void OnMouseEnter()
    {
        whatWasWritten = txtP2Log.text;
        round = PlayerPrefs.GetInt("Round");

        
        int attack;
        int defence;
        int spirit;

        if (classP2 == 1)
        {
            attack = 40;
            defence = 40;
            spirit = 100;
        }
        else if (classP2 == 2)
        {
            attack = 60;
            defence = 20;
            spirit = 100;
        }
        else
        {
            if (round <= 2)
            {
                attack = 40;
                defence = 20;
                spirit = 100;
            }
            else if ((round == 3) || (round == 4))
            {
                attack = 45;
                defence = 25;
                spirit = 100;
            }
            else if ((round == 5) || (round == 6))
            {
                attack = 50;
                defence = 30;
                spirit = 100;
            }
            else
            {
                attack = 55;
                defence = 35;
                spirit = 100;
            }

        }

        switch (button)
        {
            case 1:
                switch (classP2)
                {
                    case 1:
                        txtP2Log.text = ("[1] Corte rápido: Ataque leve. ");
                        break;
                    case 2:
                        txtP2Log.text = ("[1] Bola de fogo: Ataque leve.");
                        break;
                    case 3:
                        txtP2Log.text = ("[1] Chuva de flechas: Ataque leve.");
                        break;
                }
            
                attackDefenceHealIcon.sprite = attackIcon;
                minValue.text = ((attack - 10) * 0.2).ToString();
                minValue.color = cAttack;
                maxValue.text = ((attack + 10) * 0.2).ToString();
                maxValue.color = cAttack;
                txtP2Manacost.text = "2";

                


                break;
            case 2:
                switch (classP2)
                {
                    case 1:
                        txtP2Log.text = ("[2] Fúria berserk: Ataque pesado. ");
                        break;
                    case 2:
                        txtP2Log.text = ("[2] Meteoro: Ataque pesado.");
                        break;
                    case 3:
                        txtP2Log.text = ("[2] Tiro de elite: Ataque pesado.");
                        break;
                }
                
                attackDefenceHealIcon.sprite = attackIcon;
                minValue.text = ((attack - 10) * 0.4).ToString();
                minValue.color = cAttack;
                maxValue.text = ((attack + 10) * 0.4).ToString();
                maxValue.color = cAttack;
                txtP2Manacost.text = "4";
                

                break;
            case 3:
                switch (classP2)
                {
                    case 1:
                        txtP2Log.text = ("[3] Parede de escudos: Defender.");
                        break;
                    case 2:
                        txtP2Log.text = ("[3] Escudo mágico: Defender.");
                        break;
                    case 3:
                        txtP2Log.text = ("[3] Desviar: Defender.");
                        break;
                }
                attackDefenceHealIcon.sprite = defenceIcon;
                minValue.text = ((defence - 10) / 5).ToString();
                minValue.color = cDefense;
                maxValue.text = ((defence + 10) / 5).ToString();
                maxValue.color = cDefense;
                txtP2Manacost.text = "1";
                

                break;
            case 4:
                switch (classP2)
                {
                    case 1:
                        txtP2Log.text = ("[4] Meditar: Curar. ");
                        break;
                    case 2:
                        txtP2Log.text = ("[4] Regenerar: Curar.");
                        break;
                    case 3:
                        txtP2Log.text = ("[4] Concentrar: Curar.");
                        break;
                }
                attackDefenceHealIcon.sprite = healIcon;
                minValue.text = ((spirit - 20) / 10).ToString();
                minValue.color = cHeal;
                maxValue.text = ((spirit + 20) / 10).ToString();
                maxValue.color = cHeal;
                txtP2Manacost.text = "1";
                

                break;
            case 5:
                break;
            case 6:
                break;


        }
        skillInfo.SetActive(true);
        p2Manacost.SetActive(true);
    }

    public void OnMouseExit()
    {
        
        txtP2Log.text = whatWasWritten;
        skillInfo.SetActive(false);
        p2Manacost.SetActive(false);
    }

    public void OnMouseEnterFinishTurn()
    {
        whatWasWritten = txtP2Log.text;
        txtP2Log.text = ("[Tab] Passar a vez. <--");
    }

    public void onMouseEnterFlee()
    {
        whatWasWritten = txtP2Log.text;
        txtP2Log.text = ("[Esc] Fugir da batalha. ~Você perde!!");
    }
}
