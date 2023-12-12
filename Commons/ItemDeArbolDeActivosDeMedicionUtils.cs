using System;
using System.Collections.Generic;

public static class ItemDeArbolDeActivosDeMedicionUtils
{
    public static ItemDeArbolDeActivosDeMedicion? Get(IList<ItemDeArbolDeActivosDeMedicion> data, TipoDeItemDeArbol tipo, string nombre)
    {
        foreach (var item in data)
        {
            var match = Get(item, tipo, nombre);
            if (match is not null) return match;
        }

        return null;
    }

    public static ItemDeArbolDeActivosDeMedicion? Get(ItemDeArbolDeActivosDeMedicion item, TipoDeItemDeArbol tipo, string nombre)
    {
        if (item.Tipo != tipo)
        {
            var subItem = Get(item.SubItems, tipo, nombre);
            return subItem is null ? null : subItem;
        } else
        {
            if (item.Nombre.Contains(nombre, StringComparison.InvariantCultureIgnoreCase))
                return item;
        }

        return null;
    }

    public static ItemDeActivosDeMedicion_Vm? Get(IList<ItemDeActivosDeMedicion_Vm> data, TipoDeItemDeArbol tipo, string nombre)
    {
        foreach (var item in data)
        {
            var match = Get(item, tipo, nombre);
            if (match is not null) return match;
        }

        return null;
    }

    public static ItemDeActivosDeMedicion_Vm? Get(ItemDeActivosDeMedicion_Vm item, TipoDeItemDeArbol tipo, string nombre) { 
        if (item.Tipo != tipo)
        {
            var subItem = Get(item.Items, tipo, nombre);
            return subItem is null ? null : subItem;
        } else
        {
            if (item.Nombre.Contains(nombre, StringComparison.InvariantCultureIgnoreCase))
                return item;
        }

        return null;
    }
}
