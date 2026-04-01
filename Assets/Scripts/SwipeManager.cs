using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SwipeManager : MonoBehaviour
{  
    public static SwipeManager instance;
	[SerializeField] private InputAction position, press;
	[SerializeField] private float swipeResistance = 100f;
	[SerializeField] private float swipeTime = 1f;
	public bool timedOut;
	float timer;
	private Vector2 initialPos;
	private Vector2 currentPos => position.ReadValue<Vector2>();

	public bool hasSwiped = false;
	public bool isDragging = false;

	[SerializeField] CanvasGroup throwButtonCVGroup;
	private void Awake () 
	{
		instance = this;

		position.Enable();
		press.Enable();	

		press.performed += _ => initialPos = currentPos;	
		press.canceled += _ => DetectSwipe();
		
	}

	private void Update() 
	{
		if(press.WasPerformedThisFrame())
		{
			timedOut = false;
			timer = 0;			
		}
		if(press.IsPressed() && !timedOut && !isDragging)
		{			
			timer += Time.deltaTime;
			if(timer >= swipeTime)
			{
				timedOut = true;
			}

		}		
	}

	private void DetectSwipe () 
	{
		
		if(isDragging) return;
		
		
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
			//hasSwiped = true;
			ToggleThrowButton(false);
			StartCoroutine(HandleSwipe(direction));
		}
	}


	IEnumerator HandleSwipe(Vector2 direction) 
	{
		if(timedOut)
		{
			timedOut = false;			
			yield return null;
			ToggleThrowButton(true);
			yield break;
		}
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
			//hasSwiped = false;
			REFS.THROW_DIE_SCRIPT.ThrowAllHandDie();
		}
		
		else if(direction.y < 0)
		{
			Debug.Log("Swiped Down");
			REFS.UI_MANAGER.FillDicePanel(); //Swipe Down //TO DO: Maybe From the top open Setting?
		}
		yield return null;
		ToggleThrowButton(true);
		//hasSwiped = false;
	}

	void ToggleThrowButton(bool active)
	{
		throwButtonCVGroup.blocksRaycasts = active;
		throwButtonCVGroup.interactable = active;
	}

	
}
