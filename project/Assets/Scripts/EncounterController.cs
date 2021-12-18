using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterController : MonoBehaviour
{
    public EncounterController instance;


    void Awake()
    {
        instance = this;
    }
    
    public void beginFirstEncounter()
    {
        SceneManager.LoadScene("Encounter", LoadSceneMode.Single);
    }

}
    
   
