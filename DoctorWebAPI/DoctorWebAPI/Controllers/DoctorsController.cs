
using DoctorWebAPI.Data;
using DoctorWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DoctorsController : Controller
	{

			private readonly FullStackDbContext _fullStackDbContext;
			public DoctorsController(FullStackDbContext fullStackDbContext)
			{
				_fullStackDbContext = fullStackDbContext;
			}

			//get all Employee's Data
			[HttpGet]
			public async Task<IActionResult> GetAllDoctors()
			{
				var doctors = await _fullStackDbContext.Doctors.ToListAsync();
				//check if the employee data exists
				if (doctors == null)
				{
					return NotFound();
				}
				//return Ok(new { message = "Employee's All records",AllEmployee = employees});
				return Ok(doctors);
			}

			//get Employee Data by Employee ID
			[HttpGet]
			[Route("{id:Guid}")]

			public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
			{
				var doctor = await _fullStackDbContext.Doctors.Where(a => a.Id == id).FirstOrDefaultAsync();
				//check if the employee data exists
				if (doctor == null)
				{
					return NotFound();
				}
				//return Ok(new { message = "Employee's Data by Employee ID",GetEmployee = employees});
				return Ok(doctor);
			}
			//save Employee Data
			[HttpPost]
			public async Task<IActionResult> AddDoctor([FromRoute] Doctor  doctorRequest)
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				doctorRequest.Id = Guid.NewGuid();
				await _fullStackDbContext.AddAsync(doctorRequest);
				await _fullStackDbContext.SaveChangesAsync();

				//return Ok(new { message = "Employee's Record added Successfullly",AddedEmployee = employeeRequest});
				return Ok(doctorRequest);
			}
			//update employee Data
			[HttpPut]
			public async Task<IActionResult> UpdateDoctorData(Doctor doctorUpdateRequest)
			{
				var doctorData = await _fullStackDbContext.Doctors.Where(a => a.Id == doctorUpdateRequest.Id).FirstOrDefaultAsync();
				if (doctorData == null)
				{
					return NotFound();
				}
				//employeeData.Id=employeeUpdateRequest.Id;
				//employeeData.Id = employeeUpdateRequest.Id;
				doctorData.Name = doctorUpdateRequest.Name;
				doctorData.Email = doctorUpdateRequest.Email;
				doctorData.phone = doctorUpdateRequest.phone;
				doctorData.Salary = doctorUpdateRequest.Salary;
				doctorData.Department = doctorUpdateRequest.Department;

				await _fullStackDbContext.SaveChangesAsync();
				//return Ok(new { message = "Employee's updated Successfullly",UpdatedEmployee = employeeData});
				return Ok(doctorData);
			}
			//update Employee Data
			[HttpPut]
			[Route("{id:Guid}")]
			public async Task<IActionResult> UpdateDoctor(Guid id, Doctor updateDoctorRequest)
			{
				var doctorData = await _fullStackDbContext.Doctors.FindAsync(id);
				if (doctorData == null)
				{
					return NotFound();
				}

				//employeeData.Id = employeeUpdateRequest.Id;
				doctorData.Name = updateDoctorRequest.Name;
				doctorData.Email = updateDoctorRequest.Email;
				doctorData.phone = updateDoctorRequest.phone;
				doctorData.Salary = updateDoctorRequest.Salary;
				doctorData.Department = updateDoctorRequest.Department;

				await _fullStackDbContext.SaveChangesAsync();
				//return Ok(new { message = "Employee's record updated Successfullly",UpdatedEmployee = employeeData});
				return Ok(doctorData);
			}
			//Delete Employee Data
			[HttpDelete("{Id}")]

			public async Task<IActionResult> DeleteEmployeeData(Guid Id)
			{
				var doctorData = await _fullStackDbContext.Doctors.Where(a => a.Id == Id).FirstOrDefaultAsync();
				if (doctorData == null)
				{
					return NotFound();
				}
				_fullStackDbContext.Doctors.Remove(doctorData);
				await _fullStackDbContext.SaveChangesAsync();
				return Ok(doctorData);
			}


		}
	}


