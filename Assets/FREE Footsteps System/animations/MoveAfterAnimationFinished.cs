using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveAfterAnimationFinished : MonoBehaviour
{
    public Vector3 ToMove;
    public int RepeatTimes = 3;
    private Animator animator;
    private float waitingTime;
    private Transform parent;
    private Vector3 defaultPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = true;
        waitingTime = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        parent = transform.parent;
        defaultPosition = parent.localPosition;
        StartStuff();
    }

    public void StartStuff()
    {
        parent.localPosition = defaultPosition;
        StartCoroutine(MoveParent(waitingTime));
    }

    IEnumerator MoveParent(float waitingTime)
    {
        for (int i = 0; i < RepeatTimes; i++)
        {
            animator.Play("uff", 0, 0);
            yield return new WaitForSeconds(waitingTime - 0.0001f);
            //animator.enabled = false;
            parent.localPosition += ToMove;
        }
        StartStuff();
    }


}
