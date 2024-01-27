using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool Malabarismo = false;
    public bool Toca = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
