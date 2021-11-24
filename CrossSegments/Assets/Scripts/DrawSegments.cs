using System.Collections.Generic;
using UnityEngine;

public class DrawSegments : MonoBehaviour
{
    private LineRenderer _line;

    private void OnEnable()
    {
        DemoCross.NotyfyCalculation += DrawSeg;                                   // подписка на событие, о том, что васчет произведен (можно отрисовывать)
    }

    private void OnDisable()
    {
        DemoCross.NotyfyCalculation -= DrawSeg;
    }

    void DrawSeg(List<Segment> _arraySegments)                                   // отрисовываем массив отрезков
    {
        for (int i = 0; i < _arraySegments.Count; i++)
        {
            InitLineRender(2);
            _line.SetPosition(0, new Vector2((float)_arraySegments[i].p1.X, (float)_arraySegments[i].p1.Y));
            _line.SetPosition(1, new Vector2((float)_arraySegments[i].p2.X, (float)_arraySegments[i].p2.Y));
        }
    }

    void InitLineRender(int countPos)
    {
        _line = new GameObject("MyOutSegment").AddComponent<LineRenderer>();
        _line.material = new Material(Shader.Find("UI/Default Font"));
        _line.startWidth = 0.1f;
        _line.endWidth = 0.1f;
        _line.positionCount = countPos;
        _line.material.color = new Color(Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f), Random.Range(0.1f, 0.9f), 1f);
        _line.useWorldSpace = true;
    }
}
