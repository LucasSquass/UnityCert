using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IActorTemplate {

	int travelSpeed;
	int health;
	int hitPower;
	GameObject actor;
	GameObject fire;

	GameObject _Player;

	float width;
	float height;

	public int Health
	{
		get { return health; }
		set { health = value; }
	}

	public GameObject Fire
	{
		get { return fire; }
		set { fire = value; }
	}

	// Use this for initialization
	void Start()
	{
		height	= 1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).y - .5f);
		width	= 1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f);

		_Player = GameObject.Find("_Player");
	}

	// Update is called once per frame
	void Update()
	{
		Movement();
		Attack();
	}

	private void Attack()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			GameObject bullet = GameObject.Instantiate(fire, transform.position, Quaternion.identity);
			bullet.transform.SetParent(_Player.transform);
			bullet.transform.localScale = new Vector3(7, 7, 7);
		}
	}

	private void Movement()
	{
		float horizontalMovement = Input.GetAxisRaw("Horizontal");
		float verticalMovement = Input.GetAxisRaw("Vertical");

		//HORIZONTAL MOVEMENT
		if(horizontalMovement > 0)
		{
			if (transform.localPosition.x < width + width / 0.9f)
			{
				transform.localPosition += new Vector3(horizontalMovement * Time.deltaTime, 0, 0).normalized * travelSpeed;
			}
		}
		if(horizontalMovement < 0)
		{
			if(transform.localPosition.x > width + width / 6)
			{
				transform.localPosition += new Vector3(horizontalMovement * Time.deltaTime, 0, 0).normalized * travelSpeed;
			}
		}

		//VERTICAL MOVEMENT
		if (verticalMovement > 0)
		{
			if (transform.localPosition.y < height / 2.5f)
			{
				transform.localPosition += new Vector3(0, verticalMovement * Time.deltaTime, 0).normalized * travelSpeed;
			}
		}
		if (verticalMovement < 0)
		{
			if (transform.localPosition.y > -height / 3)
			{
				transform.localPosition += new Vector3(0, verticalMovement * Time.deltaTime, 0).normalized * travelSpeed;
			}
		}
	}

    #region IActorTemplate
    public void ActorStats(SOActorModel actorModel)
	{
		health = actorModel.health;
		travelSpeed = actorModel.speed;
		hitPower = actorModel.hitPower;
		fire = actorModel.actorsBullet;
	}

	public void Die()
	{
        GameManager.Instance.LifeLost();
		Destroy(gameObject);
	}

	public int SendDamage()
	{
		return hitPower;
	}

	public void TakeDamage(int incomingDamage)
	{
		health -= incomingDamage;
	}
    #endregion

    #region Collisions
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (health >= 1)
            {
                if (transform.Find("energy +1(Clone)"))
                {
                    Destroy(transform.Find("energy +1(Clone)").gameObject);
                    health -= other.GetComponent<IActorTemplate>().SendDamage();
                }
                else
                {
                    health -= 1;
                }
            }

            if (health <= 0)
            {
                Die();
            }
        }
    }
    #endregion
}