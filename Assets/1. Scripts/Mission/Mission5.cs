using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mission5 : MonoBehaviour
{
    public Transform rotate, handle;

    Animator anim;
    PlayerCtrl playerCtrl_script;
    RectTransform rect_handle;
    public Color blue, red;
    bool isDrag,isPlay;
    float rand;
    MissionCtrl missionCtrl_script;
    void Start()
    {
        missionCtrl_script = FindObjectOfType<MissionCtrl>();

        anim = GetComponentInChildren<Animator>();
        rect_handle = handle.GetComponent<RectTransform>();

    }
    private void Update()
    {
        if (isPlay == true)
        {
            //�巡��
            if (isDrag)
            {
                handle.position = Input.mousePosition;
                rect_handle.anchoredPosition = new Vector2(184, Mathf.Clamp(rect_handle.anchoredPosition.y, -195, 195));
                
                //�巡�� ����
                if (Input.GetMouseButtonUp(0))
                {
                    //�������� üũ
                    if(rect_handle.anchoredPosition.y>-5 && rect_handle.anchoredPosition.y < 5)
                    {
                        Invoke("MissionSuccess", 0.2f);
                        isPlay = true;
                    }
                    isDrag = false;

                }
            }

            rotate.eulerAngles = new Vector3(0, 0, 90 * rect_handle.anchoredPosition.y / 195);

            //�� ����
            if (rect_handle.anchoredPosition.y > -5 && rect_handle.anchoredPosition.y < 5)
            {
                rotate.GetComponent<Image>().color = blue;
            }
            else
            {
                rotate.GetComponent<Image>().color = red;
            }
        }
    }
    //�̼� ����
    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

        //�ʱ�ȭ
        rand = 0;
        //���� �ڵ�
        rand = Random.Range(-195, 195);
        while (rand >= -10 && rand <= 10)
        {
            rand = Random.Range(-195, 195);
        }
        rect_handle.anchoredPosition = new Vector2(184, rand);
        isPlay = true;
    }
    //������ư ������ ȣ��
    public void ClickCancel()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }
    //������ ������ ȣ��
    public void ClickHandle()
    {
        isDrag = true;
    }

    //�̼� �����ϸ� ȣ���� �Լ�
    public void MissionSuccess()
    {
        ClickCancel();
        missionCtrl_script.MissionSuccess(GetComponent<CircleCollider2D>());

    }
}
