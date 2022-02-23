using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionCtrl : MonoBehaviour
{
    public Slider guage;
    public CircleCollider2D[] colls;
    int missionCount;
    public GameObject text_amim,mainView;
    //�̼��ʱ�ȭ
    public void MissionReset()
    {
        guage.value = 0;
        missionCount = 0;
        for(int i = 0; i < colls.Length; i++)
        {
            colls[i].enabled = true;
        }
        text_amim.SetActive(false);
    }
    // �����ϸ� ȣ��
    public void MissionSuccess(CircleCollider2D coll)
    {
        missionCount++;
        guage.value = (float)missionCount /7;

        //������ �̼��� �ٽ� �÷��� ���ϰ� 
        coll.enabled = false;

        //�������� üũ
        if (guage.value == 1)
        {
            text_amim.SetActive(true);
            Invoke("Change", 1f);
        }
    }
    //ȭ����ȯ
    public void Change()
    {
        mainView.SetActive(true);
        gameObject.SetActive(false);

        //ĳ���� ���� 
        FindObjectOfType<PlayerCtrl>().DestroyPlayer();
    }

}