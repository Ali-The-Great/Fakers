namespace Fakers.Backend;
public class Director
    {
    private IBuilder _builder;
        
    public IBuilder Builder
    {
        set { _builder = value; } 
    }

    public void BuildMinimalViableProduct()
    {
        this._builder.Build();
    }
}

