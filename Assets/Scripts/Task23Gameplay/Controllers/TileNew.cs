using UnityEngine;

public class TileNew : MonoBehaviour
{
    public TileItemNew Item { get; private set; }
    private void Awake() { Item = GetComponent<TileItemNew>(); }
}
