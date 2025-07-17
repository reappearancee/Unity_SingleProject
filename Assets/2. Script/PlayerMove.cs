using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float mvSpeed = 5f;
    private int moveDirection = 0; // -1: left, 1: right, 0: idle

    void Update()
    {
        Vector3 movement = new Vector3(moveDirection * mvSpeed * Time.deltaTime, 0, 0);
        transform.Translate(movement);
    }

    // 버튼에서 호출할 함수
    public void MoveLeft()
    {
        moveDirection = -1;
    }

    public void MoveRight()
    {
        moveDirection = 1;
    }

    public void StopMove()
    {
        moveDirection = 0;
    }
    
}
