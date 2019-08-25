using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEnableOpenScene : MonoBehaviour
{
    public string nameOfScene;
    void OnEnable()
    {
        SceneManager.LoadScene(nameOfScene);
    }

}
