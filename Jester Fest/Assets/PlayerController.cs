using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Adjust this to control the player's movement speed

    public KeyCode upKey = KeyCode.W;     // Configure the keys for movement
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode interactKey = KeyCode.E;

    public float pontoAdd;
    public float pontoRem;

    public PointSliderController pointsSlider;


    private Animator animator;
    private bool Malaba;
    private bool Trumpa;
    private bool Harpa;
    private bool HulaH;
    private bool Maska;
    private bool Bulhaa;
    private bool Macaca;
    private bool animation;


    private Sprite vazio = null;

    public Sprite Bolas;
    private bool insideBolas = false;
    private bool BolasAgarradas;

    public Sprite Trumpeta;
    private bool insideTrumpa = false;
    private bool TrumpAgarr;

    public Sprite Pena;
    private bool insidePena = false;
    private bool PenaApanha;

    public Sprite Harp;
    private bool insideHarp = false;
    private bool HarpApanha;

    public Sprite Hula;
    private bool insideHula = false;
    private bool HulaApanha;

    public Sprite Mask;
    private bool insideMask = false;
    private bool MaskApanha;

    
    private bool insideBulha = false;
    private bool BulhaApanha;

    public Sprite Macac;
    private bool insideMacac = false;
    private bool MacacApanha;

    private SpriteRenderer spriteRenderer;
    public SpriteRenderer rendererBolas;
    public SpriteRenderer rendererTrumpa;
    public SpriteRenderer rendererPena;
    public SpriteRenderer rendererHarp;
    public SpriteRenderer rendererHula;
    public SpriteRenderer rendererMask;
    public SpriteRenderer rendererPlayer2;
    public SpriteRenderer rendererMacac;


    public GameObject interactObject;

    public float timeAct = 5.0f;
    private float time;

    public GameController Controller;
    public BalaoController BController;



    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        time = timeAct;

    }

    void Update()
    {


        if (Input.GetKeyDown(interactKey) && insideBolas && !Controller.GetMalabarismo())
        {


            BolasAgarradas = true;

            if (BController.GetValores().Contains(0))
            {
                pointsSlider.AddPoints(pontoAdd);
            }
            else
            {
                pointsSlider.AddPoints(pontoRem);
            }

        }

        if (BolasAgarradas)
        {
            

            if (time > 0f)
            {

                time -= Time.deltaTime;
                Controller.SetMalabarismo(true);
                rendererBolas.sprite = vazio;
                animator.SetBool("Malaba", true);
                animation = true;

                

            }


            else if (time < 0f)
            {
                Controller.SetMalabarismo(false);
                animator.SetBool("Malaba", false);

                

                rendererBolas.sprite = Bolas;
                BolasAgarradas = false;
                time = timeAct;
                animation = false;

            }
        }


        if (Input.GetKeyDown(interactKey) && insideTrumpa && !Controller.GetToca())
        {


            TrumpAgarr = true;

            if (BController.GetValores().Contains(1))
            {
                pointsSlider.AddPoints(pontoAdd);
            }
            else
            {
                pointsSlider.AddPoints(pontoRem);
            }

        }
        if (TrumpAgarr)
        {
            

            if (time > 0f)
            {

                time -= Time.deltaTime;
                Controller.SetToca(true);
                rendererTrumpa.sprite = vazio;
                animator.SetBool("Toca", true);
                animation = true;

                

            }


            else if (time < 0f)
            {
                Controller.SetToca(false);
                animator.SetBool("Toca", false);

                

                rendererTrumpa.sprite = Trumpeta;
                TrumpAgarr = false;
                time = timeAct;
                animation = false;

            }
        }

        if (Input.GetKeyDown(interactKey) && insidePena && !Controller.GetPena())
        {


            PenaApanha = true;

            if (BController.GetValores().Contains(2))
            {
                pointsSlider.AddPoints(pontoAdd);
            }
            else
            {
                pointsSlider.AddPoints(pontoRem);
            }

        }

        if (PenaApanha)
        {
            

            if (time > 0f)
            {

                time -= Time.deltaTime;
                Controller.SetPena(true);
                rendererPena.sprite = vazio;
                animator.SetBool("Pena", true);
                animation = true;

                

            }


            else if (time < 0f)
            {
                Controller.SetPena(false);
                animator.SetBool("Pena", false);

                

                rendererPena.sprite = Pena;
                PenaApanha = false;
                time = timeAct;
                animation = false;

            }

        }

        if (Input.GetKeyDown(interactKey) && insideHarp && !Controller.GetHarp())
        {


            HarpApanha = true;

            if (BController.GetValores().Contains(3))
            {
                pointsSlider.AddPoints(pontoAdd);
            }
            else
            {
                pointsSlider.AddPoints(pontoRem);
            }

        }

        if (HarpApanha)
        {
            

            if (time > 0f)
            {

                time -= Time.deltaTime;
                Controller.SetHarp(true);
                rendererHarp.sprite = vazio;
                animator.SetBool("Harpa", true);
                animation = true;

                

            }


            else if (time < 0f)
            {
                Controller.SetHarp(false);
                animator.SetBool("Harpa", false);

                

                rendererHarp.sprite = Harp;
                HarpApanha = false;
                time = timeAct;
                animation = false;

            }
        }

        if (Input.GetKeyDown(interactKey) && insideHula && !Controller.GetHula())
        {


            HulaApanha = true;

            if (BController.GetValores().Contains(4))
            {
                pointsSlider.AddPoints(pontoAdd);
            }
            else
            {
                pointsSlider.AddPoints(pontoRem);
            }

        }

        if (HulaApanha)
        {

            

            if (time > 0f)
            {

                time -= Time.deltaTime;
                Controller.SetHula(true);
                rendererHula.sprite = vazio;
                animator.SetBool("HulaH", true);
                animation = true;

                

            }


            else if (time < 0f)
            {
                Controller.SetHula(false);
                animator.SetBool("HulaH", false);

                

                rendererHula.sprite = Hula;
                HulaApanha = false;
                time = timeAct;
                animation = false;

            }
        }

        if (Input.GetKeyDown(interactKey) && insideMask && !Controller.GetMask())
        {


            MaskApanha = true;

            if (BController.GetValores().Contains(5))
            {
                pointsSlider.AddPoints(pontoAdd);
            }
            else
            {
                pointsSlider.AddPoints(pontoRem);
            }

        }

        if (MaskApanha)
        {
            

            if (time > 0f)
            {

                time -= Time.deltaTime;
                Controller.SetMask(true);
                rendererMask.sprite = vazio;
                animator.SetBool("Maska", true);
                animation = true;

                

            }


            else if (time < 0f)
            {
                Controller.SetMask(false);
                animator.SetBool("Maska", false);

                

                rendererMask.sprite = Mask;
                MaskApanha = false;
                time = timeAct;
                animation = false;

            }
        }

        if (Input.GetKeyDown(interactKey) && insideBulha && !Controller.GetBulha() && !Controller.GetMalabarismo() && !Controller.GetToca() && !Controller.GetPena() && !Controller.GetHarp() && !Controller.GetMask() && !Controller.GetMacac() && !Controller.GetHula())
        {


            BulhaApanha = true;

            StartCoroutine("delay");

            if (BController.GetValores().Contains(6))
            {
                pointsSlider.AddPoints(pontoAdd * 2f);
            }
            else
            {
                pointsSlider.AddPoints(pontoRem);
            }
        }

        if (BulhaApanha)
        {

            

            if (time > 0f)
            {
                time -= Time.deltaTime;
                Controller.SetBulha(true);
                rendererPlayer2.enabled = false;
                Controller.PlayBulhaAnim();
                animation = true;

                


            }


            else if (time < 0f)
            {
                
                Controller.StopBulhaAnim();
                

                

                
                BulhaApanha = false;
                time = timeAct;
                animation = false;

            }
        }

        if (Input.GetKeyDown(interactKey) && insideMacac && !Controller.GetMacac())
        {


            MacacApanha = true;

            if (BController.GetValores().Contains(7))
            {
                pointsSlider.AddPoints(pontoAdd);
            }
            else
            {
                pointsSlider.AddPoints(pontoRem);
            }

        }

        if (MacacApanha)
        {

            

            if (time > 0f)
            {

                time -= Time.deltaTime;
                Controller.SetMacac(true);
                rendererMacac.sprite = vazio;
                animator.SetBool("Macaca", true);
                animation = true;

                

            }


            else if (time < 0f)
            {
                Controller.SetMacac(false);
                animator.SetBool("Macaca", false);

                

                rendererMacac.sprite = Macac;
                MacacApanha = false;
                time = timeAct;
                animation = false;

            }
        }



        // Get input values for movement
        float horizontalInput = 0f;
            float verticalInput = 0f;
            if (!animation && Controller.GetBulha() == false)
            {

                if (Input.GetKey(leftKey))
                    horizontalInput -= 1f;
                if (Input.GetKey(rightKey))
                    horizontalInput += 1f;
                if (Input.GetKey(downKey))
                    verticalInput -= 1f;
                if (Input.GetKey(upKey))
                    verticalInput += 1f;
            }

            // Calculate movement direction
            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized * moveSpeed * Time.deltaTime;

            // Update position
            transform.Translate(movement);

            // Update Animator parameters
            animator.SetFloat("Horizontal", horizontalInput);
            animator.SetFloat("Vertical", verticalInput);
            animator.SetFloat("Speed", movement.magnitude);

            // Flip the sprite based on the movement direction
            if (movement != Vector3.zero)
            {
                spriteRenderer.flipX = (horizontalInput < 0);
            }
        }

        IEnumerator delay()
    {
        yield return new WaitForSeconds(timeAct + .8f);
        Debug.Log("OLA");
        Controller.SetBulha(false);
        rendererPlayer2.enabled = true;
    }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Bolas")
            {
                insideBolas = true;
                interactObject = other.gameObject;



            }

            if (other.tag == "Trumpete")
            {
                insideTrumpa = true;
                interactObject = other.gameObject;



            }

            if (other.tag == "Pena")
            {
                insidePena = true;
                interactObject = other.gameObject;



            }

            if (other.tag == "Harp")
            {
                insideHarp = true;
                interactObject = other.gameObject;



            }

            if (other.tag == "Hula")
            {
                insideHula = true;
                interactObject = other.gameObject;



            }

            if (other.tag == "Mask")
            {
                insideMask = true;
                interactObject = other.gameObject;



            }

            if (other.tag == "Player")
            {
                insideBulha = true;
                interactObject = other.gameObject;
            }

            if (other.tag == "Macac")
            {
                insideMacac = true;
                interactObject = other.gameObject;
            }
    }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Bolas")
            {
                insideBolas = false;
                interactObject = null;



            }
            if (other.tag == "Trumpete")
            {
                insideTrumpa = false;
                interactObject = null;



            }

            if (other.tag == "Pena")
            {
                insidePena = false;
                interactObject = null;



            }

            if (other.tag == "Harp")
            {
                insideHarp = false;
                interactObject = null;



            }

            if (other.tag == "Hula")
            {
                insideHula = false;
                interactObject = null;



            }

            if (other.tag == "Mask")
            {
                insideMask = false;
                interactObject = null;



            }
            if(other.tag == "Player")
            {
                insideBulha = false;
                interactObject = null; 
            }

            if(other.tag == "Macac")
            {
                insideMacac = false;
                interactObject = null; 
            }
        }

    
    }

