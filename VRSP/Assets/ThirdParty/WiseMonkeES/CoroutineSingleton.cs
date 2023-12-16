using System;
using System.Collections;
using UnityEngine;

//TODO: ADD TO WISEMONKEES UTILS
public class CoroutineSingleton : MonoBehaviour
{
    private static CoroutineSingleton _instance;
    public static CoroutineSingleton Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<CoroutineSingleton>();
                if(_instance == null)
                {
                    var go = new GameObject("CoroutineSingleton");
                    _instance = go.AddComponent<CoroutineSingleton>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void ExecuteAfterDelay(float delay, Action action)
    {
        StartCoroutine(ExecuteAfterDelayCoroutine(delay, action));
    }
    
    private IEnumerator ExecuteAfterDelayCoroutine(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
    }
    
}
