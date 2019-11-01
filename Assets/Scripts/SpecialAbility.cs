using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbility : MonoBehaviour
{
    public GameObject shield;
    public Ball ball;
    public float activationTime = 0.5f;
    public float rechargeDelay = 5.0f;
    public float recharge;
    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
        
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
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ball")
        {
            //reset ball velocity back to zero
            ball.rigidbodyBall.velocity = new Vector2(0,0);
        }
        
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds (activationTime);

        shield.SetActive(false);
    }
}
