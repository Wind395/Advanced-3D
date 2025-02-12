using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{

    enum State
    {
        Idle,
        Patrol,
        Chase,
        Attack
    }

    private State _currentState;
    private NavMeshAgent agent;
    private Animator _animator;
    [SerializeField] LayerMask playerMask;
    private Transform player;

    // For Patrol
    [SerializeField] private Transform[] patrolPoints;
    private int _currentPatrolIndex;
    

    // For Idle
    private float _idleTimer;
    [SerializeField] private float _idleDuration = 2f;

    // For Chase
    public float chaseDistance;
    private bool isRunning = false;

    // For Attack
    public float attackDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentState = State.Idle;
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        _currentState = State.Idle;
        _currentPatrolIndex = 0;
        _idleTimer = _idleDuration;
        isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        AttackPlayer();
        DetectPlayer();
        StateChange();
    }

    void StateChange()
    {
        switch (_currentState)
        {
            case State.Idle:
                HandleIdle();
                break;
            case State.Patrol:
                HandlePatrol();
                break;
            case State.Chase:
                HandleChase();
                break;
            case State.Attack:
                HandleAttack();
                break;
        }
    }


    void HandleIdle()
    {
        _animator.SetBool("isRunning", false);
        _idleTimer -= Time.deltaTime;
        isRunning = false;
        if (_idleTimer <= 0)
        {
            _currentState = State.Patrol;
            _currentPatrolIndex = (_currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    void HandlePatrol()
    {
        isRunning = true;
        if (DetectPlayer())
        {
            _currentState = State.Chase;
            return;
        }

        _animator.SetBool("isRunning", true);
        agent.SetDestination(patrolPoints[_currentPatrolIndex].position);

        if (Vector3.Distance(transform.position, patrolPoints[_currentPatrolIndex].position) < 1f)
        {
            _currentState = State.Idle;
            _idleTimer = 0;
        }
    }

    bool DetectPlayer()
    {
        return Physics.CheckSphere(transform.position, chaseDistance, playerMask);
    }

    bool AttackPlayer()
    {
        return Physics.CheckSphere(transform.position, attackDistance, playerMask);
    }

    void HandleChase()
    {
        isRunning = true;
        if (!DetectPlayer())
        {
            _currentState = State.Idle;
        }

        if (AttackPlayer())
        {
            _currentState = State.Attack;
        }

        transform.LookAt(player.position);
        _animator.SetBool("isRunning", true);
        agent.SetDestination(player.position);
    }

    void HandleAttack()
    {
        _animator.SetBool("isRunning", false);
        Debug.Log("Attack");
        agent.velocity = Vector3.zero;
        _animator.SetTrigger("isAttack");

        if (!AttackPlayer())
        {
            _animator.SetBool("isRunning", isRunning);
            _currentState = State.Chase;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
