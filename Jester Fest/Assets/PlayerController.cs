using UnityEngine;
using UnityEngine.UI;

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

    private SpriteRenderer spriteRenderer;
    public SpriteRenderer rendererBolas;
    public SpriteRenderer rendererTrumpa;
    public SpriteRenderer rendererPena;
    

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

                if (BController.GetValores().Contains(0))
                {
                    pointsSlider.AddPoints(pontoAdd);
                }
                else
                {
                    pointsSlider.AddPoints(pontoRem);
                }

                rendererBolas.sprite = Bolas;
                BolasAgarradas = false;
                time = timeAct;
                animation = false;
                
            }
        }


        if (Input.GetKeyDown(interactKey) && insideTrumpa && !Controller.GetToca())
        {

            
            TrumpAgarr = true;



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

                if (BController.GetValores().Contains(1))
                {
                    pointsSlider.AddPoints(pontoAdd);
                }
                else
                {
                    pointsSlider.AddPoints(pontoRem);
                }

                rendererTrumpa.sprite = Trumpeta;
                TrumpAgarr = false;
                time = timeAct;
                animation = false;

            }
        }

        if (Input.GetKeyDown(interactKey) && insidePena && !Controller.GetPena())
        {

            
            PenaApanha = true;



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

                if (BController.GetValores().Contains(2))
                {
                    pointsSlider.AddPoints(pontoAdd);
                }
                else
                {
                    pointsSlider.AddPoints(pontoRem);
                }

                rendererPena.sprite = Pena;
                PenaApanha = false;
                time = timeAct;
                animation = false;

            }
        }
        // Get input values for movement
        float horizontalInput = 0f;
        float verticalInput = 0f;
        if (!animation) { 

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
    }

    


}
