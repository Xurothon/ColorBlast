
public class SecondSphereTutorial : SecondSphere
{
    [UnityEngine.SerializeField] private Tutorial _tutorial;
    public new void ChangeColor()
    {
        _mainSphere.SwapMaterials();
        _tutorial.CompleteTutorial();
    }
}
