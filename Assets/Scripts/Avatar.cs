using UnityEngine;

public class Avatar : MonoBehaviour
{
    public float speed = 6f;
    public bool CanPick;
    public bool WillAffect;

    void FixedUpdate()
    {
        MoveWithKeys();
        LookAtCursor();
    }

    void MoveWithKeys()
    {
        var up = Input.GetKey(KeyCode.W);
        var down = Input.GetKey(KeyCode.S);
        var left = Input.GetKey(KeyCode.A);
        var right = Input.GetKey(KeyCode.D);

        var horizontal = left ? -1 : right ? 1 : 0;
        var vertical = down ? -1 : up ? 1 : 0;

        transform.position += new Vector3(horizontal, 0, vertical).normalized * speed * Time.deltaTime;
    }

    void LookAtCursor()
    {
        var cursorPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        var screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        var angle = Mathf.Atan2(cursorPosition.y - screenPosition.y, screenPosition.x - cursorPosition.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0f, angle - 90f, 0f));
    }

    void OnCollisionEnter(Collision other)
    {
        var colorPickable = other.gameObject.GetComponent<ColorPickable>();
        if (colorPickable != null)
        {
            if (CanPick)
            {
                var picked = colorPickable.Pick();
                if (picked && WillAffect)
                {
                    var renderer = GetComponent<MeshRenderer>();
                    renderer.material.color = colorPickable.PickColor;
                }
            }
        }
        else
        {
            var sizePickable = other.gameObject.GetComponent<SizePickable>();
            if (sizePickable != null)
            {
                if (CanPick)
                {
                    var picked = sizePickable.Pick();
                    if (picked && WillAffect)
                    {
                        transform.localScale = Vector3.one * sizePickable.Scale;
                    }
                }
            }
        }
    }
}
