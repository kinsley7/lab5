using BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Champion;
using System.Text.Json;

/**       
 *--------------------------------------------------------------------
 * 	   File name: SummonerSpells.cs
 * 	Project name: LeagueAPI
 *--------------------------------------------------------------------
 * Author’s name and email:	 kinsley crowdis crowdis@etsu.edu			
 *          Course-Section: CSCI 2900-800
 *           Creation Date:	10/05/2023
 * -------------------------------------------------------------------
 */

public class SummonerSpells
{
    public object id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int summonerLevel { get; set; }
    public int cooldown { get; set; }
    public List<string> gameModes { get; set; }
    public string iconPath { get; set; }

    public static async Task<string> GetSpellNameByIdAsync(int idUser)
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync("https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1/summoner-spells.json");
        string json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        var spells = JsonSerializer.Deserialize<List<SummonerSpells>>(json, options);

        foreach (var spell in spells)
        {
            string spellID = spell.id.ToString();

            if (spellID == idUser.ToString())
            {
                return spell.name;
            }
        }
        return "spell not found";
    }
     

}


