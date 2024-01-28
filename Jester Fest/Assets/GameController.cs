using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Animator animatorP1;

    public bool Malabarismo = false;
    public bool Toca = false;
    public bool Pena = false;
    public bool Harp = false;
    public bool Hula = false;
    public bool Mask = false;
    public bool Bulha = false;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetMalabarismo()
    {
        return Malabarismo;
    }

    public void SetMalabarismo(bool n)
    {
        Malabarismo = n;
    }

    public bool GetToca()
    {
        return Toca;
    }

    public void SetToca(bool n)
    {
        Toca = n;
    }

    public bool GetPena()
    {
        return Pena;
    }

    public void SetPena(bool n)
    {
        Pena = n;
    }

    public bool GetHarp()
    {
        return Harp;
    }

    public void SetHarp(bool n)
    {
        Harp = n;
    }

    public bool GetHula()
    {
        return Hula;
    }

    public void SetHula(bool n)
    {
        Hula = n;
    }

    public bool GetMask()
    {
        return Mask;
    }

    public void SetMask(bool n)
    {
        Mask = n;
    }

    public bool GetBulha()
    {
        return Bulha;
    }

    public void SetBulha(bool n)
    {
        Bulha = n;
    }

    public void PlayBulhaAnim()
    {
        animatorP1.SetBool("Bulhaa", true);
    }

    public void StopBulhaAnim()
    {
        animatorP1.SetBool("Bulhaa", false);
    }
}
