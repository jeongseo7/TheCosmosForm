using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemManager : MonoBehaviour
{

    public GameObject[] item; //아이템이 저장되는 배열
    public int currentItemIndex = 0; //현재 아이템의 인덱스

    // 활성화 될때마다 호출되는 함수
    //아이템을 활성화하는 함수
    private void OnEnable()
    {
        //inputsystem의 액션을 참조하는 것을 변수에 할당
        var inputActionAsset = GetComponent<PlayerInput>().actions;
        //input 시스템의 입력 액션인 ItemScroll을 찾고 그 것을 scrollAction변수에 할당함
        var scrollAction = inputActionAsset.FindActionMap("Player").FindAction("Weapon Scroll");
        //아이템 활성화
        scrollAction.Enable();
        scrollAction.performed += ScrollPerformed;//input시스템을 사용할 때 ScrollPerformed 함수를 사용하기 위해 연결
    }
    // InputAction.CallbackContext context == 플레이어가 입력한 상황을 처리하는 것
    // 마우스 입력으로 아이템전환을 설정하는 함수
    private void ScrollPerformed(InputAction.CallbackContext context)
    {
        // 입력된 값을 float 타입으로 읽는 것
        float scrollValue = context.ReadValue<float>();
        //만약 입력된 값이 0 보다 크면 (스크롤을 +Y축)
        if (scrollValue > 0)
        {   // 인덱스 값에 1을 더하며
            SwitchItem(1); //다음 인덱스(아이템)으로 변경
        }
        //만약 입력된 값이 0 보다 작으면(스크롤을 -Y축)
        else if (scrollValue < 0)
        {   // 인덱스 값에 1을 빼며
            SwitchItem(-1); //이전 인덱스(아이템)으로 변경
        }
    }
    // 아이템전환을 위한 인덱스를 관리하는 함수
    //dir에 들어가는 수는 스크롤할 시 1,-1 
    private void SwitchItem(int dir)
    {      //현재 인덱스는 dir의 값을 합한 값
        currentItemIndex += dir;
        //만약 현재 인덱스가 아이템배열보다 크면 인덱스는 0이된다. 
        if (currentItemIndex >= item.Length) currentItemIndex = 0;
        //만약 현재 인덱스가 0보다 작다면 아이템의 배열의 마지막이 된다. 
        // 현재 인덱스가 -1이 되면 배열의 크기가 증가하고 -1이 마지막배열이 된다.
        // item.Length - 1을 하여 마지막으로 생성된 -1을 배열에서 제거 하게 되는 것
        else if (currentItemIndex < 0) currentItemIndex = item.Length - 1;
        //아이템 크기만큼 반복
        for (int i = 0; i < item.Length; i++)
        {
            // i가 인덱스와 같을 때 i의 아이템 활성화
            item[i].SetActive(i== currentItemIndex);
        }
        
    }
    //비활성화 될때마다 호출되는 함수
    private void OnDisable()
    {
       var inputActionAsset = GetComponent<PlayerInput>().actions;
        var scrollAction = inputActionAsset.FindActionMap("Player").FindAction("Weapon Scroll");
        scrollAction.Disable();// input Action 비활성화
        scrollAction.performed -= ScrollPerformed;//연결해제


    }


    #region 다른 방식

    ////인덱스는 0부터
    //public float switchDelay = 1f;
    //public GameObject[] item; //아이템이 저장되는 배열
    //private int index = 0;
    //// 변경했니? = 아니요..
    //private bool isSwitching = false;
    //private void Start()
    //{
    //    //무기 활성화 비활성화 함수
    //    InitializeItem();
    //}

    //private void Update()
    //{
    //    // 만약 마우스 휠을 움직였을 때 0보다 크거나 변경하지 않았을때
    //    if(Input.GetAxis("Mouse ScrollWheel") > 0 && !isSwitching)
    //    {
    //        //인덱스는 상승되고
    //        index++;
    //        //민약 index가 아이템 배열의 크기보다 크다면
    //        if(index >= item.Length)
    //        // index는 0이다
    //        // index는 0이다
    //            index = 0;
    //        // SwitchDelay 는 0 
    //        StartCoroutine(SwitchDelay(index));
    //    }
    //    // 만약 마우스 휠을 움직였을 때 0보다 작거나 변경하지 않았을때
    //    if (Input.GetAxis("Mouse ScrollWheel") < 0 && !isSwitching)
    //    {
    //        //인덱스는 감소되고
    //        index--;
    //        //인덱스가 0보다 작을때
    //        if(index < 0)
    //        {
    //            //인덱스는 아이템 크기의 -1 이고
    //            index = item.Length - 1;
    //            // SwitchDelay 는 -1 
    //            StartCoroutine(SwitchDelay(index));
    //        }
    //    }

    //    // GetKeyDown의 49~ 58 == 숫자 키보드 0부터 9까지
    //    // i 가 49 이고, i가 58까지 반복(9번)
    //    for (int i = 49; i < 58; i++)
    //    {   // KeyCode가 i이고 변경하지 않았고, 아이템배열이 i-49보다 크고, 인덱스가 i - 49가 아닐때
    //        if (Input.GetKeyDown((KeyCode)i) && !isSwitching && item.Length > i-49 && index != i-49)
    //        {
    //            // index는 i- 49이다
    //            index = i - 49;
    //            // SwitchDelay 는 i -49
    //            StartCoroutine(SwitchDelay(index));
    //        }
    //    }
    //}
    //private void InitializeItem()
    //{   //아이템 크기가 i보다 작을 때 반복
    //    for (int i = 0; i < item.Length; i++)
    //    {
    //      // 아이템의 인덱스가 i일때(0이 아닐 때) false
    //      //SetActive = 게임 오브젝트를 활성화,비활성화 하는 함수
    //      //오브젝트 비활성화
    //      item[i].SetActive(false);

    //    }
    //    // 아이템의 인덱스가 0일때 true
    //    //오브젝트가 활성화
    //    item[0].SetActive(true);
    //    index = 0;
    //}

    //// 코루틴은 비동기적인 작업을 할때 유용하다
    //// 비동기적인 작업이란
    ////ex) 파일 하나를 다운 받고 다음으로 넘어감 - 동기적인 작업
    ////ex) 파일을 다운 받을때 여러가지 파일을 동시에 다운 - 비동기적인 작업

    //// 변경 후 딜레이를 주는 함수
    //private IEnumerator SwitchDelay(int newIndex)
    //{
    //    // 변경되고
    //    isSwitching = true;
    //    //아이템을 변경하고
    //    SwitchItem(newIndex);
    //    // 딜레이주고
    //    yield return new WaitForSeconds(newIndex);
    //    //아이템을 변경함을 false로 전환
    //    isSwitching = false;
    //}

    ////아이템을 선택(변경)하는 함수(로추정)
    //private void SwitchItem(int newIndex)
    //{
    //    // i가 0이고,i가 item의 크기보다 작을 때
    //    for(int i = 0; i < item.Length;i++)
    //    {
    //        // 아이템을 활성화 한다
    //        item[i].SetActive(true);
    //    }
    //    // 아이템을 비활성화 한다.
    //    item[0].SetActive(false);
    //}
    #endregion
}

