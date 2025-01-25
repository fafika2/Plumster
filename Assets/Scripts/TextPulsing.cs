using TMPro;
using Unity.Mathematics.Geometry;
using UnityEngine;

public class TextPulsing : MonoBehaviour
{
    [SerializeField] TextMeshPro textMeshPro;
    public float pingPongDuration = 2f;  // Duration of the alpha ping-pong cycle
    private Color originalColor;         // Store the original color

    void Start()
    {
        // Store the original color
        originalColor = textMeshPro.color;
    }

    void Update()
    {
        // Calculate a ping-pong value between 0 and 1
        float pingPong = Mathf.PingPong(Time.time / pingPongDuration, 1f);

        // Adjust the alpha value using the ping-pong value
        Color newColor = originalColor;
        newColor.a = Mathf.Lerp(0.1f, 1f, pingPong);

        // Apply the new color to the SpriteRenderer
        textMeshPro.color = newColor;
    }
}
