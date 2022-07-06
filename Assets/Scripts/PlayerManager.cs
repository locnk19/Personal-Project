using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public float health = 100;
    [SerializeField] private GameManager gameManager;
    
    public void Hit(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            gameManager.EndGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
