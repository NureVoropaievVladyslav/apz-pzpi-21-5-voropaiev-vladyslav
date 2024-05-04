using Domain.Enums;

namespace Infrastructure.Repositories;

public class PondRepository : Repository<Pond>, IPondRepository
{
    public PondRepository(ApplicationDbContext context) : base(context)
    {
    }

    public override async Task<Pond?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await base.GetAsync(id, cancellationToken) ?? throw new DataNotFoundException();
    }

    public async Task<object> GetDataAsync(Guid pondId, CancellationToken cancellationToken)
    {
        await Task.Delay(1000, cancellationToken);
        
        object dataFromSmartDevice = new
        {
            TemperatureInCelcius = 20.0f,
            FoodAmountInKilos = 0.125f,
            PhLevel = 7.2f,
            DissolvedAmmoniaMgL = 0.3
        };
        
        var temperatureInCelsius = 
            (double)dataFromSmartDevice.GetType().GetProperty("TemperatureInCelcius")!.GetValue(dataFromSmartDevice)!;
        var temperatureInFahrenheit = ConvertCelsiusToFahrenheit(temperatureInCelsius);

        var foodAmountInKilos =
            (double)dataFromSmartDevice.GetType().GetProperty("FoodAmountInKilos")!.GetValue(dataFromSmartDevice)!;
        var foodAmountInPounds = ConvertKilosToPounds(foodAmountInKilos);
        
        double dissolvedAmmoniaMgL = 
            (double)dataFromSmartDevice.GetType().GetProperty("DissolvedAmmoniaMgL")!.GetValue(dataFromSmartDevice)!;
        double dissolvedAmmoniaLbsOz = ConvertMgLtoLbsOz(dissolvedAmmoniaMgL);
        
        dataFromSmartDevice.GetType().GetProperty("TemperatureInFahrenheit")!.SetValue(dataFromSmartDevice, temperatureInFahrenheit);
        dataFromSmartDevice.GetType().GetProperty("FoodAmountInPounds")!.SetValue(dataFromSmartDevice, foodAmountInPounds);
        dataFromSmartDevice.GetType().GetProperty("DissolvedAmmoniaLbsOz")!.SetValue(dataFromSmartDevice, dissolvedAmmoniaLbsOz);

        return dataFromSmartDevice;
    }

    private double ConvertCelsiusToFahrenheit(double temperatureInCelsius)
    {
        return (temperatureInCelsius * 9 / 5) + 32;
    }

    private double ConvertKilosToPounds(double valueInKilos)
    {
        return valueInKilos * 2.20462f;
    }

    private double ConvertMgLtoLbsOz(double valueInMgL)
    {
        return valueInMgL * 2.20462e-6 * 35.27396;
    }
}