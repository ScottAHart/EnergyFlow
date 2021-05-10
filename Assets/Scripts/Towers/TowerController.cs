using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    List<ITowerPart> parts = new List<ITowerPart>();
    void Start()
    {
        parts = new List<ITowerPart>(GetComponentsInChildren<ITowerPart>());
    }
}
public interface ITowerPart
{
    void SetUp(TowerController controller);
    void Breakdown();
}
