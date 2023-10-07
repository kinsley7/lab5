using BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Champion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

/**       
 *--------------------------------------------------------------------
 * 	   File name: Program.cs
 * 	Project name: LeagueAPI
 *--------------------------------------------------------------------
 * Author’s name and email:	 kinsley crowdis crowdis@etsu.edu			
 *          Course-Section: CSCI 2900-800
 *           Creation Date:	10/04/2023
 * -------------------------------------------------------------------
 */
namespace LeagueAPI
{
    public interface ISummonerSpells
    {
        //https://ddragon.leagueoflegends.com/cdn/13.15.1/data/en_US/summoner.json
        public string name { get; set; }
        public string key { get; set; }

    
        public static async Task<string> GetSpellNameByIdAsync(long id)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://ddragon.leagueoflegends.com/cdn/13.15.1/data/en_US/summoner.json");
                string json = await response.Content.ReadAsStringAsync();
                // Console.WriteLine(json);
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                        var p = JsonSerializer.Deserialize<Data>(json, options);

                        var properties = typeof(Data).GetProperties();

                        foreach (var property in properties)
                        {
                            var value = property.GetValue(p); //issue is that P is null so it messes it up

                            if (value is ISummonerSpells spell && spell.key == id.ToString())
                            {
                                return spell.name;
                            }
                        }
                    }
                    catch (Exception ex2)
                    {
                        return "Error3" + ex2;
                    }
                    return "Error2";
                }
                else
                {
                    // Handle the case where the API call fails
                    return "API Call failed";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                return "Error" + ex;
            }
        }

    }

    public class Datavalues
    {
    }

    public class Image
    {
        public string full { get; set; }
        public string sprite { get; set; }
        public string group { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
    }

    public class SummonerBarrier : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<int>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class SummonerBoost : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<double>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class SummonerCherryFlash : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<double> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<int>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class SummonerCherryHold : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<int>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class SummonerDot : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<int>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class SummonerExhaust : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<int>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }
     
    public class SummonerFlash : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<int>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class SummonerHaste : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<int>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class SummonerHeal : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<double>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class SummonerMana : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<int>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class SummonerPoroRecall : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<int>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class SummonerPoroThrow : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<int>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class SummonerSmite : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<int>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class SummonerSnowURFSnowballMark : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<int>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class SummonerSnowball : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<int>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class SummonerTeleport : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<int>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class SummonerUltBookPlaceholder : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<int>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class SummonerUltBookSmitePlaceholder : ISummonerSpells
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tooltip { get; set; }
        public int maxrank { get; set; }
        public IList<int> cooldown { get; set; }
        public string cooldownBurn { get; set; }
        public IList<int> cost { get; set; }
        public string costBurn { get; set; }
        public Datavalues datavalues { get; set; }
        public IList<IList<int>> effect { get; set; }
        public IList<string> effectBurn { get; set; }
        public IList<object> vars { get; set; }
        public string key { get; set; }
        public int summonerLevel { get; set; }
        public IList<string> modes { get; set; }
        public string costType { get; set; }
        public string maxammo { get; set; }
        public IList<int> range { get; set; }
        public string rangeBurn { get; set; }
        public Image image { get; set; }
        public string resource { get; set; }
    }

    public class Data
    {
        public SummonerBarrier SummonerBarrier { get; set; }
        public SummonerBoost SummonerBoost { get; set; }
        public SummonerCherryFlash SummonerCherryFlash { get; set; }
        public SummonerCherryHold SummonerCherryHold { get; set; }
        public SummonerDot SummonerDot { get; set; }
        public SummonerExhaust SummonerExhaust { get; set; }
        public SummonerFlash SummonerFlash { get; set; }
        public SummonerHaste SummonerHaste { get; set; }
        public SummonerHeal SummonerHeal { get; set; }
        public SummonerMana SummonerMana { get; set; }
        public SummonerPoroRecall SummonerPoroRecall { get; set; }
        public SummonerPoroThrow SummonerPoroThrow { get; set; }
        public SummonerSmite SummonerSmite { get; set; }
        public SummonerSnowURFSnowballMark SummonerSnowURFSnowball_Mark { get; set; }
        public SummonerSnowball SummonerSnowball { get; set; }
        public SummonerTeleport SummonerTeleport { get; set; }
        public SummonerUltBookPlaceholder Summoner_UltBookPlaceholder { get; set; }
        public SummonerUltBookSmitePlaceholder Summoner_UltBookSmitePlaceholder { get; set; }
    }

    public class Example
    {
        public string type { get; set; }
        public string version { get; set; }
        public Data data { get; set; }
    }


}

