using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickPlayerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float Speed;
    private float moveDirection;

    private void Update()
    {
        // Mover o jogador com base na direção definida pelo joystick
        Vector3 movement = new Vector3(moveDirection, 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Iniciar o movimento na direção correspondente ao botão pressionado
        if (eventData.pointerCurrentRaycast.gameObject.name == "LeftButton")
        {
            moveDirection = -1f; // Mover para a esquerda
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "RightButton")
        {
            moveDirection = 1f; // Mover para a direita
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Parar o movimento quando o botão for solto
        moveDirection = 0f;
    }
}
