public enum EAgentes
{
    Ambos,
    Fabricas,
    Vehiculos
}

public enum EProvincias
{
    BsAs,
    Catamarca,
    Chaco,
    Chubut,
    Cordoba,
    Corrientes,
    EntreRios,
    Formosa,
    Jujuy,
    LaPampa,
    LaRioja,
    Mendoza,
    Misiones,
    Neuquen,
    RioNegro,
    Salta,
    SanJuan,
    SanLuis,
    SantaCruz,
    SantaFe,
    SantiagoDelEstero,
    TierraDelFuego,
    Tucuman
}

public enum ETipoFabrica
{
    Quimica = 500000,
    Metalurgica = 650000,
    Siderurgica = 520000,
    Cementera = 340000,
    Textil = 200000,
    Farmaceutica = 180000
}

public enum ETipoVehiculo
{
    Pequeño = 40,
    Mediano = 60,
    Grande = 85,
    Hibrido = 20
}

public enum Ordenamientos
{
    Nombre,
    Provincia,
    Gases_Emitidos,
    Cantidad,
    Tipo
}