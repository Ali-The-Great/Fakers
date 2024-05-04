namespace Fakers.Backend;
public class ConcreteBuilder :IBuilder
{
    private Faker _faker = new Faker();

    public ConcreteBuilder()
    {
        this.Reset();
    }

    public void Reset()
    {
        this._faker = new Faker();
    }

    public void Build()
    {
        this._faker.Add("Built");
    }

    public Faker GetFaker()
    {
        Faker result = this._faker;

        this.Reset();

        return result;
    }
}

