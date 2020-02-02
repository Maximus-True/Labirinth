using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed =5.0f;
    public float gravity = 9.8f;
    public const float baseSpeed = 6.0f;
    public float jumpspeed = 6;
    public float Gravitation;
    public float MaxHealth;
    [SerializeField] private GameOver gameOver;
    private CharacterController _charController;
    public Animator anime;
    private float Health;
    public bool GrandKey;
    public bool key;

    public HealthBar _healthBar;

    void Start()
    {
       /*StartCoroutine(TimerGetDamage());*/
        Health = MaxHealth;
        _charController = GetComponent<CharacterController>();
        gameOver.Close();
        //_healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();    
        GrandKey = false;
    }

    /*private IEnumerator TimerGetDamage()
    {
        yield return new WaitForSecondsRealtime(5);
        GetDamage(5);
    }*/

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        if /*((IsGrounded == true) &*/ (Input.GetKey(KeyCode.Space))/*)*/
        { 
            Gravitation = jumpspeed;
        }
        else
        {
            Gravitation = gravity;
        }
        
        Vector3 movement = new Vector3(deltaX, Gravitation, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = Gravitation;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
        if ((Input.GetKey(KeyCode.W) || (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.D))))))
        {
            anime = GetComponent<Animator>();
            anime.Play("HumanoidWalk");
        }
        else
        {
            anime = GetComponent<Animator>();
            anime.Play("HumanoidIdle");
        }




    }

    public void GetDamage(float Damage )
    {
        Debug.Log(Health);
        if (Health - Damage > 0)
        {
            Health -= Damage;
            var persent = Health * 100 / MaxHealth;
            _healthBar.SetValue(persent);
        }
        else
        {       
            Die();
        }
        Debug.Log(Health);
    }

    private void Die()
    {
        Debug.Log("Изя всё");
        gameOver.Open();
    }

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }
}