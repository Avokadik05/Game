// NULLcode Studio © 2016
// null-code.ru

using UnityEngine;
using System.Collections;

public class ButtonAction : MonoBehaviour {

	public void ButtonSave() // событие кнопки, для сохранения настроек
	{
		GameInput.Key.SaveSettings();
	}

	public void ButtonDefault() // событие кнопки, для установки настроек по умолчанию
	{
		GameInput.Key.DefaultSettings();
	}
}
