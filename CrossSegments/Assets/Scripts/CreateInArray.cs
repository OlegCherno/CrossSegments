using System.Collections.Generic;
using UnityEngine;

public class CreateInArray : MonoBehaviour
{
    private LineRenderer _line;
    private List<Segment> _myInArraySegments = new List<Segment>();
    private Segment _itemSegment;
    private Point _p1 = new Point();
    private Point _p2 = new Point();

    public List<Segment> MyInArraySegments { get => _myInArraySegments; }

    private void Start()
    {
        InitLineRender(0);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _line.positionCount < 2)
        {
            Vector2 _currentPoint = GetWorldCoordinate(Input.mousePosition);
           _line.positionCount++;
            switch (_line.positionCount)                                              // запоминаем начальные и конечные точки текущего отрезка
            {
                case 1:
                    _p1.X = _currentPoint.x;
                    _p1.Y = _currentPoint.y;
                    break;
                case 2:
                    _p2.X = _currentPoint.x;
                    _p2.Y = _currentPoint.y;
                    break;
            }
            _line.SetPosition(_line.positionCount - 1, _currentPoint);                 // отрисовка отрезка
            if (_line.positionCount == 2)                                              // "закрываем" текущий отрезок и переходим к следующему
            {
                _itemSegment = new Segment(_p1.X, _p1.Y, _p2.X, _p2.Y);
                MyInArraySegments.Add(_itemSegment);                                   // заносим текущий сегмент во ВХОДЯЩИЙ массив отрезков

                InitLineRender(0);
            }
        }
    }

    private Vector2 GetWorldCoordinate(Vector2 mousePosition)
    {
        Vector2 mousePoint = new Vector2(mousePosition.x, mousePosition.y);
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void InitLineRender(int countPos)
    {
        _line = new GameObject("MySegment").AddComponent<LineRenderer>();
        _line.material= new Material(Shader.Find("UI/Default"));
        _line.startWidth = 0.1f;
        _line.endWidth = 0.1f;
        _line.material.color = Color.white;
        _line.positionCount = countPos;
        //_line.useWorldSpace = true;
    }
}
