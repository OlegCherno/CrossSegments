using System.Collections.Generic;
using UnityEngine;

public class MultiCrossSegments : MonoBehaviour
{
    private static Segment _itemSegment;

    public static List<Segment> CrossSegments(List<Segment> _inArraySegments)           // Метод, формитующий выходной массив отрезков по точкам пересечения 
    {                                                                                   // отрезков из входного массива.
        List<Segment> _outArraySegments = new List<Segment>();
        List<List<Point>> _pointsOfSements = new List<List<Point>>();
        Point _crossP;

        for (int i = 0; i < _inArraySegments.Count; i++)                                 // формирование промежуточного массива "МасивовТочек"
        {
            List<Point> _points = new List<Point>();                                     // создаем масив точек для каждого исходного отрезка

            _points.Add(_inArraySegments[i].p1);                                         // заносим сразу начальные и конечные точки
            _points.Add(_inArraySegments[i].p2);
            _pointsOfSements.Add(_points);
        }                                                                                // на выходе - массив "массивов точек" ( зубчатый массив )
                                                                                         // для каждого отрезка свой набор точек
                                                                                         // (начальная точка, конечная точка и точки пересечений если такие появятся)

        for (int i = 0; i < _inArraySegments.Count; i++)                                 // перебор входного массива по приципу (каждый с каждым) и поиск пересечений 
            for (int k = i + 1; k < _inArraySegments.Count; k++)                         // ранее найденные пары не учитываются
            {
                if (SingleCrossSegments.CheckCrossing(_inArraySegments[i], _inArraySegments[k])) // если  пара отрезков пересекаются строим уравнения линий
                {
                    double a1, b1, c1, a2, b2, c2;
                    SingleCrossSegments.LineEquation(_inArraySegments[i]);
                    a1 = SingleCrossSegments.A; b1 = SingleCrossSegments.B; c1 = SingleCrossSegments.C;
                    SingleCrossSegments.LineEquation(_inArraySegments[k]);
                    a2 = SingleCrossSegments.A; b2 = SingleCrossSegments.B; c2 = SingleCrossSegments.C;
                    _crossP = SingleCrossSegments.CrossingPoint(a1, b1, c1, a2, b2, c2);           // определяем точку пересечения

                    _pointsOfSements[i].Add(_crossP);                                       // заносим в массив точек, полученную точку пересечения
                    _pointsOfSements[k].Add(_crossP);
                }
            }

        for (int i = 0; i < _pointsOfSements.Count; i++)                                    // сортируем массим так, что б в каждом отрезке точки шли последовательно
        {
            _pointsOfSements[i] = SortPoints(_pointsOfSements[i]);                           // передаем массив на сортировку
        }

        for (int i = 0; i < _pointsOfSements.Count; i++)                                    // формируем выхондной массив !!!!!!!
            for (int j = 0; j < _pointsOfSements[i].Count - 1; j++)
            {
                _itemSegment = new Segment(_pointsOfSements[i][j].X, _pointsOfSements[i][j].Y, _pointsOfSements[i][j + 1].X, _pointsOfSements[i][j + 1].Y);
                _outArraySegments.Add(_itemSegment);
            }
        
        /*for (int i = 0; i < _outArraySegments.Count; i++)                                  // тествый вывод в консоль
        {
            Debug.Log("Выходной Отрезок_" + i + " --->" + _outArraySegments[i].p1.X + "  :  " + _outArraySegments[i].p1.Y);
            Debug.Log("Выходной Отрезок_" + i + " --->" + _outArraySegments[i].p2.X + "  :  " + _outArraySegments[i].p2.Y);
        }*/
        
        return _outArraySegments;
    }

    private static List<Point> SortPoints(List<Point> _points)                                    // вспомогательный метод сортировки точек
    {
        int lastindex = _points.Count - 1;
        Point _tmpPoint;

        if (_points[0].X != _points[1].X)                                                  // не вертикаль - сортируем по X
        {
            while (lastindex != 0)
            {
                for (int j = 0; j < lastindex; j++)
                {
                    if (_points[j].X > _points[j + 1].X)
                    {
                        _tmpPoint = _points[j];
                        _points[j] = _points[j + 1];
                        _points[j + 1] = _tmpPoint;
                    }
                }
                lastindex--;
            }
        }
        else                                                                                 // вертикаль - сортируем по Y
        {
            while (lastindex != 0)
            {
                for (int j = 0; j < lastindex; j++)
                {
                    if (_points[j].Y > _points[j + 1].Y)
                    {
                        _tmpPoint = _points[j];
                        _points[j] = _points[j + 1];
                        _points[j + 1] = _tmpPoint;
                    }
                }
                lastindex--;
            }
        }

        return _points;
    }
}

