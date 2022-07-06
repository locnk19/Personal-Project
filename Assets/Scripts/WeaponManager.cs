using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject playerCam;
    [SerializeField] private float range = 100f;
    [SerializeField] private float damage = 25f;
    [SerializeField] private AudioSource _fireSound;
    [SerializeField] private GameObject hitEffectPrefab;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            PlayFireSound();
            Shoot();
        }   
    }

    void Shoot()
    {
        playerAnimator.SetTrigger("IsShooting 0");

        RaycastHit hit;

        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {
            //Debug.Log("hit");

            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            if(enemyManager != null)
            {
                enemyManager.Hit(damage);
            }
            else
            {
                CreateHitEffect(hit);
            }

        }
    }

    private void PlayFireSound()
    {
        _fireSound.Play();
    }

    private void CreateHitEffect(RaycastHit hitInfo)
    {
        Quaternion holeRotation = Quaternion.LookRotation(hitInfo.normal);
        var hole = Instantiate(hitEffectPrefab, hitInfo.point, holeRotation);
        hole.transform.position += hole.transform.forward / 1000;
        Destroy(hole, 5f);
    }
}
