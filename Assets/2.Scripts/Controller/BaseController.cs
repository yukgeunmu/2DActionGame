using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
public class BaseController : MonoBehaviour
{

    PlayerInput input;

    private void OnEnable()
    {
        input = new PlayerInput();

      
    }

}

