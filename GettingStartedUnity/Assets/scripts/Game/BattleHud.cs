using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text maxMana;
    public Text currentMana;
    public Text maxHp;
    public Text currentHp;
    public Text damageGiven;
    public Slider hpSlider;

    public void SetHUD(Unit unit)
    {
        damageGiven.text = unit.damageGiven.ToString();
        hpSlider.maxValue = unit.maxHp;
        hpSlider.value = unit.currentHp;
        maxHp.text = unit.maxHp.ToString();
        currentHp.text = unit.currentHp.ToString();
        maxMana.text = unit.maxMana.ToString();
        currentMana.text = unit.currentMana.ToString();
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }
}
