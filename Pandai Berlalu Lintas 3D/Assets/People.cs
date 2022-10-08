using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void IsWalk(float delay)
    {
        StartCoroutine(Delay(delay));
    }

    IEnumerator Delay(float delay)
    {
        animator.SetBool("IsWalk", true);
        yield return new WaitForSeconds(delay);
        animator.SetBool("IsWalk", false);
    }
}
