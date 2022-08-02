using UnityEngine;
using System.Collections;

public class TestTestTest : MonoBehaviour {

	void Start()
	{
		// загрузку нужно делать в этой функции
		GameInput.Key.LoadSettings();
	}

	void Update()
	{
		if(GameInput.Key.GetKey("Forward"))
		{
			print("Удерживается клавиша: Вперед");
		}

		if(GameInput.Key.GetKeyDown("Back"))
		{
			print("Нажата клавиша: Назад");
		}

		if(GameInput.Key.GetKeyUp("Left"))
		{
			print("Отпущена клавиша: Влево");
		}
	}
}
