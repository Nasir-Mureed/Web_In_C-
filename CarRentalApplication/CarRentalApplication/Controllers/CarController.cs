using Microsoft.AspNetCore.Mvc;
using CarRentalApplication.Models;

namespace CarRentalApplication.Controllers;

public class CarController : Controller
{
    
    private static List<Car> _avalaibleCars=new List<Car>([
        new Car(1,"Alto",3000),
        new Car(2,"Corolla",6000),
        new Car(3,"Civic",8000)
    ]);
    private static List<Car> _bookedCars= _bookedCars = new List<Car>();

    public CarController()
    {
        
    }
    
    
    //GET
    public IActionResult Index()
    {
        return View(_avalaibleCars);
    }
    
    [HttpPost]
    public IActionResult bookCar(int id)
    {
        Car? car = _avalaibleCars.Find(x => x.Id == id);
        _bookedCars.Add(car);
        _avalaibleCars.Remove(car);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult returnCar(int id)
    {
        Car? car=_bookedCars.Find(x => x.Id == id);
        _avalaibleCars.Add(car);
        _bookedCars.Remove(car);
        return RedirectToAction("Index");
    }
    
    public ViewResult Booked()
    { 
        return View(_bookedCars);
    }
}