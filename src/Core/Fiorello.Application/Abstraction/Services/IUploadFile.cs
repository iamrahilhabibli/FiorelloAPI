﻿using Microsoft.AspNetCore.Http;

namespace Fiorello.Application.Abstraction.Services;

public interface IUploadFile
{
    Task<string> WriteFile(IFormFile file);
    Task<byte[]> DownlandFile(string file);
}
