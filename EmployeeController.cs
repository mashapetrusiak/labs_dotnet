using AutoMapper;
using lab4.DTO.Interfaces;
using lab4.DTO.Models;
using lab4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Controllers
{
    public class EmployeeController : Controller
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _iMapper;

        #endregion Fields

        #region Constructors

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _iMapper = mapper;
        }

        #endregion Constructors

        #region Methods

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(_iMapper.Map<List<EmployeeViewModel>>(await _unitOfWork.EmployeeRepository.GetAsync(null, "Address, Position, FullName, ProjectInfo")));
        }

        // GET: Employee/Create
        public async Task<IActionResult> AddOrEdit(int employeeId = -1, int addressId = -1, int positionId = -1, int pojectInfoId = -1, int fullNameId = -1)
        {
            var data = _iMapper.Map<EmployeeViewModel>(_unitOfWork.EmployeeRepository.GetAsync(x => employeeId == -1 ? true : x.Id == employeeId, "Address, Position, FullName, ProjectInfo").Result.FirstOrDefault());
            ViewData["Address"] = new SelectList(_iMapper.Map<List<AddressViewModel>>(await _unitOfWork.AddressRepository.GetAsync()), "Id", "ToString", addressId == -1 ? employeeId == -1 ? 1 : data?.AddressId ?? 1 : addressId);
            ViewData["Position"] = new SelectList(_iMapper.Map<List<PositionViewModel>>(await _unitOfWork.PositionRepository.GetAsync()), "Id", "ToString", positionId == -1 ? employeeId == -1 ? 1 : data?.PositionId ?? 1 : positionId);
            ViewData["ProjectInfo"] = new SelectList(_iMapper.Map<List<ProjectInfoViewModel>>(await _unitOfWork.ProjectInfoRepository.GetAsync()), "Id", "ToString", pojectInfoId == -1 ? employeeId == -1 ? 1 : data?.ProjectInfoId ?? 1 : pojectInfoId);
            ViewData["FullName"] = new SelectList(_iMapper.Map<List<FullNameViewModel>>(await _unitOfWork.FullNameRepository.GetAsync()), "Id", "ToString", fullNameId == -1 ? employeeId == -1 ? 1 : data?.FullNameId ?? 1 : fullNameId);

            return employeeId == -1 ? View(new EmployeeViewModel() { Id = -1 }) : View(data);
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id, AddressId, Address, PositionId, Position, ProjectInfoId, ProjectInfo, FullNameId, FullName, Days, Salary, Characterization")]EmployeeViewModel employees)
        {
            if (ModelState.IsValid)
            {
                employees.Id = employees.Id == -1 ? 0 : employees.Id;
                _unitOfWork.EmployeeRepository.Update(_iMapper.Map<Employee>(employees));
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? employeeId)
        {
            if (employeeId.HasValue)
            {
                _unitOfWork.EmployeeRepository.Delete(employeeId.Value);
                await _unitOfWork.SaveAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? employeeId)
        {
            if (employeeId.HasValue)
            {
                var employee = await _unitOfWork.EmployeeRepository.GetAsync(x => x.Id == employeeId.Value, "Address, Position, FullName, ProjectInfo");
                return View(_iMapper.Map<EmployeeViewModel>(employee.FirstOrDefault()));
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddOrEditAddress(int employeeId, int addressId = -1)
        {
            return RedirectToAction(nameof(AddOrEdit), "Address", new { employeeId, addressId });
        }

        public async Task<IActionResult> AddOrEditPosition(int employeeId, int positionId = -1)
        {
            return RedirectToAction(nameof(AddOrEdit), "Position", new { employeeId, positionId });
        }

        public async Task<IActionResult> AddOrEditProjectInfo(int employeeId, int projectInfoId = -1)
        {
            return RedirectToAction(nameof(AddOrEdit), "ProjectInfo", new { employeeId, projectInfoId });
        }

        public async Task<IActionResult> AddOrEditFullName(int employeeId, int fullNameId = -1)
        {
            return RedirectToAction(nameof(AddOrEdit), "FullName", new { employeeId, fullNameId });
        }

        #endregion Methods
    }
}