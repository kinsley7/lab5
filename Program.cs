using BlossomiShymae.RiotBlossom.Api;
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Type;
using BlossomiShymae.RiotBlossom.Dto.Riot.Match;
using System;
using System.ComponentModel.Design;
using System.Text.Json;
using BlossomiShymae.RiotBlossom.Api.Riot;
using BlossomiShymae.RiotBlossom.Dto.Riot.Spectator;
using BlossomiShymae.RiotBlossom.Dto.DataDragon.Champion;
using BlossomiShymae.RiotBlossom.Dto.Riot.LolChallenges;

namespace LeagueAPI
{
    public class Program
    {
        static string key = "";
                
        static async Task Main(string[] args)
        {

            /*
           // var client = new HttpClient();

 
            // Receive a response and store it in a variable
            // use 'await' when accessing an async method / resource
            HttpResponseMessage response = await client.GetAsync($"https://{userInputServer}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{userInputName}?page=1&api_key={key}");

            // store body of the response in a variable (this is our json)
            string json = await response.Content.ReadAsStringAsync();

            // Deserialize = pulling a .NET object out of json
            // Serialize = create json from a .NET object

            // capitalization of properties doesn't matter with this option, as long as the prop names
            // match the json keys
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            SummonerDTO p = JsonSerializer.Deserialize<SummonerDTO>(json, options);
            Console.WriteLine(p + "\n");

          

            HttpResponseMessage response = await client.GetAsync($"https://{userInputServer}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{p.}?page=1&api_key={key}");
            */


            var  client = RiotBlossomCore.CreateClient(key);
            var version = await client.DataDragon.GetLatestVersionAsync();


            Platform userInputServer = ServerMenu();
            Console.Write("Enter Player's Name: ");
            string userInputName = Console.ReadLine().Trim();
            
            
            
            var summoner = await client.Riot.Summoner.GetByNameAsync(userInputServer, userInputName);
            Console.WriteLine($"\nShowing {summoner.Name}\nLevel: {summoner.SummonerLevel}");
             IRiotApi riot = client.Riot;

           

           
          
     
            int option = PlayerMenu();
            switch (option)
            {
                case 4:
                    LiveMatch(userInputServer, summoner.Id, version, client);
                    break;
            }
            
             

              /*

              var ids =
                  await riot.Match.ListIdsByPuuidAsync(Platform.NorthAmerica, summoner.Puuid);

              List<MatchDto> matches = new();
              foreach (string id in ids)
                  matches.Add(await riot.Match.GetByIdAsync(Platform.NorthAmerica, id));

              matches
                  .Select(m => m.Info.Participants
                      .Where(p => p.SummonerId == summoner.Id)
                      .First())
                  .ToList()
                  .ForEach(p => Console
                      .WriteLine($"{p.ChampionName,-16}{$"{p.Kills}/{p.Deaths}/{p.Assists}",16}"));
          
            */

        }

      /*  public async Task ChampInfo(string input)
        {

            var client = RiotBlossomCore.CreateClient(key);
            var version = await client.DataDragon.GetLatestVersionAsync();

            var champions = await client.MerakiAnalytics.GetChampionDictionaryAsync();
            var champion = champions[input];
        } */

