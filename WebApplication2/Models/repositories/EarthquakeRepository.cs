namespace WebApplication2.Models.repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class EarthquakeRepository
{
    private readonly MyDbContext _context;

    public EarthquakeRepository(MyDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Earthquake> GetAll()
    {
        return _context.Earthquakes.ToList();
    }

    public Earthquake GetById(int id)
    {
        return _context.Earthquakes.Find(id);
    }

    public void Add(Earthquake earthquake)
    {
        _context.Earthquakes.Add(earthquake);
        _context.SaveChanges();
    }

    public void Update(Earthquake earthquake)
    {
        _context.Entry(earthquake).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var earthquake = _context.Earthquakes.Find(id);
        if (earthquake != null)
        {
            _context.Earthquakes.Remove(earthquake);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Earthquake> FindByCoordinates(string coordinates)
    {
        return _context.Earthquakes.Where(e => e.Coordinates == coordinates).ToList();
    }

}
