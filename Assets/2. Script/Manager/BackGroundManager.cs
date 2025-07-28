using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundManager : MonoBehaviour
{
    public Transform tilemapA;
    public Transform tilemapB;
    private float scrollSpeed = 4f;

    private float tilemapHeight;

    void Start()
    {
        // 타일맵의 월드 기준 높이 자동 계산
        var tilemap = tilemapA.GetComponent<Tilemap>();
        if (tilemap != null)
        {
            Bounds bounds = tilemap.localBounds;
            tilemapHeight = bounds.size.y;
        }
        else
        {
            tilemapHeight = 14f; // 수동으로 지정할 경우 fallback
        }

        // tilemapA: (0, 0), tilemapB: 바로 위에
        tilemapA.position = new Vector3(0, 0, 0);
        tilemapB.position = new Vector3(0, tilemapHeight, 0);
    }

    void Update()
    {
        Vector3 move = Vector3.down * scrollSpeed * Time.deltaTime;

        tilemapA.position += move;
        tilemapB.position += move;

        if (tilemapA.position.y <= -tilemapHeight)
        {
            tilemapA.position += Vector3.up * tilemapHeight * 2;
        }

        if (tilemapB.position.y <= -tilemapHeight)
        {
            tilemapB.position += Vector3.up * tilemapHeight * 2;
        }
    }
}