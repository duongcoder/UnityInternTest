using UnityEngine;
using System.Collections;

public class TileItemNew : MonoBehaviour
{
    public string Type;
    [SerializeField] private SpriteRenderer sr;

    public void SetSprite(Sprite s) { sr.sprite = s; }
    public void ClearWithScaleDown()
    {
        if (this == null) return;

        StartCoroutine(ClearRoutine());
    }

    private IEnumerator ClearRoutine()
    {
        float t = 0;
        while (t < 1f)
        {
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, t);
            t += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
