using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Atlas.Core.Entities;
using AutoMapper;
using Core.DTOs;
using Core.DTOs.Base;
using Core.DTOs.Usuario;
using Core.Models.Entities;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Core.Services.Implementations
{
    public class UsuarioMixedService : AtlasBaseServiceMixed<Usuario, DtoUsuarioRequest, DtoUsuarioResponse>, IUsuarioMixedService
    {
        private readonly IHttpContextAccessor _http;
        public UsuarioMixedService(IUnitOfWork UoW, IMapper mapper, IHttpContextAccessor http) : base(UoW, mapper)
        {
            _http = http;
        }



        public override async Task<AtlasMixedResponse<DtoUsuarioResponse>> Apply(DtoUsuarioRequest entity)
        {
           var user =  await _BaseRepository
            .DbSet
            .Where
            ( x => x.Password == entity.Password && (x.Email == entity.User || x.Nombre == entity.User ) )
            .Include( x => x.Origen)
            .Include( x => x.Origen.Direccion)
            .Include( x => x.Rol) 
            .AsNoTracking()
            .FirstOrDefaultAsync();


            if(user != null && _http.HttpContext != null)
            {

                string address = $"{user?.Origen?.Direccion.Street} {user?.Origen?.Direccion.OutdoorNumber} Int.{user?.Origen?.Direccion.InteriorNumber}";
                string serializedUser = JsonConvert.SerializeObject(user, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                string key = "loggedUserKey";
                string schema = "Cookies";
                List<Claim> claims = new List<Claim>()
                {
                    new Claim( ClaimTypes.Name, user?.Nombre ?? "test"),
                    new Claim( ClaimTypes.Country, user?.Origen?.Direccion?.CountryName ?? "test"),
                    new Claim( ClaimTypes.Email, user?.Email ?? "test"),
                    new Claim(ClaimTypes.PostalCode, user?.Origen?.Direccion?.ZipCode ?? "test"),
                    new Claim(ClaimTypes.StreetAddress, address),                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, key);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                CookieOptions cookieOptions = new CookieOptions()
                {
                  Path = "/",
                  Expires = DateTime.UtcNow.AddHours(2),
                  HttpOnly  = true,
                  Secure = true,
                  SameSite = SameSiteMode.Strict  
                };

                _http.HttpContext?.Session.SetString(key, serializedUser);
                _http.HttpContext?.Response.Cookies.Append(key, key, cookieOptions);
                await _http.HttpContext?.SignInAsync(schema , claimsPrincipal);
                
            }
            

            DtoUsuarioResponse mappedUser = _Mapper.Map<DtoUsuarioResponse>(user);

            return new AtlasMixedResponse<DtoUsuarioResponse>()
            {
                MainResource = mappedUser
            };
        
    }

        public async Task<bool> SignOut()
        {
            try
            {
                string key = "loggedUserKey";

                _http.HttpContext?.Session.Clear();
                _http.HttpContext?.Response.Cookies.Delete(key);
                await _http.HttpContext?.SignOutAsync();

                return true;
                
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}