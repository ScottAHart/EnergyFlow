using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField]
    LoadingScreen loadScreen = null;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    [ContextMenu("Activate")]
    public async Task Activate()
    {
        await loadScreen.Activate();
    }
    [ContextMenu("Deactive")]
    public async Task Deactive()
    {
        await loadScreen.Deactivate();
    }
}
