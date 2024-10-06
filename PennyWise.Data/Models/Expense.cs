﻿namespace PennyWise.Data.Models;

public class Expense
{
    public int Id { get; set; }
    public string ExpenseTitle { get; set; }
    public string Category { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateCreated { get; set; }
}
