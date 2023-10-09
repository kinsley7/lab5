# lab5
lab 5 for 2910

<h2> 📖Table of Contents</h2>

-  [Plan from Lab 4](https://github.com/kinsley7/lab5/tree/main#-plan-from-lab-4-/)
- [Screenshots](https://github.com/kinsley7/lab5/tree/main#-screenshots-)
-  [Challenges](https://github.com/kinsley7/lab5/tree/main#-challenges-)

<p align = "center"> <h2> 📑Plan from lab 4: </h2> </p>

- view a player's league and tft match history
- view a player's champion masteries
- view challenges a player has completed & the progress made
- display the current match stats for a player that is in a live game
  

<p align = "center"> <h2> 📸Screenshots </h2> </p>

- Select Server and enter the name of the user to view
  - <img width="431" alt="image" src="https://github.com/kinsley7/lab5/assets/113950546/09edb789-172d-4b48-9ab4-c303af1a16dc">

- Select an option to view
   - <img width="215" alt="image" src="https://github.com/kinsley7/lab5/assets/113950546/51e5c4ba-c372-4972-a849-3280535cefe8">

- View Match History
  - Select League or TFT
  - <img width="256" alt="image" src="https://github.com/kinsley7/lab5/assets/113950546/940ca58d-ce71-423f-9cf5-90d356b3d8ba">
  - League:
    - <img width="431" alt="image" src="https://github.com/kinsley7/lab5/assets/113950546/29dec873-2ee4-4c8d-ac3a-3da748690f2a">
  - TFT:
   - <img width="231" alt="image" src="https://github.com/kinsley7/lab5/assets/113950546/a89bb154-16be-4b70-a106-11bcaac40664">




- View Champion Masteries
   - <img width="307" alt="image" src="https://github.com/kinsley7/lab5/assets/113950546/6c57f110-dfeb-4db8-81f5-319b137011c6">



- View Challenges
  - <img width="718" alt="image" src="https://github.com/kinsley7/lab5/assets/113950546/6c58db6f-4764-412d-9480-41c14f3463ff">



- View Live Match
  - See banned champions:
    - <img width="304" alt="image" src="https://github.com/kinsley7/lab5/assets/113950546/be777519-955f-488a-8409-54a60a0ea777">
  - View Ally and Enemy teams:
    - <img width="269" alt="image" src="https://github.com/kinsley7/lab5/assets/113950546/8283d410-ce92-481a-b3fb-49d61e0cbcc2">

  - proof...
    - <img width="626" alt="image" src="https://github.com/kinsley7/lab5/assets/113950546/33634aae-4b7b-4576-a2e8-5e4cc68db141"> tadaa 🪄
 
 
  

 


<p align = "center"> <h2> ⭐Challenges: </h2> </p>

I had to learn how to use this NuGet package that was created for the API ([RiotBlossom](https://blossomishymae.github.io/RiotBlossom/)), luckily it follows the Riot Games documentation and everything is named or put inside where the documentation says it would be.
-	I did test if I was able to use my user input menus and search for a player without using the package and I was able to.
     - <img width="263" alt="image" src="https://github.com/kinsley7/lab5/assets/113950546/b9e2f0b4-4ee5-4a60-8742-92609d174d1c">
     - The “test” string is what would be entered into the link that the API would receive: https://{test}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{userInputName}?page=1&api_key={key}
       
In order to create methods I have to pass through several objects like the client, version, and summonerID as these cannot be made static.

There are a lot of servers so in order to have the user select the correct one I decided to try a selection screen where you use the arrow keys to select an option in the menus. No more ReadLines() and all of the if/trycatch/switch statements that would be created because of it. It’s a lot easier to have the user use arrow and enter keys.
-	I had to google how to do this and watched a YouTube video (https://www.youtube.com/watch?v=YyD1MRJY0qI&ab_channel=RicardoGerbaudo) which thoroughly explains the entire thought process behind it. With this video, I was able to replicate it and create menus that fit my needs. 
-	The first error I encountered with this was that the Unicode escape character was causing not all of my text to be colored. I had to switch from the Unicode to the ASCII escape character.
-	The next issue I ran into was the Console.SetCursorPosition(left, top); causing issues when I wanted my second menu to display (It would overlap other text on the console because it would go all the way to the top and display). The fix here was to use a console.clear().

Another big issue I ran into was how to display things the way I wanted them to be displayed. I did a lot of digging through the API documentation and by following the documentation I was able to figure out what information I could pull and from where.

-	I want to put the players who share the same teamID as the summonerID that we searched for in the allyteam list and the players who don’t in the enemy team list. That way I can display who the player we are searching for is playing with and who they are against (and what champions, runes, and summoner spells everyone is using). I was stuck and knew I could use some select and where LINQ statements or a forreach and loop but I needed to get the summonerID that was equal to the one we were searching for out of that loop. After I pull that out I can do a loop or select where statement with the teamID from the summoner.
I figured it out after writing the issue out ^
     - <img width="431" alt="image" src="https://github.com/kinsley7/lab5/assets/113950546/19431c07-c5c2-4fa2-89df-7ffe97b93584">
     - Using a queue I can take the first player out of the ally teams list because the player we are searching for would appear twice (because the teamID would be equal to the teamID of the first object in the list… which is the player we are searching for).
    

Some places a different API had to be called. 

- Riot Games API only displays championIDs. In order to get the name of the champion I need to call on an API called DataDragon which will take the champion ID and the version of the game and output the name of the champion.
   - You can see me use this here:
   - <img width="521" alt="image" src="https://github.com/kinsley7/lab5/assets/113950546/79a4db1e-c0f2-414d-981e-063e6fb7efc6">

<br>

~~New issue where i need to get the name of summoner spells but the nuget package im using does not provide a method or class that will convert the id to the name. so i will have to use a json and convert it manually. will update~~ Fixed 10/07/2023.

- I created a new class (SummonerSpells.cs) and instead of using datadragon, which is outdated, switched to using communitydragon's api endpoint which is much cleaner and easier to work with (instead of having a class for each spell, and these classes inside another class that it gets deserialized to, its only one class!).
   - All i did after that was convert the id JSON object and id obj we are passing through to a string and ran a simple loop that checks if they match. if they do then it displays the summoner spell's name. Seen here:
   - <img width="275" alt="image" src="https://github.com/kinsley7/lab5/assets/113950546/8301a3ca-154c-444a-8548-a9d133db6cb6"> <img width="641" alt="image" src="https://github.com/kinsley7/lab5/assets/113950546/c470dd80-a5ee-4f76-aefc-94016e8c67ac">

<br>

Another challenge was the Challenges method. I needed to convert the id to name and I thought I would have to create a class and do the same thing I did with summoner spells. I did not. I needed to call on different endpoints.
- First I had to call on the endpoint to get the information for the user, then I needed to take the List of challenges, do a foreach, then take the id from the challenge and put it in another endpoint so I could get the information for the challenge specifically. Once I got this I did another loop so only the English name and description were returned. Seen below.
- (I also needed to skip the first 6 as these are just totals for categories and don't show in-game, and order the list by the level which I did with a dictionary as level is a string).
  - <img width="525" alt="image" src="https://github.com/kinsley7/lab5/assets/113950546/afa7e6cd-fa0d-4744-95e4-d3015f6167ac">
 



