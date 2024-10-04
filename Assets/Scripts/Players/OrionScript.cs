using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrionScript : MainPlayerScript
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    public override void SkillControlling()
    {
        if (!isSkillOnCooldown)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                characterAnim.SetTrigger("Shooting");
                cooldown = 0;
                checkb1cooldown = true;
            }
            if (Input.GetKey(KeyCode.J))
            {
                UsingSkillSlot0();
            }
            if (Input.GetKeyUp(KeyCode.J))
            {
                characterAnim.SetTrigger("StopShooting");
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

    bool checkb1cooldown = false;
    float cooldown = 0;
    public override void UsingSkillSlot0()
    {
        if (checkb1cooldown)
        {
            GameObject skillObject = PoolingManager.instance.GetFromPool(SkillSlot0.bulletName, SkillSlot0.bulletObject, transform.position, Quaternion.identity);
            checkb1cooldown = false;
        }
        else
        {
            thisBulletCooldown();
        }
    }

    public void thisBulletCooldown()
    {
        cooldown += Time.deltaTime;
        if (cooldown >= SkillSlot0.bulletCooldown)
        {
            //Debug.Log("checking");
            cooldown = 0;
            checkb1cooldown = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
