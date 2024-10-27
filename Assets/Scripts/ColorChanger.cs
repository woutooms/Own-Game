using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private EColor color; 

    private void Start()
    {
        color = (EColor)Random.Range(0, System.Enum.GetValues(typeof(EColor)).Length);
    }

    public EColor GetColor() 
    {
        return color;
    }

    private void Awake()
    {
       
    }
}
