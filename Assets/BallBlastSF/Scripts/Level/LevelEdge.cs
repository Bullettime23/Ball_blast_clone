using UnityEngine;

public enum EdgeType {
    Left,
    Right,
    Bottom,
    }
public class LevelEdge : MonoBehaviour
{
    [SerializeField] private EdgeType edgeType;

    public EdgeType Type => edgeType;
}
