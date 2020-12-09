using Entitas;
using UnityEngine;

public class InputSystem : IExecuteSystem
{
    private Contexts _contexts;

    public InputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        Vector3 rotateVal = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            rotateVal = Vector3.zero;
            // Debug.Log("LeftRight");
        } 
        else if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            rotateVal = Vector3.forward;
            // Debug.Log("Left");
        } 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotateVal = Vector3.back;
            // Debug.Log("Right");
        }

        var val = _contexts.input.GetEntities(InputMatcher.Input);
        
        //Debug.LogWarning(val.Length);
        
        _contexts.input.ReplaceInput(rotateVal);
    }
}