using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour {

    [SerializeField]
    private AudioClip death;

    private int fallDamage;


	void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Bird")
        {
            Destroy(this.gameObject);
            Score.score += 500;
            AudioSource.PlayClipAtPoint(death, transform.position, 2f);
        }
        if (Mathf.Abs(other.relativeVelocity.y) > 5f)
        {
            Destroy(this.gameObject);
            Score.score += 500;
            AudioSource.PlayClipAtPoint(death, new Vector3(26,0,-10), 2f);
        }
    }
}
