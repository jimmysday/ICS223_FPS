using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private bool isAlive = true;
    public void ReactToHit()
    {
        WanderingAI enemyAI = GetComponent<WanderingAI>();
        if (enemyAI != null && isAlive)
        {
            enemyAI.ChangeState(EnemyStates.dead);
            isAlive = false;
            Messenger.Broadcast(GameEvent.ENEMY_DEAD);
        }
        //StartCoroutine(Die());

        Animator enemyAnimator = GetComponent<Animator>();
        if (enemyAnimator != null)
        {
            enemyAnimator.SetTrigger("Die");
        }
    }
    private IEnumerator Die()
    {
        // Enemy falls over and disappears after two seconds
        //iTween.RotateAdd(this.gameObject, new Vector3(-75, 0, 0), 1);

        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    private void DeadEvent()
    {   
        Destroy(this.gameObject);
    }
}
