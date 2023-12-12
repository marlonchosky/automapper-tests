using System.Collections.Generic;

public class ItemDeArbolDeActivosDeMedicion
{
    public long Id { get; }
    public string? Nombre { get; set; }
    public string? Abreviatura { get; set; }
    public byte[]? Imagen { get; set; }
    public int? IdPlataforma { get; set; }
    public int IdSecundario { get; set; }
    public IList<ItemDeArbolDeActivosDeMedicion> SubItems { get; set; } = new List<ItemDeArbolDeActivosDeMedicion>();

    public ItemDeArbolDeActivosDeMedicion? ItemPadre { get; private set; }

    public ItemDeArbolDeActivosDeMedicion(long id, TipoDeItemDeArbol? tipo = null)
    {
        this.Id = id;
        this.Tipo = tipo;
    }

    public TipoDeItemDeArbol? Tipo { get; }

    public void AgregarSubItems(params ItemDeArbolDeActivosDeMedicion[] subItems)
    {
        foreach (var subItem in subItems)
        {
            this.AgregarSubItemInterno(subItem);
        }
    }

    private void AgregarSubItemInterno(ItemDeArbolDeActivosDeMedicion subItem)
    {
        this.SubItems.Add(subItem);
        subItem.ItemPadre = this;
    }

    public override bool Equals(object obj)
    {
        if (obj is ItemDeArbolDeActivosDeMedicion otroItem)
        {
            return this.Equals(otroItem);
        }

        return false;
    }

    protected bool Equals(ItemDeArbolDeActivosDeMedicion other)
    {
        return this.Id == other.Id && this.Tipo == other.Tipo && this.IdPlataforma == other.IdPlataforma;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (this.Id.GetHashCode() * 397) ^ this.Tipo.GetHashCode();
        }
    }

    public static bool operator ==(ItemDeArbolDeActivosDeMedicion? left, ItemDeArbolDeActivosDeMedicion? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ItemDeArbolDeActivosDeMedicion? left, ItemDeArbolDeActivosDeMedicion? right)
    {
        return !Equals(left, right);
    }
}

public enum TipoDeItemDeArbol
{
    Cliente,
    Organizacion,
    Plataforma,
    Area,
    AreaDeAnalisis,
    SistemaDeMedicion,
    Variable,
    TipoDeParametroDeFluido,
    Tag,
    TagDeArea,
    VinculoEntreTagConSamplingPoint
}
