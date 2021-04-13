using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    Transform currentFocus;

    [SerializeField]
    Vector3 offset;

    [SerializeField]
    float speed = 2f;

    [SerializeField]
    AnimationCurve tweenCurve;

    [SerializeField]
    float tweenDist = 2f;

    // Update is called once per frame
    void Update()
    {
        if (currentFocus != null)
        {
            Vector3 targetPos = currentFocus.position + offset;
            float moveSpeed = speed * tweenCurve.Evaluate(Mathf.Clamp((Vector3.Distance(targetPos, this.transform.position) / tweenDist), 0, 1));
            Vector3 moveAmount = (targetPos - this.transform.position).normalized * moveSpeed * Time.deltaTime;
            this.transform.position = this.transform.position + moveAmount;
        }
    }








#if UNITY_EDITOR
    [ContextMenu("Set Offset")]
    private void SetOffset()
    {
        Transform focus = currentFocus;
        if (focus == null) focus = UnityEditor.Selection.activeTransform;
        if (focus != null)
            offset = focus.position + this.transform.position;
        else
            Debug.LogError("Nothing to focus", this);
    }
#endif
}
