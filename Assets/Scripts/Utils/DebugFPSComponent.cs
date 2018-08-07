using Entitas;

[Game]
public class DebugFPSComponent : IComponent
{
    public float fps;

    public string message
    {
        get
        {
            return string.Format("current fps is {0}", fps.ToString("0.00"));
        }
    }
}
