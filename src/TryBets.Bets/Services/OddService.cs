using System.Net.Http;
namespace TryBets.Bets.Services;

public class OddService : IOddService
{
    private readonly HttpClient _client;
    public OddService(HttpClient client)
    {
        _client = client;
    }

    public async Task<object> UpdateOdd(int MatchId, int TeamId, decimal BetValue)
    {
        var endpoint = $"http://localhost:5504/odd/{MatchId}/{TeamId}/{BetValue}";
        var response = await _client.PatchAsync(endpoint, null);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Odd not updated");
        }

        return response;
    }
}