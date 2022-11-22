﻿using GameStore.Data;

namespace GameStore.Models.Repositories
{
    public interface IGameStoreUnitOfWork
    {
        // Game 
        Repository<Game> Games { get; }
        Repository<Category> Categories { get; }
        Repository<GameFeature> GameFeatures { get; }
        Repository<Platform> Platforms { get; }

        Repository<GameCategory> GameCategories { get; }
        Repository<PlatformGame> PlatformGames { get; }
        Repository<GameFeatureGame> GameFeatureGames { get; }

        // Event

        Repository<Event> Events { get; }
        Repository<Customer> Customers { get; }

        //Event 
        void DeleteCurrentCustomers(Event eventItem);

        //Game
        void DeleteCurrentGameCategories(Game game);
        void LoadNewGameCategories(Game game, int[] categoryids);

        void DeleteCurrentPlatformGames(Game game);
        void LoadNewPlatformGames(Game game, int[] platformids);

        void DeleteCurrentGameFeatureGames(Game game);
        void LoadNewGameFeatureGames(Game game, int[] gamefeatureids);

        void Save();
    }
}
