using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mission1 : MonoBehaviour
{
    public Color red;
    public Image[] images;
    Animator anim;
    PlayerCtrl playerCtrl_script;
    MissionCtrl missionCtrl_script;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        missionCtrl_script = FindObjectOfType<MissionCtrl>();
    }
    //�̼� ����
    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

        //�ʱ�ȭ
        for(int i = 0; i < images.Length; i++)
        {
            images[i].color = Color.white;
        }
        //���� �� ����
        for(int i = 0; i < 4; i++)
        {
            int rand = Random.Range(0, 7);
            images[rand].color = red;
        }
    }
    //������ư ������ ȣ��
    public void ClickCancel()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }
    //������ ��ư ������ ȣ��
    public void ClickButton()
    {
        Image img=EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        //���� �Ͼ���̸�
        if (img.color == Color.white)
        {
            img.color = red;
        }

        else
        {
            img.color = Color.white;
        }

        //���� ���� üũ
        int count = 0;
        for (int i = 0; i < images.Length; i++)
        {
            if (images[i].color == Color.white)
            {
                count++;
            }
        }
        if (count == images.Length)
        {
            //����
            Invoke("MissionSuccess", 0.2f); //0.2�� �� ȣ��
        }

    }
    //�̼� �����ϸ� ȣ���� �Լ�
    public void MissionSuccess()
    {
        ClickCancel();
        missionCtrl_script.MissionSuccess(GetComponent<CircleCollider2D>());
    }
}
