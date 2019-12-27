using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public GameObject bulletImpact;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision otherCollider)
	{
		GameObject impact = Instantiate(bulletImpact, otherCollider.contacts[0].point, bulletImpact.transform.rotation);
		Destroy(impact, 0.15f);
		
		if(otherCollider.transform.GetComponent<ZombieAI>())
		{
			if(otherCollider.transform.GetComponent<ZombieAI>().isAlive == true)
			{
				otherCollider.transform.GetComponent<ZombieAI>().isAlive = false;
				otherCollider.transform.GetComponent<Animator>().Play("Death");
			}
		}
		
		Destroy(this.gameObject);
	}
}
