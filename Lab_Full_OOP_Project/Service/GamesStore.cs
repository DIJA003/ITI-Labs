using Lab_Full_OOP_Project.Models;
using Lab_Full_OOP_Project.Models.Enums;

namespace Lab_Full_OOP_Project.Service
{
    public class GamesStore
    {
        public Player[] players { get; private set; } = new Player[100];
        public Game[] games { get; private set; } = new Game[100];
        public Purchase[] purchase { get; private set; } = new Purchase[200];
        public int playerCnt = 0, gameCnt = 0,purchaseCnt = 0;
        
        public void RegisterPlayer()
        {
            Console.Clear();
            if (players.Length <= playerCnt) 
            {
                Console.WriteLine("maximum numbers of players reached");
                return;
            }
            Console.Write("Enter player Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter player Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter initiale Wallet Balance: ");
            double balance =double.Parse(Console.ReadLine());
            Player player = new Player(playerCnt + 1, name, email, balance);
            players[playerCnt++] = player;
            Console.WriteLine("Player registered successfully, press a key to continue");
            Console.ReadKey(true);
        }
        public void AddGame()
        {
            Console.Clear();
            if (games.Length <= gameCnt)
            {
                Console.WriteLine("maximum numbers of games reached");
                return;
            }

            Console.Write("Enter game id : ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter game Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter game type (action,strategy,..etc): ");
            string type = Console.ReadLine();

            GameType gameType;
            if (!Enum.TryParse(type,true, out gameType))
            {
                Console.WriteLine("invaild type, default set to action");
                gameType = GameType.Action;
            }

            Console.Write("Enter Plateform (PC,Switch,..etc): ");
            string plat= Console.ReadLine();

            PlatformType platform;
            if (!Enum.TryParse(plat,true, out platform))
            {
                Console.WriteLine("invaild type, default set to pc");
                platform = PlatformType.PC;
            }
            Console.Write("Enter Game price: ");
            double price = double.Parse(Console.ReadLine());

            Game game = new Game(id, title,gameType,platform,price);
            games[gameCnt++] = game;
            Console.WriteLine("Game added successfully, press a key to continue");
            Console.ReadKey(true);
        }

        public Player GetPlayerById(int id)
        {
            foreach (var player in players)
            {
                if (player.Id == id)
                {
                    return player;
                }
            }
            return null;
        }

        public Game GetGameById(int id)
        {
            foreach (var game in games)
            {
                if (game.Id == id)
                {
                    return game;
                }
            }
            return null;
        }
        public void ListAllPlayers() 
        {
            Console.Clear();
            if (playerCnt == 0) 
            { 
                Console.WriteLine("there are no players, press enter to continue");
                Console.ReadKey(true);
                return;
            }
            foreach (var player in players) if (player != null)
                player.DisplayInfo();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey(true);
        }
        public void ListAllGames()
        {
            Console.Clear();
            if (gameCnt == 0)
            {
                Console.WriteLine("there are no games, press enter to continue");
                Console.ReadKey(true);
                return;
            }
            foreach (var game in games) if(game != null)
                game.DisplayInfo();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }

        public void UpdatePlayerInfo() 
        {
            Console.Clear();
            Console.Write("Enter player ID: ");
            int id = int.Parse(Console.ReadLine());
            Player player = GetPlayerById(id);
            if (player != null)
            {
                Console.WriteLine("Enter new name: ");
                string newName = Console.ReadLine();
                Console.WriteLine("Enter new email:");
                string newemail = Console.ReadLine();
                player.UpdateInfo(newName, newemail);
            }
            else
            {
                Console.WriteLine("there is no player with this id");
            }
            Console.WriteLine("Press a key to continue");
            Console.ReadKey(true);

        }

        public void ViewPlayerDetails() 
        {
            Console.Clear();
            Console.Write("Enter player id: ");
            int id = int.Parse(Console.ReadLine());
            Player player = GetPlayerById(id);
            if (player != null)
            {
                Console.WriteLine("Player inforamtion: ");
                player.DisplayInfo();
                Console.WriteLine("Games purchased: ");
                if(player.ownedGames.Length == 0) Console.WriteLine("no games purchased");
                else foreach(Game game in player.ownedGames) if (game!=null) Console.WriteLine($"- {game.Title}");
            }
            else Console.WriteLine("there is no player with this id");
            Console.WriteLine("Press a key to continue");
            Console.ReadKey(true);
        }
        public void PurchaseGame() 
        {
            Console.Clear();
            Console.Write("Enter player id: ");
            int playerId = int.Parse(Console.ReadLine());
            Player player = GetPlayerById(playerId);
            if (player == null)
            {
                Console.WriteLine("there is no player with this id");
                return;
            }
            Console.Write("enter game id: ");
            int gameid = int.Parse(Console.ReadLine());
            Game game = GetGameById(gameid);
            if (game == null)
            {
                Console.WriteLine("there is no game with this id");
                return;
            }
            if (player.HasGame(gameid))
            {
                Console.WriteLine("Player already has this game");
                return;
            }
            if (player.walletBalance < game.Price)
            {
                Console.WriteLine("player doesn't have enough balance");
                return;
            }
            player.AddGame(game);
            purchase[purchaseCnt++] = new Purchase(player, game);
            Console.WriteLine($"{player.Username} purchased {game.Title}");
            Console.WriteLine("Press a key to continue");
            Console.ReadKey(true);
        }

        public void ViewPlayerPurchases()
        {
            Console.Clear();
            Console.Write("Enter player id: ");
            int id = int.Parse(Console.ReadLine());
            Player player = GetPlayerById(id);
            if (player == null)
            {
                Console.WriteLine("there is no player with this id");
                return;
            }
            if (player.purchaseCnt == 0)
            {
                Console.WriteLine("there is no games purchased");
                return;
            }
            foreach (var game in player.ownedGames) if(game != null )Console.WriteLine(game.Title);
            Console.WriteLine("Press a key to continue");
            Console.ReadKey(true);


        }

        public void AddDLCToGame()
        {
            Console.Clear();
            Console.Write("Enter game id: ");
            int gameid = int.Parse(Console.ReadLine());
            Game game = GetGameById(gameid);
            if (game == null)
            {
                Console.WriteLine("there is no game with this id");
                return;
            }
            Console.Write("Enter DLC id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter DLC name: ");
            string name = Console.ReadLine();
            Console.Write("Enter DLC price: ");
            double price = double.Parse(Console.ReadLine());
            InGameItems dlc = new InGameItems(id,name, price);
            game.AddDLC(dlc);
            Console.WriteLine("DLC added successfully, press a key to continue");
            Console.ReadKey(true);
        }

        public void ViewDLCOfGame()
        {
            Console.Clear();
            Console.Write("Enter game id: ");
            int id = int.Parse(Console.ReadLine());
            Game game = GetGameById(id);
            if (game == null)
            {
                Console.WriteLine("there is no game with this id,Press a key to continue");
                Console.ReadKey(true);
                return;
            }
            if (game.DlcCnt == 0)
            {
                Console.WriteLine("no dlcs found,Press a key to continue");
                Console.ReadKey(true);
                return;
            }
            foreach (InGameItems dlc in game.Dlcs)
            {
                if(dlc != null)
                dlc.DisplayInfo();
            }
            Console.WriteLine("Press a key to continue");
            Console.ReadKey(true);
        }

    }
}
