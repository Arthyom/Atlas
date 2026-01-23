using System;
using Core.DTOs.Base;

namespace Core.DTOs;

public class AtlasDtoKeyValue : AtlasBaseDto
{
    public int Key { get; set; } 
    public string Value { get; set; } = null!;

}

public class DtoKeyValueWrapper : AtlasBaseDto
{
    public IEnumerable<AtlasDtoKeyValue> Items {get; set;}= null!;
}