﻿using Fiorello.Persistence.Exceptions;
using System.Net;

namespace UnionArchitecture.Persistence.Exceptions;

public class RegistrationException : Exception, IBaseExceptions
{
    public int StatusCode { get; set; }
    public string CustomMessage { get; set; }

    public RegistrationException(string message) : base(message)
    {
        CustomMessage = message;
        StatusCode = (int)HttpStatusCode.BadRequest;
    }
}
