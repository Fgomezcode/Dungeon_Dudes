using UnityEngine;

public class PatrolTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform parentTransform = GetComponentInParent<Transform>();

        transform.localPosition = new Vector2(parentTransform.localPosition.x, parentTransform.localPosition.y);

    }

}
