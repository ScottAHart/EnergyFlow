using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class LoadingScreen : MonoBehaviour
{
    public abstract Task Activate();
    public abstract Task Deactivate();
}
