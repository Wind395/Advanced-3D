using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{

    [SerializeField] private ProjectilesManager projectilesManager;

    [SerializeField] private GameObject launchPosition;


    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Pressed");
            animator.SetTrigger("normalAttack");
            StartCoroutine(projectilesManager.LaunchNormalProjectile(launchPosition.transform.position));
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Pressed");
            animator.SetTrigger("fireBall");
            StartCoroutine(projectilesManager.LaunchFireBall(launchPosition.transform.position));
        }
    }
}
