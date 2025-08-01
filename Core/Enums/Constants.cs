using System;
using System.ComponentModel;

namespace Core.Enums;

public class Constants
{
public static string UserLoggedKeySession = "AppCityHallLoggedUser";

    public enum AtlasIdentityState
    {
        [Description("OFF")]
        Off = 0,

        [Description("ON")]
        On = 1
    }

    public static Type[] SeederTypesAndOrder = [
        // typeof(Alcaldia),
        // typeof(Departamento),
        // typeof(Rubro),
        // typeof(Tipo),
        // typeof(Clase),
        // typeof(Ingreso),
        // typeof(Rol),

        // typeof(Usuario)

        ];
        
    public static string[] SeederInsertExceptions = [
        // typeof(Rubro).Name,
        // typeof(Tipo).Name,
        // typeof(Clase).Name,
        // typeof(Ingreso).Name,
        ];

}
