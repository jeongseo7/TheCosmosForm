using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpownObject : MonoBehaviour
{
    public static SpownObject Instance { get; private set; }
    public Tilemap tilemap;// 오브젝트를 심을 수 있는 타일 맵
    public TileBase designateTile;// 오브젝트를 심을 수 있는 타일 선정
    SpriteRenderer spriteRenderer;
    public GameObject spownObject;// 스폰할 오브젝트


    // objectToSpawn로 저장하기
    //public GameObject objectToSpawn;
    public List<GameObject> spawnedObjects = new List<GameObject>(); // 생성된 spownObject를 배열에 저장

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 중복 인스턴스 방지
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 MosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MosPos = new Vector2(Mathf.Round(MosPos.x), Mathf.Round(MosPos.y));
        transform.position = MosPos;


        if (Mathf.Abs(transform.localPosition.x) > 1.5f || Mathf.Abs(transform.localPosition.y) > 1.5f)
        {
            spriteRenderer.color = new Color(0.8867924f, 0.2718939f, 0.3070933f, 0.7f);
        }
        else
        {

            // 클릭한 위치의 타일이 designateTile이고, 마우스 왼쪽 버튼을 클릭했으며, 타일이 null이 아닌 경우
            if (designateTile == tilemap.GetTile(new Vector3Int((int)MosPos.x, (int)MosPos.y, 0)) && Input.GetMouseButtonDown(0) && tilemap.GetTile(new Vector3Int((int)MosPos.x, (int)MosPos.y, 0)) != null)
            {
                // 씨앗이 있는지 체크
                if (ObjectExistsAt(new Vector3Int((int)MosPos.x, (int)MosPos.y, 0)))
                {
                    //없다면(false) 씨앗 마우스위치에 생성
                    GameObject newObj = Instantiate(spownObject, new Vector3Int((int)MosPos.x, (int)MosPos.y, 0), Quaternion.identity);
                    spawnedObjects.Add(newObj);


                }


            }
            spriteRenderer.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
        }

    }
    // 씨앗이 있는지 체크1
    bool ObjectExistsAt(Vector3 position)
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null && (Vector3)obj.transform.position == position) // 정확한 위치 비교
            {
                return false;
            }
        }
        return true;
    }
}
