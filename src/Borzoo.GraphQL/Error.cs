﻿using System;
using GraphQL;

namespace Vivid.GraphQL
{
    public class Error : ExecutionError
    {
        public string Type { get; set; }
        
        public Error(string message)
            : base(message)
        {
        }

        public Error(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}