using System.Collections.Generic;
using UnityEngine;

public class BottomBarNew : MonoBehaviour
{
    [SerializeField] private Transform[] slots;
    private List<TileItemNew> items = new List<TileItemNew>();
    private GameManagerNew gm;

    public void Setup(GameManagerNew gameManager) { gm = gameManager; }
    public void ResetBar() { foreach (var it in items) if (it) Destroy(it.gameObject); items.Clear(); }

    public void AddItem(TileItemNew it)
    {
        if (gm.CurrentState == GameManagerNew.State.Game && GetFirstEmptySlotIndex() == -1)
        {
            gm.OnBottomBarFull();
            return;
        }
        items.Add(it);

        int idx = GetFirstEmptySlotIndex();
        Transform target = slots[idx];
        it.transform.SetParent(target);

        it.transform.localPosition = Vector3.zero;
        it.transform.localScale = Vector3.one;

        var sr = it.GetComponent<SpriteRenderer>();
        if (sr != null) sr.sortingOrder = 10;

        TryClearMatches();
    }

    private int GetFirstEmptySlotIndex()
    {
        for (int i = 0; i < slots.Length - 1; i++)
            if (slots[i].childCount == 0) return i;
        return -1;
    }

    private void TryClearMatches()
    {
        if (items.Count < 3) return;

        Dictionary<string, List<TileItemNew>> groups = new Dictionary<string, List<TileItemNew>>();

        foreach (var it in items)
        {
            if (!groups.ContainsKey(it.Type))
                groups[it.Type] = new List<TileItemNew>();

            groups[it.Type].Add(it);
        }

        foreach (var kvp in groups)
        {
            if (kvp.Value.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    var tile = kvp.Value[i];
                    items.Remove(tile);
                    tile.transform.SetParent(null);
                    tile.ClearWithScaleDown();
                }
                CompactSlots();
                break;
            }
        }
    }

    private void CompactSlots()
    {
        foreach (var it in items)
        {
            if (it != null) it.transform.SetParent(null);
        }

        int write = 0;
        foreach (var it in items)
        {
            if (write >= slots.Length) break;
            Transform target = slots[write];
            it.transform.SetParent(target);
            it.transform.localPosition = Vector3.zero;
            it.transform.localScale = Vector3.one;

            var sr = it.GetComponent<SpriteRenderer>();
            if (sr != null) sr.sortingOrder = 10;

            write++;
        }

        for (int i = write; i < slots.Length; i++)
        {
            while (slots[i].childCount > 0)
                DestroyImmediate(slots[i].GetChild(0).gameObject);
        }
    }

    public void OnBottomItemTapped(TileItemNew it)
    {
        if (gm.CurrentState != GameManagerNew.State.TimeAttack) return;
        items.Remove(it);
        FindObjectOfType<TileManagerNew>().ReturnItemToBoard(it);
    }
}
