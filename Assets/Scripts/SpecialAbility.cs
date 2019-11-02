using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbility : MonoBehaviour
{
    public GameObject shield;
    public GameObject shieldTwo;
    public Ball ball;
    public float activationTime = 0.2f;
    public float rechargeDelay = 5.0f;
    public float rechargeDelayTwo = 5.0f;
    public float recharge;
    public float rechargeTwo;
    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
        shieldTwo.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > recharge)
        {
            recharge = Time.time + rechargeDelay;
            shield.SetActive(true);

            StartCoroutine(Timer());
        
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) && Time.time > rechargeTwo)
        {
            rechargeTwo = Time.time + rechargeDelayTwo;
            shieldTwo.SetActive(true);

            StartCoroutine(TimerTwo());
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ball")
        {
            //reset ball velocity back to zero
            //ball.rigidbodyBall.velocity = new Vector2(0,0);
        }
        
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds (activationTime);

        shield.SetActive(false);
    }

    public IEnumerator TimerTwo()
    {
        yield return new WaitForSeconds (activationTime);

        shieldTwo.SetActive(false);
    }
}
