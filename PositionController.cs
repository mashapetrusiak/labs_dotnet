using AutoMapper;
using lab4.DTO.Interfaces;
using lab4.DTO.Models;
using lab4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Controllers
{
    public class PositionController : Controller
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _iMapper;

        #endregion Fields

        #region Constructors

        public PositionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _iMapper = mapper;
        }

        #endregion Constructors

        #region Methods

        // GET: Trades
        public async Task<IActionResult> ReturnToEmployee(int employeeId, int positionId = -1)
        {
            return RedirectToAction(nameof(AddOrEdit), "Employee", new { employeeId, positionId });
        }

        // GET: Trades/Create
        public IActionResult AddOrEdit(int employeeId, int positionId = -1)
        {
            var data = _iMapper.Map<PositionViewModel>(_unitOfWork.PositionRepository.GetAsync(x => positionId == -1 ? true : x.Id == positionId).Result.FirstOrDefault());
            ViewData["EmployeeId"] = employeeId;

            return positionId == -1 ? View(new PositionViewModel() { Id = -1 }) : View(data);
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id, Name")]PositionViewModel position, int employeeId)
        {
            if (ModelState.IsValid)
            {
                int positionId = position.Id;
                if (positionId == -1)
                {
                    position.Id = 0;
                    var positionEntity = await _unitOfWork.PositionRepository.InsertAsync(_iMapper.Map<Position>(position));
                    await _unitOfWork.SaveAsync();
                    positionId = positionEntity.Entity.Id;
                }
                else
                {
                    _unitOfWork.PositionRepository.Update(_iMapper.Map<Position>(position));
                }
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(ReturnToEmployee), new { employeeId, positionId });
            }
            return RedirectToAction(nameof(ReturnToEmployee), new { employeeId });
        }

        #endregion Methods
    }
}