﻿namespace ExpenseTracker.Models
{
    public class HomeViewmodel
    {
    }

    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
