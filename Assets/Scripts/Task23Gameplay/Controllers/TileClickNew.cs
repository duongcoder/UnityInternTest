using UnityEngine;

public class TileClickNew : MonoBehaviour
{
    private TileManagerNew manager;
    private void Start() { manager = FindObjectOfType<TileManagerNew>(); }
    private void OnMouseDown() { manager.OnTileTapped(GetComponent<TileNew>()); }
}
