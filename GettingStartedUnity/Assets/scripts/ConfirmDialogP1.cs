using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmDialogP1 : MonoBehaviour
{
    public int round;

    public int button;
    public Color cAttack;
    public Color cDefense;
    public Color cHeal;

    public Text currentManaP1;

    public Text txtP1Log;
    public string whatWasWritten;
    public string whatWasMana;
    public int classP1;

    public Image attackDefenceHealIcon;
    public Sprite attackIcon;
    public Sprite defenceIcon;
    public Sprite healIcon;
    public Text minValue;
    public Text maxValue;
    public Text txtP1Manacost;

    public GameObject skillInfo;
    public GameObject p1Manacost;

    // Start is called before the first frame update
    void Start()
    {
        skillInfo.SetActive(false);
        p1Manacost.SetActive(false);
        classP1 = PlayerPrefs.GetInt("ClassP1");
    }

    public void OnMouseEnter()
    {
        whatWasWritten = txtP1Log.text;
        round = PlayerPrefs.GetInt("Round");

        
        int attack;
        int defence;
        int spirit;

        if (classP1 == 1)
        {
            attack = 40;
            defence = 40;
            spirit = 100;
        }
        else if (classP1 == 2)
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
                switch (classP1)
                {
                    case 1:
                        txtP1Log.text = ("[1] Corte rápido: Ataque leve. ");
                        break;
                    case 2:
                        txtP1Log.text = ("[1] Bola de fogo: Ataque leve.");
                        break;
                    case 3:
                        txtP1Log.text = ("[1] Chuva de flechas: Ataque leve.");
                        break;
                }
                attackDefenceHealIcon.sprite = attackIcon;
                minValue.text = ((attack - 10) * 0.2).ToString();
                minValue.color = cAttack;
                maxValue.text = ((attack + 10) * 0.2).ToString();
                maxValue.color = cAttack;
                txtP1Manacost.text = "2";
                
                break;
            case 2:
                switch (classP1)
                {
                    case 1:
                        txtP1Log.text = ("[2] Fúria berserk: Ataque pesado. ");
                        break;
                    case 2:
                        txtP1Log.text = ("[2] Meteoro: Ataque pesado.");
                        break;
                    case 3:
                        txtP1Log.text = ("[2] Tiro de elite: Ataque pesado.");
                        break;
                }
                attackDefenceHealIcon.sprite = attackIcon;
                minValue.text = ((attack - 10) * 0.4).ToString();
                minValue.color = cAttack;
                maxValue.text = ((attack + 10) * 0.4).ToString();
                maxValue.color = cAttack;
                txtP1Manacost.text = "4";
                
                break;
            case 3:
                switch (classP1)
                {
                    case 1:
                        txtP1Log.text = ("[3] Parede de escudos: Defender.");
                        break;
                    case 2:
                        txtP1Log.text = ("[3] Escudo mágico: Defender.");
                        break;
                    case 3:
                        txtP1Log.text = ("[3] Desviar: Defender.");
                        break;
                }
                attackDefenceHealIcon.sprite = defenceIcon;
                minValue.text = ((defence - 10) / 5).ToString();
                minValue.color = cDefense;
                maxValue.text = ((defence + 10) / 5).ToString();
                maxValue.color = cDefense;
                txtP1Manacost.text = "1";
               

                break;
            case 4:
                switch (classP1)
                {
                    case 1:
                        txtP1Log.text = ("[4] Meditar: Curar. ");
                        break;
                    case 2:
                        txtP1Log.text = ("[4] Regenerar: Curar.");
                        break;
                    case 3:
                        txtP1Log.text = ("[4] Concentrar: Curar.");
                        break;
                }
                attackDefenceHealIcon.sprite = healIcon;
                minValue.text = ((spirit - 20) / 10).ToString();
                minValue.color = cHeal;
                maxValue.text = ((spirit + 20) / 10).ToString();
                maxValue.color = cHeal;
                txtP1Manacost.text = "1";

                break;
            case 5:
                break;
            case 6:
                break;


        }
        skillInfo.SetActive(true);
        p1Manacost.SetActive(true);
    }

    public void OnMouseExit()
    {
        txtP1Log.text = whatWasWritten;
        skillInfo.SetActive(false);
        p1Manacost.SetActive(false);
    }

    public void OnMouseEnterFinishTurn()
    {
        whatWasWritten = txtP1Log.text;
        txtP1Log.text = ("[Tab] Passar a vez. -->");
    }

    public void onMouseEnterFlee()
    {
        whatWasWritten = txtP1Log.text;
        txtP1Log.text = ("[Esc] Fugir da batalha. ~Você perde!!");
    }

}
