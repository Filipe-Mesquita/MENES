using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalaoController : MonoBehaviour
{
    public List<int> valores;             // List of sprites
    public List<Sprite> sprites;
    public List<int> valoresR;
    public List<SpriteRenderer> renderers;   // List of sprite renderers
    public float timer, time;

    [SerializeField] Slider volumeSlider;

    void Start()
    {
        time = timer;
        // Shuffle the list of sprites
        ShuffleList(valores);

        // Assign sprites to sprite renderers
        for (int i = 0; i < renderers.Count; i++)
        {

            valoresR.Add(valores[i]);

            renderers[i].sprite = sprites[valoresR[i]];
        }
        
    }

    void Update()
    {

        volumeSlider.value = (timer/time);

        timer -= Time.deltaTime;
        if(timer < 0) 
        { 
            ChooseTask();
            timer = time;
        }
    }

    // Function to shuffle a list
    void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public List<int> GetValores()
    {
        return this.valoresR;
    }

    public void ChooseTask()
    {
       
            // Shuffle the list of sprites
            ShuffleList(valores);
            valoresR = new List<int>();
            // Assign sprites to sprite renderers
            for (int i = 0; i < renderers.Count; i++)
            {

                valoresR.Add(valores[i]);

                renderers[i].sprite = sprites[valoresR[i]];
            }
        
    }
}
