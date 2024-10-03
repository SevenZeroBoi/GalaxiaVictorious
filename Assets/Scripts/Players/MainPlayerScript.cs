using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MainPlayerScript : MonoBehaviour
{
    [Header("Character Details")]
    public string characterName;
    public float characterHealth;
    public float characterMoveSpeed;
    [HideInInspector] public float currentMoveSpeed;
    public Animator characterAnim;
    [HideInInspector] public int _movementAnim; //0 - Idle/1 - MoveFront/-1 - MoveBack

    [Header("Skill Slots")]
    public SO_PlayerBullets SkillSlot0;
    public SO_PlayerBullets SkillSlot1;
    public SO_PlayerBullets SkillSlot2;

    [HideInInspector] public float skillCooldown;
    [HideInInspector] public float currentSkillCooldown;
    [HideInInspector] public bool isSkillOnCooldown = false;

    void Movements()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        transform.position = transform.position + new Vector3(moveX, moveY).normalized * Time.deltaTime * currentMoveSpeed;

        characterAnim.SetInteger("Movement", _movementAnim);
        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            _movementAnim = 0;
        }
        else if (Input.GetAxisRaw("Vertical") == 1 && Input.GetAxisRaw("Horizontal") == -1)
        {
            _movementAnim = -1;
        }
        else if (Input.GetAxisRaw("Vertical") == 1 || (Input.GetAxisRaw("Vertical") != 1 && Input.GetAxisRaw("Horizontal") == 1))
        {
            _movementAnim = 1;
        }
        else if (Input.GetAxisRaw("Vertical") == -1 || (Input.GetAxisRaw("Vertical") != -1 && Input.GetAxisRaw("Horizontal") == -1))
        {
            _movementAnim = -1;
        }
    }

    public void Start()
    {
        currentMoveSpeed = characterMoveSpeed;
    }

    public void Update()
    {
        if (StatesManager.instance.currentGameStates == StatesManager.GameStatesList.PLAYING)
        {
            Movements();
            SkillControlling();
        }
    }

    public virtual void SkillControlling()
    {
        if (!isSkillOnCooldown)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                UsingSkillSlot0();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                UsingSkillSlot1();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                UsingSkillSlot2();
            }
        }
    }

    public void CooldownChecking()
    {
        if (isSkillOnCooldown)
        {
            currentSkillCooldown += Time.deltaTime;
            if (currentSkillCooldown >= skillCooldown)
            {
                isSkillOnCooldown = false;
            }
        }
    }

    public virtual void UsingSkillSlot0()
    {
        GameObject skillObject = PoolingManager.instance.GetFromPool(SkillSlot0.bulletName, SkillSlot0.bulletObject, transform.position, Quaternion.identity);
        characterAnim.SetTrigger("UseSkill0");
        skillCooldown = SkillSlot0.bulletCooldown;
        currentSkillCooldown = 0;
        isSkillOnCooldown = true;
    }
    public virtual void UsingSkillSlot1()
    {
        GameObject skillObject = PoolingManager.instance.GetFromPool(SkillSlot1.bulletName, SkillSlot1.bulletObject, transform.position, Quaternion.identity);
        characterAnim.SetTrigger("UseSkill1");
        skillCooldown = SkillSlot1.bulletCooldown;
        currentSkillCooldown = 0;
        isSkillOnCooldown = true;

    }
    public virtual void UsingSkillSlot2()
    {
        GameObject skillObject = PoolingManager.instance.GetFromPool(SkillSlot2.bulletName, SkillSlot2.bulletObject , transform.position, Quaternion.identity);
        characterAnim.SetTrigger("UseSkill2");
        skillCooldown = SkillSlot2.bulletCooldown;
        currentSkillCooldown = 0;
        isSkillOnCooldown = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyAttack")
        {
            characterHealth--;
            DamageTrigger();
        }
    }

    void DamageTrigger()
    {
        characterAnim.SetTrigger("GotHit");
    }

    void DeathTrigger()
    {
        characterAnim.SetTrigger("Death");
    }
}
