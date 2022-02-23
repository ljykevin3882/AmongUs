using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public bool isJoyStick;
    public Image touchBtn, joyStickBtn;
    public Color blue;
    public PlayerCtrl playerCtrl_script;

    GameObject mainView, playView;
    //������ư ������ ȣ��
    private void Start()
    {
        mainView = playerCtrl_script.mainView;
        playView = playerCtrl_script.playView;
    }
    public void ClickSetting()
    {
        gameObject.SetActive(true);
        playerCtrl_script.isCantMove = true;
    }

    //�������� ���ư��� ��ư�� ������ ȣ��
    public void ClickBack()
    {
        gameObject.SetActive(false);
        playerCtrl_script.isCantMove = false;
    }

    //��ġ�̵��� ������ ȣ��
    public void ClickTouch()
    {
        isJoyStick = false;
        touchBtn.color = blue;
        joyStickBtn.color = Color.white;
    }
    //���̽�ƽ�� ������ ȣ��
    public void ClickJoyStick()
    {
        isJoyStick = true;
        touchBtn.color = Color.white;
        joyStickBtn.color = blue;
    }
    //���� ������ ��ư ������ ȣ��
    public void ClickQuit()
    {
        mainView.SetActive(true);
        playView.SetActive(false);

        //ĳ���� ���� 
        playerCtrl_script.DestroyPlayer();
    }

}
