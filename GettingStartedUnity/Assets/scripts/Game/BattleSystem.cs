 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public enum BattleState { START, P1TURN, P2TURN, P1WIN, P2WIN }

public class BattleSystem : MonoBehaviour
{
    public float blinkInterval = 0.5f;
    public Text textComponentP1;
    public Text textComponentP2;
    private bool isTextVisible = true;

    private int endgame;
    public int randomP1;
    public int randomP2;
    public int round;

    public Animator animationsP1;
    public Animator animationsP2;

    public Animator p1PopUp;
    public Animator p2PopUp;

    public Image[] playerCam;
    public Sprite[] imgP1;
    public Sprite[] imgP2;

    public AudioSource diceRoll;
    public Button[] btnP1;
    public Button[] btnP2;
    public Image imgDadoP1;
    public Image imgDadoP2;
    public Sprite[] allFacesDice;
    public Sprite[] rollingDice;

    public GameObject[] p1Prefab;
    public GameObject[] p2Prefab;

    public GameObject panelP1Wins;
    public GameObject panelP2Wins;

    public GameObject p1Log;
    public GameObject p2Log;
    public Text txtP1Log;
    public Text txtP2Log;  

    public Transform p1BattleStation;
    public Transform p2BattleStation;

    public int classP1;
    public int classP2;

    Unit p1Unit;
    Unit p2Unit;

    public BattleHUD player1HUD;
    public BattleHUD player2HUD;

    public Button btnSong;
    public Button btnHealP1;
    public Button btnHealP2;

