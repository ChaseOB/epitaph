using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Entity
{

    // Start is called before the first frame update
    protected override void Start()
    {
        //UPDATE LATER WITH UNIQUE BEHAVIOR, IF NEEDED
        base.Start();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    protected override void Update()
    {
        //UPDATE LATER WITH UNIQUE BEHAVIOR, IF NEEDED
        GameObject player = GameObject.FindWithTag("Player");
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < 1000)
        {
            StopEnemy(agent);
        }
        base.Update();
    }

    public void StopEnemy(UnityEngine.AI.NavMeshAgent agent)
    {
        agent.isStopped = true;
    }

    protected override void Die() {
        Destroy(gameObject);
    }

    public override void TakeDamage(float dmgAmt) {
        GameObject player = GameObject.FindWithTag("Player");
        base.TakeDamage(dmgAmt);
        //Knockback(player);
    }
}
