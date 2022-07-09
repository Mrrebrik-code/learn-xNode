using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

// общедоступные классы, производные от Node, регистрируются как узлы для использования в графе
public class MathNode : Node
{
    // Добавление [Input] или [Output] — это все, что вам нужно сделать, чтобы зарегистрировать поле как действительный порт на вашем узле
    [Input] public float a;
    [Input] public float b;
    // Значение поля выходного узла ни для чего не используется, но может быть использовано для кэширования выходных результатов
    [Output] public float result;
    [Output] public float sum;

    // Значение 'mathType' будет отображаться на узле в редактируемом формате, подобно инспектору
    public MathType mathType = MathType.Add;
    public enum MathType { Add, Subtract, Multiply, Divide }

    // GetValue следует переопределить, чтобы вернуть значение для любого указанного выходного порта
    public override object GetValue(NodePort port)
    {

        // Получить новые значения a и b из входных соединений. Возврат к значениям полей, если вход не подключен
        float a = GetInputValue<float>("a", this.a);
        float b = GetInputValue<float>("b", this.b);

        // После того, как вы получили свои входные значения, вы можете выполнить свои вычисления и вернуть значение
        if (port.fieldName == "result")
            switch (mathType)
            {
                case MathType.Add: default: return a + b;
                case MathType.Subtract: return a - b;
                case MathType.Multiply: return a * b;
                case MathType.Divide: return a / b;
            }
        else if (port.fieldName == "sum") return a + b;
        else return 0f;
    }
}