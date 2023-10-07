﻿using BlossomiShymae.RiotBlossom.Api;
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
using System.Runtime.CompilerServices;
using BlossomiShymae.RiotBlossom.Dto.Riot.ChampionMastery;

/**       
 *--------------------------------------------------------------------
 * 	   File name: Program.cs
 * 	Project name: LeagueAPI
 *--------------------------------------------------------------------
 * Author’s name and email:	 kinsley crowdis crowdis@etsu.edu			
 *          Course-Section: CSCI 2900-800
 *           Creation Date:	10/03/2023
 * -------------------------------------------------------------------
 */
namespace LeagueAPI
{
    public class Program
    {
        static string key = "RGAPI-d277bffa-2077-4192-95ec-d21c284d0d66";

        static async Task Main(string[] args)
        {

            /*
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


            var clientRiot = RiotBlossomCore.CreateClient(key);
            var version = await clientRiot.DataDragon.GetLatestVersionAsync();


            Platform userInputServer = ServerMenu();

        summonerName:
            Console.Write("Enter Player's Name: ");
            string userInputName = Console.ReadLine().Trim();

            try
            {
                var summoner = await clientRiot.Riot.Summoner.GetByNameAsync(userInputServer, userInputName);
                Console.WriteLine($"\nShowing {summoner.Name}\nLevel: {summoner.SummonerLevel}");

                bool menu = true;
                while (menu)
                {
                    int option = PlayerMenu();
                    switch (option)
                    {
                        case 2: //champion masteries
                            await ChampionMasteries(userInputServer, summoner.Id, version, clientRiot);
                            break;
                        case 3: //challenges
                            await Challenges(userInputServer, summoner.Puuid, version, clientRiot);
                            break;
                        case 4:
                            try
                            {
                                await LiveMatch(userInputServer, summoner.Id, version, clientRiot);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Player is not in a live match.");
                            }
                            break;
                        case 5: //exit
                            menu = false;
                            break;
                        case 6: //league match history
                            await LeagueMatches(userInputServer, summoner.Puuid, clientRiot);
                            break;
                        case 7: //tft match history
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("User not found. Try again");
                goto summonerName;
            }

            Console.WriteLine("Thanks for using");
        }

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
                Console.WriteLine($"{(option == 10 ? color : null)}TR: Turkey\x1b[0m");
                Console.WriteLine($"{(option == 11 ? color : null)}RU: Russia\x1b[0m");
                Console.WriteLine($"{(option == 12 ? color : null)}PH: The Philippines\x1b[0m"); //PH2
                Console.WriteLine($"{(option == 13 ? color : null)}SG: Singapore, Malaysia, & Indonesia\x1b[0m"); //SG2
                Console.WriteLine($"{(option == 14 ? color : null)}TH: Thailand\x1b[0m");
                Console.WriteLine($"{(option == 15 ? color : null)}TW: Taiwan, Hong Kong, and Macao\x1b[0m");
                Console.WriteLine($"{(option == 16 ? color : null)}VN: Vietnam\x1b[0m");
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
                    userPlatform = Platform.LatinAmericaSouth;
                    test = "la2";
                    break;
                case 8:
                    userPlatform = Platform.Oceania;
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
            int optionTwo = 0;
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
                Console.WriteLine($"{(option == 5 ? color : null)}Exit\u001b[0m");

                key = Console.ReadKey(true);

                switch (key.Key) //when key is pressed:
                {
                    case ConsoleKey.DownArrow:
                        option = (option == 5 ? option = 1 : option + 1); //if the cursor is at the last option and the user presses down, it will return to the top/first option. otherwise it goes down one
                        break;
                    case ConsoleKey.UpArrow:
                        option = (option == 1 ? option = 5 : option - 1); //if the cursor is at the first option and the user pressed up, it will return to the last/bottom option. otherwise it just goes up one
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
                Console.WriteLine(option);
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
                    Console.WriteLine($"{(optionTwo == 1 ? color : null)}League of Legends\x1b[0m");
                    Console.WriteLine($"{(optionTwo == 2 ? color : null)}Teamfight Tactics\x1b[0m");

                    key2 = Console.ReadKey(true);

                    switch (key2.Key) //when key is pressed:
                    {
                        case ConsoleKey.DownArrow:
                            optionTwo = (optionTwo == 2 ? optionTwo = 1 : optionTwo + 1); //if the cursor is at the last option and the user presses down, it will return to the top/first option. otherwise it goes down one
                            break;
                        case ConsoleKey.UpArrow:
                            optionTwo = (optionTwo == 1 ? optionTwo = 2 : optionTwo - 1); //if the cursor is at the first option and the user pressed up, it will return to the last/bottom option. otherwise it just goes up one
                            break;
                        case ConsoleKey.Enter:
                            isSelectedTwo = true;
                            break;
                    }
                    Console.WriteLine(optionTwo);
                }
            }

            if (optionTwo == 1)
                option = 6;
            else if (optionTwo == 2)
                option = 7;

            return option;

        }

        public static async Task ChampionMasteries(Platform server, string summonerId, string version, IRiotBlossomClient clientRiot)
        {
            Console.WriteLine("Loading Champion Masteries... ");

            var masteries = await clientRiot.Riot.ChampionMastery.ListBySummonerIdAsync(server, summonerId);

            var sortedMasteries = masteries.OrderByDescending(x => x.ChampionLevel).ToList();

            Console.WriteLine("\t-------------------");
            Console.WriteLine("\t Top Ten Champions");
            Console.WriteLine("\t-------------------");
            Console.WriteLine();
            Console.WriteLine($"{"Name",16} Level {"Total Points",-16}"); //16 spaces behind "Name" ... 16 spaces infront of "Total Points"
             
            foreach (var item in sortedMasteries)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"{(await clientRiot.DataDragon.GetChampionByIdAsync(version, Convert.ToInt32(item.ChampionId))).Name,16} {item.ChampionLevel} {item.ChampionPoints,-16}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Hit enter to return to menu.");
            Console.ReadLine();
        }

        public static async Task Challenges(Platform server, string summonerPuuid, string version, IRiotBlossomClient clientRiot)
        {
            Console.WriteLine("Loading Challenges...");

            var challenges = await clientRiot.Riot.LolChallenges.GetPlayerInfoByPuuidAsync(server, summonerPuuid);

            Console.WriteLine();
            Console.WriteLine("Hit enter to return to menu.");
            Console.ReadLine();

        }
        public static async Task LeagueMatches(Platform server, string summonerPUUID, IRiotBlossomClient clientRiot)
        {
            Console.WriteLine("Loading Matches...");
            var ids =
                 await clientRiot.Riot.Match.ListIdsByPuuidAsync(server, summonerPUUID);

            List<MatchDto> matches = new();
            foreach (string id in ids)
                matches.Add(await clientRiot.Riot.Match.GetByIdAsync(server, id));

            Console.WriteLine($"{"Champion",-16} Role {"K/D/A",16}"); // 16 spaces behind "Champion" ... 16 spaces infront of "KDA"

            int kills = 0;
            int deaths = 0;
            int goldEarned = 0;
            var sortedMatches = matches.Select(m => m.Info.Participants.Where(p => p.Puuid == summonerPUUID).First()).ToList();

            foreach (var match in sortedMatches)
            {
                Console.WriteLine($"{match.ChampionName,-16} {((match.TeamPosition) == "UTILITY" ? "SUPPORT" : (match.TeamPosition))} {$" {match.Kills}/{match.Deaths}/{match.Assists}",16}");
 
                kills += match.Kills;
                deaths += match.Deaths;
                goldEarned += match.GoldEarned;
            }

            Console.WriteLine();
            Console.WriteLine($"\tAverage KDA is: {((kills + deaths) / matches.Count())}");
            Console.WriteLine($"\tAverage Gold Earned is: {goldEarned / matches.Count()}");

            Console.WriteLine();
            Console.WriteLine("Hit enter to return to menu.");
            Console.ReadLine();
        }
        public static async Task TFTMatches()
        {
            Console.WriteLine();
            Console.WriteLine("Hit enter to return to menu.");
            Console.ReadLine();
        }
        public static async Task LiveMatch(Platform server, string summonerId, string version, IRiotBlossomClient clientRiot)
        {
            Console.WriteLine($"Loading Live Match Data...");

            CurrentGameInfo game = await clientRiot.Riot.Spectator.GetCurrentGameInfoBySummonerIdAsync(server, summonerId); //returns the json file

            Console.WriteLine("\t-------------------");
            Console.WriteLine("\tLive Match Data");
            Console.WriteLine("\t-------------------");

            //list of all the banned champions in the live match
            List<Champion> banned = new();
            foreach (var gameInfo in game.BannedChampions)
                banned.Add(await clientRiot.DataDragon.GetChampionByIdAsync(version, Convert.ToInt32(gameInfo.ChampionId)));

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
            foreach (var player in players)
            {
                if (player.SummonerId == summonerId)
                {
                    allyTeam.Enqueue(player);
                }
            }

            foreach (var player in players)
            {
                if (player.TeamId == allyTeam.First().TeamId)
                {
                    allyTeam.Enqueue(player);
                }
                else
                    enemyTeam.Enqueue(player);
            }

            allyTeam.Dequeue(); //there will be a duplicate so we remove the first one to get rid of the duplicate.

            // TODO: add what rank the player is. Rank: {(await clientRiot.Riot.League.GetLeagueByIdAsync(server,summoner.SummonerId)).Tier}
            // TODO: add summoner spells

            Console.WriteLine("\n\t Player's Ally Team:\n");
            foreach (var summoner in allyTeam)
                Console.WriteLine($"{summoner.SummonerName} is playing {(await clientRiot.DataDragon.GetChampionByIdAsync(version, Convert.ToInt32(summoner.ChampionId))).Name}\n  \n" +
                    $"Runes: {(await clientRiot.DataDragon.GetPerkStyleByIdAsync(version, Convert.ToInt32(summoner.Perks.PerkStyle))).Name} & {(await clientRiot.DataDragon.GetPerkStyleByIdAsync(version, Convert.ToInt32(summoner.Perks.PerkSubStyle))).Name} \n"); // Summoner Spells: {await ISummonerSpells.GetSpellNameByIdAsync(summoner.Spell1Id)} {await ISummonerSpells.GetSpellNameByIdAsync(summoner.Spell2Id)}\n");

            Console.WriteLine("\t Player's Enemy Team:\n");
            foreach (var summoner in enemyTeam)
                Console.WriteLine($"{summoner.SummonerName} is playing {(await clientRiot.DataDragon.GetChampionByIdAsync(version, Convert.ToInt32(summoner.ChampionId))).Name}\n " +
                    $"Runes: {(await clientRiot.DataDragon.GetPerkStyleByIdAsync(version, Convert.ToInt32(summoner.Perks.PerkStyle))).Name} & {(await clientRiot.DataDragon.GetPerkStyleByIdAsync(version, Convert.ToInt32(summoner.Perks.PerkSubStyle))).Name}"); // \n Summoner Spells: {(await client.DataDragon.GetSpellByIdAsync(version, Convert.ToInt32(summoner.Spell1Id))).Name} {summoner.Spell2Id}\n");

            Console.WriteLine();
            Console.WriteLine("Hit enter to return to menu.");
            Console.ReadLine();
        }
    }
}