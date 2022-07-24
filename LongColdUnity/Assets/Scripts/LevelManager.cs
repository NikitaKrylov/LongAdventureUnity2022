using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    void Start()
    {
        Instance = this;
    }

    public void Play(int n_Scene)
    {
        SceneManager.LoadScene(n_Scene);
    }
}
