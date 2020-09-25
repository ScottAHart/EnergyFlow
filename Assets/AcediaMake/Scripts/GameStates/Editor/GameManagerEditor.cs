using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(GameMachine))]
public class GameMachineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //Drop down of possible states?
        //typeof(GameState).Assembly.GetTypes();
        //typeof(A).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(A)));
    }
}
