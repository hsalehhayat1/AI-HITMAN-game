using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
using TMPro;

public class ZombieSpawnController : MonoBehaviour
{
    public int initialZombiesPerWave;
    public int currentZombiesPerWave;

    public float spawnDelay = 0.5f;

    public int currentWave = 0;
    public float waveCooldown = 10.0f;

    public bool incooldown;
    public float cooldownCounter;

    
    public List<EnemyAI> currentZombiesAlive;

    public GameObject zombiePrefab;

    public TextMeshProUGUI waveOverUI;
    public TextMeshProUGUI cooldownCounterUI;

    public TextMeshProUGUI currentWaveUI;

    private void Start()
    {
        currentZombiesPerWave = initialZombiesPerWave;

        
        waveOverUI.gameObject.SetActive(false);

        StartNextWave();
    }

    private void StartNextWave()
    {
        currentZombiesAlive.Clear();
        currentWave++;
        currentWaveUI.text = "Wave:" + currentWave.ToString();
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < currentZombiesPerWave; i++)
        {
            Vector3 spawnOffset = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
            Vector3 spawnPosition = transform.position + spawnOffset;

            var zombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

           
            EnemyAI enemyScript = zombie.GetComponent<EnemyAI>();

            currentZombiesAlive.Add(enemyScript);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void Update()
    {
        
        List<EnemyAI> zombiesToRemove = new List<EnemyAI>();

        foreach (EnemyAI zombie in currentZombiesAlive)
        {
            if (zombie.isDead)
            {
                zombiesToRemove.Add(zombie);
            }
        }

        foreach (EnemyAI zombie in zombiesToRemove)
        {
            currentZombiesAlive.Remove(zombie);
        }

        zombiesToRemove.Clear();

        if (currentZombiesAlive.Count == 0 && incooldown == false)
        {
            StartCoroutine(wavecooldown());
        }

        if (incooldown)
        {
            cooldownCounter -= Time.deltaTime;

            
            cooldownCounterUI.text = "In: " + Mathf.Ceil(cooldownCounter).ToString();
        }
        else
        {
            cooldownCounter = waveCooldown;
            cooldownCounterUI.text = "";
        }
    }

    private IEnumerator wavecooldown()
    {
        incooldown = true;

        
        waveOverUI.gameObject.SetActive(true);

        yield return new WaitForSeconds(waveCooldown);

        incooldown = false;

        waveOverUI.gameObject.SetActive(false);

        currentZombiesPerWave *= 1;
        StartNextWave();
    }
}