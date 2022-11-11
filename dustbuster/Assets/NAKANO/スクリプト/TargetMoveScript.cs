using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMoveScript : MonoBehaviour
{
	// ���x
	public Vector2 speed = new Vector2(0.01f, 0.01f);
	// �^�[�Q�b�g�ƂȂ�I�u�W�F�N�g
	public GameObject targetObject;
	// ���W�A���ϐ�
	private float rad;
	// ���݈ʒu��������ׂ̕ϐ�
	private Vector2 Position;

	public bool flg = false;

	
	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		//�S�~�͈͓̔��ɓ��違�v���C���[�̃S�~�e�ʂ��]���Ă���ƃS�~������
		if (flg && Player.DustFULL == false)
		{
			//GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
			// ���W�A��
			// atan2(�ڕW������y���W - �����ʒu��y���W, �ڕW������x���W - �����ʒu��x���W)
			// ����Ń��W�A�����o��B
			// ���̃��W�A����Cos��Sin�Ɏg���A����̕����֐i�ނ��Ƃ��o����B
			rad = Mathf.Atan2(
				targetObject.transform.position.y - transform.position.y,
				targetObject.transform.position.x - transform.position.x);
			// ���݈ʒu��Position�ɑ��
			Position = transform.position;
			// x += SPEED * cos(���W�A��)
			// y += SPEED * sin(���W�A��)
			// ����œ���̕����֌������Đi��ł����B
			Position.x += speed.x * Mathf.Cos(rad);
			Position.y += speed.y * Mathf.Sin(rad);
			// ���݂̈ʒu�ɉ��Z���Z���s����Position��������
			transform.position = Position;
		}
		else
			flg = false;

	}
}