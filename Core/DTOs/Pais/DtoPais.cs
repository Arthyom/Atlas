using System;
using Core.DTOs.Base;

namespace Core.DTOs;

public class DtoPais : AtlasBaseDto
{
    public string code { get; set; } = null!;
    public string name { get; set; }    = null!;
}
