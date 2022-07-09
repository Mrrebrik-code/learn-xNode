using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using XNode;

public class ButtonNode : MonoBehaviour
{
	[SerializeField] private NodeGraph _mathNodeGraph;
	[SerializeField] private TMP_Text _text;
	MathNodeGraph _mathNodeGraph2;
	private void Start()
	{
		_mathNodeGraph2 = _mathNodeGraph as MathNodeGraph;
		_mathNodeGraph2.Init((text) =>
		{
			Debug.Log("asda: " + text);
			_text.text = text;
		});

		GetComponent<Button>().onClick.AddListener(() =>
		{
			_mathNodeGraph2.GetTextNode();
		});
	}
}
