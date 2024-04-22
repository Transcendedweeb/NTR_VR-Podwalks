using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextScene : MonoBehaviour
{
    public float nextSceneTime = 0.1f;


    void Move()
    {
        SceneManager.LoadScene(1);
    }


    void Awake()
    {
        Invoke("Move", nextSceneTime);
    }
}
