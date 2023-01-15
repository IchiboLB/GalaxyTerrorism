using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMan : MonoBehaviour
{
    public GameObject firstGroupOrig;
    public GameObject ramGroupOrig;
    private GroupBase curGr;
    private int countGr = 0;
    private EnGroupType[] grTypes = {EnGroupType.baseGr, EnGroupType.ramGr, EnGroupType.ramGr};
    void Start()
    {
        
       NewGrpGen();
       countGr += 1;
       
    }

    
    void Update()
    {
        if(curGr != null && curGr.isAlive == false) {
            Destroy(curGr.gameObject);
            if(countGr == grTypes.Length) {
                SceneManager.LoadSceneAsync(SceneIDS.winScrID);
            } else {
                NewGrpGen();
                countGr++;
            }
           
            
        }
    }

    void NewGrpGen() 
    {
        if (grTypes[countGr] == EnGroupType.baseGr) {
        GameObject newGr = Instantiate(firstGroupOrig);
        newGr.transform.position = transform.position;
        curGr = newGr.GetComponent<FirstEnGroup>();
        } else if(grTypes[countGr] == EnGroupType.ramGr) {
            GameObject newGr = Instantiate(ramGroupOrig);
            newGr.transform.position = transform.position;
            curGr = newGr.GetComponent<RamEnGroup>();
        }

    }
       
}
