using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float lifeTime;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private float damage = 20f;
    [SerializeField] private float health = 100f;
    [SerializeField] public GameManager gameManager;

    private Collider enemiesCollider;

    public void Hit(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            enemyAnimator.SetBool("IsDying", true);
            enemiesCollider = GetComponent<Collider>();
            enemiesCollider.enabled = !enemiesCollider.enabled;
            Destroy(gameObject, lifeTime);
            gameManager.enemiesAlive--;
        }
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        if(GetComponent<NavMeshAgent>().velocity.magnitude > 3)
        {
            enemyAnimator.SetBool("IsRunning", true);
        }
        else
        {
            enemyAnimator.SetBool("IsRunning", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            player.GetComponent<PlayerManager>().Hit(damage);
        }
    }
}
