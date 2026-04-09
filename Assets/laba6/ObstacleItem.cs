using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Renderer))]
public class ObstacleItem : MonoBehaviour, IDamageable
{
    [Range(0f, 1f)] public float currentValue = 1f;
    public UnityEvent onDestroyObstacle;

    private Renderer objRenderer;

    void Awake()
    {
        objRenderer = GetComponent<Renderer>();
    }

    void Start()
    {
        UpdateColor();
    }

    public void GetDamage(float value)
    {
        currentValue -= value;
        currentValue = Mathf.Clamp01(currentValue);
        UpdateColor();

        if (currentValue <= 0f)
        {
            onDestroyObstacle?.Invoke();
            Destroy(gameObject);
        }
    }

    private void UpdateColor()
    {
        Color color = Color.Lerp(Color.red, Color.white, currentValue);
        objRenderer.material.color = color;
    }
}