        static public Platform ServerMenu()
        {
            // menu tutorial from https://www.youtube.com/watch?v=YyD1MRJY0qI&ab_channel=RicardoGerbaudo

            Console.WriteLine("\t-------------------");
            Console.WriteLine("Select Player's Server Using the Up and Down Arrow Keys.");
            Console.WriteLine("\tPress Enter to Select");
            Console.WriteLine("\t-------------------");

            ConsoleKeyInfo key;
            int option = 1;
            bool isSelected = false;
            (int left, int top) = Console.GetCursorPosition(); //puts cursor back to the top. (so if the up key is pressed continuously it does not say option -4 is selected)
            string color = "\x1b[42m"; //this is the color that appears over a selected option (the [42m is the color of the text and \x1b is a unicode character that allows us to do this
            
            while (!isSelected) 
            {
                Console.SetCursorPosition(left, top); //sets cursor at the top and does not repeat allll these console.writelines

                Console.WriteLine($"{(option == 1 ? color : null)}NA: North America\x1b[0m"); // if option 1 is selected change color to the color we selected otherwise no color change (color = "  ") then with [0m we change the console color back to white
                Console.WriteLine($"{(option == 2 ? color : null)}EUW: Europe West\x1b[0m"); //euw1
                Console.WriteLine($"{(option == 3 ? color : null)}EUNE: Europe Nordic & East\x1b[0m"); //eun1
                Console.WriteLine($"{(option == 4 ? color : null)}JP: Japan\x1b[0m");
                Console.WriteLine($"{(option == 5 ? color : null)}KR: Korea\x1b[0m");
                Console.WriteLine($"{(option == 6 ? color : null)}BR: Brazil\x1b[0m");
                Console.WriteLine($"{(option == 7 ? color : null)}LAN: Latin America North\x1b[0m"); // LA1
                Console.WriteLine($"{(option == 8 ? color : null)}LAS: Latin America South\x1b[0m"); //LA2
                Console.WriteLine($"{(option == 9 ? color : null)}OCE: Oceania\x1b[0m");
                Console.WriteLine($"{(option == 10 ? color :null)}TR: Turkey\x1b[0m");
                Console.WriteLine($"{(option == 11 ? color :null)}RU: Russia\x1b[0m");
                Console.WriteLine($"{(option == 12 ? color :null)}PH: The Philippines\x1b[0m"); //PH2
                Console.WriteLine($"{(option == 13 ? color :null)}SG: Singapore, Malaysia, & Indonesia\x1b[0m"); //SG2
                Console.WriteLine($"{(option == 14 ? color :null)}TH: Thailand\x1b[0m");
                Console.WriteLine($"{(option == 15 ? color :null)}TW: Taiwan, Hong Kong, and Macao\x1b[0m");
                Console.WriteLine($"{(option == 16 ? color :null)}VN: Vietnam\x1b[0m");
                key = Console.ReadKey(true);
                
                switch (key.Key) //when key is pressed:
                {
                    case ConsoleKey.DownArrow:
                        option = (option == 16 ? option = 1 : option + 1); //if the cursor is at the last option and the user presses down, it will return to the top/first option. otherwise it goes down one
                        break;
                    case ConsoleKey.UpArrow:
                        option = (option == 1 ? option = 16 : option - 1); //if the cursor is at the first option and the user pressed up, it will return to the last/bottom option. otherwise it just goes up one
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

                //Console.WriteLine($"Selected Option {option}");
            }
            Console.WriteLine($"Selected Option {option}");

            option--;
            Platform userPlatform = new Platform();
            string test = "";

            switch (option)
            {
                case 0:
                    userPlatform = Platform.NorthAmerica;
                    test = "na1";
                    break;
                case 1:
                     userPlatform = Platform.EuropeWest;
                    test = "euw1";
                    break;
                case 2:
                     userPlatform = Platform.EuropeNordicEast;
                    test = "eun1";
                    break;
                case 3:
                     userPlatform = Platform.Japan;
                    test = "jp1";
                    break;
                case 4:
                     userPlatform = Platform.Korea;
                    test = "kr";
                    break;
                case 5:
                     userPlatform = Platform.Brazil;
                    test = "br1";
                    break;
                case 6:
                      userPlatform = Platform.LatinAmericaNorth;
                    test = "la1";
                    break;
                case 7:
                      userPlatform= Platform.LatinAmericaSouth;
                    test = "la2";
                    break;
                case 8:
                      userPlatform= Platform.Oceania;
                    test = "oc1";
                    break;
                case 9:
                      userPlatform = Platform.Turkey;
                    test = "tr1";
                    break;
                case 10:
                      userPlatform = Platform.Russia;
                    test = "ru";
                    break;
                case 11:
                     userPlatform = Platform.Philippines;
                    test = "ph2";
                    break;
                case 12:
                      userPlatform = Platform.Singapore;
                    test = "sg2";
                    break;
                case 13:
                     userPlatform = Platform.Thailand;
                    test = "th2";
                    break;
                case 14:
                     userPlatform = Platform.Taiwan;
                    test = "tw2";
                    break;
                case 15:
                     userPlatform = Platform.Vietnam;
                    test = "vn2";
                    break;
                default:
                    break;
            }
               
            return userPlatform;
        }

        static public int PlayerMenu()
        {
            Console.Clear();
            Console.WriteLine("\t-------------------");
            Console.WriteLine("\tSelect an Option");
            Console.WriteLine("\t-------------------");

            ConsoleKeyInfo key;
            int option = 1;
            bool isSelected = false;
            (int left, int top) = Console.GetCursorPosition(); //puts cursor back to the top. (so if the up key is pressed continuously it does not say option -4 is selected)
            string color = "\x1b[42m"; //this is the color that appears over a selected option (the [42m is the color of the text and \x1b is a  character that allows us to do this

            while (!isSelected)
            {
                Console.SetCursorPosition(left, top); //sets cursor at the top and does not repeat allll these console.writelines
                Console.WriteLine($"{(option == 1 ? color : null)}View Match History\u001b[0m");
                Console.WriteLine($"{(option == 2 ? color : null)}View Champion Masteries\u001b[0m");
                Console.WriteLine($"{(option == 3 ? color : null)}View Challenges\u001b[0m");
                Console.WriteLine($"{(option == 4 ? color : null)}View Live Match Stats\u001b[0m");

                key = Console.ReadKey(true);

                switch (key.Key) //when key is pressed:
                {
                    case ConsoleKey.DownArrow:
                        option = (option == 4 ? option = 1 : option + 1); //if the cursor is at the last option and the user presses down, it will return to the top/first option. otherwise it goes down one
                        break;
                    case ConsoleKey.UpArrow:
                        option = (option == 1 ? option = 4 : option - 1); //if the cursor is at the first option and the user pressed up, it will return to the last/bottom option. otherwise it just goes up one
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }

            if (option == 1)
            {
                Console.Clear();
                Console.WriteLine("\t-------------------");
                Console.WriteLine("\tSelect Game to View Match History");
                Console.WriteLine("\t-------------------");

                ConsoleKeyInfo key2;
                
                bool isSelectedTwo = false;
                while (!isSelectedTwo)
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine($"{(option == 5 ? color : null)}League of Legends\x1b[0m");
                    Console.WriteLine($"{(option == 6 ? color : null)}Teamfight Tactics\x1b[0m");

                    key2 = Console.ReadKey(true);

                    switch (key2.Key) //when key is pressed:
                    {
                        case ConsoleKey.DownArrow:
                            option = (option == 6 ? option = 5 : option + 1); //if the cursor is at the last option and the user presses down, it will return to the top/first option. otherwise it goes down one
                            break;
                        case ConsoleKey.UpArrow:
                            option = (option == 5 ? option = 6 : option - 1); //if the cursor is at the first option and the user pressed up, it will return to the last/bottom option. otherwise it just goes up one
                            break;
                        case ConsoleKey.Enter:
                            isSelected = true;
                            break;
                    }

                }
            }

            return option;

        }

        public static async Task LiveMatch(Platform server, string summonerId, string version, IRiotBlossomClient client)
        {
            Console.WriteLine("Loading Live Match Data...");
           
            var game = await client.Riot.Spectator.GetCurrentGameInfoBySummonerIdAsync(server, summonerId); //returns the json file

            Console.WriteLine("\t-------------------");
            Console.WriteLine("\tLive Match Data");
            Console.WriteLine("\t-------------------");

            //list of all the banned champions in the live match
            List<Champion> banned = new();
            foreach (var gameInfo in game.BannedChampions)
                banned.Add(await client.DataDragon.GetChampionByIdAsync(version,Convert.ToInt32(gameInfo.ChampionId)));

            Console.WriteLine("Banned Champions in current match: ");
            foreach (var champ in banned)
                Console.WriteLine(champ.Name);
            
            

           
            //make a list of all the participants in the live match so we can pull the champions and summoner names of enemy and ally teams
            List<CurrentGameParticipant> players = new();
            Queue<CurrentGameParticipant> allyTeam = new();
            Queue<CurrentGameParticipant> enemyTeam = new();
            foreach (var player in game.Participants)
                players.Add(player);

            //if team id = summoner id's team id then add to allyteam list otherwise add to enemy team list.
           foreach(var player in players)
            {
                if (player.SummonerId == summonerId)
                {
                    allyTeam.Enqueue(player);

                    if (player.TeamId == allyTeam.First().TeamId)
                    {
                        allyTeam.Enqueue(player);
                    }
                    else
                        enemyTeam.Enqueue(player);
                }
            }

           allyTeam.Dequeue();
            Console.WriteLine("\tPlayer's Ally Team:\n");
            foreach (var summoner in allyTeam)
                Console.WriteLine($"{summoner.SummonerName} is playing {await client.DataDragon.GetChampionByIdAsync(version, Convert.ToInt32(summoner.ChampionId))}\n" +
                    $"Runes: {summoner.Perks.PerkStyle} {summoner.Perks.PerkSubStyle} \n Summoner Spells: {summoner.Spell1Id} {summoner.Spell2Id}\n");

            Console.WriteLine("\t Player's Enemy Team:\n");
            foreach (var summoner in enemyTeam)
                Console.WriteLine($"{summoner.SummonerName} is playing {await client.DataDragon.GetChampionByIdAsync(version, Convert.ToInt32(summoner.ChampionId))}\n" +
                    $"Runes: {summoner.Perks.PerkStyle} {summoner.Perks.PerkSubStyle} \n Summoner Spells: {summoner.Spell1Id} {summoner.Spell2Id}\n");

        }
    }
}