using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour, IActorTemplate {

	int health;
	int travelSpeed;
	int fireSpeed;
	int hitPower;

	//wave enemy
	[SerializeField] float verticalSpeed = 2;
	[SerializeField] float verticalAmplitude = 1;
	Vector3 sineVer;
	float time;

	public void ActorStats(SOActorModel actorModel)
	{
		throw new System.NotImplementedException();
	}

	public void Die()
	{
		throw new System.NotImplementedException();
	}

	public int SendDamage()
	{
		throw new System.NotImplementedException();
	}

	public void TakeDamage(int incomingDamage)
	{
		throw new System.NotImplementedException();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
