using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Array of prefabs (GameObject)
    public GameObject[] enemyPrefabs;
    public Enemy curEnemy;
    public Transform canvas;

    public static EnemyManager instance;

    void Awake()
    {
        instance = this;
    }

    void CreateNewEnemy()
    {
        GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        // Track the newly created enemy instance by storing it in a GameObject variable called obj
        GameObject obj = Instantiate(enemyToSpawn, canvas);
        Instantiate(enemyToSpawn, canvas);
        // search for the Enemy script inside obj and pass it to the curEnemy variable
        curEnemy = obj.GetComponent<Enemy>();
    }
    public void DefeatEnemy(GameObject enemy)
    {
        //Destroy the current enemy and create a new enemy.
        Destroy(enemy);
        CreateNewEnemy();
        GameManager.instance.BackgroundCheck();
    }
    public void Defeated()
    {
        EnemyManager.instance.DefeatEnemy(gameObject);
    }
}
