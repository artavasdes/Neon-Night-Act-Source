using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Mirror;

public class Character_Control : NetworkBehaviour {
    [SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 7.5f;
    [SerializeField] float      scale = 2f;



    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = false;
    private bool                m_combatIdle = false;
    private bool                m_isDead = false;
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        maxHealth = 100;
        currentHealth = maxHealth;
        // healthBar.SetMaxHealth(maxHealth);
        transform.localScale = new Vector3(scale, scale, scale);
    }

	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer) {
          return;
        }
        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State()) {
            m_grounded = true;
            m_animator.SetBool("isGrounded", m_grounded);
        }

        //Check if character just started falling
        if(m_grounded && !m_groundSensor.State()) {
            m_grounded = false;
            m_animator.SetBool("isGrounded", m_grounded);
        }

        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
            transform.localScale = new Vector3(-scale, scale, scale);
        else if (inputX < 0)
            transform.localScale = new Vector3(scale, scale, scale);

        //Move
        if (inputX != 0){
            m_body2d.velocity = new Vector2((inputX * m_speed), m_body2d.velocity.y);
            m_animator.SetFloat("speed", Mathf.Abs(inputX * m_speed));
        }
        else {
            m_animator.SetFloat("speed", 0);
        }

        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

        // -- Handle Animations --
        //Death
        if (Input.GetKeyDown("e")) {
            m_animator.SetTrigger("Death");
        }

        //Hurt
        else if (Input.GetKeyDown("q")){
            TakeDamage(20);
            m_animator.SetTrigger("Hurt");
        }

        //Attack
        else if(Input.GetMouseButtonDown(0)) {
            int i  = Random.Range(1, 4);
            m_animator.SetTrigger("Attack" + i);
        }

        //Jump
        else if (Input.GetKeyDown("space") && m_grounded) {
            Debug.Log("JUMP");
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("isGrounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
        }
        Debug.Log(m_grounded);


    }

    void TakeDamage(int damage)
    {
      if (!isLocalPlayer) {
        return;
      }
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        // if (currentHealth <= 0){
        //     m_animator.SetTrigger("Death");
        // }
    }
}
