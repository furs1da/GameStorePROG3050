using GameStore.Data;
using GameStore.Models.Query;

namespace GameStore.Models.Repositories
{
    public class GameStoreUnitOfWork : IGameStoreUnitOfWork
    {
        private StoreContext context { get; set; }
        public GameStoreUnitOfWork(StoreContext ctx) => context = ctx;

        private Repository<Merchandise> merchandiseData;

        public Repository<Merchandise> Merchandises
        {
            get
            {
                if (merchandiseData == null)
                    merchandiseData = new Repository<Merchandise>(context);
                return merchandiseData;
            }
        }


        private Repository<Order> orderData;

        public Repository<Order> Orders
        {
            get
            {
                if (orderData == null)
                    orderData = new Repository<Order>(context);
                return orderData;
            }
        }

        private Repository<Review> reviewData;

        public Repository<Review> Reviews
        {
            get
            {
                if (reviewData == null)
                    reviewData = new Repository<Review>(context);
                return reviewData;
            }
        }

        private Repository<CreditCard> creditCardData;

        public Repository<CreditCard> CreditCards
        {
            get
            {
                if (creditCardData == null)
                    creditCardData = new Repository<CreditCard>(context);
                return creditCardData;
            }
        }




        private Repository<Event> eventData; 

        public Repository<Event> Events
        {
            get
            {
                if (eventData == null)
                    eventData = new Repository<Event>(context);
                return eventData;
            }
        }

        private Repository<Customer> customerData;
        public Repository<Customer> Customers
        {
            get
            {
                if (customerData == null)
                    customerData = new Repository<Customer>(context);
                return customerData;
            }
        }

        private Repository<CustomerEvent> customerEventData;
        public Repository<CustomerEvent> CustomerEvent
        {
            get
            {
                if (customerEventData == null)
                    customerEventData = new Repository<CustomerEvent>(context);
                return customerEventData;
            }
        }


        private Repository<Game> gameData;
        public Repository<Game> Games
        {
            get
            {
                if (gameData == null)
                    gameData = new Repository<Game>(context);
                return gameData;
            }
        }



        private Repository<Category> categoryData;
        public Repository<Category> Categories
        {
            get
            {
                if (categoryData == null)
                    categoryData = new Repository<Category>(context);
                return categoryData;
            }
        }

        private Repository<GameCategory> gamecategoryData;
        public Repository<GameCategory> GameCategories
        {
            get
            {
                if (gamecategoryData == null)
                    gamecategoryData = new Repository<GameCategory>(context);
                return gamecategoryData;
            }
        }



        private Repository<Platform> platformData;
        public Repository<Platform> Platforms
        {
            get
            {
                if (platformData == null)
                    platformData = new Repository<Platform>(context);
                return platformData;
            }
        }

        private Repository<PlatformGame> platformgameData;
        public Repository<PlatformGame> PlatformGames
        {
            get
            {
                if (platformgameData == null)
                    platformgameData = new Repository<PlatformGame>(context);
                return platformgameData;
            }
        }

        


        private Repository<GameFeature> gamefeatureData;
        public Repository<GameFeature> GameFeatures
        {
            get
            {
                if (gamefeatureData == null)
                    gamefeatureData = new Repository<GameFeature>(context);
                return gamefeatureData;
            }
        }

        private Repository<GameFeatureGame> gamefeaturegameData;
        public Repository<GameFeatureGame> GameFeatureGames
        {
            get
            {
                if (gamefeaturegameData == null)
                    gamefeaturegameData = new Repository<GameFeatureGame>(context);
                return gamefeaturegameData;
            }
        }



        public void DeleteCurrentCustomers(Event eventItem)
        {
            var currentCustomers = CustomerEvent.List(new QueryOptions<CustomerEvent>
            {
                Where = ce => ce.Eventid == eventItem.EventId
            });

            foreach (CustomerEvent ce in currentCustomers)
            {
                CustomerEvent.Delete(ce);
            }
        }


        public void DeleteCurrentGameCategories(Game game)
        {
            var currentCategories = GameCategories.List(new QueryOptions<GameCategory>
            {
                Where = gc => gc.Gameid == game.GameId
            });

            foreach (GameCategory gc in currentCategories)
            {
                GameCategories.Delete(gc);
            }
        }

        public void LoadNewGameCategories(Game game, int[] categoryids)
        {
            foreach (int id in categoryids)
            {
                GameCategory gc = new GameCategory { Game = game, Categoryid = id };
                GameCategories.Insert(gc);
            }
        }

        public void DeleteCurrentPlatformGames(Game game)
        {
            var currentPlatforms = PlatformGames.List(new QueryOptions<PlatformGame>
            {
                Where = pg => pg.Gameid == game.GameId
            });

            foreach (PlatformGame pg in currentPlatforms)
            {
                PlatformGames.Delete(pg);
            }
        }

        public void LoadNewPlatformGames(Game game, int[] platformids)
        {
            foreach (int id in platformids)
            {
                PlatformGame pg = new PlatformGame { Game = game, Platformid = id };
                PlatformGames.Insert(pg);
            }
        }



        public void DeleteCurrentGameFeatureGames(Game game)
        {
            var currentGameFeatures = GameFeatureGames.List(new QueryOptions<GameFeatureGame>
            {
                Where = gfg => gfg.Gameid == game.GameId
            });

            foreach (GameFeatureGame gfg in currentGameFeatures)
            {
                GameFeatureGames.Delete(gfg);
            }
        }

        public void LoadNewGameFeatureGames(Game game, int[] gamefeatureids)
        {
            foreach (int id in gamefeatureids)
            {
                GameFeatureGame gfg = new GameFeatureGame { Game = game, GameFeatureid = id };
                GameFeatureGames.Insert(gfg);
            }
        }

        public void Save() => context.SaveChanges();


    }
}