    public AudioSource seLightAttackWarrior;
    public AudioSource seLightAttackWizard;
    public AudioSource seLightAttackArcher;
    public AudioSource seHeavyAttackWarrior;
    public AudioSource seHeavyAttackWizard;
    public AudioSource seHeavyAttackArcher;
    public AudioSource seDefend;
    public AudioSource seHeal;
    public AudioSource seReceiveDmg;
    public AudioSource seWinDice;
    public AudioSource seLoseDice;
    public AudioSource seFinishTurn;
    public AudioSource seAcessDenied;
    public AudioSource currentSong;
    public AudioSource songEndBattle;
    

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        classP1 = PlayerPrefs.GetInt("ClassP1");
        classP2 = PlayerPrefs.GetInt("ClassP2");
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            OnLightAttackButton();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            OnHeavyAttackButton();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            OnDefendButton();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            OnHealButton();
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            OnFinishButton();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnFleeButton();
        }

        if (endgame == 1)
        {
            nextScene();
        }
    }

    public async void RollDiceP1()
    {
        diceRoll.Play();
        randomP1 = Random.Range(1, 21);

        for (int cont = 0; cont <= 1; cont++)
        {
            for (int i = 0; i <= 5; i++)
            {
                imgDadoP1.sprite = rollingDice[i];
                await Task.Delay(100);
            }
        }
        
        
        imgDadoP1.sprite = allFacesDice[randomP1 - 1];
        if (randomP1 < 5)
        {
            seLoseDice.Play();
        }
        else if (randomP1 > 16)
        {
            seWinDice.Play();
        }

    }

    public async void RollDiceP2()
    {
        diceRoll.Play();
        randomP2 = Random.Range(1, 21);
        for (int cont = 0; cont <= 1; cont++)
        {
            for (int i = 0; i <= 5; i++)
            {
                imgDadoP2.sprite = rollingDice[i];
                await Task.Delay(100);
            }
        }
        
        
        imgDadoP2.sprite = allFacesDice[randomP2 - 1];

        if (randomP2 < 5)
        {
            seLoseDice.Play();
        }
        else if (randomP2 > 16)
        {
            seWinDice.Play();
        }

    }
    

    IEnumerator SetupBattle()
    {
        GameObject player1GO = new GameObject();
        GameObject player2GO = new GameObject();
        switch (classP1)
        {
            case 1:
                playerCam[0].sprite = imgP1[0];
                player1GO = Instantiate(p1Prefab[0], p1BattleStation);
                break;
            case 2:
                playerCam[0].sprite = imgP1[1];
                player1GO = Instantiate(p1Prefab[1], p1BattleStation);
                break;
            case 3:
                playerCam[0].sprite = imgP1[2];
                player1GO = Instantiate(p1Prefab[2], p1BattleStation);
                break;
        }

        switch (classP2)
        {
            case 1:
                playerCam[1].sprite = imgP2[0];
                player2GO = Instantiate(p2Prefab[0], p2BattleStation);
                break;
            case 2:
                playerCam[1].sprite = imgP2[1];
                player2GO = Instantiate(p2Prefab[1], p2BattleStation);
                break;
            case 3:
                playerCam[1].sprite = imgP2[2];
                player2GO = Instantiate(p2Prefab[2], p2BattleStation);
                break;
        }
        p1Unit = player1GO.GetComponent<Unit>();
        p2Unit = player2GO.GetComponent<Unit>();
       
        animationsP1 = player1GO.GetComponent<Animator>();
        animationsP2 = player2GO.GetComponent<Animator>();


        //aqui você pode colocar alguma mensagem que aparece ao começar o game.

        player1HUD.SetHUD(p1Unit);
        player2HUD.SetHUD(p2Unit);


        int loop = 0;
        while (loop == 0) {

            RollDiceP1();
            RollDiceP2();
            yield return new WaitForSeconds(2f);

            if (randomP1 > randomP2)
            {
                txtP1Log.text = ("O player 1 começa jogando.");
                
                Player1Turn();
                loop = 1;
            }
            else if (randomP1 < randomP2)
            {
                txtP2Log.text = ("O player 2 começa jogando.");
                
                Player2Turn();
                loop = 1;
            }
            else
            {
            loop = 0;
            }
        }


    }

    void Player1Turn()
    {
        round += 1;
        randomP1 = 0;
        
        p1Log.SetActive(true); 
        p2Log.SetActive(false);
        state = BattleState.P1TURN;
        p1Unit.damageGiven = 0;

        if (round > 1)
        {
            txtP1Log.text = ("Turno do Player 1.");
        }

        if (p2Unit.damageGiven > 0)
        {
            p1Unit.damageTaken = p2Unit.damageGiven;
            txtP1Log.text = ("O player 1 está recebendo " + p1Unit.damageTaken + " de dano.");
        }

        if (round > 2)
        {
            Passiva();
            PlayerPrefs.SetInt("Round", round);
            p1Unit.ManaRegen();
            p1Unit.maxMana = p1Unit.currentMana;
            player1HUD.SetHUD(p1Unit);
        }

        for (int i = 0; i <= 5; i++)
        {
            btnP1[i].interactable = true;
            btnP2[i].interactable = false;
        }

    }

    void Player2Turn()
    {
        round += 1;
        randomP2 = 0;
        
        p2Log.SetActive(true);
        p1Log.SetActive(false);
        PlayerPrefs.SetInt("Round", round);
        state = BattleState.P2TURN;
        p2Unit.damageGiven = 0;

        if (round > 1)
        {
            txtP2Log.text = ("Turno do Player 2.");
        }

        if (p1Unit.damageGiven > 0)
        {
            p2Unit.damageTaken = p1Unit.damageGiven;
            txtP2Log.text = ("O player 2 está recebendo " + p2Unit.damageTaken + " de dano.");
        }

        if (round > 2)
        {
            Passiva();
            p2Unit.ManaRegen();
            p2Unit.maxMana = p2Unit.currentMana;
            player2HUD.SetHUD(p2Unit);
        }

        for (int i = 0; i <= 5; i++)
        {
            btnP2[i].interactable = true;
            btnP1[i].interactable = false;
        }

    }

    public async void OnLightAttackButton()
    {
        int hit;

        if (state == BattleState.P1TURN)
        {
            if (p1Unit.currentMana >= 2)
            {

                RollDiceP1();
                p1Unit.currentMana -= 2;
                p1Unit.damageGiven += p1Unit.ThrowLightAttack(p1Unit.attack, randomP1);
                player1HUD.SetHUD(p1Unit);
                hit = p1Unit.ThrowLightAttack(p1Unit.attack, randomP1);
                
                await Task.Delay(1200);
                if (randomP1 <= 4)
                {
                    p1PopUp.SetInteger("DebuffAttack", 1);
                }
                else if (randomP1 >= 17)
                {
                    p1PopUp.SetInteger("BuffAttack", 1);
                }
                txtP1Log.text = ("O player 1 causou " + hit + " de dano.");
                animationsP1.SetInteger("lightAttack", 1);
                
                switch (classP1)
                {
                    case 1:
                        seLightAttackWarrior.Play();
                        break;
                    case 2:
                        seLightAttackWizard.Play();
                        break;
                    case 3:
                        seLightAttackArcher.Play();
                        break;

                }
                await Task.Delay(1000);
                p1PopUp.SetInteger("DebuffAttack", 0);
                p1PopUp.SetInteger("BuffAttack", 0);                
                animationsP1.SetInteger("lightAttack", 0);
            }
            else
            {
                seAcessDenied.Play();
            }


        }
        else if (state == BattleState.P2TURN)
        {
            if (p2Unit.currentMana >= 2)
            {
                RollDiceP2();
                p2Unit.currentMana -= 2;
                p2Unit.damageGiven += p2Unit.ThrowLightAttack(p2Unit.attack, randomP2);
                player2HUD.SetHUD(p2Unit);
                hit = p2Unit.ThrowLightAttack(p2Unit.attack, randomP2);
                
                await Task.Delay(1200);
                if (randomP2 <= 4)
                {
                    p2PopUp.SetInteger("DebuffAttack", 1);
                }
                else if (randomP2 >= 17)
                {
                    p2PopUp.SetInteger("BuffAttack", 1);
                }
                txtP2Log.text = ("O player 2 causou " + hit + " de dano.");
                animationsP2.SetInteger("lightAttack", 1);
                switch (classP2)
                {
                    case 1:
                        seLightAttackWarrior.Play();
                        break;
                    case 2:
                        seLightAttackWizard.Play();
                        break;
                    case 3:
                        seLightAttackArcher.Play();
                        break;

                }
                await Task.Delay(1000);
                p2PopUp.SetInteger("DebuffAttack", 0);
                p2PopUp.SetInteger("BuffAttack", 0);
                animationsP2.SetInteger("lightAttack", 0);
            }
            else
            {
                seAcessDenied.Play();
            }
        }
    }

    public async void OnHeavyAttackButton()
    {
        int hit;

        if (state == BattleState.P1TURN)
        {
            if (p1Unit.currentMana >= 4)
            {
                RollDiceP1();
                p1Unit.currentMana -= 4;
                p1Unit.damageGiven += p1Unit.ThrowHeavyAttack(p1Unit.attack, randomP1);
                player1HUD.SetHUD(p1Unit);
                hit = p1Unit.ThrowHeavyAttack(p1Unit.attack, randomP1);
                
                await Task.Delay(1200);
                if (randomP1 <= 4)
                {
                    p1PopUp.SetInteger("DebuffAttack", 1);
                }
                else if (randomP1 >= 17)
                {
                    p1PopUp.SetInteger("BuffAttack", 1);
                }
                txtP1Log.text = ("O player 1 causou " + hit + " de dano.");
                animationsP1.SetInteger("heavyAttack", 1);
                switch (classP1)
                {
                    case 1:
                        seHeavyAttackWarrior.Play();
                        break;
                    case 2:
                        seHeavyAttackWizard.Play();
                        break;
                    case 3:
                        seHeavyAttackArcher.Play();
                        break;

                }

                await Task.Delay(2500);
                p1PopUp.SetInteger("DebuffAttack", 0);
                p1PopUp.SetInteger("BuffAttack", 0);
                animationsP1.SetInteger("heavyAttack", 0);
            }
            else
            {
                seAcessDenied.Play();
            }
        }
            else if (state == BattleState.P2TURN)
        {
            if (p2Unit.currentMana >= 4)
            {
                RollDiceP2();
                p2Unit.currentMana -= 4;
                p2Unit.damageGiven += p2Unit.ThrowHeavyAttack(p2Unit.attack, randomP2);
                player2HUD.SetHUD(p2Unit);
                hit = p2Unit.ThrowHeavyAttack(p2Unit.attack, randomP2);
                
                await Task.Delay(1200);
                if (randomP2 <= 4)
                {
                    p2PopUp.SetInteger("DebuffAttack", 1);
                }
                else if (randomP2 >= 17)
                {
                    p2PopUp.SetInteger("BuffAttack", 1);
                }
                txtP2Log.text = ("O player 2 causou " + hit + " de dano.");
                animationsP2.SetInteger("heavyAttack", 1);
                switch (classP2)
                {
                    case 1:
                        seHeavyAttackWarrior.Play();
                        break;
                    case 2:
                        seHeavyAttackWizard.Play();
                        break;
                    case 3:
                        seHeavyAttackArcher.Play();
                        break;

                }
                await Task.Delay(2500);
                p2PopUp.SetInteger("DebuffAttack", 0);
                p2PopUp.SetInteger("BuffAttack", 0);
                
                animationsP2.SetInteger("heavyAttack", 0);
            }
            else
            {
                seAcessDenied.Play();
            }
        }
    }

    public async void OnDefendButton()
    {
        int block;

        if (state == BattleState.P1TURN)
        {
            if ((p1Unit.currentMana >= 1) && (p1Unit.damageTaken >= 1))
            {
                RollDiceP1();
                p1Unit.currentMana -= 1;
                p1Unit.damageTaken -= p1Unit.Defend(p1Unit.defence, randomP1);
                p2Unit.damageGiven -= p1Unit.Defend(p1Unit.defence, randomP1);
                if (p1Unit.damageTaken < 0)
                {
                    p1Unit.damageTaken = 0;

                }
                if (p2Unit.damageGiven < 0)
                {
                    p2Unit.damageGiven = 0;
                }
                player1HUD.SetHUD(p1Unit);
                player2HUD.SetHUD(p2Unit);
                block = p1Unit.Defend(p1Unit.defence, randomP1);
                
                
                await Task.Delay(1200);
                if (randomP1 <= 4)
                {
                    p1PopUp.SetInteger("DebuffDefence", 1);
                }
                else if (randomP1 >= 17)
                {
                    p1PopUp.SetInteger("BuffDefence", 1);
                }
                txtP1Log.text = ("O player 1 bloqueou " + block + " de dano.");
                seDefend.Play();
                await Task.Delay(1200);
                p1PopUp.SetInteger("DebuffDefence", 0);
                p1PopUp.SetInteger("BuffDefence", 0);


                

            }
            else
            {
                seAcessDenied.Play();
            }
        }
        else if (state == BattleState.P2TURN)
        {
            if ((p2Unit.currentMana >= 1) && (p2Unit.damageTaken >= 1))
            {
                RollDiceP2();
                p2Unit.currentMana -= 1;
                p2Unit.damageTaken -= p2Unit.Defend(p2Unit.defence, randomP2);
                p1Unit.damageGiven -= p2Unit.Defend(p2Unit.defence, randomP2);
                if (p2Unit.damageTaken < 0)
                {
                    p2Unit.damageTaken = 0;
                }
                if (p1Unit.damageGiven < 0)
                {
                    p1Unit.damageGiven = 0;
                }
                player1HUD.SetHUD(p1Unit);
                player2HUD.SetHUD(p2Unit);
                block = p2Unit.Defend(p2Unit.defence, randomP2);
                
                
                await Task.Delay(1200);
                if (randomP2 <= 4)
                {
                    p2PopUp.SetInteger("DebuffDefence", 1);
                }
                else if (randomP2 >= 17)
                {
                    p2PopUp.SetInteger("BuffDefence", 1);
                }
                txtP2Log.text = ("O player 2 bloqueou " + block + " de dano.");

                seDefend.Play();
                await Task.Delay(1200);
                p2PopUp.SetInteger("DebuffDefence", 0);
                p2PopUp.SetInteger("BuffDefence", 0);

                
            }
            else
            {
                seAcessDenied.Play();
            }
        }
    }

    public async void OnHealButton()
    {
        int healed;

        if (state == BattleState.P1TURN)
        {
            if ((p1Unit.currentMana >= 1) && p1Unit.currentHp < 50)
            {
                RollDiceP1();
                btnHealP1.interactable = false;
                p1Unit.currentMana -= 1;
                p1Unit.currentHp += p1Unit.Heal(p1Unit.spirit, randomP1);
                if (p1Unit.currentHp > 50)
                {
                    p1Unit.currentHp = 50;
                }
                player1HUD.SetHUD(p1Unit);
                healed = p1Unit.Heal(p1Unit.spirit, randomP1);
                
                

                await Task.Delay(1200);
                if (randomP1 <= 4)
                {
                    p1PopUp.SetInteger("DebuffSpirit", 1);
                }
                else if (randomP1 >= 17)
                {
                    p1PopUp.SetInteger("BuffSpirit", 1);
                }
                txtP1Log.text = ("O player 1 se regenerou em " + healed + " de vida.");
                seHeal.Play();
                await Task.Delay(1200);

                p1PopUp.SetInteger("DebuffSpirit", 0);
                p1PopUp.SetInteger("BuffSpirit", 0);
            }
            else
            {
                seAcessDenied.Play();
            }
        }
        else if (state == BattleState.P2TURN)
        {
            if ((p2Unit.currentMana >= 1) && p2Unit.currentHp < 50)
            {
                RollDiceP2();
                btnHealP2.interactable = false;
                p2Unit.currentMana -= 1;
                p2Unit.currentHp += p2Unit.Heal(p2Unit.spirit, randomP2);
                if (p2Unit.currentHp > 50)
                {
                    p2Unit.currentHp = 50;
                }
                player2HUD.SetHUD(p2Unit);

                healed = p2Unit.Heal(p2Unit.spirit, randomP2);
                
                
                await Task.Delay(1200);
                if (randomP2 <= 4)
                {
                    p2PopUp.SetInteger("DebuffSpirit", 1);
                }
                else if (randomP2 >= 17)
                {
                    p2PopUp.SetInteger("BuffSpirit", 1);
                }
                txtP2Log.text = ("O player 2 se regenerou em " + healed + " de vida.");
                seHeal.Play();
                await Task.Delay(1200);
                p2PopUp.SetInteger("DebuffSpirit", 0);
                p2PopUp.SetInteger("BuffSpirit", 0);

            }
            else
            {
                seAcessDenied.Play();
            }
        }
    }

    public void OnFleeButton()
    {
        if (state == BattleState.P1TURN)
        {
            
            txtP1Log.text = ("O player 1 foge da batalha...");
            Player2Win();
        }
        else if (state == BattleState.P2TURN)
        {
            
            txtP2Log.text = ("O player 2 foge da batalha...");
            Player1Win();
        }
    }

    public async void OnFinishButton()
    {
        if (state == BattleState.P1TURN)
        {
            if (p1Unit.damageTaken > 0)
            {
                txtP1Log.text = ("O player 1 recebe " + p1Unit.damageTaken + " de dano.");
                seReceiveDmg.Play();
                p1Unit.receiveDamage(p1Unit.damageTaken);
                p1Unit.damageTaken = 0;
                player1HUD.SetHUD(p1Unit);
                animationsP1.SetInteger("receiveDmg", 1);
                await Task.Delay(1200);
                animationsP1.SetInteger("receiveDmg", 0);
            }

            seFinishTurn.Play();

            if (p1Unit.currentHp > 0)
            {
                Player2Turn();
            }
            else
            {
                p1Unit.currentHp = 0;
                Player2Win();
            }

        }
        else if (state == BattleState.P2TURN)
        {
            if (p2Unit.damageTaken > 0)
            {
                txtP2Log.text = ("O player 2 recebe " + p2Unit.damageTaken + " de dano.");
                seReceiveDmg.Play();
                p2Unit.receiveDamage(p2Unit.damageTaken);
                p2Unit.damageTaken = 0;
                player2HUD.SetHUD(p2Unit);
                animationsP2.SetInteger("receiveDmg", 1);
                await Task.Delay(1200);
                animationsP2.SetInteger("receiveDmg", 0);
            }

            seFinishTurn.Play();

            if (p2Unit.currentHp > 0)
            {
                Player1Turn();
            }
            else
            {
                p2Unit.currentHp = 0;
                Player1Win();
            }
        }
    }

    void Passiva()
    {
        if (state == BattleState.P1TURN)
        {
                switch (classP1)
                {
                    case 1:
                        if (p1Unit.currentHp < p2Unit.currentHp)
                        {
                        txtP1Log.text = ("[Passiva] O Guerreiro escuta os tambores da batalha...");
                        
                        p1Unit.currentHp += 5;
                            if (p1Unit.currentHp > 50)
                            {
                                p1Unit.currentHp = 50;
                                player1HUD.SetHUD(p1Unit);
                            } 
                        }
                    break;
                    case 2:
                        if (p1Unit.damageTaken == 0)
                        {
                        txtP1Log.text = ("[Passiva] O Mago escuta a voz de seus ancestrais...");
                        
                        p1Unit.currentMana += 1;
                        player1HUD.SetHUD(p1Unit);
                    }
                    break;
                    case 3:
                    
                    if ((p1Unit.attack < 55) && (p1Unit.defence < 35)) 
                        {
                        txtP1Log.text = ("[Passiva] O Arqueiro rastreia a fraqueza de seus inimigos...");
                        
                        p1Unit.attack += 5;
                        p1Unit.defence += 5;
                    }
                    break;
                }
        }
        else if (state == BattleState.P2TURN)
        {
            switch (classP2)
            {
                case 1:
                    if (p2Unit.currentHp < p1Unit.currentHp)
                    {
                        txtP2Log.text = ("[Passiva] O Guerreiro escuta os tambores da batalha...");
                       
                        p2Unit.currentHp += 5;
                        if (p2Unit.currentHp > 50)
                        {
                            p2Unit.currentHp = 50;
                            player2HUD.SetHUD(p2Unit);
                        }
                    }
                    break;
                case 2:
                    if (p2Unit.damageTaken == 0)
                    {
                        txtP2Log.text = ("[Passiva] O Mago escuta a voz de seus ancestrais...");
                        
                        p2Unit.currentMana += 1;
                        player2HUD.SetHUD(p2Unit);
                    }
                    break;
                case 3:
                    if ((p2Unit.attack < 55) && (p2Unit.defence < 35))
                    {
                        txtP2Log.text = ("[Passiva] O Arqueiro rastreia a fraqueza de seus inimigos...");
                        
                        p2Unit.attack += 5;
                        p2Unit.defence += 5;
                    }
                    break;
            }
        }
    }

    private IEnumerator BlinkTextP1()
    {
        while (true)
        {
            // Inverter a visibilidade do texto (ligado/desligado)
            textComponentP1.enabled = isTextVisible;
            isTextVisible = !isTextVisible;

            // Esperar o intervalo de tempo definido
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    private IEnumerator BlinkTextP2()
    {
        while (true)
        {
            // Inverter a visibilidade do texto (ligado/desligado)
            textComponentP2.enabled = isTextVisible;
            isTextVisible = !isTextVisible;

            // Esperar o intervalo de tempo definido
            yield return new WaitForSeconds(blinkInterval);
        }
    }


    void Player1Win()
    {
        player2HUD.SetHUD(p2Unit);
        panelP1Wins.SetActive(true);
        StartCoroutine(BlinkTextP1());
        p2Log.SetActive(false);
        
        

        btnSong.interactable = false;
        
        
        currentSong.Stop();
        songEndBattle.Play();
        animationsP1.SetInteger("win", 1);
        animationsP2.SetInteger("die", 1);
        state = BattleState.P1WIN;
        for (int i = 0; i <= 5; i++)
        {
            btnP1[i].interactable = false;
            btnP2[i].interactable = false;
        }
        endgame = 1;
    }

    void Player2Win()
    {
        player1HUD.SetHUD(p1Unit);
        panelP2Wins.SetActive(true);
        StartCoroutine(BlinkTextP2());
        p1Log.SetActive(false);
        
        

        
        btnSong.interactable = false;
        currentSong.Stop();
        songEndBattle.Play();
        animationsP2.SetInteger("win", 1);
        animationsP1.SetInteger("die", 1);
        state = BattleState.P2WIN;
        for (int i = 0; i <= 5; i++)
        {
            btnP1[i].interactable = false;
            btnP2[i].interactable = false;
        }
        endgame = 1;
    }

    void nextScene()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("FinishScreen");
        }
    }
}
