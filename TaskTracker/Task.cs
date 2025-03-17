﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker;

public class Task
{
    public string Description { get; set; } = default!;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }
    public TaskStatus TaskStatus { get; set; }

    public Task(string description)
    {
        Description = description;
        CreatedAt = DateTime.Now;
    }
    public Task()
    {
        CreatedAt = DateTime.Now;
    }
}
