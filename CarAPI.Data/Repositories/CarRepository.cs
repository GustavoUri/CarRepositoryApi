using CarAPI.Data.DbEFContext;
using CarAPI.Data.Interfaces;
using CarAPI.Domain.Entities;
using CarAPI.Domain.Exceptions;

namespace CarAPI.Data.Repositories;

public class CarRepository : IRepository<Car>
{
    private readonly EFDbContext _db;

    public CarRepository(EFDbContext db)
    {
        _db = db;
    }

    public IEnumerable<Car> GetAll()
    {
        var result = _db.Cars.ToList();
        return result;
    }

    public Car GetById(int id)
    {
        var result = _db.Cars.Find(id);
        if (result == null)
            throw new BadRequestException("No cars with this id");
        return result;
    }

    public void Create(Car item)
    {
        _db.Cars.Add(item);
    }

    public void Delete(int id)
    {
        var carToDel = _db.Cars.Find(id);
        if (carToDel == null)
            throw new BadRequestException("No cars with this id");
        _db.Cars.Remove(carToDel);
    }

    public void SaveChanges()
    {
        _db.SaveChanges();
    }
}