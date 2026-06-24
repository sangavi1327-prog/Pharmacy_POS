using System;
using System.Collections.Generic;
using System.Linq;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.Utilities
{
    public static class LinearSearchHelper
    {
        /// <summary>
        /// LINEAR SEARCH ALGORITHM
        /// 
        /// Time Complexity: O(N) where N is the number of medicines.
        /// Space Complexity: O(1) auxiliary space.
        /// 
        /// Explanation:
        /// Linear Search iterates sequentially through each item in the list.
        /// For each element, it checks if the criteria matches. It is simple,
        /// doesn't require sorted data, and is optimal for small lists.
        /// </summary>
        public static List<Medicine> LinearSearch(List<Medicine> list, string keyword)
        {
            List<Medicine> results = new List<Medicine>();
            if (string.IsNullOrWhiteSpace(keyword)) return list;

            string lowerKeyword = keyword.ToLower();

            // Perform iterative check on each element
            for (int i = 0; i < list.Count; i++)
            {
                Medicine med = list[i];
                if ((med.MedicineName != null && med.MedicineName.ToLower().Contains(lowerKeyword)) ||
                    (med.Category != null && med.Category.ToLower().Contains(lowerKeyword)) ||
                    (med.Supplier != null && med.Supplier.ToLower().Contains(lowerKeyword)))
                {
                    results.Add(med);
                }
            }

            return results;
        }

        /// <summary>
        /// LINQ FILTERING
        /// 
        /// Time Complexity: O(N) but uses C# deferred execution and optimized internal enumerators.
        /// Space Complexity: O(N) for storing matching query items.
        /// 
        /// Explanation:
        /// LINQ (Language Integrated Query) leverages declarative filtering via Lambda expressions.
        /// It compiles down to an iterator pattern (yield return) and provides highly expressive,
        /// readable, and maintainable C# code.
        /// </summary>
        public static List<Medicine> LinqFilter(List<Medicine> list, string category, decimal? minPrice, decimal? maxPrice)
        {
            var query = list.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(m => string.Equals(m.Category, category, StringComparison.OrdinalIgnoreCase));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(m => m.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(m => m.Price <= maxPrice.Value);
            }

            return query.ToList();
        }
    }
}
