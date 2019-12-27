using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	private bool fire;
	public int totalBullets;
	private int remainingBullets;
	public int magLimit;
	
	public GameObject bullet;
	public float bulletSpeed;
	public GameObject shootPoint;
	public float bulletDestroyTime;
	
	public Animator animator;
	
    // Start is called before the first frame update
    void Start()
    {
        remainingBullets = magLimit;
    }

    // Update is called once per frame
    void Update()
    {
		fire = Input.GetButtonDown("Fire1");
		
		if(totalBullets > 0)
		{
			if(remainingBullets > 0)
			{
				if(fire)
				{
					Fire();
				}	
			}	
			else
			{
				Reload();
			}
		}
		
		
    }
	
	void Fire()
	{
		GameObject b = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
		
		b.GetComponent<Rigidbody>().AddForce(shootPoint.transform.forward * bulletSpeed, ForceMode.Impulse);
		Destroy(b, bulletDestroyTime);
		
		remainingBullets--;
		
		animator.Play("Fire");
	}
	void Reload()
	{
		animator.Play("Reload");
	}
	
	public void CalculateBullets()
	{
		if(totalBullets > magLimit)
		{
			remainingBullets = magLimit;
			totalBullets -= magLimit;
		}
		if(totalBullets < magLimit)
		{
			int limit = totalBullets;
			remainingBullets = limit;
			totalBullets = 0;
		}
	}
}
