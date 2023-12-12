using System.Collections.Generic;

public class ItemDeActivosDeMedicion_Vm
{
    public long Id { get; set; }
    public string? Nombre { get; set; }
    public string? Abreviatura { get; set; }
    public TipoDeItemDeArbol Tipo { get; set; }
    public byte[]? Imagen { get; set; }
    public int IdSecundario { get; set; }

    public ItemDeActivosDeMedicion_Vm? ItemPadre { get; set; }

    public IList<ItemDeActivosDeMedicion_Vm>? Items { get; set; }
    public int IdPlataforma { get; set; }
    public bool SeSelecciono { get; set; }
}
