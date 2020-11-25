using AutoMapper;
using lab4.DTO.Interfaces;
using lab4.DTO.Models;
using lab4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Controllers
{
    public class ProjectInfoController : Controller
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _iMapper;

        #endregion Fields

        #region Constructors

        public ProjectInfoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _iMapper = mapper;
        }

        #endregion Constructors

        #region Methods

        // GET: Trades
        public async Task<IActionResult> ReturnToEmployee(int employeeId, int projectInfoId = -1)
        {
            return RedirectToAction(nameof(AddOrEdit), "Employee", new { employeeId, projectInfoId });
        }

        // GET: Trades/Create
        public IActionResult AddOrEdit(int employeeId, int projectInfoId = -1)
        {
            var data = _iMapper.Map<ProjectInfoViewModel>(_unitOfWork.ProjectInfoRepository.GetAsync(x => projectInfoId == -1 ? true : x.Id == projectInfoId).Result.FirstOrDefault());
            ViewData["EmployeeId"] = employeeId;

            return projectInfoId == -1 ? View(new ProjectInfoViewModel() { Id = -1 }) : View(data);
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id, Name, StartDate, EndDate, Description")]ProjectInfoViewModel projectInfo, int employeeId)
        {
            if (ModelState.IsValid)
            {
                int projectInfoId = projectInfo.Id;
                if (projectInfoId == -1)
                {
                    projectInfo.Id = 0;
                    var projectInfoEntity = await _unitOfWork.ProjectInfoRepository.InsertAsync(_iMapper.Map<ProjectInfo>(projectInfo));
                    await _unitOfWork.SaveAsync();
                    projectInfoId = projectInfoEntity.Entity.Id;
                }
                else
                {
                    _unitOfWork.ProjectInfoRepository.Update(_iMapper.Map<ProjectInfo>(projectInfo));
                }
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(ReturnToEmployee), new { employeeId, projectInfoId });
            }
            return RedirectToAction(nameof(ReturnToEmployee), new { employeeId });
        }

        #endregion Methods
    }
}