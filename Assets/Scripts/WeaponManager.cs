using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject playerCam;
    [SerializeField] private float range = 100f;
    [SerializeField] private float damage = 25f;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAnimator.GetBool("IsShooting"))
        {
            playerAnimator.SetBool("IsShooting", false);
        }

        if (Input.GetButton("Fire1"))
        {
            //Debug.Log("Shoot");
            Shoot();
        }   
    }

    void Shoot()
    {
        playerAnimator.SetBool("IsShooting", true);

        RaycastHit hit;

        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {
            //Debug.Log("hit");

            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            if(enemyManager != null)
            {
                enemyManager.Hit(damage);
            }

        }
    }
}
