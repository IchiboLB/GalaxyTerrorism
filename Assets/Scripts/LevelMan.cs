using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMan : MonoBehaviour
{
    public GameObject firstGroupOrig;
    private FirstEnGroup curGr;
    private int countGr = 0;
    void Start()
    {
        
       NewGrpGen();
       countGr += 1;
       
    }

    
    void Update()
    {
        if(curGr.isAlive == false) {
            Destroy(curGr.gameObject);
            if(countGr == 5) {
                SceneManager.LoadSceneAsync(1);
            } else {
                NewGrpGen();
                countGr++;
            }
           
            
        }
    }

    void NewGrpGen() 
    {
        GameObject newGr = Instantiate(firstGroupOrig);
        newGr.transform.position = transform.position;
        curGr = newGr.GetComponent<FirstEnGroup>();
    }
}
