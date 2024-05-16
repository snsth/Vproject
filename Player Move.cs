using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rigidbody;    // 리지드 바디를 불러옴
    public float speed = 10f;       // 이동 속도
    public float jumpHeight = 3f;   // 점프 높이
    public float dash = 5f;         // 대쉬 구현 
    public float rotSpeed = 3f;     // 회전 속도

    private Vector3 dir = Vector3.zero; // 이동 방향


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();  // 리지드 바디를 연결
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");    // a나 d키 눌렀을때 왼쪽 오른쪽
        dir.z = Input.GetAxis("Vertical");      // w나 s키 눌렀을때 앞 뒤
        dir.Normalize();                        // 대각선 이동 속도 증가되는 현상을 없애기 위한 모든 방향 이동속도를 1로 지정
        
    }

    private void FixedUpdate()
    {
        if (dir != Vector3.zero)        // 서서히 회전
        {
            transform.forward = Vector3.Lerp(transform.forward,dir,rotSpeed * Time.deltaTime);        // 키보드를 누른 방향으로 회전
        }

        rigidbody.MovePosition(this.gameObject.transform.position + dir * speed * Time.deltaTime);
    }
}
