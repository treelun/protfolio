/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Status
{
    Animator anima;
    EnemyEye enemyEye;
    EnemyAttackArea enemyAttackArea;
    AudioSource audioSource;
    Material material;
    EtcItemContoller item;

    public SphereCollider eye;
    public SphereCollider wanderArea;

    bool isWalk;

    public bool isHit = false;

    public float Hitpoint;

    public bool isDeath;

    public float velocity;
    public float accelaration;

    float delta;
    float romingTiming;



    private void Start()
    {
        anima = GetComponent<Animator>();
        enemyAttackArea = GetComponentInChildren<EnemyAttackArea>();
        audioSource = GetComponent<AudioSource>();
        material = GetComponentInChildren<SkinnedMeshRenderer>().material;
        enemyEye = GetComponentInChildren<EnemyEye>();
        item = GetComponentInChildren<EtcItemContoller>();
    }
    // Update is called once per frame
    void Update()
    {
        MoveToTarget();

        //죽으면 2초뒤 오브젝트 파괴(나중에 오브젝트 풀링방식으로 바꿀예정)
        if (isDeath)
        {
            anima.SetBool("isWalk", false);
            anima.SetBool("isRun", false);

            KillCharacter();
           
        }

    }

    void MoveToTarget()
    {
        
        romingTiming += Time.deltaTime;

        if (romingTiming > 1 && !enemyEye.target && !enemyAttackArea.isAttack &&  !isDeath)
        {
            audioSource.Play();
            anima.SetBool("isWalk", true);
            //n초뒤 이동
            if (romingTiming > 7f)
            {    
                romingTiming = 0;
                anima.SetBool("isWalk", false);
                anima.SetTrigger("turn");
            }
        }
           
       
        else if (enemyEye.target && !enemyAttackArea.isAttack && !isDeath)
        {
            //점프하면 rotation의 x값이 -90으로 바닥에 누워서 플레이어를 쳐다봄...수정하기위해 y값 만 본인의 값으로
            transform.LookAt(new Vector3(enemyEye.target.position.x, transform.position.y, enemyEye.target.position.z));
            anima.SetBool("isWalk", true);
            Debug.Log(isWalk);
        }
        else if (enemyEye.target && enemyAttackArea.isAttack && !isDeath)
        {
            anima.SetBool("isWalk", false);
            audioSource.Stop();
        }


    }

    void KillCharacter()
    {
        Destroy(gameObject, 2f);
    }

    //재생성될때의 값들
    public void ResetCharacter()
    {
        Hitpoint = startHp;
        isDeath = false;
    }

    //실질적으로 데미지를 받는 메서드
    public void DamageCharacter(float damage)
    {
        Hitpoint -= damage;
        
        StartCoroutine(OnDamaged());
        if (Hitpoint <= float.Epsilon) //float.Epsilon은 0보다 큰 가장 작은 양수의 값을 나타냄
        {
            isDeath = true;
            eye.enabled = false;
            wanderArea.enabled = false;
            gameObject.layer = 18;

            
            //item.DropItem();
        }
    }

    //활성화되면 재생성시 값을 초기화함
    private void OnEnable()
    {
        ResetCharacter();
    }



    IEnumerator OnDamaged()
    {
        material.color = Color.red;
        anima.SetTrigger("hitMotion");
        gameObject.layer = 18;
        yield return new WaitForSeconds(0.2f);

        if (Hitpoint > 0)
        {
            material.color = new Color32(226, 214, 195, 30);
            gameObject.layer = 17;
        }
    }

}
*/