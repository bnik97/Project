using WebApplication2.Models.repositories;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Services;
public class EarthquakeService
{
    private readonly EarthquakeRepository _repository;

    public EarthquakeService(EarthquakeRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Earthquake> SearchByCoordinates(string coordinates)
    {
        return _repository.FindByCoordinates(coordinates);
    }

    public IEnumerable<Earthquake> GetAll()
    {
        return _repository.GetAll();
    }
    public void Add(Earthquake earthquake)
    {
        _repository.Add(earthquake);
    }
 
}

