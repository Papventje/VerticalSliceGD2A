using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WoodHP : MonoBehaviour {
	[SerializeField]
	private float StartingHealth = 35;
	[SerializeField]
	private float CurrentHealth;

    [SerializeField]
    private AudioClip onDestroyWood;

	void Awake()
	{
		CurrentHealth = StartingHealth;
	}
		
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Bird")
		{
			CurrentHealth -= 5;
		}

		if (Mathf.Abs(other.relativeVelocity.y ) >1f)
		{
			CurrentHealth -= Mathf.Round ((other.relativeVelocity.y - 1f)*(other.relativeVelocity.y - 0.5f));
			Score.score += Mathf.Round ((other.relativeVelocity.y - 1f) * (other.relativeVelocity.y - 0.5f)) * 10;
	    }

		if (CurrentHealth <= 0) 
		{
            AudioSource.PlayClipAtPoint(onDestroyWood, transform.position, 1f);
			Destroy(this.gameObject);
		}
			

	}
		

}