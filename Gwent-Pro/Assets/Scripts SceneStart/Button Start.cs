using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    [SerializeField] private SceneManager Startscene;
    [SerializeField] private SceneManager GameScene;
    private AudioSource audioSource;
    private GameObject panel;


    public void OnMouseDown()
    {
        SceneManager.LoadSceneAsync("SampleScene");
        SceneManager.UnloadSceneAsync("StartScene");
    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        panel = GameObject.Find("PrincipalMenu").transform.GetChild(1).gameObject;
    }
    public void OnMouseEnter()
    {

    }
    public void OnMouseExit()
    {

    }
    private void Update()
    {
       if(Input.GetKey(KeyCode.None))
       {
            audioSource.Play();
       }
    }
}
