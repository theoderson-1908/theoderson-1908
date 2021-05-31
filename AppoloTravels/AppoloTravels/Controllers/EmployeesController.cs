using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppoloTravels.Models;

namespace AppoloTravels.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly TransportManagementContext _context;

        public EmployeesController(TransportManagementContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,EmployeeName,Department,Phone,BoardingPoint,Address,Age,Gender,Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {

                if (employee.BoardingPoint != null )
                {
                    var RoutesAvaiability = _context.Routes.Where(m => m.StartingPoint == employee.BoardingPoint|| m.StopOne == employee.BoardingPoint || m.StopTwo == employee.BoardingPoint || m.StopThree == employee.BoardingPoint);
                    //Check Routes Availablity
                  
                    if (RoutesAvaiability != null && RoutesAvaiability.Count() > 0)
                       
                        {
                        
                      var VehicleAvaiability = _context.Vehicles.Where(m => m.SeatsAvailable > 0 & m.Location == employee.BoardingPoint);
                        // Check vehicle availability
                        if (VehicleAvaiability != null & VehicleAvaiability.Count() > 0)
                        {
                            _context.Add(employee);
                            // Reduce the Seats
                            var final_seat = 0;
                            var driver_name = "";
                            var driver_contact_number = "";
                            var vechile_no = "";
                            foreach (var val in VehicleAvaiability)
                            {
                                final_seat = val.SeatsAvailable;
                                driver_name = val.DriverName;
                                driver_contact_number = val.DriverContactNumber;
                                vechile_no = val.VehicleNumber;
                            }

                            final_seat = final_seat - 1;

                            await _context.Vehicles.Where(m => m.Location == employee.BoardingPoint).ForEachAsync(s => s.SeatsAvailable = final_seat); ;
                            await _context.SaveChangesAsync();

                            // Add Values to Allocation
                            var a_employee_name = employee.EmployeeName;
                            var a_boarding_location = employee.BoardingPoint;
                            var a_driver_name = driver_name;
                            var a_contact_number = driver_contact_number;
                            var a_vechile_no = vechile_no;
                            var a_allocations = new Allocation { BoardingPoint = a_boarding_location, DriverContactNumber = a_contact_number, DriverName = a_driver_name, EmployeeName = a_employee_name, VehicleNumber = a_vechile_no };
                             _context.Allocations.Add(a_allocations);
                            await _context.SaveChangesAsync();

                            return RedirectToAction(nameof(Index));
                           
                        }

                    }
                    else
                    {
                        return View();
                    }

                }
                else
                {
                    // if (employee.BoardingPoint != null )
                }



            }//Model State
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
         }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,EmployeeName,Department,Phone,BoardingPoint,Address,Age,Gender,Email")] Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int EmployeeID)
        {
            var employee = await _context.Employees.FindAsync(EmployeeID);
            //    List<Allocation> d = new List<Allocation>();
            var q = _context.Allocations.Where(m => m.EmployeeName == employee.EmployeeName).SingleOrDefault();
            // _context.Allocations.Where(m => m.EmployeeName == employee.EmployeeName).ToList();
            //    d = q.ToList();
            //   _context.Allocations.Remove(d);
            var SeatReduce = _context.Vehicles.Where(m => m.Location == employee.BoardingPoint);
            var ChangedSeat = 0;
            foreach(var value in SeatReduce)
            {
                ChangedSeat = value.SeatsAvailable;
            }
            ChangedSeat = ChangedSeat + 1;
            await _context.Vehicles.Where(m => m.Location == employee.BoardingPoint).ForEachAsync(s => s.SeatsAvailable = ChangedSeat);
            await _context.SaveChangesAsync();



            _context.Allocations.Remove(q);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }
    }
}
