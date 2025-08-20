using System;
using Core.Models.Entities.Base;

namespace Core.DTOs.Base;

public class AtlasMixedResponse<TObject> where TObject : class 
{
    public  TObject? MainResource { get; set; } = null;

    public IEnumerable<TObject> MainResourceCollection {get;set;} = null!;



    public dynamic? Extras { get; set; }
}
