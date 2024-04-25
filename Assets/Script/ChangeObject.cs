using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeObject : MonoBehaviour
{

  
    public Tilemap tilemap;// 오브젝트를 심을 수 있는 타일 맵
    SpriteRenderer spriteRenderer;
    private GameObject destoryObject;//만들어졌던 오브젝트(지울 오브젝트)
    public GameObject spownObject;// 스폰할 오브젝트

    // objectToSpawn로 저장하기
    //public GameObject objectToSpawn;
    //public List<GameObject> spawnedObjects = new List<GameObject>(); // 생성된 spownObject를 배열에 저장

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
            //캘 수 없을 때
            spriteRenderer.color = new Color(0.8867924f, 0.2718939f, 0.3070933f, 0.7f);
        }
        else
        {

            //캘 수 있을때
            Debug.Log("0");
            // 클릭한 위치의 타일이 designateTile이고, 마우스 왼쪽 버튼을 클릭했으며, 타일이 null이 아닌 경우
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
                        //destoryObject.transform.parent.gameObject.SetActive(false);//아이템을 삭제한다
                    }
                }
            }
            spriteRenderer.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
        }
    }
    // 씨앗이 있는지 체크
    bool ObjectExistsAt(Vector3 position)
    {
        foreach (GameObject obj in SpownObject.Instance.spawnedObjects)
        {
            if (obj == null) continue;

            if (obj != null && (Vector3)obj.transform.position == position) // 정확한 위치 비교
            //(obj != null)
            {
                destoryObject = obj;
                return true; // 있다
            }
        }
        return false;// 없다
    }

    
    void Changeobject()
    {
        // destoryObject.SetActive(false);
       
    }




}



