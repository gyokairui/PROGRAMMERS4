using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Unity��UI�ibutton�Ȃǂ̋@�\�j���g�p���邨�܂��Ȃ�

public class PopupScript : MonoBehaviour
{
    public GameObject Popup;//Popup�Ƃ����Q�[���I�u�W�F�N�g��錾����

    // Use this for initialization

    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {

    }

    //Appear�֐����Ăяo�����ƃ|�b�v�A�b�v���\�������
    public void Appear()
    {
        Popup.SetActive(true);
    }

    //Delete�֐����Ăяo�����ƃ|�b�v�A�b�v����\���ɂȂ�
    public void Delete()
    {
        Popup.SetActive(false);
    }
}
