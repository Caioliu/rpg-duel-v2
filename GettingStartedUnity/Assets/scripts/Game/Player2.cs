using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Warrior warrior;
    public Wizard wizard;
    public Archer archer;
    public Unit skills;
    public int P2;

    public string unitName;
    public int unitLevel;

    public int attack;
    public int defence;
    public int spirit;
    public int maxHp = 50;
    public int currentHp;
    // Start is called before the first frame update
    void Start()
    {
        unitLevel = 99;
        currentHp = 50;
        P2 = PlayerPrefs.GetInt("ClassP2");
        GearP2(P2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GearP2(int classP2)
    {
        if (classP2 == 1)
        {
            unitName = warrior.name;
            attack = warrior.attack;
            defence = warrior.defence;
            spirit = warrior.spirit;
            maxHp = warrior.maxHp;
        }
        else if (classP2 == 2)
        {
            unitName = wizard.name;
            attack = wizard.attack;
            defence = wizard.defence;
            spirit = wizard.spirit;
            maxHp = wizard.maxHp;
        }
        else if (classP2 == 3)
        {
            unitName = archer.name;
            attack = archer.attack;
            defence = archer.defence;
            spirit = archer.spirit;
            maxHp = archer.maxHp;
        }

    }
}
