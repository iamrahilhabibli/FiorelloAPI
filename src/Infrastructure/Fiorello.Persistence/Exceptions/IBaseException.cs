﻿namespace Fiorello.Persistence.Exceptions;

public interface IBaseException
{
    public int StatusCode { get; set; }
    public string CustomMessage { get; set; }
}
