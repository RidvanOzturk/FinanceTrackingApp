﻿using DataLayer.Entities;


namespace ServiceLayer.DTOs;

public class AddIncomeRequestDTO
{
    public string username { get; set; }
    public decimal amount {  get; set; }
    public int CategoryId { get; set; }
    public DateTime date { get; set; }
}
