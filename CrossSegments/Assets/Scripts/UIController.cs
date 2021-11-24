using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] Button _button;
   
    private void OnEnable()
    {
        DemoCross.NotyfyCloseApp += DisableButton;                                   // подписка на событие, о том, что васчет произведен (можно отключаться)
    }

    private void OnDisable()
    {
        DemoCross.NotyfyCloseApp -= DisableButton;
    }

    private void DisableButton()
    {
        Application.Quit();                                                          // закрыть приложение
       _button.interactable=false;                                                   // временно, для отключения рассчета приложения в PlayMode
    }

   
}
