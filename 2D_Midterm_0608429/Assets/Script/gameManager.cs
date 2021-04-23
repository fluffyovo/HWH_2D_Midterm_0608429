using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    private void Update()
    {
        
    }

    public void NextSc()
    {
        SceneManager.LoadScene("遊戲場景");
    }
}
