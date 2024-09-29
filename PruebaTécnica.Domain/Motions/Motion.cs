using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Clientes.Events;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.Cuenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTécnica.Domain.Shared;
using PruebaTécnica.Domain.Motions.Events;
using PruebaTécnica.Domain.Motions;
using System.Drawing;

namespace PruebaTécnica.Domain.Movimientos;

public sealed class Motion : Entity
{
    public Motion(
        Guid id,
        TypeOfMotion type,
        Money valor,
        Money saldo,
        DateTime time,
        Guid guid) 
        :base(id)
    {
        TipoDeMovimiento = type;
        FechaDeMovimiento = time;
        Valor = valor;
        Saldo = saldo;
        CuentaId = guid;
    }
    private Motion() 
    {
    }

    public Guid IdMovimiento { get; private set; }
    public TypeOfMotion TipoDeMovimiento { get; private set; }
    public Money Valor {  get; private set; }
    public Money Saldo { get; private set; }
    public DateTime FechaDeMovimiento { get; private set; }
    public Guid CuentaId { get; private set; }
    public Account Cuenta { get; private set; }

    public static Motion Create(
        TypeOfMotion typeOfMotion,
        Money worthDetails,
        Money worthService,
        DateTime time,
        Guid guid)
    {
        var motion = new Motion(
        Guid.NewGuid(),
        typeOfMotion,
        worthDetails,
        worthService,
        time,
        guid);

        motion.RaiseDomainEvent(new MotionCreatedDomainEvent(motion.Id));

        return motion;
    }

    public void UpdateTypeOfMotion(TypeOfMotion typeOfMotion)
    {
        TipoDeMovimiento = typeOfMotion;
    }

    public void UpdateValor(Money money)
    {
        Valor = money;
    }

    public void UpdateSaldo(Money saldo)
    {
        Saldo = saldo;
    }

    public void UpdateFechaDeMovimiento(DateTime time)
    {
        FechaDeMovimiento = time;
    }
}
