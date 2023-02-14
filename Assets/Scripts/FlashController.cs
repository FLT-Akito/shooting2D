using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FlashController : MonoBehaviour
{
	public bool isFlash = false;

	private Image _img;
	
	void Start()
	{
		_img = GetComponent<Image>();
		_img.color = Color.clear;
	}

	public void Flash()
    {
			this._img.color = new Color(255f, 120f, 0, 0.5f);
	}

	public void OriginalState()
    {
		this._img.color = Color.Lerp(_img.color, Color.clear, Time.deltaTime);
	}

}
