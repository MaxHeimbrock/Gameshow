using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamTags : Singleton<TeamTags>
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ComeIn()
    {
        animator.SetTrigger("NamesIn");
    }


    public void GoOut()
    {
        animator.SetTrigger("NamesOut");
    }
}
