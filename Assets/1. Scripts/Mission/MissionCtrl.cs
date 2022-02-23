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
    //미션초기화
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
    // 성공하면 호출
    public void MissionSuccess(CircleCollider2D coll)
    {
        missionCount++;
        guage.value = (float)missionCount /7;

        //성공한 미션은 다시 플레이 못하게 
        coll.enabled = false;

        //성공여부 체크
        if (guage.value == 1)
        {
            text_amim.SetActive(true);
            Invoke("Change", 1f);
        }
    }
    //화면전환
    public void Change()
    {
        mainView.SetActive(true);
        gameObject.SetActive(false);

        //캐릭터 삭제 
        FindObjectOfType<PlayerCtrl>().DestroyPlayer();
    }

}