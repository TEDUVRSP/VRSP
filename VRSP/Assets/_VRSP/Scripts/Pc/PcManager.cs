using UnityEngine;

public class PcManager : MonoBehaviour
{

    // Singelton
    public static PcManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        gameObject.SetActive(false);
    }
    public void Open(Vector3 position, float rotation)
    {
        transform.position = position;
        transform.eulerAngles = new (transform.eulerAngles.x, rotation, 0);
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
   
}
