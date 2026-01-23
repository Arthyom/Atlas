using System;
using Core.DTOs.Base;

namespace Core.DTOs;

public class DtoEstado : AtlasBaseDto
{
    public string code { get; set; }   = null!;
}
