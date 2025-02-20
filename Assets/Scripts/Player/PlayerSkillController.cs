using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{

    [SerializeField] private ProjectilesManager projectilesManager;

    [SerializeField] private GameObject launchPosition;


    private Animator _animator;
    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Pressed");
            _animator.SetTrigger("normalAttack");
            _characterController.Move(Vector3.zero);
            StartCoroutine(projectilesManager.LaunchNormalProjectile());
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Pressed");
            _animator.SetTrigger("fireBall");
            _characterController.Move(Vector3.zero);
            StartCoroutine(projectilesManager.LaunchFireBall(launchPosition.transform.position));
        }
    }
}
