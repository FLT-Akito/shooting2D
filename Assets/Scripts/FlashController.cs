using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FlashController : MonoBehaviour
{
	public UnityEvent flashEvent = new UnityEvent();
	public bool isFlash = false;

	private Image _img;
	public Image Img { get => _img; }

	void Start()
	{
		_img = GetComponent<Image>();
	}

	void Update()
	{
		flashEvent.AddListener(() =>
		{
			if (isFlash)
			{
				this._img.color = new Color(255f, 120f, 0, 0.5f);
			}
			else
			{
				
				this._img.color = Color.Lerp(_img.color, Color.clear, Time.deltaTime);
			}
		});

      
    }


}
