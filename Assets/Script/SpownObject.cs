using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpownObject : MonoBehaviour
{
    public static SpownObject Instance { get; private set; }
    public Tilemap tilemap;// ������Ʈ�� ���� �� �ִ� Ÿ�� ��
    public TileBase designateTile;// ������Ʈ�� ���� �� �ִ� Ÿ�� ����
    SpriteRenderer spriteRenderer;
    public GameObject spownObject;// ������ ������Ʈ


    // objectToSpawn�� �����ϱ�
    //public GameObject objectToSpawn;
    public List<GameObject> spawnedObjects = new List<GameObject>(); // ������ spownObject�� �迭�� ����

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ� �ν��Ͻ� ����
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

            // Ŭ���� ��ġ�� Ÿ���� designateTile�̰�, ���콺 ���� ��ư�� Ŭ��������, Ÿ���� null�� �ƴ� ���
            if (designateTile == tilemap.GetTile(new Vector3Int((int)MosPos.x, (int)MosPos.y, 0)) && Input.GetMouseButtonDown(0) && tilemap.GetTile(new Vector3Int((int)MosPos.x, (int)MosPos.y, 0)) != null)
            {
                // ������ �ִ��� üũ
                if (ObjectExistsAt(new Vector3Int((int)MosPos.x, (int)MosPos.y, 0)))
                {
                    //���ٸ�(false) ���� ���콺��ġ�� ����
                    GameObject newObj = Instantiate(spownObject, new Vector3Int((int)MosPos.x, (int)MosPos.y, 0), Quaternion.identity);
                    spawnedObjects.Add(newObj);


                }


            }
            spriteRenderer.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
        }

    }
    // ������ �ִ��� üũ1
    bool ObjectExistsAt(Vector3 position)
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null && (Vector3)obj.transform.position == position) // ��Ȯ�� ��ġ ��
            {
                return false;
            }
        }
        return true;
    }
}
