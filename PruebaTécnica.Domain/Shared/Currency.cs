using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Shared;

public sealed class Currency
{
    public static readonly Currency None = new("");
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Cop = new("COP");
    public static readonly Currency Eur = new("EUR");
    private Currency(string code) => Code = code;
    public string Code { get; init; }
    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ??
            throw new ApplicationException("The currency code is invalid");
    }

    public static readonly IReadOnlyCollection<Currency> All = new[]
    {
        Usd,
        Cop,
        Eur
    };
}
