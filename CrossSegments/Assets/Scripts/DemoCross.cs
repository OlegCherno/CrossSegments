using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

public class DemoCross : MonoBehaviour
{
    public static UnityAction<List<Segment>> NotyfyCalculation;                                                         // Объявляем событие
    public static UnityAction NotyfyCloseApp;

    [SerializeField] CreateInArray _createInArray;                                                                      // ссылка на входной массив
    
    private List<Segment> _inArraySegments = new List<Segment>();
    private List<Segment> _outArraySegments = new List<Segment>();
          
    private void Start()
    {
        _inArraySegments = _createInArray.MyInArraySegments;
    }

    public void CalcMultiCross()                                                                                     // Вызывается по кнопке "Рассчитать"
    {
        _outArraySegments = MultiCrossSegments.CrossSegments(_inArraySegments);                                       // расчет выходного массива
        NotyfyCalculation?.Invoke(_outArraySegments);                                                                 // вызов события (подписка в DrawSegments)
        NotyfyCloseApp?.Invoke();
    }
}
