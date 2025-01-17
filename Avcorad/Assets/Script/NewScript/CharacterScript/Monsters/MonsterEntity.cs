using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;

public class MonsterEntity : LivingEntity
{
    public enum EnemyState
    {
        Move = 0, Attack, Death, Tracking, Hit
    }
    EnemyState _enemyState;
    
    public EnemyState enemyState
    {
        get { return _enemyState; }
        set
        {
            switch (value)
            {
                case EnemyState.Attack:
                    AttackBox.gameObject.layer = 19;
                    StopCoroutine(EnemyWalk());
                    StopCoroutine(StartTraking());
                    Attack();
                    break;
                case EnemyState.Move:
                    if (enemyType == EnemyType.Alien)
                    {
                        animator.SetBool("isSideMove", false);
                    }
                    
                    StopCoroutine(StartTraking());
                    StartCoroutine(EnemyWalk());
                    //Move();
                    break;
                case EnemyState.Death:
                    capsuleCollider.enabled = false;
                    target = null;
                    AttackBox.enabled = false;
                    DropItemAndExp();
                    StopCoroutine(EnemyWalk());
                    StopCoroutine(StartTraking());
                    Death();


                    if (enemyType == EnemyType.Alien)
                    {
                        StartCoroutine(BossDeath());
                    }
                    break;
                case EnemyState.Tracking:
                    gameObject.layer = 17;
                    Debug.Log("트래킹 실행");
                    StopCoroutine(EnemyWalk());
                    StartCoroutine(StartTraking());
                    break;
                case EnemyState.Hit:
                    if (enemyType == EnemyType.Zombie)
                    {
                        AttackBox.enabled = false;
                        animator.SetTrigger("Hit");
                    }
                    
                    break;
                default:
                    break;
            }
            _enemyState = value;
        }
    }

    public enum EnemyType
    {
        Zombie, Alien
    }
    public EnemyType enemyType;

    protected GameObject dropObject;


    public Transform target;

    public SphereCollider playerCheckCollier;
    public BoxCollider AttackBox;
    public CapsuleCollider capsuleCollider;
    public GameObject hpBarPrefab;
    GameObject hpBar;

    public Vector3 hpBarOffset = new Vector3(-0.5f, 2.4f, 0);

    public Canvas enemyHpBarCanvas;
    public Slider enemyHpbarSlider;

    public float maxHp;
    public float maxSta;
    public float maxMp;
    public float _AttackForce;
    public float _Exp;


    int turnType;
    int attackType;

    float delta;


    public AudioSource audioSource;

    public AudioClip idleSound;
    public AudioClip attackSound;
    public AudioClip deathSound;
    public AudioClip hitSound;

    [SerializeField]
    /// a feedback to be played when the cube lands
    private MMFeedbacks cameraShake;

    public ParticleSystem bloodExplosion;

    [SerializeField]
    private ItemBox itemBox;

    private void Start()
    {
        itemBox.SetObject(new Vector3(transform.position.x, 1, transform.position.z));
        SetHpbar();
    }
    public virtual void Update()
    {
        if (target == null)
        {
            hpBar.SetActive(false);
        }
        else if (target != null)
        {
            hpBar.SetActive(true);
        }

    }

    public override void Attack()
    {
        if (enemyType == EnemyType.Zombie)
        {
            animator.SetBool("isAttack", true);
            animator.SetBool("isAttack2", true);
        }
        else if (enemyType == EnemyType.Alien)
        {
            animator.SetBool("isSideMove", false);
            animator.SetBool("isJumpAttack", false);
            
          
            attackType = Random.Range(0, 2);

            if (attackType == 0)
            {
                animator.SetBool("isAttack", true);
                animator.SetBool("isAttack2", true);
                animator.SetBool("isAttack3", false);
            }
            else if (attackType == 1)
            {
                animator.SetBool("isAttack", true);
                animator.SetBool("isAttack2", false);
                animator.SetBool("isAttack3", true);
            }
            
            
        }

    }

    //아이템, 경험치 drop(아이템드랍은 인터넷 참조 예상으로는 죽으면 > 비활성화된 아이템 프리펩 true로 바꾸고,
    //먹으면 비활성화, position은 몬스터의 위치로)
    public void DropItemAndExp()
    {
        int random = Random.Range(0, 1001);
        GameManager.Instance.mainPlayer.playerData.currentExp += EnemyExp;
        //아이템 드랍
        int potionrand = Random.Range(0, 101);
        if (random < 600)
        {
            itemBox.GetHpPotion(potionrand).transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            itemBox.GetHpPotion(potionrand).SetActive(true);
        }
        else if (600 <= random && random < 950)
        {
            itemBox.GetMpPotion(potionrand).transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            itemBox.GetMpPotion(potionrand).SetActive(true);
        }
        else if (950 <= random && random < 1000)
        {
            itemBox.Getweapon(new Vector3(transform.position.x, 0.5f, transform.position.z)).SetActive(true);
        }

        //오브젝트 풀링으로 아이템 드롭 구현
    }

