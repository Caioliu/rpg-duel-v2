using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    public int attack;
    public int defence;
    public int spirit;
    public int maxHp;
    public int currentHp;
    public int maxMana;
    public int currentMana;
    public int damageGiven;
    public int damageTaken;
    public int classP1;
    public int classP2;
    // Start is called before the first frame update
    void Start()
    {
        classP1 = PlayerPrefs.GetInt("ClassP1");
        classP2 = PlayerPrefs.GetInt("ClassP2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int ThrowLightAttack(int attack, int dado)
    {
       

        int damage;

        if (dado <= 4)
        {
            attack -= 10;
        }
        else if (dado >= 17)
        {
            attack += 10;
        }

        damage = Convert.ToInt32(attack * 0.2);
        
        return damage;
    }

    public int ThrowHeavyAttack(int attack, int dado)
    {
        int damage;

        if (dado <= 4)
        {
            attack -= 10;
        }
        else if (dado >= 17)
        {
            attack += 10;
        }

        damage = Convert.ToInt32(attack * 0.4);
        
        return damage;
    }

    public int Defend(int defence, int dado)
    {
        int shield;

        if (dado <= 4)
        {
            defence -= 10;
        }
        else if (dado >= 17)
        {
            defence += 10;
        }

        shield = Convert.ToInt32(defence * 0.2);
        
        return shield;
    }

    public int Heal(int spirit, int dado)
    {
        int healed;

        if (dado <= 4)
        {
            spirit -= 20;
        }
        else if (dado >= 17)
        {
            spirit += 20;
        }

        healed = Convert.ToInt32(spirit * 0.1);
        

        return healed;
    }

    public void ManaRegen()
    {
        currentMana += 3;
    }

    public void receiveDamage(int damage)
    {
        currentHp -= damage;
    }

    public void PassivaP1()
    {
        switch (classP1)
        {
            case 1:
                if (damageGiven == 0)
                {
                    currentHp += 5;
                    if (currentHp > 50)
                    {
                        currentHp = 50;
                    }
                }
                break;
            case 2:
                if (damageTaken == 0)
                {
                    currentMana += 1;
                }
                break;
            case 3:
                if ((attack < 55) && (defence < 35))
                {
                    attack += 5;
                    defence += 5;
                }
                break;
        }
    }

    public void PassivaP2()
    {
        switch (classP2)
        {
            case 1:
                if (damageGiven <= 0)
                {
                    currentHp += 5;
                    if (currentHp > 50)
                    {
                        currentHp = 50;
                    }
                }
                break;
            case 2:
                if (damageTaken <= 0)
                {
                    currentMana += 1;
                }
                break;
            case 3:
                if ((attack < 55) && (defence < 35))
                {
                    attack += 5;
                    defence += 5;
                }
                break;
        }
    }

}
