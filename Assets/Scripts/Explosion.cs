using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public GameObject explosion;
    private float timer = 0.5f;

    void ExplosionTime()
    {
        GameObject go = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        Destroy(go, 1f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            Debug.Log("hit");
            StartCoroutine("ExplosionTimer");
        }
    }

    IEnumerator ExplosionTimer()
    {
        yield return new WaitForSeconds(timer);
        ExplosionTime();
    }

}
