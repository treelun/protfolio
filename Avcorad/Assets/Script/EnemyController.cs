using System.Collections;
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

        //������ 2�ʵ� ������Ʈ �ı�(���߿� ������Ʈ Ǯ��������� �ٲܿ���)
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
            //n�ʵ� �̵�
            if (romingTiming > 7f)
            {    
                romingTiming = 0;
                anima.SetBool("isWalk", false);
                anima.SetTrigger("turn");
            }
        }
           
       
        else if (enemyEye.target && !enemyAttackArea.isAttack && !isDeath)
        {
            //�����ϸ� rotation�� x���� -90���� �ٴڿ� ������ �÷��̾ �Ĵٺ�...�����ϱ����� y�� �� ������ ������
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

    //������ɶ��� ����
    public void ResetCharacter()
    {
        Hitpoint = startHp;
        isDeath = false;
    }

    //���������� �������� �޴� �޼���
    public void DamageCharacter(float damage)
    {
        Hitpoint -= damage;
        
        StartCoroutine(OnDamaged());
        if (Hitpoint <= float.Epsilon) //float.Epsilon�� 0���� ū ���� ���� ����� ���� ��Ÿ��
        {
            isDeath = true;
            eye.enabled = false;
            wanderArea.enabled = false;
            gameObject.layer = 18;

            
            //item.DropItem();
        }
    }

    //Ȱ��ȭ�Ǹ� ������� ���� �ʱ�ȭ��
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
