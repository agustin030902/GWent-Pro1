using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    [SerializeField] private SceneManager Startscene;
    [SerializeField] private SceneManager GameScene;

    public void OnMouseDown()
    {
        SceneManager.LoadSceneAsync("SampleScene");
        SceneManager.UnloadSceneAsync("StartScene");
        print("hice click en el gameObject");
    }
    public void OnMouseEnter()
    {

    }
    public void OnMouseExit()
    {

    }
}