    public IEnumerator EnemyWalk()
    {
        while (target == null)
        {
            animator.SetBool("isAttack", false);
            animator.SetBool("isAttack2", false);
            animator.SetBool("isRun", false);
            animator.SetBool("isTurn", false);
            animator.SetBool("isTurn2", false);

            if (enemyType== EnemyType.Alien)
            {
                animator.SetBool("isSideMove", false);
                animator.SetBool("isSideMove2", false);
            }

            animator.SetBool("isWalk", true);
            yield return new WaitForSeconds(10f);

            
            turnType = Random.Range(0, 2);

            if (turnType == 0)
            {
                animator.SetBool("isTurn", true);
                animator.SetBool("isWalk", false);
            }
            else if (turnType == 1)
            {
                animator.SetBool("isTurn2", true);
                animator.SetBool("isWalk", false);
            }
                
            
            yield return new WaitForSeconds(3f);
        }
        audioSource.clip = idleSound;
        audioSource.Play();
    }

    //추적
    public IEnumerator StartTraking()
    {
        while (target != null)
        {
            if (enemyState == EnemyState.Tracking && enemyType == EnemyType.Zombie)
            {
                animator.SetBool("isAttack", false);
                animator.SetBool("isAttack2", false);
                animator.SetBool("isRun", true);
                transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
            }
            else if (enemyState == EnemyState.Tracking && enemyType == EnemyType.Alien)
            {
                animator.SetBool("isAttack", false);
                animator.SetBool("isAttack2", false);
                animator.SetBool("isAttack3", false);
                Debug.Log("Alien State Traking");
                animator.SetBool("isWalk", false);
                transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
                
                delta += Time.deltaTime;
                if (delta > 7f)
                {
                    turnType = Random.Range(0, 3);
                    if (turnType == 0)
                    {
                        animator.SetBool("isSideMove2", false);
                        animator.SetBool("isJumpAttack", false);
                        animator.SetBool("isSideMove", true);
                    }
                    else if (turnType == 1)
                    {
                        animator.SetBool("isJumpAttack", false);
                        animator.SetBool("isSideMove", false);
                        animator.SetBool("isSideMove2", true);
                    }
                    else if (turnType == 2)
                    {
                        animator.SetBool("isSideMove", false);
                        animator.SetBool("isSideMove2", false);
                        animator.SetBool("isJumpAttack", true);
                    }
                    delta = 0;
                }
                
            }
            else if (enemyState == EnemyState.Attack)
            {
                animator.SetBool("isRun", false);
            }
            yield return null;
        }

    }


    public void StartAttack()
    {
        AttackBox.enabled = true;
        audioSource.clip = attackSound;
        audioSource.Play();
    }
    public void EndAttack()
    {
        AttackBox.enabled = false;
    }

    void SetHpbar()
    {
        enemyHpBarCanvas = GameObject.Find("EnemyHpbarCanvas").GetComponent<Canvas>();
        hpBar = Instantiate(hpBarPrefab, enemyHpBarCanvas.transform);
        
        var _hpbar = hpBar.GetComponent<EnemyHpbarPosition>();
        
        _hpbar.enemy = this.gameObject.transform;
        _hpbar.offset = hpBarOffset;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        Init();
        capsuleCollider.enabled = true;
        enemyState = EnemyState.Move;
        
    }

    public override void Init()
    {
        base.Init();
        AttackForce = _AttackForce;
        Hp = maxHp;
        EnemyExp = _Exp;
    }

    public override void Death()
    {
        base.Death();
        hpBar.SetActive(false);

        audioSource.clip = deathSound;
        audioSource.Play();
    }
    public override void Hit(float _AttackForce)
    {
        base.Hit(_AttackForce);
        audioSource.clip = hitSound;
        audioSource.Play();
        cameraShake?.PlayFeedbacks();
        bloodExplosion.Play();
    }

    IEnumerator BossDeath()
    {
        yield return new WaitForSeconds(5f);
        LodingSceneContoller.LoadScene("EndingScene");
    }

}
