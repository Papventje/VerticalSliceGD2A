using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StoneHP : MonoBehaviour {
	[SerializeField]
	private float StartingHealth = 55;
	[SerializeField]
	private float CurrentHealth;

    [SerializeField]
    private AudioClip onDestroyStone;

	void Awake()
	{
		CurrentHealth = StartingHealth;
	}
		
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Bird")
		{
			CurrentHealth -= 2;
		}

		if (Mathf.Abs(other.relativeVelocity.y ) >2f)
		{
			CurrentHealth -= Mathf.Round ((other.relativeVelocity.y - 2f)*(other.relativeVelocity.y - 0.5f));
			Score.score += Mathf.Round ((other.relativeVelocity.y - 2f)*(other.relativeVelocity.y - 0.8f)) * 15;
	    }

		if (CurrentHealth <= 0) 
		{
            AudioSource.PlayClipAtPoint(onDestroyStone, transform.position, 1f);
			Destroy(this.gameObject);
		}
	}

}