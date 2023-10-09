using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController shapeController;
    [SerializeField, Range(3f, 100)] private int levelLength = 50;
    [SerializeField, Range(1f, 50f)] private float xMultiplier = 2f;
    [SerializeField, Range(1f, 50f)] private float yMultiplier = 2f;
    [SerializeField, Range(0f, 1f)] private float curveSmoothness = 0.5f;
    [SerializeField] private float noiseStep = 0.5f;
    [SerializeField] private float bottom = 10f;


    private Vector3 lastPosition;

    private void OnValidate()
    {
        shapeController.spline.Clear();

        for(int i=0; i<levelLength; i++)
        {
            lastPosition = transform.position + new Vector3(i * xMultiplier, Mathf.PerlinNoise(0, i * noiseStep) * yMultiplier);
            shapeController.spline.InsertPointAt(i, lastPosition);

            if(i != 0 && i!=levelLength - 1)
            {
                shapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                shapeController.spline.SetLeftTangent(i, Vector3.left * xMultiplier * curveSmoothness);
                shapeController.spline.SetRightTangent(i, Vector3.right * xMultiplier * curveSmoothness);
            }
        }

        shapeController.spline.InsertPointAt(levelLength, new Vector3(lastPosition.x, transform.position.y - bottom));
        shapeController.spline.InsertPointAt(levelLength + 1, new Vector3(transform.position.x, transform.position.y - bottom));
    }


}
