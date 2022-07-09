using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class TextNode : Node
{
	[Input] public string InputText;
	[Input] public string[] InputTexts;
	[Output] public string OutputText;
	[Output] public string[] OutputTexts;
	public override object GetValue(NodePort port)
	{
		var inputText = (GetInputValue<object>("InputText", this.InputText)).ToString();
		
		var test = GetInputValues<object>("InputTexts", this.InputTexts);
		var inputTexts = new List<string>();

		foreach (var obj in test)
		{
			if(obj.GetType() == typeof(System.String[]))
			{
				var testt = obj as System.String[];
				foreach (var item in testt)
				{
					inputTexts.Add(item.ToString());
				}
			}
			else
			{
				inputTexts.Add(obj.ToString());
			}
		}
		
		if (test.GetType() == typeof(System.String[]))
		{
			
		}

		if (port.fieldName == "OutputText")
		{
			OutputText = inputText;
			
			return inputText;
		}
		else if (port.fieldName == "OutputTexts")
		{
			var count = 0;
			if(inputTexts != null)
			{
				count = inputTexts.Count;
				OutputTexts = new string[count];
				for (int i = 0; i < count; i++)
				{
					OutputTexts[i] = inputTexts[i].ToString();
				}
			}
			
			return OutputTexts;
		}
		return null;
	}
}
