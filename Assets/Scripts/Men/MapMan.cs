using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapMan : MonoBehaviour
{
    public void StartLvL1() 
    {
        SceneManager.LoadSceneAsync(SceneIDS.lvlSceneID);
    }
}
