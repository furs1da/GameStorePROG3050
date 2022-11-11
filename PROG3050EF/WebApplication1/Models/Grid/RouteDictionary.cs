﻿using System;
using System.Collections.Generic;
using System.Linq;
using GameStore.Models.DTOs;
using GameStore.Models.ExtensionModels;

namespace GameStore.Models.Grid
{
    public static class FilterPrefix
    {
        public const string Category = "category-";
        public const string GameFeature = "gamefeature-";
        public const string Platform = "platform-";
        public const string Price = "price-";
    }

    public class RouteDictionary : Dictionary<string, string>
    {
        public int PageNumber
        {
            get => Get(nameof(GridDTO.PageNumber)).ToInt();
            set => this[nameof(GridDTO.PageNumber)] = value.ToString();
        }

        public int PageSize
        {
            get => Get(nameof(GridDTO.PageSize)).ToInt();
            set => this[nameof(GridDTO.PageSize)] = value.ToString();
        }

        public string SortField
        {
            get => Get(nameof(GridDTO.SortField));
            set => this[nameof(GridDTO.SortField)] = value;
        }

        public string SortDirection
        {
            get => Get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }

        public void SetSortAndDirection(string fieldName, RouteDictionary current)
        {
            this[nameof(GridDTO.SortField)] = fieldName;

            if (current.SortField.EqualsNoCase(fieldName) &&
                current.SortDirection == "asc")
                this[nameof(GridDTO.SortDirection)] = "desc";
            else
                this[nameof(GridDTO.SortDirection)] = "asc";
        }

        public string PriceFilter
        {
            get => Get(nameof(GamesGridDTO.Price))?.Replace(FilterPrefix.Price, "");
            set => this[nameof(GamesGridDTO.Price)] = value;
        }

        public string CategoryFilter
        {
            get
            {
                string s = Get(nameof(GamesGridDTO.Category))?.Replace(FilterPrefix.Category, "");
                int index = s?.IndexOf('-') ?? -1;
                return (index == -1) ? s : s.Substring(0, index);
            }
            set => this[nameof(GamesGridDTO.Category)] = value;
        }

        public string PlatformFilter
        {
            get
            {
                string s = Get(nameof(GamesGridDTO.Platform))?.Replace(FilterPrefix.Platform, "");
                int index = s?.IndexOf('-') ?? -1;
                return (index == -1) ? s : s.Substring(0, index);
            }
            set => this[nameof(GamesGridDTO.Platform)] = value;
        }

        public string GameFeatureFilter
        {
            get
            {
                string s = Get(nameof(GamesGridDTO.GameFeature))?.Replace(FilterPrefix.GameFeature, "");
                int index = s?.IndexOf('-') ?? -1;
                return (index == -1) ? s : s.Substring(0, index);
            }
            set => this[nameof(GamesGridDTO.GameFeature)] = value;
        }



        public void ClearFilters() =>
            PriceFilter = CategoryFilter = PlatformFilter = GameFeatureFilter = GamesGridDTO.DefaultFilter;

        private string Get(string key) => Keys.Contains(key) ? this[key] : null;

        public RouteDictionary Clone()
        {
            var clone = new RouteDictionary();
            foreach (var key in Keys)
            {
                clone.Add(key, this[key]);
            }
            return clone;
        }
    }
}