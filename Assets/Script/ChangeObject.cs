using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeObject : MonoBehaviour
{

  
    public Tilemap tilemap;// ������Ʈ�� ���� �� �ִ� Ÿ�� ��
    SpriteRenderer spriteRenderer;
    private GameObject destoryObject;//��������� ������Ʈ(���� ������Ʈ)
    public GameObject spownObject;// ������ ������Ʈ

    // objectToSpawn�� �����ϱ�
    //public GameObject objectToSpawn;
    //public List<GameObject> spawnedObjects = new List<GameObject>(); // ������ spownObject�� �迭�� ����

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //destoryObject = GetComponent<GameObject>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 MosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MosPos = new Vector2(Mathf.Round(MosPos.x), Mathf.Round(MosPos.y));
        transform.position = MosPos;

        if (Mathf.Abs(transform.localPosition.x) > 1.5f || Mathf.Abs(transform.localPosition.y) > 1.5f)
        {
            //Ķ �� ���� ��
            spriteRenderer.color = new Color(0.8867924f, 0.2718939f, 0.3070933f, 0.7f);
        }
        else
        {

            //Ķ �� ������
            Debug.Log("0");
            // Ŭ���� ��ġ�� Ÿ���� designateTile�̰�, ���콺 ���� ��ư�� Ŭ��������, Ÿ���� null�� �ƴ� ���
            if (Input.GetMouseButtonDown(0) && tilemap.GetTile(new Vector3Int((int)MosPos.x, (int)MosPos.y, 0)) != null)
            {
                Debug.Log("1");
                if (ObjectExistsAt(new Vector3Int((int)MosPos.x, (int)MosPos.y, 0)))
                {
                    Debug.Log("2");
                    if (destoryObject != null)
                    {
                        Debug.Log("3");
                        Destroy(destoryObject);

                        // GameObject newObj = Instantiate(spownObject, new Vector3Int((int)MosPos.x, (int)MosPos.y, 0), Quaternion.identity);
                        //SpownStone.Instance.spawnedObjects.Add(newObj);

                        Instantiate(spownObject, new Vector3Int((int)MosPos.x, (int)MosPos.y, 0), Quaternion.identity);

                        //Changeobject();
                        //destoryObject.transform.parent.gameObject.SetActive(false);//�������� �����Ѵ�
                    }
                }
            }
            spriteRenderer.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
        }
    }
    // ������ �ִ��� üũ
    bool ObjectExistsAt(Vector3 position)
    {
        foreach (GameObject obj in SpownObject.Instance.spawnedObjects)
        {
            if (obj == null) continue;

            if (obj != null && (Vector3)obj.transform.position == position) // ��Ȯ�� ��ġ ��
            //(obj != null)
            {
                destoryObject = obj;
                return true; // �ִ�
            }
        }
        return false;// ����
    }

    
    void Changeobject()
    {
        // destoryObject.SetActive(false);
       
    }




}



