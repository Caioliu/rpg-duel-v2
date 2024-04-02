using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInfo : MonoBehaviour
{
    public GameObject panelP1;
    public Text txtAttackP1;
    public Text txtDefenceP1;
    public Text txtSpiritP1;
    public AudioSource lightAttackSound;
    public Button btnConfirm;
    public btnConfirm selecionado;
    public Image imagemAlvo;
    public Sprite novaImagem;
    public int classValue;

    private void Start()
    {
        panelP1.SetActive(true);
    }

    public void TrocarWarrior()
    {
        panelP1.SetActive(true);
        txtAttackP1.text = ("40");
        txtDefenceP1.text = ("40");
        txtSpiritP1.text = ("50");
        lightAttackSound = GetComponent<AudioSource>();
        lightAttackSound.Play();
        imagemAlvo.sprite = novaImagem;
        selecionado.classP1 = 1;
        btnConfirm.interactable = true;
    }

    public void TrocarWizard()
    {
        panelP1.SetActive(true);
        txtAttackP1.text = ("60");
        txtDefenceP1.text = ("20");
        txtSpiritP1.text = ("50");
        lightAttackSound = GetComponent<AudioSource>();
        lightAttackSound.Play();
        imagemAlvo.sprite = novaImagem;
        selecionado.classP1 = 2;
        btnConfirm.interactable = true;
    }

    public void TrocarArcher()
    {
        panelP1.SetActive(true);
        txtAttackP1.text = ("40");
        txtDefenceP1.text = ("20");
        txtSpiritP1.text = ("50");
        lightAttackSound = GetComponent<AudioSource>();
        lightAttackSound.Play();
        imagemAlvo.sprite = novaImagem;
        selecionado.classP1 = 3;
        btnConfirm.interactable = true;
    }
}
