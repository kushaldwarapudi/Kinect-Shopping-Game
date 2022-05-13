using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        StartCoroutine(ResetGAme());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator ResetGAme()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
        
    }
    
    
}
