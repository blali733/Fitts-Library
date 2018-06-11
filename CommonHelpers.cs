using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

namespace SharedTypes
{
    public class Helpers
    {
        public static IEnumerable<float> FloatRange(float min, float max, float step)
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                float value = min + step * i;
                if (value > max)
                {
                    break;
                }

                yield return value;
            }
        }

        public static float Distance2D(float x1, float y1, float x2, float y2)
        {
            return (float) Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        public static Questionarie ParseQuestionarie(GameObject questionarieWindow)
        {
            Questionarie questionarie = new Questionarie();
            questionarie.AgeGroup = questionarieWindow.transform.Find("AgeGroup").gameObject.GetComponent<Dropdown>()
                .options[questionarieWindow.transform.Find("AgeGroup").gameObject.GetComponent<Dropdown>().value].text; // Have fun
            questionarie.TouchFrequency = questionarieWindow.transform.Find("TouchAdaptation").gameObject.GetComponent<Dropdown>()
                .options[questionarieWindow.transform.Find("TouchAdaptation").gameObject.GetComponent<Dropdown>().value].text;
            questionarie.None = questionarieWindow.transform.Find("None").gameObject.GetComponent<Toggle>().isOn;
            questionarie.Smaller5 = questionarieWindow.transform.Find("less5").gameObject.GetComponent<Toggle>().isOn;
            questionarie.Smaller11 = questionarieWindow.transform.Find("less11").gameObject.GetComponent<Toggle>().isOn;
            questionarie.Greater11 = questionarieWindow.transform.Find("greater11").gameObject.GetComponent<Toggle>().isOn;
            questionarie.Activities = questionarieWindow.transform.Find("Activities").gameObject.GetComponent<Dropdown>()
                .options[questionarieWindow.transform.Find("Activities").gameObject.GetComponent<Dropdown>().value].text;
            return questionarie;
        }
    }

    [System.Serializable]
    public class SerializableColor
    {

        public float[] ColorStore = new float[4] { 1F, 1F, 1F, 1F };
        public Color Color
        {
            get { return new Color(ColorStore[0], ColorStore[1], ColorStore[2], ColorStore[3]); }
            set { ColorStore = new float[4] { value.r, value.g, value.b, value.a }; }
        }

        //makes this class usable as Color, Color normalColor = mySerializableColor;
        public static implicit operator Color(SerializableColor instance)
        {
            return instance.Color;
        }

        //makes this class assignable by Color, SerializableColor myColor = Color.white;
        public static implicit operator SerializableColor(Color color)
        {
            return new SerializableColor { Color = color };
        }
    }
}
