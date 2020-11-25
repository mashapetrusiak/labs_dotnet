using AutoMapper;
using lab4.DTO.Interfaces;
using lab4.DTO.Models;
using lab4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Controllers
{
    public class FullNameController : Controller
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _iMapper;

        #endregion Fields

        #region Constructors

        public FullNameController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _iMapper = mapper;
        }

        #endregion Constructors

        #region Methods

        // GET: Trades
        public async Task<IActionResult> ReturnToEmployee(int employeeId, int fullNameId = -1)
        {
            return RedirectToAction(nameof(AddOrEdit), "Employee", new { employeeId, fullNameId });
        }

        // GET: Trades/Create
        public IActionResult AddOrEdit(int employeeId, int fullNameId = -1)
        {
            var data = _iMapper.Map<FullNameViewModel>(_unitOfWork.FullNameRepository.GetAsync(x => fullNameId == -1 ? true : x.Id == fullNameId).Result.FirstOrDefault());
            ViewData["EmployeeId"] = employeeId;

            return fullNameId == -1 ? View(new FullNameViewModel() { Id = -1 }) : View(data);
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id, FirstName, LastName")]FullNameViewModel fullName, int employeeId)
        {
            if (ModelState.IsValid)
            {
                int fullNameId = fullName.Id;
                if (fullNameId == -1)
                {
                    fullName.Id = 0;
                    var fullNameEntity = await _unitOfWork.FullNameRepository.InsertAsync(_iMapper.Map<FullName>(fullName));
                    await _unitOfWork.SaveAsync();
                    fullNameId = fullNameEntity.Entity.Id;
                }
                else
                {
                    _unitOfWork.FullNameRepository.Update(_iMapper.Map<FullName>(fullName));
                }
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(ReturnToEmployee), new { employeeId, fullNameId });
            }
            return RedirectToAction(nameof(ReturnToEmployee), new { employeeId });
        }

        #endregion Methods
    }
}