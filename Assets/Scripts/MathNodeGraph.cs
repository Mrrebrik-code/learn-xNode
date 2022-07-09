using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using XNode;

[CreateAssetMenu]
public class MathNodeGraph : NodeGraph 
{
	private bool _isInit = false;
	private Action<string> _callback;
	public void Init(Action<string> callback)
	{
		_callback = callback;
		_isInit = true;
	}
	public void GetTextNode()
	{
		if (_isInit)
		{
			var text = nodes.First(node => node.GetType() == typeof(TextNode)).GetPort("OutputText").GetOutputValue().ToString();
			_callback?.Invoke(text);
		}
	}

}