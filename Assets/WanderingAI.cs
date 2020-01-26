using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class WanderingAI : MonoBehaviour {
    public const float baseSpeed = 3.0f;
    public float speed = 4.0f;
    private float health = 10;
    public float obstacleRange = 3.0f;
    private bool _alive;
    private bool attack;
    public bool walk;
    public Animator anime;
    public FPSInput FPSInput;
    public float damage = 3;
    

    public int damageCount = 0;

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;


    // Use this for initialization
    void Start ()
    {
        _alive = true;
        attack = false;
        walk = true;
        
	}
    public IEnumerator TimerGetDamage()
    {
        FPSInput.GetDamage(damage);
        yield return new WaitForSecondsRealtime(0.4f);
    }
    // Update is called once per frame
    void Update () {
       
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (attack == true)
        {
            anime = GetComponent<Animator>();
            anime.Play("Attack");    
        }
        else
        {
            anime = GetComponent<Animator>();
            anime.Play("Walk");
            damageCount = 0;
        }

        if (walk == true)
        {
            attack = false;
        }
        else
        {
            attack = true;
        }
        
        if (Physics.SphereCast(ray, 1.5f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hit.distance < obstacleRange)
            {
                if (hitObject.GetComponent<FPSInput>())
                {
                    Debug.Log("атакую");
                    attack = true;
                    //TimerGetDamage();

                   if (damageCount ==75)
                    {
                        FPSInput.GetDamage(damage);
                        damageCount = 0;
                        Debug.Log("урон");
                    }
                    else damageCount++;
                }
                else 
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
            
        }
        if (attack == false)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
       if (attack == true)
        {
            TimerGetDamage();
        }
    }
   
    private void OnSpeedChanged(float value)
    {
     speed = baseSpeed * value;
    }
    
}
