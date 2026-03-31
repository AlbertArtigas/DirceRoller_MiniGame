using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeManager : MonoBehaviour
{  
    public static SwipeManager instance;
	[SerializeField] private InputAction position, press;
	[SerializeField] private float swipeResistance = 100f;
	private Vector2 initialPos;
	private Vector2 currentPos => position.ReadValue<Vector2>();
	private void Awake () 
	{
		position.Enable();
		press.Enable();	
		press.performed += _ => { initialPos = currentPos; };
		press.canceled += _ => DetectSwipe();
		instance = this;
	}

	private void DetectSwipe () 
	{
		Vector2 delta = currentPos - initialPos;
		Vector2 direction = Vector2.zero;

		if(Mathf.Abs(delta.x) > swipeResistance)
		{
			direction.x = Mathf.Clamp(delta.x, -1, 1);
		}
		if(Mathf.Abs(delta.y) > swipeResistance)
		{
			direction.y = Mathf.Clamp(delta.y, -1, 1);
		}
		if(direction != Vector2.zero) 
		{
			HandleSwipe(direction);
		}
	}


	private void HandleSwipe (Vector2 direction) 
	{
            if(direction.x > 0) //Swipe Right
            {
                Debug.Log("Swiped Right");
            }
                
            else if(direction.x < 0) //Swipe Left
            {
                Debug.Log("Swiped Left");
                //TO DO: Open Side Shop
            }

            if(direction.y > 0) //Swipe Up
            {
                Debug.Log("Swiped Up");
                //TO DO: throw all dice
            }
            
            else if(direction.y < 0)
			{
				Debug.Log("Swiped Down");
				REFS.UI_MANAGER.FillDicePanel(); //Swipe Down //TO DO: Maybe From the top open Setting?
			}
	}
}
