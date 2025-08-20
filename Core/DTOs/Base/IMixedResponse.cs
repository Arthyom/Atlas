using System;
using Core.Models.Entities.Base;

namespace Core.DTOs.Base;

public interface IMixedResponse<TBase>  where TBase  : BaseEntity
{
        public TBase MainResource {get; set;}
        public dynamic? Extras { get; set; }
}
