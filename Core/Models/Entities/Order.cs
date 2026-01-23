using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Atlas.Core.Entities;
using Core.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.Models.Entities;

public partial class Order : BaseEntity
{
    // [NotMapped]
    // public Customer Customer { get; set; } = null!;

    // [NotMapped]
    // public Address Address { get; set; } = null!;

    // [NotMapped]
    // public IEnumerable<Producto> Items { get; set; } = null!;

    [StringLength(4)]
    [Unicode(false)]
    public string Currency { get; set; } = null!;

    [NotMapped]
    public string NotifyUrl { get; set; } = null!;



    [StringLength(100)]
    [Unicode(false)]
    public string ApiId { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string ApiAcountId { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string ApiCustomerId {get; set;} = null!;

    // public int DireccionId {get; set;}

    [StringLength(100)]
    [Unicode(false)]
    public string ApiType {get;set;} = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string ApiNumber {get;set;} = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string ApiStatus { get; set; } = null!;

    public int EnvioId { get; set; } 

    public virtual Customer Customer { get; set; } = null!;


    // public virtual Direccion Address { get; set; } = null!;

    // public virtual Direccion Direccion { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual ICollection<ProductoOrder> ProductoOrder { get; set; } = new List<ProductoOrder>();


    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

}
