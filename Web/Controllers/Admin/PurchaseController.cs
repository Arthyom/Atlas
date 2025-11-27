using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Atlas.Core.Entities;
using Core.DTOs;
using Core.Models.Entities;
using Core.Services.Interfaces;
using Core.Services.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Controllers.Base;

namespace Web.Controllers.Admin
{
    public class PurchaseController : AtlasMixedFileBaseController<Order, DtoOrder, DtoOrderResponse>
    {
        public PurchaseController(IOrderService baseService) : base(baseService, "Purchase")
        {
        }
    }
}