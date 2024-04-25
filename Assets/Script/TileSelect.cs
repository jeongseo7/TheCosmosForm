using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


#region 타일
//public class TileSelect : MonoBehaviour
//{
//    public Tilemap tilemap;
//    public TileBase ChangeTile;
//    public TileBase SelectTile;
//    SpriteRenderer spriteRenderer;

//    Rigidbody2D rb;
//    public GameObject Seed;
//    private bool isField;

//     objectToSpawn로 저장하기
//    public GameObject objectToSpawn;
//    private List<GameObject> spawnedObjects = new List<GameObject>(); // 생성된 GameObject 저장

//     Start is called before the first frame update
//    void Awake()
//    {
//        isField = false;
//        spriteRenderer = GetComponent<SpriteRenderer>();
//        rb = GetComponent<Rigidbody2D>();
//    }
//     Update is called once per frame
//    void Update()
//    {
//        Vector2 MosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        MosPos = new Vector2(Mathf.Round(MosPos.x), Mathf.Round(MosPos.y));
//        transform.position = MosPos;

//        if (Mathf.Abs(transform.localPosition.x) > 1.5f || Mathf.Abs(transform.localPosition.y) > 1.5f)
//        {
//            spriteRenderer.color = new Color(0.8867924f, 0.2718939f, 0.3070933f, 0.7f);
//        }
//        else
//        {

//            Debug.Log($"{isField}");
//            if (Input.GetMouseButtonDown(0) && tilemap.GetTile(new Vector3Int((int)MosPos.x, (int)MosPos.y, 0)) != null)
//            {   // 타일 마우스위치에 생성
//                tilemap.SetTile(new Vector3Int((int)MosPos.x, (int)MosPos.y, 0), ChangeTile);
//                 이미 씨앗이 있는 상태거나 타일의 태그가 다르면
//                if (ObjectExistsAt(new Vector3Int((int)MosPos.x, (int)MosPos.y, 0)))
//                {
//                     씨앗 마우스위치에 생성
//                    GameObject newObj = Instantiate(Seed, new Vector3Int((int)MosPos.x, (int)MosPos.y, 0), Quaternion.identity);
//                    spawnedObjects.Add(newObj);
//                }

//            }
//            spriteRenderer.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
//        }

//    }
//    bool ObjectExistsAt(Vector3 position)
//    {
//        foreach (GameObject obj in spawnedObjects)
//        {
//            if (obj != null && (Vector3)obj.transform.position == position) // 정확한 위치 비교
//            {
//                return false;
//            }
//        }
//        return true;
//    }

//    private void OnTriggerStay2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Player")) return;
//        if (collision.tag == "Field")
//        {
//            isField = true;
//        }
//        else
//        {
//            isField = false;
//        }
//        Debug.Log($"{isField}");
//    }
//}
#endregion





public class TileSelect : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase ChangeTile;
    public TileBase SelectTile;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    // Update is called once per frame
    void Update()
    {
        Vector2 MosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MosPos = new Vector2(Mathf.Round(MosPos.x), Mathf.Round(MosPos.y));
        //마우스 위치와 포인트 위치
        transform.position = MosPos;

        if (Mathf.Abs(transform.localPosition.x) > 1.5f || Mathf.Abs(transform.localPosition.y) > 1.5f)
        { // 위의 범위를 벗어날 시 컬러 변함
            spriteRenderer.color = new Color(0.8867924f, 0.2718939f, 0.3070933f, 0.7f);
        }
        else
        {   
            if (Input.GetMouseButton(0) && tilemap.GetTile(new Vector3Int((int)MosPos.x, (int)MosPos.y, 0)) != null)
            {   // 타일 마우스위치에 생성
                tilemap.SetTile(new Vector3Int((int)MosPos.x, (int)MosPos.y, 0), ChangeTile);
            }
            spriteRenderer.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
        }

    }

}
