using UnityEngine;

public class TargetController : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.localScale = new Vector3(gameManager.SetTargetSize(), gameManager.SetTargetSize(), gameManager.SetTargetSize()); 
    }

    private void Update()
    {
        if (!gameManager.GameStart)
        {
            Destroy(gameObject);
        }
    }
}
