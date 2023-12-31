﻿using System.ComponentModel.DataAnnotations;
using TaskManagement.Models;

public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int TaskId { get; set; }
    public TaskManagement.Models.Task Task { get; set; }
}