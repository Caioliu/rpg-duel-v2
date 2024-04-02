using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public Warrior warrior;
    public Wizard wizard;
    public Archer archer;
    public Unit skills;
    public int P1;

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
        P1 = PlayerPrefs.GetInt("ClassP1");
        GearP1(P1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GearP1(int classP1) 
    {
        if (classP1 == 1)
        {
            unitName = warrior.name;
            attack = warrior.attack;
            defence = warrior.defence;
            spirit = warrior.spirit;
            maxHp = warrior.maxHp;
        }
        else if (classP1 == 2)
        {
            unitName = wizard.name;
            attack = wizard.attack;
            defence = wizard.defence;
            spirit = wizard.spirit;
            maxHp = wizard.maxHp;
        } else if (classP1 == 3) 
        {
            unitName = archer.name;
            attack = archer.attack;
            defence = archer.defence;
            spirit = archer.spirit;
            maxHp = archer.maxHp;
        }
        
    }


}
