using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rigidbody;    // ������ �ٵ� �ҷ���
    public float speed = 10f;       // �̵� �ӵ�
    public float jumpHeight = 3f;   // ���� ����
    public float dash = 5f;         // �뽬 ���� 
    public float rotSpeed = 3f;     // ȸ�� �ӵ�

    private Vector3 dir = Vector3.zero; // �̵� ����


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();  // ������ �ٵ� ����
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");    // a�� dŰ �������� ���� ������
        dir.z = Input.GetAxis("Vertical");      // w�� sŰ �������� �� ��
        dir.Normalize();                        // �밢�� �̵� �ӵ� �����Ǵ� ������ ���ֱ� ���� ��� ���� �̵��ӵ��� 1�� ����
        
    }

    private void FixedUpdate()
    {
        if (dir != Vector3.zero)        // ������ ȸ��
        {
            transform.forward = Vector3.Lerp(transform.forward,dir,rotSpeed * Time.deltaTime);        // Ű���带 ���� �������� ȸ��
        }

        rigidbody.MovePosition(this.gameObject.transform.position + dir * speed * Time.deltaTime);
    }
}
