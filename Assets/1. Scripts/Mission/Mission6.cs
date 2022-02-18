using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mission6 : MonoBehaviour
{
    public bool[] isColor = new bool[4];
    Animator anim;
    PlayerCtrl playerCtrl_script;
    Vector2 clickpos;
    LineRenderer line;
    bool isDrag;
    float leftY, rightY;
    Color leftC, rightC;
    public RectTransform[] rights;
    public LineRenderer[] lines;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();


    }
    private void Update()
    {
        //�巡��
        if (isDrag)
        {
            line.SetPosition(1, new Vector3(Input.mousePosition.x - clickpos.x, Input.mousePosition.y - clickpos.y, -10));
            //�巡�� ����
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                //������
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject rightLine = hit.transform.gameObject;
                    //������ ��y��
                    rightY = rightLine.GetComponent<RectTransform>().anchoredPosition.y;
                    //������ �� ����
                    rightC = rightLine.GetComponent<Image>().color;
                    line.SetPosition(1, new Vector3(500, rightY - leftY, -10));

                    //�� ��
                    if (leftC == rightC)
                    {
                        switch (leftY)
                        {
                            case 225: isColor[0] = true; break;
                            case 75: isColor[1] = true; break;
                            case -75: isColor[2] = true; break;
                            case -225: isColor[3] = true; break;

                        }
                    }
                    else
                    {
                        switch (leftY)
                        {
                            case 225: isColor[0] = false; break;
                            case 75: isColor[1] = false; break;
                            case -75: isColor[2] = false; break;
                            case -225: isColor[3] = false; break;

                        }
                    }
                    //���� ���� üũ
                    if(isColor[0]&& isColor[1] && isColor[2] && isColor[3])
                    {
                        Invoke("MissionSuccess", 0.2f);
                    }
                }
                //����������
                else{
                line.SetPosition(1, new Vector3(0, 0, -10));

                
            }
                isDrag = false;
            }
        }
        
    }
    //�̼� ����
    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();
        //�ʱ�ȭ
        for(int i = 0; i < 4; i++)
        {
            isColor[i] = false;
            lines[i].SetPosition(1, new Vector3(0, 0, -10));
        }
        //����
        for(int i = 0; i < rights.Length; i++)
        {
            Vector3 temp = rights[i].anchoredPosition;
            int rand = Random.Range(0, 4);
            rights[i].anchoredPosition = rights[rand].anchoredPosition;

            rights[rand].anchoredPosition = temp;
        }
       
    }
    //������ư ������ ȣ��
    public void ClickCancel()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }
    //�� ������ ȣ��
    public void ClickLine(LineRenderer click)
    {
        clickpos = Input.mousePosition;
        line = click;
        //���ʼ� y��
        leftY = click.transform.parent.GetComponent<RectTransform>().anchoredPosition.y;
        //���� �� ����
        leftC = click.transform.parent.GetComponent<Image>().color;

        isDrag = true;
    }

    //�̼� �����ϸ� ȣ���� �Լ�
    public void MissionSuccess()
    {
        ClickCancel();
    }
}
