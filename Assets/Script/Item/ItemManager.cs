using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemManager : MonoBehaviour
{

    public GameObject[] item; //�������� ����Ǵ� �迭
    public int currentItemIndex = 0; //���� �������� �ε���

    // Ȱ��ȭ �ɶ����� ȣ��Ǵ� �Լ�
    //�������� Ȱ��ȭ�ϴ� �Լ�
    private void OnEnable()
    {
        //inputsystem�� �׼��� �����ϴ� ���� ������ �Ҵ�
        var inputActionAsset = GetComponent<PlayerInput>().actions;
        //input �ý����� �Է� �׼��� ItemScroll�� ã�� �� ���� scrollAction������ �Ҵ���
        var scrollAction = inputActionAsset.FindActionMap("Player").FindAction("Weapon Scroll");
        //������ Ȱ��ȭ
        scrollAction.Enable();
        scrollAction.performed += ScrollPerformed;//input�ý����� ����� �� ScrollPerformed �Լ��� ����ϱ� ���� ����
    }
    // InputAction.CallbackContext context == �÷��̾ �Է��� ��Ȳ�� ó���ϴ� ��
    // ���콺 �Է����� ��������ȯ�� �����ϴ� �Լ�
    private void ScrollPerformed(InputAction.CallbackContext context)
    {
        // �Էµ� ���� float Ÿ������ �д� ��
        float scrollValue = context.ReadValue<float>();
        //���� �Էµ� ���� 0 ���� ũ�� (��ũ���� +Y��)
        if (scrollValue > 0)
        {   // �ε��� ���� 1�� ���ϸ�
            SwitchItem(1); //���� �ε���(������)���� ����
        }
        //���� �Էµ� ���� 0 ���� ������(��ũ���� -Y��)
        else if (scrollValue < 0)
        {   // �ε��� ���� 1�� ����
            SwitchItem(-1); //���� �ε���(������)���� ����
        }
    }
    // ��������ȯ�� ���� �ε����� �����ϴ� �Լ�
    //dir�� ���� ���� ��ũ���� �� 1,-1 
    private void SwitchItem(int dir)
    {      //���� �ε����� dir�� ���� ���� ��
        currentItemIndex += dir;
        //���� ���� �ε����� �����۹迭���� ũ�� �ε����� 0�̵ȴ�. 
        if (currentItemIndex >= item.Length) currentItemIndex = 0;
        //���� ���� �ε����� 0���� �۴ٸ� �������� �迭�� �������� �ȴ�. 
        // ���� �ε����� -1�� �Ǹ� �迭�� ũ�Ⱑ �����ϰ� -1�� �������迭�� �ȴ�.
        // item.Length - 1�� �Ͽ� ���������� ������ -1�� �迭���� ���� �ϰ� �Ǵ� ��
        else if (currentItemIndex < 0) currentItemIndex = item.Length - 1;
        //������ ũ�⸸ŭ �ݺ�
        for (int i = 0; i < item.Length; i++)
        {
            // i�� �ε����� ���� �� i�� ������ Ȱ��ȭ
            item[i].SetActive(i== currentItemIndex);
        }
        
    }
    //��Ȱ��ȭ �ɶ����� ȣ��Ǵ� �Լ�
    private void OnDisable()
    {
       var inputActionAsset = GetComponent<PlayerInput>().actions;
        var scrollAction = inputActionAsset.FindActionMap("Player").FindAction("Weapon Scroll");
        scrollAction.Disable();// input Action ��Ȱ��ȭ
        scrollAction.performed -= ScrollPerformed;//��������


    }


    #region �ٸ� ���

    ////�ε����� 0����
    //public float switchDelay = 1f;
    //public GameObject[] item; //�������� ����Ǵ� �迭
    //private int index = 0;
    //// �����ߴ�? = �ƴϿ�..
    //private bool isSwitching = false;
    //private void Start()
    //{
    //    //���� Ȱ��ȭ ��Ȱ��ȭ �Լ�
    //    InitializeItem();
    //}

    //private void Update()
    //{
    //    // ���� ���콺 ���� �������� �� 0���� ũ�ų� �������� �ʾ�����
    //    if(Input.GetAxis("Mouse ScrollWheel") > 0 && !isSwitching)
    //    {
    //        //�ε����� ��µǰ�
    //        index++;
    //        //�ξ� index�� ������ �迭�� ũ�⺸�� ũ�ٸ�
    //        if(index >= item.Length)
    //        // index�� 0�̴�
    //        // index�� 0�̴�
    //            index = 0;
    //        // SwitchDelay �� 0 
    //        StartCoroutine(SwitchDelay(index));
    //    }
    //    // ���� ���콺 ���� �������� �� 0���� �۰ų� �������� �ʾ�����
    //    if (Input.GetAxis("Mouse ScrollWheel") < 0 && !isSwitching)
    //    {
    //        //�ε����� ���ҵǰ�
    //        index--;
    //        //�ε����� 0���� ������
    //        if(index < 0)
    //        {
    //            //�ε����� ������ ũ���� -1 �̰�
    //            index = item.Length - 1;
    //            // SwitchDelay �� -1 
    //            StartCoroutine(SwitchDelay(index));
    //        }
    //    }

    //    // GetKeyDown�� 49~ 58 == ���� Ű���� 0���� 9����
    //    // i �� 49 �̰�, i�� 58���� �ݺ�(9��)
    //    for (int i = 49; i < 58; i++)
    //    {   // KeyCode�� i�̰� �������� �ʾҰ�, �����۹迭�� i-49���� ũ��, �ε����� i - 49�� �ƴҶ�
    //        if (Input.GetKeyDown((KeyCode)i) && !isSwitching && item.Length > i-49 && index != i-49)
    //        {
    //            // index�� i- 49�̴�
    //            index = i - 49;
    //            // SwitchDelay �� i -49
    //            StartCoroutine(SwitchDelay(index));
    //        }
    //    }
    //}
    //private void InitializeItem()
    //{   //������ ũ�Ⱑ i���� ���� �� �ݺ�
    //    for (int i = 0; i < item.Length; i++)
    //    {
    //      // �������� �ε����� i�϶�(0�� �ƴ� ��) false
    //      //SetActive = ���� ������Ʈ�� Ȱ��ȭ,��Ȱ��ȭ �ϴ� �Լ�
    //      //������Ʈ ��Ȱ��ȭ
    //      item[i].SetActive(false);

    //    }
    //    // �������� �ε����� 0�϶� true
    //    //������Ʈ�� Ȱ��ȭ
    //    item[0].SetActive(true);
    //    index = 0;
    //}

    //// �ڷ�ƾ�� �񵿱����� �۾��� �Ҷ� �����ϴ�
    //// �񵿱����� �۾��̶�
    ////ex) ���� �ϳ��� �ٿ� �ް� �������� �Ѿ - �������� �۾�
    ////ex) ������ �ٿ� ������ �������� ������ ���ÿ� �ٿ� - �񵿱����� �۾�

    //// ���� �� �����̸� �ִ� �Լ�
    //private IEnumerator SwitchDelay(int newIndex)
    //{
    //    // ����ǰ�
    //    isSwitching = true;
    //    //�������� �����ϰ�
    //    SwitchItem(newIndex);
    //    // �������ְ�
    //    yield return new WaitForSeconds(newIndex);
    //    //�������� �������� false�� ��ȯ
    //    isSwitching = false;
    //}

    ////�������� ����(����)�ϴ� �Լ�(������)
    //private void SwitchItem(int newIndex)
    //{
    //    // i�� 0�̰�,i�� item�� ũ�⺸�� ���� ��
    //    for(int i = 0; i < item.Length;i++)
    //    {
    //        // �������� Ȱ��ȭ �Ѵ�
    //        item[i].SetActive(true);
    //    }
    //    // �������� ��Ȱ��ȭ �Ѵ�.
    //    item[0].SetActive(false);
    //}
    #endregion
}

