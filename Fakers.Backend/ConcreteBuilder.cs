namespace Fakers.Backend;
using System.Net.Http;
using System.Text.Json;
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

public void Build(){
        using (var httpClient = new HttpClient())
        {
            var endpoint = new Uri("http://127.0.0.1:8000/get_result_array");
            var result = httpClient.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result;
            var jsonDoc = JsonDocument.Parse(result);
            var root = jsonDoc.RootElement;
            if (root.TryGetProperty("result_array", out var resultArray))
            {
                foreach (var item in resultArray.EnumerateArray())
                {
                    if (item.ValueKind == JsonValueKind.Number)
                    {
                        _faker.Add(item.GetInt32().ToString());
                    }
                    else if (item.ValueKind == JsonValueKind.String)
                    {
                        _faker.Add(item.GetString());
                    }
                }
            }
        }
}

    public Faker GetFaker()
    {
        Faker result = this._faker;

        this.Reset();

        return result;
    }
}

