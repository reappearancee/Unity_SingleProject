using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyStats enemyStats;
    private Vector3 moveDirection = Vector3.down; // 기본값 (혹시라도 설정 안 됐을 때 대비)

    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
    }
    
    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
    }

    void Update()
    {
        transform.position += moveDirection * enemyStats.moveSpeed * Time.deltaTime;
    }
    
    //플레이어와 충돌
    //피격시 넉백(슈팅에 넣을지, 여기에 넣을지 모르겠음)
}
