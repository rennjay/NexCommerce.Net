using NexCommerce.Catalog.Core.Exceptions;

namespace NexCommerce.Catalog.Core.ValueObjects;
public record Price
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Price(decimal amount, string currency)
    {
        if (amount < 0)
            throw new NegativePriceException();

        if (string.IsNullOrWhiteSpace(currency))
            throw new InvalidCurrencyException();

        Amount = amount;
        Currency = currency.ToUpperInvariant();
    }

    public override string ToString() => $"{Amount:C} {Currency}";
}