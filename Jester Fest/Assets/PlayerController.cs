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

    private SpriteRenderer spriteRenderer;
    public SpriteRenderer rendererBolas;
    public SpriteRenderer rendererTrumpa;
    

    public GameObject interactObject;

    private float time = 5.0f;

    public GameController Controller;
    


    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        
        if (Input.GetKeyDown(interactKey) && insideBolas && !Controller.GetMalabarismo())
        {
            
            pointsSlider.AddPoints(20f);
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
                rendererBolas.sprite = Bolas;
                BolasAgarradas = false;
                time = 5f;
                animation = false;
                
            }
        }


        if (Input.GetKeyDown(interactKey) && insideTrumpa && !Controller.GetToca())
        {

            pointsSlider.AddPoints(20f);
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
                rendererTrumpa.sprite = Trumpeta;
                TrumpAgarr = false;
                time = 5f;
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
    }

    


}
