using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInfoP2 : MonoBehaviour
{
    public GameObject panelP2;
    public Text txtAttackP2;
    public Text txtDefenceP2;
    public Text txtSpiritP2;
    public AudioSource lightAttackSound;
    public Button btnConfirm;
    public btnConfirm selecionado;
    public Image imagemAlvo;
    public Sprite novaImagem;
    public int classValue;

    private void Start()
    {
        panelP2.SetActive(false);
    }

    public void TrocarWarrior()
    {
        panelP2.SetActive(true);
        txtAttackP2.text = ("40");
        txtDefenceP2.text = ("40");
        txtSpiritP2.text = ("50");
        lightAttackSound = GetComponent<AudioSource>();
        lightAttackSound.Play();
        imagemAlvo.sprite = novaImagem;
        selecionado.classP2 = 1;
        btnConfirm.interactable = true;
    }

    public void TrocarWizard()
    {
        panelP2.SetActive(true);
        txtAttackP2.text = ("60");
        txtDefenceP2.text = ("20");
        txtSpiritP2.text = ("50");
        lightAttackSound = GetComponent<AudioSource>();
        lightAttackSound.Play();
        imagemAlvo.sprite = novaImagem;
        selecionado.classP2 = 2;
        btnConfirm.interactable = true;
    }

    public void TrocarArcher()
    {
        panelP2.SetActive(true);
        txtAttackP2.text = ("40");
        txtDefenceP2.text = ("20");
        txtSpiritP2.text = ("50");
        lightAttackSound = GetComponent<AudioSource>();
        lightAttackSound.Play();
        imagemAlvo.sprite = novaImagem;
        selecionado.classP2 = 3;
        btnConfirm.interactable = true;
    }
}
