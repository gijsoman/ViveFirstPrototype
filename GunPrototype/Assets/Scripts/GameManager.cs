using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton!
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public EnemyScript Enemy = null;
    public PlayerScript Player = null;

    private void Start()
    {
        Application.targetFrameRate = -1;
        QualitySettings.vSyncCount = 0;
        Enemy.IDied += EnemyDeathSequence;
        Player.IDied += PlayerDeathSequence;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void PlayerDeathSequence()
    {
        Debug.Log("The Player Died");
    }

    private void EnemyDeathSequence()
    {
        Debug.Log("The Enemy Died");
    }

    private void OnDestroy()
    {
        Enemy.IDied -= EnemyDeathSequence;
        Player.IDied -= PlayerDeathSequence;
    }
}
