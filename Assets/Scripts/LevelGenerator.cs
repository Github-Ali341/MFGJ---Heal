using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform levelPart_Parent;
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelParts;
    [SerializeField] private Transform player;

    private Vector3 _lastEndPosition;

    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 12.5F;

    private void Awake ()
    {
        _lastEndPosition = levelPart_Start.Find("EndPosition").position;

        int startLevelParts = 2;
        for (int i = 0; i < startLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update ()
    {
        if (player != null && Vector3.Distance(player.position, _lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart ()
    {
        Transform lastLevelPartTransform = SpawnLevelPart(levelParts[Random.Range(0, levelParts.Count)], _lastEndPosition);
        lastLevelPartTransform.parent = levelPart_Parent;
        _lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart (Transform levelPart, Vector3 position)
    {
        return Instantiate(levelPart, position, Quaternion.identity);
    }
}
