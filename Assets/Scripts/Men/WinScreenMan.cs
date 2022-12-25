using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenMan : MonoBehaviour
{
    public void GameKiller() {
        Application.Quit();
    }
    
    public void ReplayLVL() {
        SceneManager.LoadSceneAsync(SceneIDS.lvlSceneID);
    }

    public void ReturnSelect() 
    {
         SceneManager.LoadSceneAsync(SceneIDS.selectScrID);
    }
}
